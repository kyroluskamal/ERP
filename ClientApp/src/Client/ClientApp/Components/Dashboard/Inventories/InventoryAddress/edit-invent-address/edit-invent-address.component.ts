import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { CardTitle, FormDefs, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { GeneralsService } from '../../../Generals/generals.service';
import { Inventories, InventoryAddress } from '../../../Models/inventories.model';
import { InventoriesService } from '../../inventories.service';
@Component({
  selector: 'app-edit-invent-address',
  templateUrl: './edit-invent-address.component.html',
  styleUrls: ['./edit-invent-address.component.css']
})
export class EditInventAddressComponent implements OnInit {

  EditAddress: FormGroup;
  Form: FormDefs = new FormDefs();
  Title: CardTitle[] = [];
  subdomain: string = window.location.hostname.split(".")[0];
  BuildingNoMaxLength = 15;
  FlatNoMaxLength = 15;
  PostalCodeMaxLength = 15;
  CityMaxLength = 30;
  GovernmentMaxLength = 30;
  StreetNameMaxLength = 30;
  AllSelectionData: SelectedDataTransfer[] = []

  constructor(public Constants: ConstantsService, private InventoreisService: InventoriesService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories, private GeneralsService: GeneralsService,
    private _bottomSheetRef: MatBottomSheetRef<InventoryAddress>,
    private ServerHandler: ServerResponseHandelerService, private translate: TranslationService) {
    this.EditAddress = new FormGroup({
      buildingno: new FormControl(this.data.inventoryAddress?.buildingNo, [Validators.maxLength(this.BuildingNoMaxLength)]),
      flatno: new FormControl(this.data.inventoryAddress?.flatNo, [Validators.maxLength(this.FlatNoMaxLength)]),
      addressline_1: new FormControl(this.data.inventoryAddress?.addressLine_1, [Validators.required]),
      addressline_2: new FormControl(this.data.inventoryAddress?.addressLine_2),
      postalcode: new FormControl(this.data.inventoryAddress?.postalCode, [Validators.maxLength(this.PostalCodeMaxLength)]),
      city: new FormControl(this.data.inventoryAddress?.city, [Validators.maxLength(this.CityMaxLength)]),
      government: new FormControl(this.data.inventoryAddress?.government, [Validators.maxLength(this.GovernmentMaxLength)]),
      streetname: new FormControl(this.data.inventoryAddress?.streetName, [Validators.maxLength(this.StreetNameMaxLength)]),
      country: new FormControl(this.data.inventoryAddress?.countryId, [Validators.required])
    });
    this.AllSelectionData.push({ property: 'countryName', SelectedData: this.GeneralsService.Country })

    this.Title = [
      { text: this.Constants.Edit, needTranslation: true },
      { text: this.Constants.address, needTranslation: true },
      { text: " : ", needTranslation: false },
      { text: this.data.warehouseName, needTranslation: false }
    ]
    this.Form = {
      form: this.EditAddress,
      Card_fxFlex: "100%",
      Form_fxLayout: "row wrap",
      Form_fxLayoutAlign: "space-between",
      Button_GoogleIcon: "add_circle",
      ButtonText: [this.Constants.Add],
      formFieldsSpec: [{
        type: "text",
        formControlName: this.Constants.buildingNo,
        appearance: "outline",
        fxFlex: "24%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.buildingNo,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.BuildingNoMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.BuildingNoMaxLength.toString()
      }, {
        type: "text",
        formControlName: this.Constants.flatNo,
        appearance: "outline",
        fxFlex: "24%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.flatNo,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.FlatNoMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.FlatNoMaxLength.toString()
      }, {
        type: "text",
        formControlName: this.Constants.streetName,
        appearance: "outline",
        fxFlex: "24%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.streetName,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.StreetNameMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.StreetNameMaxLength.toString()
      }, {
        type: "select",
        formControlName: this.Constants.country,
        appearance: "outline",
        fxFlex: "24%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.country,
        required: true,
        SelectData: this.GeneralsService.Country,
        PropertyNameToSetInValue: 'id',
        PropertyNameToShowInSelection: "countryName",
      }, {
        type: "text",
        formControlName: this.Constants.city,
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.city,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.CityMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.CityMaxLength.toString()
      }, {
        type: "text",
        formControlName: this.Constants.government,
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.government,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.GovernmentMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.GovernmentMaxLength.toString()
      }, {
        type: "text",
        formControlName: this.Constants.postalCode,
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.postalCode,
        required: false,
        errors: [{
          type: 'maxlength',
          TranslatedMessage: [{
            text: this.Constants.MaxLengthExceeded_ERROR,
            needTraslation: true
          }, {
            text: this.PostalCodeMaxLength.toString(),
            needTraslation: false
          }, {
            text: this.Constants.characters,
            needTraslation: true
          }]
        }],
        maxLength: this.PostalCodeMaxLength.toString()
      }, {
        type: "text",
        formControlName: this.Constants.addressLine_1,
        appearance: "outline",
        fxFlex: "49%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.addressLine_1,
        required: false,
        errors: [{
          type: 'required',
          TranslatedMessage: [{
            text: this.Constants.Required_field_Error,
            needTraslation: true
          }]
        }],
      }, {
        type: "text",
        formControlName: this.Constants.addressLine_2,
        appearance: "outline",
        fxFlex: "49%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.addressLine_2,
        required: false
      }]
    }
  }

  ngOnInit(): void {

  }
  EditInventAddress(AddToEdit: FormDefs) {
    let currentCountry = this.GeneralsService.Country.find(x => x.id === AddToEdit.form.get(this.Constants.country)?.value);
    if (
      this.data.inventoryAddress?.buildingNo === AddToEdit.form.get(this.Constants.buildingNo)?.value
      && this.data.inventoryAddress?.flatNo === AddToEdit.form.get(this.Constants.flatNo)?.value
      && this.data.inventoryAddress?.streetName === AddToEdit.form.get(this.Constants.streetName)?.value
      && this.data.inventoryAddress?.addressLine_1 === AddToEdit.form.get(this.Constants.addressLine_1)?.value
      && this.data.inventoryAddress?.addressLine_2 === AddToEdit.form.get(this.Constants.addressLine_2)?.value
      && this.data.inventoryAddress?.city === AddToEdit.form.get(this.Constants.city)?.value
      && this.data.inventoryAddress?.government === AddToEdit.form.get(this.Constants.government)?.value
      && this.data.inventoryAddress?.postalCode === AddToEdit.form.get(this.Constants.postalCode)?.value
      && this.data.inventoryAddress?.countryId === AddToEdit.form.get(this.Constants.country)?.value
    ) {
      this._bottomSheetRef.dismiss();
      return;
    }

    let UpdatedAddress: InventoryAddress = {
      id: this.data.inventoryAddress?.id!,
      buildingNo: AddToEdit.form.get(this.Constants.buildingNo)?.value,
      flatNo: AddToEdit.form.get(this.Constants.flatNo)?.value,
      streetName: AddToEdit.form.get(this.Constants.streetName)?.value,
      addressLine_1: AddToEdit.form.get(this.Constants.addressLine_1)?.value,
      addressLine_2: AddToEdit.form.get(this.Constants.addressLine_2)?.value,
      city: AddToEdit.form.get(this.Constants.city)?.value,
      government: AddToEdit.form.get(this.Constants.government)?.value,
      postalCode: AddToEdit.form.get(this.Constants.postalCode)?.value,
      countryId: AddToEdit.form.get(this.Constants.country)?.value,
      countryName: currentCountry?.countryName,
      countryNameCode: currentCountry?.countryNameCode!,
      inventoriesId: this.data.inventoryAddress?.inventoriesId!,
      inventories: this.data.inventoryAddress?.inventories!,
      subdomain: this.subdomain
    }
    this.InventoreisService.UpdateAddress(UpdatedAddress).subscribe({
      next: r => {
        if (r.status)
          if (r.status !== this.Constants.SameObject) {
            this.data.inventAdd = (UpdatedAddress?.buildingNo !== "" ? UpdatedAddress?.buildingNo + '-' : '') +
              (UpdatedAddress?.streetName !== '' ? this.translate.isRightToLeft(this.translate.GetCurrentLang()) ?
                this.translate.GetTranslation(this.Constants.St) + ' ' + UpdatedAddress?.streetName : UpdatedAddress?.streetName +
                ` ${this.translate.GetTranslation(this.Constants.St)} ` : '') +
              (UpdatedAddress?.addressLine_1 !== '' ? UpdatedAddress?.addressLine_1 + ', ' : '') +
              (UpdatedAddress?.addressLine_2 !== '' ? UpdatedAddress?.addressLine_2 + ', ' : '') +
              (UpdatedAddress?.flatNo !== '' ? this.translate.GetTranslation(this.Constants.Flat_No) + ':' + UpdatedAddress?.flatNo + ', ' : '') +
              (UpdatedAddress?.city !== '' ? UpdatedAddress?.city + ',' : '') +
              (UpdatedAddress?.government !== '' ? UpdatedAddress?.government + ', ' : '') +
              (UpdatedAddress?.countryName !== "" ? UpdatedAddress?.countryName : '');
            this.data.inventAdd = this.data.inventAdd.trim();
            if (this.data.inventAdd[this.data.inventAdd.length - 1] === ",") {
              this.data.inventAdd = this.data.inventAdd.slice(0, this.data.inventAdd.length - 1) + ".";
            }
            this.data.inventoryAddress = UpdatedAddress;
            this.ServerHandler.GeneralSuccessResponse_Swal(r);
          }
        this._bottomSheetRef.dismiss();
      },
      error: e => {
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.flatNo, maxLength: 15 },
          { prop: this.Constants.buildingNo, maxLength: 15 },
          { prop: this.Constants.postalCode, maxLength: 15 },
          { prop: this.Constants.streetName, maxLength: 30 },
          { prop: this.Constants.city, maxLength: 30 },
          { prop: this.Constants.government, maxLength: 30 }
        ]
        this.ServerHandler.GetErrorNotification_swal(e, x);
        AddToEdit.form.get(this.Constants.buildingNo)?.setValue(this.data.inventoryAddress?.buildingNo);
        AddToEdit.form.get(this.Constants.flatNo)?.setValue(this.data.inventoryAddress?.flatNo);
        AddToEdit.form.get(this.Constants.streetName)?.setValue(this.data.inventoryAddress?.streetName);
        AddToEdit.form.get(this.Constants.addressLine_1)?.setValue(this.data.inventoryAddress?.addressLine_1);
        AddToEdit.form.get(this.Constants.addressLine_2)?.setValue(this.data.inventoryAddress?.addressLine_2);
        AddToEdit.form.get(this.Constants.city)?.setValue(this.data.inventoryAddress?.city);
        AddToEdit.form.get(this.Constants.government)?.setValue(this.data.inventoryAddress?.government);
        AddToEdit.form.get(this.Constants.postalCode)?.setValue(this.data.inventoryAddress?.postalCode);
        AddToEdit.form.get(this.Constants.country)?.setValue(this.data.inventoryAddress?.countryId);
      }
    })
  }

}
