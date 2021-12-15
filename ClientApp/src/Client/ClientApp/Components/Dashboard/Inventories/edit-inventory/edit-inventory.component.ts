import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { FormDefs } from 'src/Interfaces/interfaces';
import { Inventories } from '../../Models/inventories.model';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit } from '@fortawesome/free-solid-svg-icons'
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';

@Component({
  selector: 'app-edit-inventory',
  templateUrl: './edit-inventory.component.html',
  styleUrls: ['./edit-inventory.component.css']
})
export class EditInventoryComponent implements OnInit {
  Subdomain: string = window.location.hostname.split(".")[0];

  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;

  MaxLength: number = 30;

  EditInvenoty: FormGroup = new FormGroup({});

  FormBuilder: FormDefs = new FormDefs();
  constructor(private NotificationService: NotificationsService,
    public Constants: ConstantsService, private InventoriesService: InventoriesService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories, private ClientSideValidation: ClientSideValidationService,
    private _bottomSheetRef: MatBottomSheetRef<EditInventoryComponent>,
    private ServerResponseHandler: ServerResponseHandelerService) {

  }


  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.EditInvenoty = new FormGroup({
      Name: new FormControl(this.data.warehouseName),
      IsMain: new FormControl(this.data.isMainInventory),
      Phone: new FormControl(this.data.telephone),
      Mobile: new FormControl(this.data.mobilePhone),
      IsActive: new FormControl(this.data.isActive),
      Notes: new FormControl(this.data.notes)
    });

    this.FormBuilder = {
      form: this.EditInvenoty,
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
        required: false,
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
  }
  EditInvent(EditedInvent: FormDefs) {
    this.data.warehouseName = EditedInvent.form.get("Name")?.value;
    this.data.mobilePhone = EditedInvent.form.get("Mobile")?.value;
    this.data.telephone = EditedInvent.form.get("Phone")?.value;
    this.data.isActive = Boolean(EditedInvent.form.get("IsActive")?.value);
    this.data.isMainInventory = Boolean(EditedInvent.form.get("IsMain")?.value);
    this.data.notes = EditedInvent.form.get("Notes")?.value;
    this.data.subdomain = this.Subdomain;

    this.InventoriesService.UpdateWarehouse(this.data).subscribe({
      next: r => {
        this.ServerResponseHandler.Data_Updaed_Success();
        this._bottomSheetRef.dismiss(this.data);
      },
      error: e => {
        this.ServerResponseHandler.GetErrorNotification(e);
      }
    });

  }
}
