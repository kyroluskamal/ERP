import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription, tap } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ColDefs, FormDefs, MaxMinLengthValidation, ThemeColor } from 'src/Interfaces/interfaces';
import { Inventories, InventoryAddress } from '../../Models/inventories.model';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'
import { MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { AddInventAddressComponent } from '../InventoryAddress/add-invent-address/add-invent-address.component';
import { EditInventAddressComponent } from '../InventoryAddress/edit-invent-address/edit-invent-address.component';

@Component({
  selector: 'app-inventories',
  templateUrl: './inventories.component.html',
  styleUrls: ['./inventories.component.css']
})
export class InventoriesComponent implements OnInit, AfterViewInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  MaxLength: number = 30;
  AddNewInventory: FormGroup = new FormGroup({});
  loading: boolean = false;

  columns: ColDefs[] = [];
  AllInventories: Inventories[] = [];
  isLoadingResults: boolean = true;
  SelectedRows: Inventories[] = [];
  dataSource = new MatTableDataSource<any>();
  ShowProgressBar: boolean = true;
  AddedRow: any;
  PreventDeleteFor: any;
  ReferencialField: string = "inventoryAddress";
  FormBuilder: FormDefs = new FormDefs();
  constructor(private NotificationService: NotificationsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories, private ServerResponseHandler: ServerResponseHandelerService,
    private InventoriesService: InventoriesService, private ClientValidaiton: ClientSideValidationService) {
    this.PreventDeleteFor = this.translate.GetTranslation(this.Constants.MainWarehouse);

  }


  ngOnDestroy(): void {

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

    this.InventoriesService.GetAllInventories().subscribe(r => {
      console.log(r);
      for (let x of r) {
        let add: InventoryAddress | undefined = x.inventoryAddress;
        if (add !== null) {
          x.inventAdd = (add?.buildingNo !== "" ? add?.buildingNo + '-' : '') +
            (add?.streetName !== '' ? this.translate.isRightToLeft(this.translate.GetCurrentLang()) ?
              this.translate.GetTranslation(this.Constants.St) + ' ' + add?.streetName : add?.streetName +
              ` ${this.translate.GetTranslation(this.Constants.St)} ` : '') +
            (add?.addressLine_1 !== '' ? add?.addressLine_1 + ', ' : '') +
            (add?.addressLine_2 !== '' ? add?.addressLine_2 + ', ' : '') +
            (add?.flatNo !== '' ? this.translate.GetTranslation(this.Constants.Flat_No) + ':' + add?.flatNo + ', ' : '') +
            (add?.city !== '' ? add?.city + ',' : '') +
            (add?.government !== '' ? add?.government + ', ' : '') +
            (add?.country !== null ? add?.country?.countryName : '');
          x.inventAdd = x.inventAdd.trim();
          if (x.inventAdd[x.inventAdd.length - 1] === ",") {
            console.log(x.inventAdd.slice(0, x.inventAdd.length - 1))
            x.inventAdd = x.inventAdd.slice(0, x.inventAdd.length - 1) + ".";
          }
        } else {
          x.inventAdd = "";
        }

      }
      if (r[0].warehouseName === this.Constants.MainWarehouse) {
        r[0].warehouseName = this.translate.GetTranslation(this.Constants.MainWarehouse);
      }
      this.AllInventories = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );

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
    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: '#' },
      { field: 'warehouseName', display: this.Constants.Name, preventDeleteFor: this.translate.GetTranslation(this.Constants.MainWarehouse) },
      { field: 'mobilePhone', display: "", HeaderfaIcon: this.faMobileAlt },
      { field: 'telephone', display: "", HeaderfaIcon: this.faPhone },
      { field: 'notes', display: this.Constants.Notes },
      { field: 'inventAdd', display: this.Constants.address },
      { field: 'isActive', display: this.Constants.Active, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'isMainInventory', display: this.Constants.Main, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'addedBy_UserName', display: this.Constants.AddedBy },
    ];


    console.log(this.PreventDeleteFor);
  }


  Delete(invent: Inventories) {
    this.ShowProgressBar = true;
    this.InventoriesService.DeleteWarehouse(invent.id).subscribe({
      next: r => {
        this.ServerResponseHandler.GeneralSuccessResponse(r);
        this.AllInventories = this.AllInventories.filter((item) => {
          return item.id !== invent.id;
        })
        this.dataSource.paginator?.getNumberOfPages();
        this.dataSource.data = this.AllInventories;
        this.ShowProgressBar = false;
      },
      error: e => {
        this.ShowProgressBar = false;
        if (Array.isArray(e)) {
          this.NotificationService.error(this.translate.GetTranslation(e[0].status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        } else
          this.NotificationService.error(this.translate.GetTranslation(e.error.status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');

        this.ShowProgressBar = false;
      }
    })
  }
  Dbclick(row: Inventories) {
    let x: { dataToEdit: Inventories, Array: any[] } = { dataToEdit: row, Array: this.AllInventories }
    this.bottomSheet.open(EditInventoryComponent, {
      data: x
    });
    this.bottomSheet._openedBottomSheetRef?.afterDismissed().subscribe({
      next: r => console.log(r)
    })
  }

  SelectRow(event: any) {
    this.SelectedRows = event;
  }
  EditInventory(row: Inventories) {
    let x: { dataToEdit: Inventories, Array: any[] } = { dataToEdit: row, Array: this.AllInventories }
    this.bottomSheet.open(EditInventoryComponent, {
      data: x
    });
    this.bottomSheet._openedBottomSheetRef?.afterDismissed().subscribe({
      next: r => console.log(r)
    })
  }
  ShiftDelete(requiredKeys: boolean) {
    if (this.SelectedRows.length > 0 && requiredKeys) {
      if (this.SelectedRows[0].warehouseName === this.Constants.MainWarehouse) {
        this.NotificationService.error(this.translate.GetTranslation(this.Constants.Delete_Default_inventory_Error), '',
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
      } else {
        this.Delete(this.SelectedRows[0]);
        this.SelectedRows = [];
      }
    }
  }
  ngAfterViewInit() {

  }
  AddNewInvetory(formDefs: FormDefs) {
    this.ShowProgressBar = true;
    let CurrentUser: any = localStorage.getItem(this.Constants.Client);
    CurrentUser = JSON.parse(CurrentUser);
    let newInvent: Inventories = {
      id: 0,
      warehouseName: formDefs.form.get("Name")?.value,
      mobilePhone: formDefs.form.get("Mobile")?.value,
      telephone: formDefs.form.get("Phone")?.value,
      isActive: Boolean(formDefs.form.get("IsActive")?.value),
      isMainInventory: Boolean(formDefs.form.get("IsMain")?.value),
      notes: formDefs.form.get("Notes")?.value,
      addedBy_UserId: CurrentUser.userId,
      addedBy_UserName: CurrentUser.username,
      subdomain: this.Subdomain
    }
    if (!this.ClientValidaiton.isUnique(this.AllInventories, "warehouseName", formDefs.form.get("Name")?.value)) {
      this.ClientValidaiton.notUniqueNotification("warehouseName");
      this.ShowProgressBar = false;
      return;
    }
    this.InventoriesService.AddWarehouse(newInvent).subscribe(
      {
        next: (r) => {
          r.inventAdd = "";
          this.AllInventories.push(r);
          this.SelectedRows = [];
          this.SelectedRows.push(r);
          this.AddedRow = r;
          this.dataSource.data = this.AllInventories;
          this.ServerResponseHandler.DatatAddition_Success();
          setTimeout(() => {
            this.dataSource.paginator?.lastPage();
          }, 500);
        },
        error: (e) => {
          let x: MaxMinLengthValidation[] = [{ prop: "warehouseName", maxLength: this.MaxLength }]
          this.ServerResponseHandler.GetErrorNotification(e, x);
        }
      });
    this.AddNewInventory.reset();
    this.ShowProgressBar = false
  }

  AddAddress(row: Inventories) {
    this.bottomSheet.open(AddInventAddressComponent, {
      data: row
    });
  }
  EditAdress(row: Inventories) {
    this.bottomSheet.open(EditInventAddressComponent, {
      data: row
    });
  }
}
