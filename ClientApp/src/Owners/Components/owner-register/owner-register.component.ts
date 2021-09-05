import { EventEmitter, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnersAuthenticationService } from '../../Services/owners-authentication.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent implements OnInit {
RegisterForm: FormGroup | any;
  constructor(public OwnerAuth: OwnersAuthenticationService,
    public formBuilder: FormBuilder, private dialogHandler: DialogHandlerService) {
  }

  OwnerRegisterModel: OwnerRegister = new OwnerRegister();
  ownerWithToken: any = null;

  ngOnInit(): void {
    this.RegisterForm = this.formBuilder.group({
      Username: null,
      Email: null,
      Password: null,
      ConfirmPassword:null
    });
  }


  OnRegisterClick(event: any) {
    this.OwnerAuth.OwnerRegister(this.RegisterForm.value).subscribe(
      (response)=>{
        this.ownerWithToken = response;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  Close() {
    this.dialogHandler.CloseDialog();
  }
}
