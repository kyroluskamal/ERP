import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { GeneralsService } from '../../Generals/generals.service';
import { Suppliers } from '../../Models/supplier.model';
import { SuppliersService } from '../suppliers.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
@Component({
  selector: 'app-edit-supplier',
  templateUrl: './edit-supplier.component.html',
  styleUrls: ['./edit-supplier.component.css']
})
export class EditSupplierComponent implements OnInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  Title: CardTitle[] = [];
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split('.')[0];
  Edit: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];

  constructor(
    private spinner: SpinnerService, private GeneralsService: GeneralsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: DataToEdit_PassToBottomSheet<Suppliers>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<EditSupplierComponent>, private SuppliersService: SuppliersService,
    private ClientValidaiton: ClientSideValidationService
  ) { }

  ngOnInit(): void {
    this.AllSelectionData.push({ property: this.Constants.countryName, SelectedData: this.GeneralsService.Country, });
    this.AllSelectionData.push({ property: this.Constants.currencyCode, SelectedData: this.GeneralsService.Currencies });
    this._bottomSheetRef.backdropClick().subscribe((r) => {
      this.data.ShowProgressBar = false;
      this.spinner.removeSpinner();
      this._bottomSheetRef.dismiss(this.data);
    });

    this.Edit = new FormGroup({
      businessName: new FormControl(this.data.dataToEdit.businessName, [Validators.required, Validators.maxLength(this.Constants.MaxLength50)]),
      firstName: new FormControl(this.data.dataToEdit.firstName, [Validators.maxLength(this.Constants.MaxLength30)]),
      lastName: new FormControl(this.data.dataToEdit.lastName, [Validators.maxLength(this.Constants.MaxLength30)]),
      telephone: new FormControl(this.data.dataToEdit.telephone, [Validators.pattern(this.Constants.PhoneRegex)]),
      mobilePhone: new FormControl(this.data.dataToEdit.mobilePhone, [Validators.pattern(this.Constants.PhoneRegex)]),
      taxID: new FormControl(this.data.dataToEdit.taxID, [Validators.maxLength(this.Constants.MaxLength30)]),
      cr: new FormControl(this.data.dataToEdit.cr, [Validators.maxLength(this.Constants.MaxLength30)]),
      email: new FormControl(this.data.dataToEdit.email, [Validators.pattern(this.Constants.EmailRegex)]),
      openingBalanceDate: new FormControl(this.data.dataToEdit.openingBalanceDate, [Validators.required, Validators.min(this.Constants.MinZero)]),
      openingBalance: new FormControl(this.data.dataToEdit.openingBalance, [Validators.required, Validators.pattern("[0-9]+(\.[0-9]+)?")]),
      notes: new FormControl(this.data.dataToEdit.notes),
      currencyId: new FormControl(this.data.dataToEdit.currencyId, [Validators.required]),
      countryId: new FormControl(this.data.dataToEdit.countryId, [Validators.required]),
      logo: new FormControl(this.data.dataToEdit.logo),
    });

    this.Title = [
      { text: this.Constants.Add, needTranslation: true },
      { text: this.Constants.Supplier_Singular, needTranslation: true },
    ];
    this.FormBuilder = {
      form: this.Edit,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'add_circle',
      ButtonText: [this.Constants.Add, this.Constants.Supplier_Singular],
      formSections: [
        {
          fxFlex: '49%',
          sectionTitle: [
            { text: this.Constants.SupplierDetails, needTranslation: true },
          ],
          formFieldsSpec: [
            {
              type: 'text',
              formControlName: this.Constants.businessName,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.businessName,
              faIcon: faPenAlt,
              required: true,
              errors: [
                {
                  type: 'required',
                  TranslatedMessage: [
                    { text: this.Constants.Required_field_Error, needTraslation: true },
                  ],
                },
                {
                  type: 'maxlength',
                  TranslatedMessage: [
                    { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true, },
                    { text: this.Constants.MaxLength50.toString(), needTraslation: false, },
                    { text: this.Constants.characters, needTraslation: true, },
                  ],
                },
              ],
              maxLength: this.Constants.MaxLength50,
            },
            {
              type: 'text',
              formControlName: this.Constants.firstName,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.firstName,
              faIcon: faPenAlt,
              required: false,
              errors: [
                {
                  type: 'maxlength',
                  TranslatedMessage: [
                    { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                    { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                    { text: this.Constants.characters, needTraslation: true },
                  ],
                },
              ],
              maxLength: this.Constants.MaxLength30,
            },
            {
              type: 'text',
              formControlName: this.Constants.lastName,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.lastName,
              faIcon: faPenAlt,
              required: false,
              errors: [
                {
                  type: 'maxlength',
                  TranslatedMessage: [
                    { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                    { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                    { text: this.Constants.characters, needTraslation: true },
                  ],
                },
              ],
              maxLength: this.Constants.MaxLength30,
            },
            {
              type: 'tel',
              formControlName: this.Constants.CellPhoneNumber,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.CellPhoneNumber,
              faIcon: faMobileAlt,
              required: false,
              hint: {
                text_no_translation: '+(20)xxxxxxxxxx',
                dir: 'ltr',
                align: 'end',
                text_to_translation: '',
              },
              errors: [
                {
                  type: "pattern",
                  TranslatedMessage: [
                    { text: this.Constants.NOT_VALID_PHONE_NUMBER, needTraslation: true },
                  ],
                },
              ],
            },
            {
              type: 'tel',
              formControlName: this.Constants.TelephoneNumber,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.TelephoneNumber,
              faIcon: faPhoneAlt,
              required: false,
              hint: {
                text_no_translation: '+(20)xxxxxxxxxx',
                dir: 'ltr',
                align: 'end',
                text_to_translation: '',
              },
              errors: [
                {
                  type: "pattern",
                  TranslatedMessage: [
                    { text: this.Constants.NOT_VALID_PHONE_NUMBER, needTraslation: true },
                  ],
                },
              ],
            },
            {
              type: 'select',
              formControlName: this.Constants.countryId,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.countryName,
              required: true,
              errors: [
                {
                  type: 'required',
                  TranslatedMessage: [
                    { text: this.Constants.Required_field_Error, needTraslation: true },
                  ],
                },
              ],
              SelectData: this.GeneralsService.Country,
              PropertyNameToSetInValue: 'id',
              PropertyNameToShowInSelection: this.Constants.countryName,
            },
            {
              type: 'text',
              formControlName: this.Constants.taxID,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.taxID,
              faIcon: faPenAlt,
              required: false,
              errors: [
                {
                  type: 'maxlength',
                  TranslatedMessage: [
                    { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                    { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                    { text: this.Constants.characters, needTraslation: true },
                  ],
                },
              ],
              maxLength: this.Constants.MaxLength30,
            },
            {
              type: 'text',
              formControlName: this.Constants.cr,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '49%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.cr,
              faIcon: faPenAlt,
              required: false,
              errors: [
                {
                  type: 'maxlength',
                  TranslatedMessage: [
                    { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                    { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                    { text: this.Constants.characters, needTraslation: true },
                  ],
                },
              ],
              maxLength: this.Constants.MaxLength30,
            },
          ],
        },
        {
          sectionTitle: [
            { text: this.Constants.AccountDetails, needTranslation: true },
          ],
          fxFlex: '49%',
          formFieldsSpec: [
            {
              type: 'email',
              formControlName: this.Constants.email,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.email,
              faIcon: faEnvelope,
              required: false,
              errors: [
                {
                  type: "pattern",
                  TranslatedMessage: [
                    { text: this.Constants.IncorrecEmail, needTraslation: true },
                  ],
                },
              ],
            },
            {
              type: 'number',
              formControlName: this.Constants.openingBalance,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '30%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.openingBalance,
              required: true,
              min: this.Constants.MinZero.toString(),
              errors: [
                {
                  type: 'required',
                  TranslatedMessage: [
                    { text: this.Constants.Required_field_Error, needTraslation: true },
                  ],
                }, {
                  type: 'min',
                  TranslatedMessage: [
                    { text: this.Constants.Negative_Value_ERROR, needTraslation: true },
                  ],
                }, {
                  type: 'pattern',
                  TranslatedMessage: [
                    { text: this.Constants.Negative_Value_ERROR, needTraslation: true },
                  ],
                }
              ],
            },
            {
              type: 'date',
              formControlName: this.Constants.openingBalanceDate,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '69%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.openingBalanceDate,
              required: true,
              errors: [
                {
                  type: 'required',
                  TranslatedMessage: [
                    { text: this.Constants.Required_field_Error, needTraslation: true },
                  ],
                },
              ],
            },
            {
              type: 'select',
              formControlName: this.Constants.currencyId,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.currency,
              required: true,
              SelectData: this.GeneralsService.Currencies,
              PropertyNameToSetInValue: 'id',
              PropertyNameToShowInSelection: this.Constants.currencyCode,
              errors: [
                {
                  type: 'required',
                  TranslatedMessage: [
                    { text: this.Constants.Required_field_Error, needTraslation: true },
                  ],
                },
              ],
            },
            {
              type: 'textarea',
              formControlName: this.Constants.Notes,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.Notes,
              faIcon: faPenAlt,
              cdkAutosizeMinRows: '5',
              required: false,
            },
            {
              type: 'OneFile',
              formControlName: this.Constants.logo,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.logo,
              required: false,
              UploadInputText: [{ text: this.Constants.ChooseImage, needTranslation: true }]
            },
          ],
        },
      ],
    };
  }
  CloseBottomSheet(event: boolean) {
    if (event) {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }
  EditSupplier(EditedObj: FormDefs) {
    //If not updated close the bottomsheet
    // if (!this.ClientValidaiton.isUpdated(this.data.dataToEdit, EditedObj.form)) {
    //   this._bottomSheetRef.dismiss(this.data);
    //   return;
    // }
    this.spinner.fullScreenSpinnerForForm();
    if (!(this.ClientValidaiton.isUnique(this.data.Array, this.Constants.businessName, this.Edit.get(this.Constants.businessName)?.value, this.data.dataToEdit.id))) {
      this.spinner.removeSpinner();
      this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.businessName);
      this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form)
      return;
    }
    let UpdatedItem: Suppliers = { ...this.data.dataToEdit };
    this.ClientValidaiton.FillObjectFromForm(UpdatedItem, EditedObj.form);
    UpdatedItem.currency = this.GeneralsService.Currencies.find((x) => x.id === UpdatedItem.currencyId)?.currencyCode!;
    UpdatedItem.countryName = this.GeneralsService.Country.find((x) => x.id === UpdatedItem.countryId)?.countryName!;
    UpdatedItem.countryNameCode = this.GeneralsService.Country.find((x) => x.id === UpdatedItem.countryId)?.countryNameCode!;
    UpdatedItem.subdomain = this.Subdomain;
    this.SuppliersService.UpdateSupplier(UpdatedItem).subscribe({
      next: r => {
        if (r.status)
          if (r.status !== this.Constants.SameObject) {
            this.spinner.removeSpinner();
            this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
            // this.data.dataToEdit = { ...UpdatedItem };
            let oldBalance = this.data.dataToEdit.balance;
            let oldOpeningBalance = this.data.dataToEdit.openingBalance;
            this.ClientValidaiton.FillObjectFromAnotherObject(this.data.dataToEdit, UpdatedItem);
            this.data.dataToEdit.balance = (oldBalance - oldOpeningBalance) + UpdatedItem.openingBalance;
          }
        this.data.ShowProgressBar = false;
        this._bottomSheetRef.dismiss(this.data);
      },
      error: e => {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.businessName, maxLength: this.Constants.MaxLength50 },
          { prop: this.Constants.firstName, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.lastName, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.taxID, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.cr, maxLength: this.Constants.MaxLength30 },
        ];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
  }
}
