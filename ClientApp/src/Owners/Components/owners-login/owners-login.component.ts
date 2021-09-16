import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { SendEmailConfirmationAgian } from '../../../Client/Models/send-email-confirmation-agian.model';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { OwnerLogin } from '../../Models/owner-login.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-owners-login',
  templateUrl: './owners-login.component.html',
  styleUrls: ['./owners-login.component.css']
})
export class OwnersLoginComponent implements OnInit {
  passwordHide: boolean = true;
  loginForm = new FormGroup({});
  ValidationErrors: any[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  OwnerLogin: OwnerLogin = new OwnerLogin();
  constructor(public formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    private Notifications: NotificationsService,
    public accountService: OwnerAccountService  ) {
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]],
      RememberMe: [null]
    });
  }

  Login(RememberMe: boolean) {
    if (this.loginForm.invalid) return;
    this.OwnerLogin = {
      Email: this.loginForm.get("Email")?.value,
      Password: this.loginForm.get("Password")?.value
    }
    this.accountService.login(this.OwnerLogin, RememberMe).subscribe(
      response => {
        console.log(response);
        this.Notifications.success(Constants.LoggedInSuccessfully);
        this.dialogHandler.CloseDialog();
      },
      error => {
        console.log(error);
        this.ValidationErrors = error;
      }
    );
  }

  SendConfirmationAgain() {
    const sendEmailConfirmationAgian: SendEmailConfirmationAgian = {
      Email: this.loginForm.get("Email")?.value,
      ClientUrl: Constants.ClientUrl(Constants.Owner_EmailConfirmationUrl)
    }
    this.accountService.SendConfirmationAgain(sendEmailConfirmationAgian).subscribe(
      (response: any) => { this.Notifications.success(Constants.EmilConfirmationResnding_success) },
      (error) => {
        this.Notifications.error(Constants.EmilConfirmationResnding_Error, "");
        console.log(error);
      }
    );
  }
  rememberMeOnClick() {
    localStorage.setItem(Constants.OwnerRememberMe, this.loginForm.get(Constants.RememberMe)?.value);
  }
}
