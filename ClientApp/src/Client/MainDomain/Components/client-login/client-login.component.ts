import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ClientLogin } from '../../../Models/client-login.model';
import { ClientAccountService } from '../../../Services/Authentication/client-account-service.service';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent implements OnInit {
  loginForm:FormGroup = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: string[]  = []
  passwordHide: boolean = true;
  ClientLogin: ClientLogin = new ClientLogin();
  constructor(private formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public accountService: ClientAccountService,
    private Notifications: NotificationsService,
    public router: Router  ) {
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]],
      RememberMe:[null]
    });
  }
  
  
  Login(RememberMe:boolean) {
    if (this.loginForm.invalid) return;
    this.ClientLogin = {
      Email: this.loginForm.get("Email")?.value,
      Password: this.loginForm.get("Password")?.value,
      Subdomain: window.location.href.split("kherp.com")[0].split("https://")[1].split(".")[0]
    }
    this.accountService.loginMainDomain(this.ClientLogin, RememberMe).subscribe(
      response => {
        console.log(response);
        this.Notifications.success("You logined Successfully");
        this.dialogHandler.CloseDialog();
      },
      error => {
        console.log(error);
        this.ValidationErrors = error;
      },
    );
  }
}
