import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { CardTitle, FormDefs } from 'src/Interfaces/interfaces';
import { InventoryAddress } from '../../Models/inventories.model';

@Component({
  selector: 'app-add-invent-address',
  templateUrl: './add-invent-address.component.html',
  styleUrls: ['./add-invent-address.component.css']
})
export class AddInventAddressComponent implements OnInit {

  AddAddress: FormGroup;
  Form: FormDefs = new FormDefs();
  Title: CardTitle[] = [];
  constructor(public Constants: ConstantsService) {
    this.AddAddress = new FormGroup({
      buildingNo: new FormControl(null),
      flatNo: new FormControl(null),
      addressLine_1: new FormControl(null),
      addressLine_2: new FormControl(null),
      postalCode: new FormControl(null)
    });
    this.Title = [{
      text: this.Constants.Add,
      needTranslation: true
    }
    ]
    this.Form = {
      form: this.AddAddress,
      Card_fxFlex: "100%",
      Form_fxLayout: "row wrap",
      Form_fxLayoutAlign: "space-between",
      Button_GoogleIcon: "add_circle",
      ButtonText: [this.Constants.Add],
      formFieldsSpec: [{
        type: "text",
        formControlName: "buildingNo",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.buildingNo,
        required: false,
        disabled: false
      }, {
        type: "text",
        formControlName: "flatNo",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.flatNo,
        required: false,
        disabled: false
      }, {
        type: "text",
        formControlName: "postalCode",
        appearance: "outline",
        fxFlex: "33%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.postalCode,
        required: false,
        disabled: false
      }, {
        type: "text",
        formControlName: "addressLine_1",
        appearance: "outline",
        fxFlex: "49%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.addressLine_1,
        required: false,
        disabled: false
      }, {
        type: "text",
        formControlName: "addressLine_2",
        appearance: "outline",
        fxFlex: "49%",
        fxFlex_xs: "100%",
        mat_label: this.Constants.addressLine_2,
        required: false,
        disabled: false
      }]
    }
  }

  ngOnInit(): void {

  }
  AddNewAddress(newAddress: FormDefs) {

  }
}
