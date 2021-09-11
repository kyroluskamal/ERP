import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
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
  ValidationErrors: string[] = [];
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
        this.Notifications.success("You logined in Successfully");
        this.dialogHandler.CloseDialog();
      },
      error => {
        console.log(error);
        this.ValidationErrors = error;
      }
    );
  }
}
