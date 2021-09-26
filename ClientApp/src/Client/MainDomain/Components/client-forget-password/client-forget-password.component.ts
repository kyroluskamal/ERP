import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
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
export class ClientForgetPasswordComponent implements OnInit, OnDestroy {
  ForgetPassworForm = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = [];
  selected: any;
  LangSubscibtion: Subscription = new Subscription();

  //Constructor
  constructor(private formBuilder: FormBuilder, private AccountService: ClientAccountService,
    public dialogHandler: DialogHandlerService, public translate: TranslationService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    private Notifications: NotificationsService) {
    this.selected = localStorage.getItem(Constants.lang);

  }
  //NgOnInit
  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.ForgetPassworForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]]
    });
  }

  //new Functions
  OnSubmit() {
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
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
