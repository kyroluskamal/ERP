import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormControl, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import {
  CardTitle,
  FormDefs,
  MatBottomSheetDismissData,
  MaxMinLengthValidation,
  SelectedDataTransfer,
  ThemeColor,
} from 'src/Interfaces/interfaces';
import {
  MatBottomSheet,
  MatBottomSheetRef,
  MAT_BOTTOM_SHEET_DATA,
} from '@angular/material/bottom-sheet';
import {
  faEnvelope,
  faMobileAlt,
  faPhone,
  faPenAlt,
  faEdit,
  faCheckCircle,
  faTimesCircle,
  faPhoneAlt,
} from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { GeneralsService } from '../../Generals/generals.service';
import { Suppliers } from '../../Models/supplier.model';
import { SuppliersService } from '../suppliers.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';

@Component({
  selector: 'app-add-new-supplier',
  templateUrl: './add-new-supplier.component.html',
  styleUrls: ['./add-new-supplier.component.css'],
})
export class AddNewSupplierComponent implements OnInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  Title: CardTitle[] = [];

  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split('.')[0];
  MaxLength: number = 30;
  AddNew: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];
  BusinessNameMaxLength: number = 50;
  FirstNameMaxLength: number = 30;
  LastNameMaxLength: number = 30;
  constructor(
    private spinner: SpinnerService,
    private GeneralsService: GeneralsService,
    public Constants: ConstantsService,
    private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA)
    public data: MatBottomSheetDismissData<Suppliers>,
    @Inject(LOCALE_ID) public locale: string,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewSupplierComponent>,
    private SuppliersService: SuppliersService,
    private ClientValidaiton: ClientSideValidationService
  ) { }

  ngOnInit(): void {
    this.AllSelectionData.push({
      property: this.Constants.countryName,
      SelectedData: this.GeneralsService.Country,
    });
    this.AllSelectionData.push({
      property: this.Constants.currencyCode,
      SelectedData: this.GeneralsService.Currencies,
    });
    this._bottomSheetRef.backdropClick().subscribe((r) => {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    });

    this.AddNew = new FormGroup({
      businessName: new FormControl(''),
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      telephone: new FormControl(''),
      mobilePhone: new FormControl(''),
      taxID: new FormControl(''),
      cr: new FormControl(''),
      email: new FormControl(''),
      openingBalanceDate: new FormControl(new Date()),
      openingBalance: new FormControl(0.00),
      notes: new FormControl(''),
      currencyId: new FormControl(this.GeneralsService.CurrenctCurrencyId),
      countryId: new FormControl(
        this.GeneralsService.GetCountryId_by_countryCode()
      ),
      logo: new FormControl(''),
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
              formControlName: this.Constants.businessName,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.businessName,
              faIcon: faPenAlt,
              required: false,
              // errors: [{
              //   type: 'required',
              //   TranslatedMessage: [{
              //     text: this.Constants.Required_field_Error,
              //     needTraslation: true
              //   }]
              // }, {
              //   type: 'maxlength',
              //   TranslatedMessage: [{
              //     text: this.Constants.MaxLengthExceeded_ERROR,
              //     needTraslation: true
              //   }, {
              //     text: this.MaxLength.toString(),
              //     needTraslation: false
              //   }, {
              //     text: this.Constants.characters,
              //     needTraslation: true
              //   }]
              // }],
              // maxLength: "30"
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
            },
            {
              type: 'select',
              formControlName: this.Constants.countryId,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.countryName,
              required: true,
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
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
              // errors: [
              //   {
              //     type: this.Constants.NOT_VALID_PHONE_NUMBER,
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.NOT_VALID_PHONE_NUMBER,
              //         needTraslation: true
              //       }
              //     ]
              //   }
              // ]
            },
            {
              type: 'number',
              formControlName: this.Constants.openingBalance,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '30%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.openingBalance,
              required: false,
              // errors: [
              //   {
              //     type: 'required',
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.Required_field_Error,
              //         needTraslation: true,
              //       },
              //     ],
              //   },
              //   {
              //     type: 'maxlength',
              //     TranslatedMessage: [
              //       {
              //         text: this.Constants.MaxLengthExceeded_ERROR,
              //         needTraslation: true,
              //       },
              //       { text: this.MaxLength.toString(), needTraslation: false },
              //       { text: this.Constants.characters, needTraslation: true },
              //     ],
              //   },
              // ],
              // maxLength: '30',
            },
            {
              type: 'date',
              formControlName: this.Constants.openingBalanceDate,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '69%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.openingBalanceDate,
              required: false,
              // errors: [{
              //   type: 'required',
              //   TranslatedMessage: [{ text: this.Constants.Required_field_Error, needTraslation: true }]
              // },
              // {
              //   type: 'maxlength',
              //   TranslatedMessage: [{ text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true }, { text: this.MaxLength.toString(), needTraslation: false }, { text: this.Constants.characters, needTraslation: true }]
              // }],
              // maxLength: "30"
            },
            {
              type: 'select',
              formControlName: this.Constants.currencyId,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: '100%',
              fxFlex_xs: '100%',
              mat_label: this.Constants.currency,
              required: false,
              SelectData: this.GeneralsService.Currencies,
              PropertyNameToSetInValue: 'id',
              PropertyNameToShowInSelection: this.Constants.currencyCode,
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
            },
          ],
        },
      ],
    };
  }

  AddNewSupplier(formDefs: FormDefs) {
    this.spinner.fullScreenSpinner();
    this.data.ShowBrogressBar = true;
    let CurrentUser: any = localStorage.getItem(this.Constants.Client);
    CurrentUser = JSON.parse(CurrentUser);
    let newSupplier = new Suppliers();
    // Filling supplier Object
    this.ClientValidaiton.FillObjectFromForm(newSupplier, formDefs.form);
    newSupplier.addedBy_UserId = CurrentUser.userId;
    newSupplier.addedBy_UserName = CurrentUser.username;
    newSupplier.balance = newSupplier.openingBalance;
    newSupplier.currencyId = formDefs.form.get(
      this.Constants.currencyId
    )?.value;
    newSupplier.currency = this.GeneralsService.Currencies.find(
      (x) => x.id === newSupplier.currencyId
    )?.currencyCode!;
    newSupplier.countryId = formDefs.form.get(this.Constants.countryId)?.value;
    newSupplier.countryName = this.GeneralsService.Country.find(
      (x) => x.id === formDefs.form.get(this.Constants.countryId)?.value
    )?.countryName!;
    newSupplier.subdomain = this.Subdomain;
    newSupplier.logo = formDefs.form.get(this.Constants.logo)?.value;
    console.log(newSupplier);
    if (this.data)
      if (
        !this.ClientValidaiton.isUnique(
          this.data.data,
          this.Constants.businessName,
          formDefs.form.get(this.Constants.businessName)?.value
        )
      ) {
        this.spinner.removeSpinner();
        this.ClientValidaiton.notUniqueNotification_Swal(
          this.Constants.businessName
        );
        this.data.ShowBrogressBar = false;
        return;
      }
    this.SuppliersService.AddNewSupplier(newSupplier).subscribe({
      next: (r) => {
        if (this.data) {
          this.data.data.push(r);
          this.data.SelectedRows = [];
          this.data.SelectedRows.push(r);
          this.data.addedRow = r;
          this.data.dataSource.data = this.data.data;
        }
        this.spinner.removeSpinner();
        this.ServerResponseHandler.DatatAddition_Success_Swal();
        setTimeout(() => {
          this.data.dataSource.paginator?.lastPage();
        }, 500);
        this._bottomSheetRef.dismiss(this.data);
      },
      error: (e) => {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(newSupplier, this.FormBuilder.form);
        console.log(e);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.businessName, maxLength: this.BusinessNameMaxLength },
          { prop: this.Constants.firstName, maxLength: this.FirstNameMaxLength },
          { prop: this.Constants.lastName, maxLength: this.LastNameMaxLength },
        ]
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      },
    });
    this.AddNew.reset();
    this.spinner.removeSpinner();
    this.data.ShowBrogressBar = false;
  }
  CloseBottomSheet(event: boolean) {
    if (event) {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }
}
