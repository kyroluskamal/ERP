import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ClientForgetPasswordModel } from '../../../Models/client-forget-password-model.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-forget-password',
  templateUrl: './client-forget-password.component.html',
  styleUrls: ['./client-forget-password.component.css']
})
export class ClientForgetPasswordComponent implements OnInit {
  ForgetPassworForm = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = [];
  selected: any;
  //Constructor
  constructor(private formBuilder: FormBuilder, private AccountService: ClientAccountService,
    public dialogHandler: DialogHandlerService, public translate: TranslationService,
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
    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = "en";
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
    const ForgetPasswordModel: ClientForgetPasswordModel = {
      Email: this.ForgetPassworForm.get("Email")?.value,
      ClientUrl: Constants.ClientUrl(Constants.Client_PasswordResetURL)
    }
    this.AccountService.ClientForgetPassord(ForgetPasswordModel).subscribe(
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
  switchLang(lang: string) {
    this.selected = this.translate.setTranslationLang(lang);
  }
}
