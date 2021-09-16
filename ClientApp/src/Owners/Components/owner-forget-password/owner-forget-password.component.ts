import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../Helpers/constants';
import { ForgetPasswordModel } from '../../Models/forget-password-model.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';

@Component({
  selector: 'app-owner-forget-password',
  templateUrl: './owner-forget-password.component.html',
  styleUrls: ['./owner-forget-password.component.css']
})
export class OwnerForgetPasswordComponent implements OnInit {
  ForgetPassworForm = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = [];
  //Constructor
  constructor(private formBuilder: FormBuilder, private AccountService: OwnerAccountService,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    private Notifications: NotificationsService) { }
  //NgOnInit
  ngOnInit(): void {
    this.ForgetPassworForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]]
    });
  }

 //new Functions
  OnSubmit() {
    const ForgetPasswordModel: ForgetPasswordModel = {
      Email: this.ForgetPassworForm.get("Email")?.value,
      ClientUrl: Constants.ClientUrl(Constants.Owner_PasswordResetURL)
    }
    this.AccountService.OwnerForgetPassord(ForgetPasswordModel).subscribe(
      () => {
        this.Notifications.success(Constants.PasswordResetEmail_success)
        this.dialogHandler.CloseDialog();
      },
      (error) => {
        this.Notifications.error(Constants.PasswordResetEmail_Error, "");
        this.ValidationErrors = error;
      }
    );
  }
}
