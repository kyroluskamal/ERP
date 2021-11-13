import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';

@Component({
  selector: 'app-icon-button-renderer',
  templateUrl: './Icon-button-renderer.component.html',
  styleUrls: ['./Icon-button-renderer.component.css'],
})
export class IconButtonRendererComponent implements ICellRendererAngularComp {

  constructor(private Constant: ConstantsService, private translate: TranslationService) { }
  params: any;
  iconName: string = "";
  hidden: boolean = false;
  agInit(params: any): void {
    this.params = params;
    this.iconName = params.iconName;
    this.hidden = this.params.node.data.name === this.translate.GetTranslation(this.params.preventionName);
  }

  refresh(params?: any): boolean {
    return true;
  }

  onClick(event: any) {
    if (this.params.onClick instanceof Function) {

      this.params.onClick(this.params);
    }
  }
}
