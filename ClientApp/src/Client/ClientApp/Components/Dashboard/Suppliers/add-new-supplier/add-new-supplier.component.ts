import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, FormDefs, MaxMinLengthValidation, ThemeColor } from 'src/Interfaces/interfaces';
import { Inventories } from '../../Models/inventories.model';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { Suppliers } from '../../Models/supplier.model';
import { SuppliersService } from '../suppliers.service';
@Component({
  selector: 'app-add-new-supplier',
  templateUrl: './add-new-supplier.component.html',
  styleUrls: ['./add-new-supplier.component.css']
})
export class AddNewSupplierComponent implements OnInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  Title: CardTitle[] = [];

  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split(".")[0];
  MaxLength: number = 30;
  AddNewInventory: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  constructor(
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: {
      dataSource: MatTableDataSource<Suppliers>, ShowBrogressBar: boolean,
      addedRow: any, AllSuppliers: Suppliers[], SelectedRows: Suppliers[]
    }, private ServerResponseHandler: ServerResponseHandelerService, private _bottomSheetRef: MatBottomSheetRef<AddNewSupplierComponent>,
    private SuppliersService: SuppliersService, private ClientValidaiton: ClientSideValidationService) {

  }

  ngOnInit(): void {
    this.AddNewInventory = new FormGroup({
      Name: new FormControl(null, [Validators.required, Validators.maxLength(this.MaxLength)]),
      IsMain: new FormControl(null),
      Phone: new FormControl(null, [CustomValidators.patternValidator(/\+?(\(?[0-9]+\)?)?[0-9]+\s?((x|ext)[0-9]+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      Mobile: new FormControl(null, [CustomValidators.patternValidator(/\+?(\(?[0-9]+\)?)?[0-9]+\s?((x|ext)[0-9]+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      IsActive: new FormControl(null),
      Notes: new FormControl(null)
    });
    this.Title = [
      { text: this.Constants.Add, needTranslation: true },
      { text: this.Constants.Warehouse_Singular, needTranslation: true }
    ]
    this.FormBuilder = {
      form: this.AddNewInventory,
      Card_fxFlex: "100%",
      Form_fxLayout: "row wrap",
      Form_fxLayoutAlign: "space-between",
      Button_GoogleIcon: "add_circle",
      ButtonText: [this.Constants.Add, this.Constants.Warehouse_Singular],
      formFieldsSpec: [{
        type: "text",
        formControlName: "Name",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.WarehouseName,

        faIcon: faPenAlt,
        errors: [{
          type: 'required',
          TranslatedMessage: [{
            text: this.Constants.Required_field_Error,
            needTraslation: true
          }]
        }, {
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.MaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        required: true,
        maxLength: "30"
      }, {
        type: "tel",
        formControlName: "Phone",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.TelephoneNumber,
        faIcon: faPhone,

        required: false,
        hint: {
          text_no_translation: "+(20)xxxxxxxxxx",
          dir: "ltr",
          align: "end",
          text_to_translation: ""
        },
        errors: [
          {
            type: this.Constants.NOT_VALID_PHONE_NUMBER,
            TranslatedMessage: [
              {
                text: this.Constants.NOT_VALID_PHONE_NUMBER,
                needTraslation: true
              }
            ]
          }
        ]
      }, {
        type: "tel",
        formControlName: "Mobile",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.CellPhoneNumber,
        faIcon: faMobileAlt,
        required: false,
        hint: {
          text_no_translation: "+(20)xxxxxxxxxx",
          dir: "ltr",
          align: "end",
          text_to_translation: ""
        },
        errors: [
          {
            type: this.Constants.NOT_VALID_PHONE_NUMBER,
            TranslatedMessage: [
              {
                text: this.Constants.NOT_VALID_PHONE_NUMBER,
                needTraslation: true
              }
            ]
          }
        ]
      }, {
        type: "textarea",
        formControlName: "Notes",
        appearance: "outline",
        fxFlex: "100%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.Notes,
        faIcon: faPenAlt,
        cdkAutosizeMinRows: '5',
        required: false,
      }, {
        type: "checkbox",
        appearance: "fill",
        formControlName: "IsActive",
        fxFlex: "100%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.Active,
        required: false,
      }, {
        type: "checkbox",
        appearance: "fill",
        formControlName: "IsMain",
        fxFlex: "100%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.Main,
        required: false,
      }]
    }
  }



  // AddNewInvetory(formDefs: FormDefs) {
  //   this.data.ShowBrogressBar = true;
  //   let CurrentUser: any = localStorage.getItem(this.Constants.Client);
  //   CurrentUser = JSON.parse(CurrentUser);
  //   let newInvent: Inventories = {
  //     id: 0,
  //     warehouseName: formDefs.form.get("Name")?.value,
  //     mobilePhone: formDefs.form.get("Mobile")?.value,
  //     telephone: formDefs.form.get("Phone")?.value,
  //     isActive: Boolean(formDefs.form.get("IsActive")?.value),
  //     isMainInventory: Boolean(formDefs.form.get("IsMain")?.value),
  //     notes: formDefs.form.get("Notes")?.value,
  //     addedBy_UserId: CurrentUser.userId,
  //     addedBy_UserName: CurrentUser.username,
  //     subdomain: this.Subdomain
  //   }
  //   if (this.data)
  //     if (!this.ClientValidaiton.isUnique(this.data.AllSuppliers, "warehouseName", formDefs.form.get("Name")?.value)) {
  //       this.ClientValidaiton.notUniqueNotification_Swal("warehouseName");

  //       this.data.ShowBrogressBar = false;
  //       return;
  //     }
  //   this.SuppliersService.AddNewSupplier(newInvent).subscribe(
  //     {
  //       next: (r) => {
  //         r.inventAdd = "";
  //         if (this.data) {
  //           this.data.AllSuppliers.push(r);
  //           this.data.SelectedRows = [];
  //           this.data.SelectedRows.push(r);
  //           this.data.addedRow = r;
  //           this.data.dataSource.data = this.data.AllSuppliers;
  //         }
  //         this.ServerResponseHandler.DatatAddition_Success_Swal();
  //         setTimeout(() => {
  //           this.data.dataSource.paginator?.lastPage();
  //         }, 500);
  //         this._bottomSheetRef.dismiss(this.data);
  //       },
  //       error: (e) => {
  //         let x: MaxMinLengthValidation[] = [{ prop: "warehouseName", maxLength: this.MaxLength }]
  //         this.ServerResponseHandler.GetErrorNotification_swal(e, x);
  //       }
  //     });
  //   this.AddNewInventory.reset();
  //   this.data.ShowBrogressBar = false
  // }
}
