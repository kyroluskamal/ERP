import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ICellEditorAngularComp, ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellEditorParams, ICellRendererParams } from 'ag-grid-community';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';

@Component({
  selector: 'app-number-cell-editor',
  templateUrl: './number-cell-editor.component.html',
  styleUrls: ['./number-cell-editor.component.css']
})
export class NumberCellEditorComponent implements ICellEditorAngularComp, OnInit {

  params: any;

  NumberValueForm: FormGroup = new FormGroup({});
  value: number = 0;
  constructor(private NotificationService: NotificationsService,
    public Constants: ConstantsService, public translate: TranslationService) { }

  agInit(params: ICellEditorParams): void {
    this.NumberValueForm = new FormGroup({
      Numbers: new FormControl(params.value, [Validators.required, Validators.min(0)])
    })
    this.params = params;
    if (params.value !== null) {
      this.value = params.value
    }
    console.log(this.value);
    this.NumberValueForm.get("Numbers")?.setValue(this.value);
  }

  ngOnInit(): void {
    this.NumberValueForm.valueChanges.subscribe(
      {
        error: e => console.log(e),
        next: value => {
          if (value <= 0) {
            this.NotificationService.error(this.translate.GetTranslation(this.Constants.Negative_Value_ERROR), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
            this.NumberValueForm.get("Numbers")?.setValue(this.value);
            value = this.value
          } else
            this.value = value.Numbers
        }
      }
    )
  }
  getValue(): any {
    return this.value;
  }
}
