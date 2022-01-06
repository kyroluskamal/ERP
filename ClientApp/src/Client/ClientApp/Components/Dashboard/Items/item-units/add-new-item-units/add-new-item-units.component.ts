import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, FormDefs, KeyValueForUniqueCheck, MatBottomSheetDismissData, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { ItemUnit } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-add-new-item-units',
  templateUrl: './add-new-item-units.component.html',
  styleUrls: ['./add-new-item-units.component.css']
})
export class AddNewItemUnitsComponent implements OnInit
{
  Title: CardTitle[] = [];
  Subdomain: string = window.location.hostname.split('.')[0];
  AddNew: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: MatBottomSheetDismissData<ItemUnit>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewItemUnitsComponent>,
    private ItemsService: ItemsService, private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.ShowBrogressBar = false;
      this.spinner.removeSpinner();
      this._bottomSheetRef.dismiss(this.data);
    });
    this.AddNew = new FormGroup({
      wholeSaleUnit: new FormControl(null, [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]),
      numberInWholeSale: new FormControl(1, [Validators.required, Validators.pattern(this.Constants.IntNumberRegex_start1), Validators.min(this.Constants.MinLength1)]),
      retailUnit: new FormControl(null, [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]),
      numberInRetailSale: new FormControl(1, [Validators.required, Validators.pattern(this.Constants.IntNumberRegex_start1), Validators.min(this.Constants.MinLength1)])
    });
    this.Title = [{ text: this.Constants.Add_New_Units, needTranslation: true },];
    this.FormBuilder = {
      form: this.AddNew,
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
              formControlName: this.Constants.wholeSaleUnit,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.wholeSaleUnit,
              required: true,
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
              formControlName: this.Constants.numberInWholeSale,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.numberInWholeSale,
              required: true,
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
              formControlName: this.Constants.retailUnit,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.retailUnit,
              required: true,
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
              formControlName: this.Constants.numberInRetailSale,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "49%", fxFlex_xs: "100%",
              mat_label: this.Constants.numberInRetailSale,
              required: true,
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
  AddNewUnit(formDefs: FormDefs)
  {
    this.spinner.fullScreenSpinnerForForm();
    this.data.ShowBrogressBar = true;
    let newItem = new ItemUnit();
    this.ClientValidaiton.FillObjectFromForm(newItem, formDefs.form);
    if (this.data)
      if (!this.ClientValidaiton.isUnique(this.data.data, this.Constants.wholeSaleUnit, formDefs.form.get(this.Constants.wholeSaleUnit)?.value))
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.wholeSaleUnit);
        this.data.ShowBrogressBar = false;
        return;
      }
    this.ItemsService.AddNew_ItemUnit(newItem).subscribe({
      next: (r) =>
      {
        if (this.data)
        {
          this.data.data.push(r);
          this.data.SelectedRows = [];
          this.data.SelectedRows.push(r);
          this.data.addedRow = r;
          this.data.dataSource.data = this.data.data;
        } this.spinner.removeSpinner();
        this.ServerResponseHandler.DatatAddition_Success_Swal();
        setTimeout(() =>
        {
          this.data.dataSource.paginator?.lastPage();
        }, 500);
        this.AddNew.reset();
        this.AddNew.clearValidators();
        this.AddNew.get(this.Constants.numberInRetailSale)?.setValue(1);
        this.AddNew.get(this.Constants.numberInWholeSale)?.setValue(1);
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(newItem, this.FormBuilder.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.wholeSaleUnit, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.retailUnit, maxLength: this.Constants.MaxLength30 }
        ];
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

