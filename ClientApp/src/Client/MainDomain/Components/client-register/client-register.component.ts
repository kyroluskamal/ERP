import { OnDestroy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../../Helpers/CustomValidation/custom-validators';
import { ClientRegister } from '../../../Models/client-register.model';
import { ClientWithToken } from '../../../Models/client-with-token.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit, OnDestroy {
  //Properties
  passwordHide: boolean = true;
  confirmPasswordHide: boolean = true;
  RegisterForm: FormGroup = new FormGroup({});
  ValidationErrors: any[] = [];
  loading: boolean = false;
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ClientRegisterModel: ClientRegister = new ClientRegister();
  clientWithToken: ClientWithToken = new ClientWithToken();
  selected: any;
  CompanyName: string = '';
  LangSubscibtion: Subscription = new Subscription();

  //Constructor
  constructor(public ClientAuth: ClientAccountService, public Constants: ConstantsService,
    public formBuilder: FormBuilder, public translate: TranslationService,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public Notifications: NotificationsService) {
    this.selected = localStorage.getItem(Constants.lang);

  }


  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.RegisterForm = this.formBuilder.group({
      Email: [null, [Validators.required, Validators.email, CustomValidators.patternValidator(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/, { pattern: true })]],
      Password: [null, Validators.compose([
        Validators.required,
        CustomValidators.patternValidator(/\d/, { hasNumber: true }),
        CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
        CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true }),
        CustomValidators.patternValidator(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/, { hasSpecialCharacters: true }),
        Validators.minLength(8)])
      ],
      ConfirmPassword: [null, [Validators.required]],
      CompanyName: [null, [Validators.required, CustomValidators.patternValidator(/[A-Za-z]/, { EnglishName: true })]],
      Subdomain: [null, [Validators.required]],
      Username: [null, [Validators.required]],
    },
      {
        validator: CustomValidators.passwordMatchValidator
      });
  }
  //Register Function
  OnRegisterClick(event: any) {
    this.loading = true;
    this.ClientRegisterModel = {
      Email: this.RegisterForm.get("Email")?.value,
      Password: this.RegisterForm.get("Password")?.value,
      Subdomain: this.RegisterForm.get("Subdomain")?.value,
      CompanyName: this.RegisterForm.get("CompanyName")?.value,
      ConfirmPassword: this.RegisterForm.get("ConfirmPassword")?.value,
      UserName: this.RegisterForm.get("Username")?.value,
      ClientUrl: "https://" + window.location.host + "/" + RouterConstants.Client_EmailConfirmationUrl
    };
    if (this.RegisterForm.invalid) return;
    this.ClientAuth.Register(this.ClientRegisterModel).subscribe(
      (response: ClientWithToken) => {
        this.clientWithToken = response;
        console.log(response);
        this.ValidationErrors = [];
        this.Notifications.success(this.translate.GetTranslation(this.Constants.SuccessfulRegistration),
          this.translate.isRightToLeft(this.selected) ? "rtl" : "ltr");
        this.dialogHandler.CloseDialog();
      },
      (error) => {
        console.log(error);
        this.loading = false;
        this.ValidationErrors = error;
      }
    );


  }

  autoSubdomain() {
    this.CompanyName = this.RegisterForm.get('CompanyName')?.value;
    this.CompanyName = this.CompanyName.split(' ').join('').trim();
    this.RegisterForm.patchValue({
      Subdomain: this.CompanyName
    });
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}

