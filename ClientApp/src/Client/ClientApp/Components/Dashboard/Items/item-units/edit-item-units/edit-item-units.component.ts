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
import { Units } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-edit-item-units',
  templateUrl: './edit-item-units.component.html',
  styleUrls: ['./edit-item-units.component.css']
})
export class EditItemUnitsComponent implements OnInit
{

  Title: CardTitle[] = [];
  Subdomain: string = window.location.hostname.split('.')[0];
  Edit: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();

  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, private ItemService: ItemsService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: DataToEdit_PassToBottomSheet<Units>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<EditItemUnitsComponent>,
    private ClientValidaiton: ClientSideValidationService) { }

  ngOnInit(): void
  {
    this._bottomSheetRef.backdropClick().subscribe(
      (r) =>
      {
        this.data.ShowProgressBar = false;
        this.spinner.removeSpinner(); this._bottomSheetRef.dismiss(this.data);
      });
    this.Edit = new FormGroup({
      wholeSaleUnit: new FormControl(this.data.dataToEdit.wholeSaleUnit,
        [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]
      ),
      numberInWholeSale: new FormControl(this.data.dataToEdit.numberInWholeSale,
        [Validators.required, Validators.pattern(this.Constants.IntNumberRegex_start1), Validators.min(this.Constants.MinLength1)]
      ),
      retailUnit: new FormControl(this.data.dataToEdit.retailUnit,
        [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]
      ),
      numberInRetailSale: new FormControl(this.data.dataToEdit.numberInRetailSale,
        [Validators.required, Validators.pattern(this.Constants.IntNumberRegex_start1), Validators.min(this.Constants.MinLength1)]
      )
    });
    this.Title = [{ text: this.Constants.Add_New_Units, needTranslation: true },];
    this.FormBuilder = {
      form: this.Edit,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'add_circle',
      ButtonText: [this.Constants.Add, this.Constants.Unit],
      formSections: [
        {
          fxFlex: "100%",
          formFieldsSpec: [
            {
              type: "text",
              fieldToolTip: '',
              formControlName: this.Constants.wholeSaleUnit,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.wholeSaleUnit,
              required: false,
              errors: [{
                type: 'required',
                TranslatedMessage: [
                  { text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: 'maxlength',
                TranslatedMessage: [
                  { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                  { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                  { text: this.Constants.characters, needTraslation: true }]
              }],
              maxLength: this.Constants.MaxLength30
            }, {
              type: "number",
              fieldToolTip: '',
              formControlName: this.Constants.numberInWholeSale,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.numberInWholeSale,
              required: false,
              errors: [{
                type: 'required',
                TranslatedMessage: [
                  { text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: "min",
                TranslatedMessage: [
                  { text: this.Constants.Negative_Value_ERROR, needTraslation: true }
                ]
              }
              ],
              min: this.Constants.Min1.toString()
            }, {
              type: "text",
              fieldToolTip: '',
              formControlName: this.Constants.retailUnit,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.retailUnit,
              required: false,
              errors: [{
                type: 'required',
                TranslatedMessage: [
                  { text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: 'maxlength',
                TranslatedMessage: [
                  { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                  { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                  { text: this.Constants.characters, needTraslation: true }
                ]
              }],
              maxLength: this.Constants.MaxLength30
            }, {
              type: "number",
              fieldToolTip: '',
              formControlName: this.Constants.numberInRetailSale,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.numberInRetailSale,
              required: false,
              errors: [{
                type: 'required',
                TranslatedMessage: [
                  { text: this.Constants.Required_field_Error, needTraslation: true }]
              }, {
                type: "min",
                TranslatedMessage: [
                  { text: this.Constants.Negative_Value_ERROR, needTraslation: true }
                ]
              }
              ],
              min: this.Constants.Min1.toString()
            },

          ],
        }],
    };
  }

  EditUnit(EditedObj: FormDefs)
  {
    if (!this.ClientValidaiton.isUpdated(this.data.dataToEdit, EditedObj.form))
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
      return;
    }
    this.spinner.fullScreenSpinnerForForm();
    if (!(this.ClientValidaiton.isUnique(this.data.Array, this.Constants.wholeSaleUnit,
      this.Edit.get(this.Constants.wholeSaleUnit)?.value, this.data.dataToEdit.id)))
    {
      this.spinner.removeSpinner();
      this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.wholeSaleUnit);
      this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
      return;
    }
    let UpdatedItem: Units = { ...this.data.dataToEdit };
    UpdatedItem.subdomain = this.Subdomain;
    this.ClientValidaiton.FillObjectFromForm(UpdatedItem, EditedObj.form);
    this.ItemService.Update_ItemUnit(UpdatedItem).subscribe({
      next: (r) =>
      {
        if (r.status)
          if (r.status !== this.Constants.SameObject)
          {
            this.spinner.removeSpinner();
            this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
            this.ClientValidaiton.FillObjectFromAnotherObject(this.data.dataToEdit, UpdatedItem);
            this.data.dataToEdit.conversionRate = this.data.dataToEdit.numberInRetailSale * this.data.dataToEdit.numberInWholeSale;
          }
        this.data.ShowProgressBar = false;
        this._bottomSheetRef.dismiss(this.data);
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.wholeSaleUnit, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.retailUnit, maxLength: this.Constants.MaxLength30 }
        ];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
  }
  CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }

}
