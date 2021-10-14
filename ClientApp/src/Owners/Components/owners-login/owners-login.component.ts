import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Subscription } from 'rxjs';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { SendEmailConfirmationAgian } from '../../../Client/Models/send-email-confirmation-agian.model';
import { ConstantsService } from '../../../CommonServices/constants.service';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { OwnerLogin } from '../../Models/owner-login.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-owners-login',
  templateUrl: './owners-login.component.html',
  styleUrls: ['./owners-login.component.css']
})
export class OwnersLoginComponent implements OnInit, OnDestroy {
  passwordHide: boolean = true;
  loading: boolean = false;
  loginForm = new FormGroup({});
  ValidationErrors: any[] = [];
  selected: any;
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  OwnerLogin: OwnerLogin = new OwnerLogin();
  LangSubscibtion: Subscription = new Subscription();

  //Constructor
  constructor(public formBuilder: FormBuilder, public translate: TranslationService,
    public dialogHandler: DialogHandlerService, public Constants: ConstantsService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    private Notifications: NotificationsService,
    public accountService: OwnerAccountService) {
    this.selected = localStorage.getItem(this.Constants.lang);
  }

  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]],
      RememberMe: [null]
    });
  }

  Login(RememberMe: boolean) {
    this.loading = true;
    if (this.loginForm.invalid) return;
    this.OwnerLogin = {
      Email: this.loginForm.get("Email")?.value,
      Password: this.loginForm.get("Password")?.value
    }
    this.accountService.login(this.OwnerLogin, RememberMe).subscribe(
      response => {
        console.log(response);
        this.Notifications.success(this.translate.GetTranslation(this.Constants.LoggedInSuccessfully),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.dialogHandler.CloseDialog();
        this.loading = false;
      },
      error => {
        this.loading = false
        console.log(error);
        this.ValidationErrors = error;
      }
    );
  }

  SendConfirmationAgain() {
    this.loading = true;
    const sendEmailConfirmationAgian: SendEmailConfirmationAgian = {
      Email: this.loginForm.get("Email")?.value,
      ClientUrl: this.Constants.ClientUrl(RouterConstants.Owner_EmailConfirmationUrl)
    }
    this.accountService.SendConfirmationAgain(sendEmailConfirmationAgian).subscribe(
      (response: any) => {
        this.Notifications.success(this.translate.GetTranslation(this.Constants.EmilConfirmationResnding_success),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.loading = false;
      },
      (error) => {
        this.loading = false;
        this.Notifications.error(this.translate.GetTranslation(this.Constants.EmilConfirmationResnding_Error), "",
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        console.log(error);
      }
    );
  }
  rememberMeOnClick() {
    localStorage.setItem(this.Constants.OwnerRememberMe, this.loginForm.get(this.Constants.RememberMe)?.value);
  }
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
