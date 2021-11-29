import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { NavigationEnd, Router } from '@angular/router';
import { filter, Subscription } from 'rxjs';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ClientLogin } from 'src/Client/Models/client-login.model';
import { SendEmailConfirmationAgian } from 'src/Client/Models/send-email-confirmation-agian.model';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { RouterConstants } from 'src/Helpers/RouterConstants';


@Component({
  selector: 'app-login-on-app',
  templateUrl: './login-on-app.component.html',
  styleUrls: ['./login-on-app.component.css']
})
export class LoginOnAppComponent implements OnInit {
  //constructor
  Subdomain: any = window.location.hostname.split(".").pop();
  constructor(public router: Router) {

  }

  ngOnInit(): void {
    console.log(this.Subdomain);
  }


}
