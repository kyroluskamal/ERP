import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription, tap } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ColDefs, FormDefs, ThemeColor } from 'src/Interfaces/interfaces';
import { Inventories } from '../../Models/inventories.model';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'
import { MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { AddInventAddressComponent } from '../add-invent-address/add-invent-address.component';

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
  }


  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.AddNewInventory = new FormGroup({
      Name: new FormControl(null, [Validators.required, Validators.maxLength(this.MaxLength)]),
      IsMain: new FormControl(null),
      Phone: new FormControl(null, [CustomValidators.patternValidator(/^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      Mobile: new FormControl(null, [CustomValidators.patternValidator(/^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      IsActive: new FormControl(null),
      Notes: new FormControl(null)
    });

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
        disabled: false,
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
        disabled: false,
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
        faIcon: faPhone,
        required: false,
        disabled: false,
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
        disabled: false,
      }, {
        type: "checkbox",
        appearance: "fill",
        formControlName: "IsActive",
        fxFlex: "100%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.Active,
        required: false,
        disabled: false,
      }, {
        type: "checkbox",
        appearance: "fill",
        formControlName: "IsMain",
        fxFlex: "100%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.Main,
        required: false,
        disabled: false,
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

    this.InventoriesService.GetAllInventories().pipe(tap(
      r => {
        for (let x of r) {
          let add: any = x.inventoryAddress;
          if (add !== null) {
            let address = "";
            for (let key in add) {
              if (key !== 'id') {
                address += add[key] + ", ";
              }

            }
            x.inventAdd = address;
          } else {
            x.inventAdd = "";
          }
          if (x.warehouseName === this.Constants.MainWarehouse) {
            x.warehouseName = this.translate.GetTranslation(this.Constants.MainWarehouse);
            this.PreventDeleteFor = x;
          }
        }
      }
    )).subscribe(r => {
      console.log(r);
      this.AllInventories = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );

  }


  Delete(invent: Inventories) {
    this.ShowProgressBar = true;
    this.InventoriesService.DeleteWarehouse(invent.id).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(r.status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
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
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
    });
  }

  SelectRow(event: any) {
    this.SelectedRows = event;
  }
  EditInventory(row: Inventories) {
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
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
          this.ServerResponseHandler.GetErrorNotification(e, this.MaxLength);
        }
      });
    this.AddNewInventory.reset();
    this.ShowProgressBar = false
  }

  AddAddress(row: Inventories) {
    this.bottomSheet.open(AddInventAddressComponent);
  }
  EditAdress(row: Inventories) {
    console.log(row);
  }
}
