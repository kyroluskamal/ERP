import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../../Helpers/CustomValidation/custom-validators';
import { ClientResetPasswordModel } from '../../../Models/client-reset-password-model.model';
import { Location } from '@angular/common'
import { ClientForgetPasswordModel } from '../../../Models/client-forget-password-model.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { Subscription } from 'rxjs';
import { OnDestroy } from '@angular/core';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
@Component({
  selector: 'app-client-reset-password',
  templateUrl: './client-reset-password.component.html',
  styleUrls: ['./client-reset-password.component.css']
})
export class ClientResetPasswordComponent implements OnInit, OnDestroy {
  //Properties
  passwordHide: boolean = true;
  confirmPasswordHide: boolean = true;
  ResetForm: FormGroup = new FormGroup({});
  ValidationErrors: any[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ClientResetPasswordModel: ClientResetPasswordModel = new ClientResetPasswordModel();
  Success: boolean = false;
  Fail: boolean = false;
  Error: any;
  email: string | null = "";
  token: string | null = "";
  selected: any;
  LangSubscibtion: Subscription = new Subscription();

  //Constructor
  constructor(private accountService: ClientAccountService, private route: ActivatedRoute,
    public formBuilder: FormBuilder, public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService, private location: Location,
    public Notifications: NotificationsService, private router: Router,
    public translate: TranslationService, public Constants: ConstantsService) {
    this.selected = localStorage.getItem(this.Constants.lang);

  }
  //ngOnInit
  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.ResetForm = this.formBuilder.group({
      Password: [null, Validators.compose([
        Validators.required,
        CustomValidators.patternValidator(/\d/, { hasNumber: true }),
        CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
        CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true }),
        CustomValidators.patternValidator(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/, { hasSpecialCharacters: true }),
        Validators.minLength(8)])
      ],
      ConfirmPassword: [null, [Validators.required]]
    },
      {
        validator: CustomValidators.passwordMatchValidator
      });
    this.email = this.route.snapshot.queryParamMap.get(this.Constants.email);
    this.token = this.route.snapshot.queryParamMap.get(this.Constants.token);
    if (this.email && this.token) {
    } else {
      this.Success = false;
      this.router.navigateByUrl("/");
    }
  }

  PasswordReset() {
    this.ClientResetPasswordModel = {
      email: this.email,
      token: this.token,
      Password: this.ResetForm.get("Password")?.value,
      ConfirmPassword: this.ResetForm.get("ConfirmPassword")?.value
    }
    console.log(this.ClientResetPasswordModel);
    this.accountService.ClientResetPassword(this.ClientResetPasswordModel).subscribe(
      (Response: any) => {
        this.Success = true;
        this.Notifications.success(this.Constants.ResetPassword_Success);
        this.router.navigateByUrl("/");
        this.dialogHandler.CloseDialog();
      },
      (error: any) => {
        this.Fail = true;
        this.Success = false;
        this.ValidationErrors = error
        this.Notifications.error(this.Constants.ResetPassword_Error, "");
      }
    );
  }

  OnSubmit() {
    const ForgetPasswordModel: ClientForgetPasswordModel = {
      Email: this.email,
      ClientUrl: this.Constants.ClientUrl(RouterConstants.Client_PasswordResetURL)
    }
    this.accountService.ClientForgetPassord(ForgetPasswordModel).subscribe(
      () => {
        this.Notifications.success(this.Constants.PasswordResetEmail_success)
        this.router.navigateByUrl("/");
        this.dialogHandler.CloseDialog();
      },
      (error) => {
        this.Notifications.error(this.Constants.PasswordResetEmail_Error, "");
        this.ValidationErrors = error;
      }
    );
  }
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
