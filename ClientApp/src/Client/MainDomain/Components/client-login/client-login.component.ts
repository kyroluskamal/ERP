import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { TranslateService } from '@ngx-translate/core';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { TranslationServiceService } from '../../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ClientLogin } from '../../../Models/client-login.model';
import { SendEmailConfirmationAgian } from '../../../Models/send-email-confirmation-agian.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ValidationErrors: any[] = []
  passwordHide: boolean = true;
  ClientLogin: ClientLogin = new ClientLogin();
  selected: any;
  //constructor
  constructor(private formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService, public translate: TranslationServiceService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public accountService: ClientAccountService, 
    private Notifications: NotificationsService,
    public router: Router) {
    
  }

  ngOnInit(): void {
    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = "en";
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]],
      RememberMe: [false]
    });
    this.rememberMeOnClick();
  }


  Login(RememberMe: boolean) {
    if (this.loginForm.invalid) return;
    this.ClientLogin = {
      Email: this.loginForm.get("Email")?.value,
      Password: this.loginForm.get("Password")?.value,
      Subdomain: window.location.href.split("kherp.com")[0].split("https://")[1].split(".")[0]
    }
    this.accountService.loginMainDomain(this.ClientLogin, RememberMe).subscribe(
      response => {
        console.log(response);
        this.Notifications.success(Constants.LoggedInSuccessfully);
        this.dialogHandler.CloseDialog();
      },
      error => {
        console.log(error);
        this.ValidationErrors = error;
      },
    );
  }

  SendConfirmationAgain() {
    const sendEmailConfirmationAgian: SendEmailConfirmationAgian = {
      Email: this.loginForm.get("Email")?.value,
      ClientUrl: Constants.ClientUrl(Constants.Client_EmailConfirmationUrl)
    }
    this.accountService.SendConfirmationAgain(sendEmailConfirmationAgian).subscribe(
      (response: any) => { this.Notifications.success(Constants.EmilConfirmationResnding_success) },
      (error) => {
        this.Notifications.error(Constants.EmilConfirmationResnding_Error, '');
        console.log(error);
      }
    );
  }
  rememberMeOnClick() {
    localStorage.setItem(Constants.ClientRememberMe, this.loginForm.get(Constants.RememberMe)?.value);
  }
  switchLang(lang: string) {
    this.selected = this.translate.setTranslationLang(lang);
  }

}
