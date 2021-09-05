import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { ClientRegister } from '../../../Models/client-register.model';
import { ClientAuthenticationService } from '../../../Services/Authentication/client-authentication.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {

  RegisterForm: FormGroup | any;
  constructor(public ClientAuth: ClientAuthenticationService,
    public formBuilder: FormBuilder, private dialogHandler: DialogHandlerService) {
  }

  ClientRegisterModel: ClientRegister = new ClientRegister();
  clientWithToken: any = null;

  ngOnInit(): void {
    this.RegisterForm = this.formBuilder.group({
      Email: [''],
      Password: [''],
      ConfirmPassword: [''],
      CompanyName: [''],
      Subdomain: [''],
      Username: ['']
    });
  }


  OnRegisterClick(event: any) {
    this.ClientAuth.OwnerRegister(this.RegisterForm.value).subscribe(
      (response) => {
        this.clientWithToken = response;
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
