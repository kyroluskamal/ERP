import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../../Helpers/CustomValidation/custom-validators';
import { ClientResetPasswordModel } from '../../../Models/client-reset-password-model.model';
import { Location } from '@angular/common'
import { ClientForgetPasswordModel } from '../../../Models/client-forget-password-model.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
@Component({
  selector: 'app-client-reset-password',
  templateUrl: './client-reset-password.component.html',
  styleUrls: ['./client-reset-password.component.css']
})
export class ClientResetPasswordComponent implements OnInit {
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

  //Constructor
  constructor(private accountService: ClientAccountService, private route: ActivatedRoute,
    public formBuilder: FormBuilder, public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService, private location: Location,
    public Notifications: NotificationsService, private router: Router,
    public translate: TranslationService  ) { }
  //ngOnInit
  ngOnInit(): void {
    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = "en";
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
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
    this.email = this.route.snapshot.queryParamMap.get(Constants.email);
    this.token = this.route.snapshot.queryParamMap.get(Constants.token);
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
        this.Notifications.success(Constants.ResetPassword_Success);
        this.router.navigateByUrl("/");
        this.dialogHandler.CloseDialog();
        },
      (error: any) => {
        this.Fail = true;
        this.Success = false;
        this.ValidationErrors = error
        this.Notifications.error(Constants.ResetPassword_Error, "");
      }
    );
  }

  OnSubmit() {
    const ForgetPasswordModel: ClientForgetPasswordModel = {
      Email: this.email,
      ClientUrl: Constants.ClientUrl(Constants.Client_PasswordResetURL)
    }
    this.accountService.ClientForgetPassord(ForgetPasswordModel).subscribe(
      () => {
        this.Notifications.success(Constants.PasswordResetEmail_success)
        this.router.navigateByUrl("/");
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
