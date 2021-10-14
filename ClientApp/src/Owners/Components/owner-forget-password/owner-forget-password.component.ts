import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { ForgetPasswordModel } from '../../Models/forget-password-model.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { TranslationService } from '../../../CommonServices/translation-service.service';
import { OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConstantsService } from '../../../CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';

@Component({
  selector: 'app-owner-forget-password',
  templateUrl: './owner-forget-password.component.html',
  styleUrls: ['./owner-forget-password.component.css']
})
export class OwnerForgetPasswordComponent implements OnInit, OnDestroy {
  ForgetPassworForm = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = [];
  selected: any;
  LangSubscibtion: Subscription = new Subscription();

  //Constructor
  constructor(private formBuilder: FormBuilder, private AccountService: OwnerAccountService,
    public dialogHandler: DialogHandlerService, public translate: TranslationService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    private Notifications: NotificationsService, public Constants: ConstantsService) {
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
    const ForgetPasswordModel: ForgetPasswordModel = {
      Email: this.ForgetPassworForm.get("Email")?.value,
      ClientUrl: this.Constants.ClientUrl(RouterConstants.Owner_PasswordResetURL)
    }
    this.AccountService.OwnerForgetPassord(ForgetPasswordModel).subscribe(
      () => {
        this.Notifications.success(this.translate.GetTranslation(this.Constants.PasswordResetEmail_success),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.dialogHandler.CloseDialog();
      },
      (error) => {
        this.Notifications.error(this.translate.GetTranslation(this.Constants.PasswordResetEmail_Error), "",
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.ValidationErrors = error;
      }
    );
  }
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
