import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormControl, FormGroup, MaxLengthValidator, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, FormDefs, FormFieldType, MatBottomSheetDismissData, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { GeneralsService } from '../../Generals/generals.service';
import { Suppliers } from '../../Models/supplier.model';
import { SuppliersService } from '../suppliers.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';

@Component({
  selector: 'app-add-new-supplier',
  templateUrl: './add-new-supplier.component.html',
  styleUrls: ['./add-new-supplier.component.css'],
})
export class AddNewSupplierComponent implements OnInit
{
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  Title: CardTitle[] = [];
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split('.')[0];
  AddNew: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];

  constructor(
    private spinner: SpinnerService, private GeneralsService: GeneralsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: MatBottomSheetDismissData<Suppliers>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewSupplierComponent>, private SuppliersService: SuppliersService,
    private ClientValidaiton: ClientSideValidationService
  ) { }

  ngOnInit(): void
  {
    this.AllSelectionData.push({ property: this.Constants.countryName, SelectedData: this.GeneralsService.Country, });
    this.AllSelectionData.push({ property: this.Constants.currencyCode, SelectedData: this.GeneralsService.Currencies });
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    });

    this.AddNew = new FormGroup({
      businessName: new FormControl(null, [Validators.required, Validators.maxLength(this.Constants.MaxLength50)]),
      firstName: new FormControl(null, [Validators.maxLength(this.Constants.MaxLength30)]),
      lastName: new FormControl(null, [Validators.maxLength(this.Constants.MaxLength30)]),
      telephone: new FormControl(null, [Validators.pattern(this.Constants.PhoneRegex)]),
      mobilePhone: new FormControl(null, [Validators.pattern(this.Constants.PhoneRegex)]),
      taxID: new FormControl(null, [Validators.maxLength(this.Constants.MaxLength30)]),
      cr: new FormControl(null, [Validators.maxLength(this.Constants.MaxLength30)]),
      email: new FormControl(null, [Validators.pattern(this.Constants.EmailRegex)]),
      openingBalanceDate: new FormControl(new Date(), [Validators.required, Validators.min(this.Constants.MinZero)]),
      openingBalance: new FormControl(0.0, [Validators.required, Validators.pattern(this.Constants.DecimalNumber_Regex_Start0)]),
      notes: new FormControl(null),
      currencyId: new FormControl(this.GeneralsService.CurrenctCurrencyId, [Validators.required]),
      countryId: new FormControl(this.GeneralsService.GetCountryId_by_countryCode(), [Validators.required]),
      logo: new FormControl(null),
    });
    this.Title = [
      { text: this.Constants.Add, needTranslation: true },
      { text: this.Constants.Supplier_Singular, needTranslation: true },
    ];
    this.FormBuilder = {
      form: this.AddNew,
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              fieldToolTip: '',
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
              type: FormFieldType.image,
              fieldToolTip: '',
              formControlName: this.Constants.logo,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.logo,
              required: false,
              imageHeight: "200",
              imageWidth: "200",
              UploadedImageWidth: "100",
              UploadInputText: [{ text: this.Constants.ChooseImage, needTranslation: true }]
            },
          ],
        },
      ],
    };
  }

  AddNewSupplier(formDefs: FormDefs)
  {
    this.data.ShowBrogressBar = true;
    let CurrentUser: any = localStorage.getItem(this.Constants.Client);
    CurrentUser = JSON.parse(CurrentUser);
    let newSupplier = new Suppliers();
    // Filling supplier Object
    this.ClientValidaiton.FillObjectFromForm(newSupplier, formDefs.form);
    newSupplier.addedBy_UserId = CurrentUser.userId;
    newSupplier.addedBy_UserName = CurrentUser.username;
    newSupplier.balance = newSupplier.openingBalance;
    newSupplier.currencyId = formDefs.form.get(this.Constants.currencyId)?.value;
    newSupplier.currency = this.GeneralsService.Currencies.find((x) => x.id === newSupplier.currencyId)?.currencyCode!;
    newSupplier.countryId = formDefs.form.get(this.Constants.countryId)?.value;
    newSupplier.countryName = this.GeneralsService.Country.find((x) => x.id === formDefs.form.get(this.Constants.countryId)?.value)?.countryName!;
    newSupplier.countryNameCode = this.GeneralsService.Country.find((x) => x.id === formDefs.form.get(this.Constants.countryId)?.value)?.countryNameCode!;
    newSupplier.subdomain = this.Subdomain;
    newSupplier.logo = formDefs.form.get(this.Constants.logo)?.value;
    this.spinner.fullScreenSpinnerForForm();

    if (this.data)
      if (!this.ClientValidaiton.isUnique(
        this.data.data, this.Constants.businessName, formDefs.form.get(this.Constants.businessName)?.value))
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.businessName);
        this.data.ShowBrogressBar = false;
        return;
      }

    this.SuppliersService.AddNewSupplier(newSupplier).subscribe({
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
        this.AddNew.get(this.Constants.openingBalance)?.setValue(0);
        this.AddNew.get(this.Constants.openingBalanceDate)?.setValue(new Date());
        this.AddNew.get(this.Constants.currencyId)?.setValue(this.GeneralsService.CurrenctCurrencyId);
        this.AddNew.get(this.Constants.countryId)?.setValue(this.GeneralsService.GetCountryId_by_countryCode());
        this.AddNew.clearValidators();
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(newSupplier, this.FormBuilder.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.businessName, maxLength: this.Constants.MaxLength50 },
          { prop: this.Constants.firstName, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.lastName, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.taxID, maxLength: this.Constants.MaxLength30 },
          { prop: this.Constants.cr, maxLength: this.Constants.MaxLength30 },
        ];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      },
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