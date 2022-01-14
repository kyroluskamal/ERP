import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormDefs, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { Brands } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-edit-item-brand',
  templateUrl: './edit-item-brand.component.html',
  styleUrls: ['./edit-item-brand.component.css']
})
export class EditItemBrandComponent implements OnInit
{


  Title: CardTitle[] = [];

  Subdomain: string = window.location.hostname.split('.')[0];
  Edit: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();


  constructor(private spinner: SpinnerService, public Constants: ConstantsService,
    private bottomSheet: MatBottomSheet, public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: DataToEdit_PassToBottomSheet<Brands>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<EditItemBrandComponent>,
    private ItemsService: ItemsService,
    private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.ShowProgressBar = false; this.spinner.removeSpinner();
      this._bottomSheetRef.dismiss(this.data);
    });
    this.Edit = new FormGroup({
      brandName: new FormControl(this.data.dataToEdit.brandName, [Validators.required, Validators.maxLength(this.Constants.MaxLength30)])
    });
    this.Title = [{ text: this.Constants.Edit, needTranslation: true },
    { text: ": ", needTranslation: false },
    { text: this.data.dataToEdit.brandName, needTranslation: false },
    ];
    this.FormBuilder = {
      form: this.Edit,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'save',
      ButtonText: [this.Constants.Save],
      formSections: [
        {
          fxFlex: "100%",
          formFieldsSpec: [
            {
              type: "text",
              fieldToolTip: '',
              formControlName: this.Constants.brandName,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "100%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.brandName,
              faIcon: faPenAlt,
              required: true,
              errors: [{
                type: 'required',
                TranslatedMessage: [{ text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: 'maxlength',
                TranslatedMessage: [
                  { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                  { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                  { text: this.Constants.characters, needTraslation: true }]
              }],
              maxLength: this.Constants.MaxLength30
            }
          ],
        }],
    };
  }
  Edit_Brand(EditedObj: FormDefs)
  {
    if (!this.ClientValidaiton.isUpdated(this.data.dataToEdit, EditedObj.form))
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data); return;
    }
    this.spinner.fullScreenSpinnerForForm();
    if (!(this.ClientValidaiton.isUnique(this.data.Array, this.Constants.brandName, this.Edit.get(this.Constants.brandName)?.value, this.data.dataToEdit.id)))
    {
      this.spinner.removeSpinner(); this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.brandName); this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
      return;
    }
    let UpdatedItem: Brands = { ...this.data.dataToEdit };
    this.ClientValidaiton.FillObjectFromForm(UpdatedItem, EditedObj.form);
    UpdatedItem.subdomain = this.Subdomain;
    this.ItemsService.Update_ItemBrand(UpdatedItem).subscribe({
      next: (r) =>
      {
        if (r.status)
          if (r.status !== this.Constants.SameObject)
          {
            this.spinner.removeSpinner();
            this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
            this.ClientValidaiton.FillObjectFromAnotherObject(this.data.dataToEdit, UpdatedItem);
          }
        this.data.ShowProgressBar = false;
        this._bottomSheetRef.dismiss(this.data);
      }, error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
        let x: MaxMinLengthValidation[] = [{ prop: this.Constants.brandName, maxLength: this.Constants.MaxLength30 }];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
  } CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }

}
