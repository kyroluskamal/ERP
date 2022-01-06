import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, FormDefs, MatBottomSheetDismissData, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { Brands } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';
@Component({
  selector: 'app-add-new-item-brand',
  templateUrl: './add-new-item-brand.component.html',
  styleUrls: ['./add-new-item-brand.component.css']
})
export class AddNewItemBrandComponent implements OnInit
{

  faMobileAlt = faMobileAlt; faPhone = faPhone; faPenAlt = faPenAlt; faEdit = faEdit; Title: CardTitle[] = []; faCheckCircle = faCheckCircle; faTimesCircle = faTimesCircle; Subdomain: string = window.location.hostname.split('.')[0]; AddNew: FormGroup = new FormGroup({}); FormBuilder: FormDefs = new FormDefs(); AllSelectionData: SelectedDataTransfer[] = [];
  constructor(private spinner: SpinnerService, public Constants: ConstantsService,
    private bottomSheet: MatBottomSheet, public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: MatBottomSheetDismissData<Brands>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewItemBrandComponent>,
    private ItemsService: ItemsService, private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {
    this.AddNew = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(this.Constants.MaxLength30)])
    });
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    });
    this.Title = [{ text: this.Constants.Add, needTranslation: true },
    { text: this.Constants.Brand_Name_Singular, needTranslation: true }];
    this.FormBuilder = {
      form: this.AddNew,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'add_circle',
      ButtonText: [this.Constants.Add, this.Constants.Brand_Name_Singular],
      formSections: [
        {
          fxFlex: "100%",
          formFieldsSpec: [
            {
              type: "text",
              formControlName: this.Constants.Name.toLowerCase(),
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "100%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.Name,
              faIcon: faPenAlt,
              required: true,
              errors: [{
                type: 'required',
                TranslatedMessage: [{ text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: 'maxlength', TranslatedMessage: [{ text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true }, { text: this.Constants.MaxLength30.toString(), needTraslation: false }, { text: this.Constants.characters, needTraslation: true }]
              }],
              maxLength: this.Constants.MaxLength30
            }
          ],
        }],
    };
  }
  AddNewBrand(formDefs: FormDefs)
  {
    this.spinner.fullScreenSpinnerForForm();
    this.data.ShowBrogressBar = true;
    let newItem = new Brands();
    this.ClientValidaiton.FillObjectFromForm(newItem, formDefs.form);
    if (this.data)
      if (!this.ClientValidaiton.isUnique(this.data.data, this.Constants.Name.toLowerCase(), formDefs.form.get(this.Constants.Name.toLowerCase())?.value))
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.Name);
        this.data.ShowBrogressBar = false;
        return;
      }
    this.ItemsService.AddNew_ItemBrand(newItem).subscribe({
      next: (r) =>
      {
        if (this.data)
        {
          this.data.data.push(r);
          this.data.SelectedRows = [];
          this.data.SelectedRows.push(r);
          this.data.addedRow = r;
          this.data.dataSource.data = this.data.data;
        }
        this.spinner.removeSpinner();
        this.ServerResponseHandler.DatatAddition_Success_Swal();
        setTimeout(() =>
        {
          this.data.dataSource.paginator?.lastPage();
        }, 500);
        this.AddNew.reset();
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(newItem, this.FormBuilder.form);
        let x: MaxMinLengthValidation[] = [{ prop: this.Constants.Name, maxLength: this.Constants.MaxLength30 }];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
    this.data.ShowBrogressBar = false;
  }
  CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }
}
