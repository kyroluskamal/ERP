import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { NavigationEnd, Router } from '@angular/router';
import { filter, Subscription } from 'rxjs';
import { ClientLogin, SendEmailConfirmationAgian } from 'src/Client/Models/client-models.model';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = []
  passwordHide: boolean = true;
  ClientLogin: ClientLogin = new ClientLogin();
  selected: any;
  LangSubscibtion: Subscription = new Subscription();
  loading: boolean = false;
  //constructor
  constructor(private formBuilder: FormBuilder, public router: Router,
    public dialogHandler: DialogHandlerService, public translate: TranslationService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public Constants: ConstantsService,
    public accountService: ClientAccountService, private Notifications: NotificationsService) {
    this.selected = localStorage.getItem(this.Constants.lang);
  }
  @Input() CloseIconHide: boolean = false;
  @Input() IsCOC: boolean = false;
  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    console.log(window.location.hostname.split("."));
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]],
      RememberMe: [false]
    });
    this.rememberMeOnClick();
  }


  Login(RememberMe: boolean) {
    this.loading = true;
    if (this.loginForm.invalid) return;
    this.ClientLogin = {
      Email: this.loginForm.get("Email")?.value,
      Password: this.loginForm.get("Password")?.value,
      Subdomain: window.location.hostname.split(".")[0],
      IsCOC: this.IsCOC === false && window.location.hostname.split(".")[0] === "localhost" ? false : true
    }
    this.accountService.loginMainDomain(this.ClientLogin, RememberMe).subscribe({
      next: response => {
        console.log(response);
        this.Notifications.success(this.translate.GetTranslation(this.Constants.LoggedInSuccessfully),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.dialogHandler.CloseDialog();
        this.loading = false;
        if (this.IsCOC)
          this.router.navigateByUrl("/app");
      },
      error: error => {
        this.loading = false;
        if (!Array.isArray(error)) {
          if (error.error.status)
            this.Notifications.error(this.translate.GetTranslation(error.error.status), "",
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? "rtl" : "ltr");
        } else {
          let errors = "";
          for (let e of error) {
            errors += this.translate.GetTranslation(e.status);
          }
          this.Notifications.error(errors, "",
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? "rtl" : "ltr");
        }
        console.log(error);
        this.ValidationErrors = error;
      },
    });
  }

  SendConfirmationAgain() {
    const sendEmailConfirmationAgian: SendEmailConfirmationAgian = {
      Email: this.loginForm.get("Email")?.value,
      ClientUrl: this.Constants.ClientUrl(RouterConstants.Client_EmailConfirmationUrl)
    }
    this.accountService.SendConfirmationAgain(sendEmailConfirmationAgian).subscribe(
      (response: any) => {
        this.Notifications.success(this.translate.GetTranslation(this.Constants.EmilConfirmationResnding_success),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr")
      },
      (error) => {
        this.Notifications.error(this.translate.GetTranslation(this.Constants.EmilConfirmationResnding_Error), '',
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        console.log(error);
      }
    );
  }
  rememberMeOnClick() {
    localStorage.setItem(this.Constants.ClientRememberMe, this.loginForm.get(this.Constants.RememberMe)?.value);
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
function input() {
  throw new Error('Function not implemented.');
}

