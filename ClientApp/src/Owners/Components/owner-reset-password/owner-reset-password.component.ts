import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../Helpers/CustomValidation/custom-validators';
import { ForgetPasswordModel } from '../../Models/forget-password-model.model';
import { OwnerResetPasswordModel } from '../../Models/owner-reset-password-model.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';
import { Location } from '@angular/common';
import { TranslationService } from '../../../CommonServices/translation-service.service';
@Component({
  selector: 'app-owner-reset-password',
  templateUrl: './owner-reset-password.component.html',
  styleUrls: ['./owner-reset-password.component.css']
})
export class OwnerResetPasswordComponent implements OnInit {

  //Properties
  passwordHide: boolean = true;
  confirmPasswordHide: boolean = true;
  ResetForm: FormGroup = new FormGroup({});
  ValidationErrors: any[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  OwnerResetPasswordModel: OwnerResetPasswordModel = new OwnerResetPasswordModel();
  Success: boolean = false;
  Fail: boolean = false;
  Error: any;
  email: string | null = "";
  token: string | null = "";
  selected: any;

  //Constructor
  constructor(private accountService: OwnerAccountService, private route: ActivatedRoute,
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
      this.router.navigateByUrl("/owners");
    }
  }

  PasswordReset() {
    this.OwnerResetPasswordModel = {
      email: this.email,
      token: this.token,
      Password: this.ResetForm.get("Password")?.value,
      ConfirmPassword: this.ResetForm.get("ConfirmPassword")?.value
    }
    console.log(this.OwnerResetPasswordModel);
    this.accountService.OwnerResetPassword(this.OwnerResetPasswordModel).subscribe(
      (Response: any) => {
        this.Success = true;
        this.Notifications.success(Constants.ResetPassword_Success);
        this.router.navigateByUrl("/owners");
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
    const ForgetPasswordModel: ForgetPasswordModel = {
      Email: this.email,
      ClientUrl: Constants.ClientUrl(Constants.Owner_PasswordResetURL)
    }
    this.accountService.OwnerForgetPassord(ForgetPasswordModel).subscribe(
      () => {
        this.Notifications.success(Constants.PasswordResetEmail_success)
        this.router.navigateByUrl("/owners");
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
