import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { CardTitle, FormDefs, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { GeneralsService } from '../../../Generals/generals.service';
import { Inventories, InventoryAddress } from '../../../Models/inventories.model';
import { AddNewInventoryComponent } from '../../add-new-inventory/add-new-inventory.component';
import { InventoriesService } from '../../inventories.service';

@Component({
  selector: 'app-add-invent-address',
  templateUrl: './add-invent-address.component.html',
  styleUrls: ['./add-invent-address.component.css']
})
export class AddInventAddressComponent implements OnInit {

  AddAddress: FormGroup;
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
    private GeneralsService: GeneralsService, private spinner: SpinnerService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories, private _bottomSheetRef: MatBottomSheetRef<InventoryAddress>,
    private ServerHandler: ServerResponseHandelerService, private translate: TranslationService) {
    navigator.geolocation.getCurrentPosition((position) => console.log(position))
    this.AddAddress = new FormGroup({
      buildingNo: new FormControl("", [Validators.maxLength(this.BuildingNoMaxLength)]),
      flatNo: new FormControl("", [Validators.maxLength(this.FlatNoMaxLength)]),
      addressLine_1: new FormControl("", [Validators.required]),
      addressLine_2: new FormControl(""),
      postalCode: new FormControl("", [Validators.maxLength(this.PostalCodeMaxLength)]),
      city: new FormControl("", [Validators.maxLength(this.CityMaxLength)]),
      government: new FormControl("", [Validators.maxLength(this.GovernmentMaxLength)]),
      streetName: new FormControl("", [Validators.maxLength(this.StreetNameMaxLength)]),
      countryName: new FormControl(this.GeneralsService.GetCountryId_by_countryCode(), [Validators.required])
    });
    this.AllSelectionData.push({ property: this.Constants.countryName, SelectedData: this.GeneralsService.Country })
    this.Title = [
      { text: this.Constants.Add, needTranslation: true },
      { text: this.Constants.address, needTranslation: true },
      { text: " : ", needTranslation: false },
      { text: this.data.warehouseName, needTranslation: false }
    ];
    this.Form = {
      form: this.AddAddress,
      Card_fxFlex: "100%",
      Form_fxLayout: "row wrap",
      Form_fxLayoutAlign: "space-between",
      Button_GoogleIcon: "add_circle",
      ButtonText: [this.Constants.Save],
      formSections: [{
        fxFlex: "100%",
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
              text: this.Constants.MaxLength15.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength15
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
              text: this.Constants.MaxLength15.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength15
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
              text: this.Constants.MaxLength30.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength30
        }, {
          type: "select",
          formControlName: this.Constants.countryName,
          appearance: "outline",
          fxFlex: "24%",
          fxFlex_xs: "100%",
          mat_label: this.Constants.countryName,
          required: true,
          SelectData: this.GeneralsService.Country,
          PropertyNameToSetInValue: 'id',
          PropertyNameToShowInSelection: this.Constants.countryName,
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
              text: this.Constants.MaxLength30.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength30
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
              text: this.Constants.MaxLength30.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength30
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
              text: this.Constants.MaxLength15.toString(),
              needTraslation: false
            }, {
              text: this.Constants.characters,
              needTraslation: true
            }]
          }],
          maxLength: this.Constants.MaxLength15
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
      }]
    }
  }

  ngOnInit(): void {

  }
  AddNewAddress(newAddress: FormDefs) {
    this.spinner.fullScreenSpinner();
    let newAdd: InventoryAddress = {
      id: 0,
      buildingNo: newAddress.form.get(this.Constants.buildingNo)?.value,
      flatNo: newAddress.form.get(this.Constants.flatNo)?.value,
      streetName: newAddress.form.get(this.Constants.streetName)?.value,
      addressLine_1: newAddress.form.get(this.Constants.addressLine_1)?.value,
      addressLine_2: newAddress.form.get(this.Constants.addressLine_2)?.value,
      city: newAddress.form.get(this.Constants.city)?.value,
      government: newAddress.form.get(this.Constants.government)?.value,
      postalCode: newAddress.form.get(this.Constants.postalCode)?.value,
      inventoriesId: this.data.id,
      inventories: this.data,
      countryNameCode: this.GeneralsService.Country.find(x => x.id === newAddress.form.get(this.Constants.countryName)?.value)?.countryNameCode!,
      countryName: this.GeneralsService.Country.find(x => x.id === newAddress.form.get(this.Constants.countryName)?.value)?.countryName!,
      countryId: newAddress.form.get(this.Constants.countryName)?.value,

      subdomain: this.subdomain
    }
    this.InventoreisService.AddAddress(newAdd).subscribe({
      next: r => {
        this.data.inventAdd = (r?.buildingNo !== "" ? r?.buildingNo + '-' : '') +
          (r?.streetName !== '' ? this.translate.isRightToLeft(this.translate.GetCurrentLang()) ?
            this.translate.GetTranslation(this.Constants.St) + ' ' + r?.streetName + ", " : r?.streetName +
            ` ${this.translate.GetTranslation(this.Constants.St)}, ` : '') +
          (r?.addressLine_1 !== '' ? r?.addressLine_1 + ', ' : '') +
          (r?.addressLine_2 !== '' ? r?.addressLine_2 + ', ' : '') +
          (r?.flatNo !== '' ? this.translate.GetTranslation(this.Constants.Flat_No) + ':' + r?.flatNo + ', ' : '') +
          (r?.city !== '' ? r?.city + ',' : '') +
          (r?.government !== '' ? r?.government + ', ' : '') +
          (r?.countryName !== null ? r?.countryName : '');
        this.data.inventAdd = this.data.inventAdd.trim();
        if (this.data.inventAdd[this.data.inventAdd.length - 1] === ",") {
          this.data.inventAdd = this.data.inventAdd.slice(0, this.data.inventAdd.length - 1) + ".";
        }
        this.data.inventoryAddress = r;
        this.spinner.removeSpinner();
        this.ServerHandler.DatatAddition_Success_Swal();
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
        ];
        this.spinner.removeSpinner();
        this.ServerHandler.GetErrorNotification_swal(e, x);
      }
    })
  }
}
