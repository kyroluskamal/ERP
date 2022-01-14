import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormDefs } from 'src/Interfaces/interfaces';
import { Inventories } from '../../Models/inventories.model';
import { InventoriesService } from '../../Inventories/inventories.service';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit } from '@fortawesome/free-solid-svg-icons';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { faSave } from '@fortawesome/free-solid-svg-icons';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { SpinnerService } from 'src/CommonServices/spinner.service';
@Component({
  selector: 'app-edit-inventory',
  templateUrl: './edit-inventory.component.html',
  styleUrls: ['./edit-inventory.component.css']
})
export class EditInventoryComponent implements OnInit
{
  Subdomain: string = window.location.hostname.split(".")[0];

  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  EditInvenoty: FormGroup = new FormGroup({});
  Title: CardTitle[] = [];
  FormBuilder: FormDefs = new FormDefs();
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private InventoriesService: InventoriesService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: DataToEdit_PassToBottomSheet<Inventories>, private ClientSideValidation: ClientSideValidationService,
    private _bottomSheetRef: MatBottomSheetRef<EditInventoryComponent>,
    private ServerResponseHandler: ServerResponseHandelerService)
  {

  }


  ngOnDestroy(): void
  {

  }
  ngOnInit(): void
  {
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.ShowProgressBar = false;
      this.spinner.removeSpinner();
      this._bottomSheetRef.dismiss(this.data);
    });
    this.Title = [
      { text: this.Constants.Edit, needTranslation: true },
      { text: " : ", needTranslation: false },
      { text: this.data.dataToEdit.warehouseName, needTranslation: false }
    ];
    this.EditInvenoty = new FormGroup({
      Name: new FormControl(this.data.dataToEdit.warehouseName, [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]),
      IsMain: new FormControl(this.data.dataToEdit.isMainInventory),
      Phone: new FormControl(this.data.dataToEdit.telephone, [CustomValidators.patternValidator(/\+?(\(?[0-9]+\)?)?[0-9]+\s?((x|ext)[0-9]+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      Mobile: new FormControl(this.data.dataToEdit.mobilePhone, [CustomValidators.patternValidator(/\+?(\(?[0-9]+\)?)?[0-9]+\s?((x|ext)[0-9]+)?/, { NOT_VALID_PHONE_NUMBER: true })]),
      IsActive: new FormControl(this.data.dataToEdit.isActive),
      Notes: new FormControl(this.data.dataToEdit.notes)
    });

    this.FormBuilder = {
      form: this.EditInvenoty,
      Card_fxFlex: "100%",
      Form_fxLayout: "row wrap",
      Form_fxLayoutAlign: "space-between",
      Button_GoogleIcon: "save",
      ButtonText: [this.Constants.Save],
      formSections: [{
        fxFlex: "100%",
        formFieldsSpec: [{
          type: "text",
          fieldToolTip: '',
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
              text: this.Constants.MaxLength30.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          required: false,
          maxLength: this.Constants.MaxLength30
        }, {
          type: "tel",
          fieldToolTip: '',
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
          fieldToolTip: '',
          formControlName: "Mobile",
          appearance: "outline",
          fxFlex: "33%",
          fxFlex_xs: "100%",
          mat_label: this.Constants.CellPhoneNumber,
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
          type: "textarea",
          fieldToolTip: '',
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
          fieldToolTip: '',
          appearance: "fill",
          formControlName: "IsActive",
          fxFlex: "100%",
          fxFlex_xs: "100%",
          mat_label: this.Constants.Active,
          required: false,
        }, {
          type: "checkbox",
          fieldToolTip: '',
          appearance: "fill",
          formControlName: "IsMain",
          fxFlex: "100%",
          fxFlex_xs: "100%",
          mat_label: this.Constants.Main,
          required: false,
        }]
      }]
    };
  }
  EditInvent(EditedInvent: FormDefs)
  {
    if (this.data.dataToEdit.warehouseName === EditedInvent.form.get("Name")?.value
      && this.data.dataToEdit.mobilePhone === EditedInvent.form.get("Mobile")?.value
      && this.data.dataToEdit.telephone === EditedInvent.form.get("Phone")?.value
      && this.data.dataToEdit.isActive === Boolean(EditedInvent.form.get("IsActive")?.value)
      && this.data.dataToEdit.isMainInventory === Boolean(EditedInvent.form.get("IsMain")?.value)
      && this.data.dataToEdit.notes === EditedInvent.form.get("Notes")?.value)
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
      return;
    }
    this.spinner.fullScreenSpinnerForForm();
    if (!(this.ClientSideValidation.isUnique(this.data.Array, 'warehouseName', this.EditInvenoty.get("Name")?.value, this.data.dataToEdit.id)))
    {
      this.spinner.removeSpinner();
      this.ClientSideValidation.notUniqueNotification_Swal("warehouseName");
      EditedInvent.form.get("Name")?.setValue(this.data.dataToEdit.warehouseName);
      EditedInvent.form.get("Mobile")?.setValue(this.data.dataToEdit.mobilePhone);
      EditedInvent.form.get("Phone")?.setValue(this.data.dataToEdit.telephone);
      EditedInvent.form.get("IsActive")?.setValue(this.data.dataToEdit.isActive);
      EditedInvent.form.get("IsMain")?.setValue(this.data.dataToEdit.isMainInventory);
      EditedInvent.form.get("Notes")?.setValue(this.data.dataToEdit.notes);
      return;
    }
    let UpdateInvent: Inventories = {
      id: this.data.dataToEdit.id,
      warehouseName: EditedInvent.form.get("Name")?.value,
      mobilePhone: EditedInvent.form.get("Mobile")?.value,
      telephone: EditedInvent.form.get("Phone")?.value,
      isActive: Boolean(EditedInvent.form.get("IsActive")?.value),
      isMainInventory: Boolean(EditedInvent.form.get("IsMain")?.value),
      notes: EditedInvent.form.get("Notes")?.value,
      subdomain: this.Subdomain,
      addedBy_UserName: this.data.dataToEdit.addedBy_UserName,
      addedBy_UserId: this.data.dataToEdit.addedBy_UserId
    };


    this.InventoriesService.UpdateWarehouse(UpdateInvent).subscribe({
      next: r =>
      {
        if (r.status)
          if (r.status !== this.Constants.SameObject)
          {
            for (let x of this.InventoriesService.AllInventories)
            {
              if (x.id === UpdateInvent.id)
              {
                x = { ...UpdateInvent };
              }
            }
            this.spinner.removeSpinner();
            this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
            this.data.dataToEdit.warehouseName = UpdateInvent.warehouseName;
            this.data.dataToEdit.mobilePhone = UpdateInvent.mobilePhone;
            this.data.dataToEdit.telephone = UpdateInvent.telephone;
            this.data.dataToEdit.isActive = UpdateInvent.isActive;
            this.data.dataToEdit.isMainInventory = UpdateInvent.isMainInventory;
            this.data.dataToEdit.notes = UpdateInvent.notes;
          }
        this.data.ShowProgressBar = false;
        this._bottomSheetRef.dismiss(this.data);
      },
      error: e =>
      {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GetErrorNotification_swal(e);
        EditedInvent.form.get("Name")?.setValue(this.data.dataToEdit.warehouseName);
        EditedInvent.form.get("Mobile")?.setValue(this.data.dataToEdit.mobilePhone);
        EditedInvent.form.get("Phone")?.setValue(this.data.dataToEdit.telephone);
        EditedInvent.form.get("IsActive")?.setValue(this.data.dataToEdit.isActive);
        EditedInvent.form.get("IsMain")?.setValue(this.data.dataToEdit.isMainInventory);
        EditedInvent.form.get("Notes")?.setValue(this.data.dataToEdit.notes);
      }
    });

  }
}
