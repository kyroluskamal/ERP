import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { Constants } from '../../../Helpers/constants';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../Helpers/CustomValidation/custom-validators';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent implements OnInit {
  passwordHide: boolean = true;
  loading: boolean = false;
  confirmPasswordHide: boolean = true;
  RegisterForm: FormGroup | any;
  ValidationErrors: any[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  OwnerRegisterModel: OwnerRegister = new OwnerRegister();
  selected: any;
  constructor(public OwnerAuth: OwnerAccountService,
    public formBuilder: FormBuilder, public translate: TranslationService,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public Notifications: NotificationsService) { }

  ngOnInit(): void {
    this.selected = localStorage.getItem('lang');
    if (!this.selected) {
      this.selected = "en";
      this.switchLang(this.selected);
    } else {
      this.switchLang(this.selected);
    }
    this.RegisterForm = this.formBuilder.group({
      Email: [null, [Validators.required, Validators.email, Validators.pattern(/.+@.+\..+/)]],
      Password: [null, Validators.compose([
        Validators.required,
        CustomValidators.patternValidator(/\d/, { hasNumber: true }),
        CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
        CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true }),
        CustomValidators.patternValidator(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/, { hasSpecialCharacters: true }),
        Validators.minLength(8)])
      ],
      ConfirmPassword: [null, [Validators.required]],
      Username: [null, [Validators.required]],
      FirstName: [null, [Validators.required]],
      LastName: [null, [Validators.required]]
    },
      {
        validator: CustomValidators.passwordMatchValidator
      });
  }

  OnRegisterClick(event: any) {
    this.loading = true;
    this.OwnerRegisterModel = {
      Email: this.RegisterForm.get("Email")?.value,
      Password: this.RegisterForm.get("Password")?.value,
      ConfirmPassword: this.RegisterForm.get("ConfirmPassword")?.value,
      UserName: this.RegisterForm.get("Username")?.value,
      ClientUrl: "https://" + window.location.host + "/" + Constants.Owner_EmailConfirmationUrl,
      FirstName: this.RegisterForm.get("FirstName")?.value,
      LastName: this.RegisterForm.get("LastName")?.value
    };
    if (this.RegisterForm.invalid) return;
    this.OwnerAuth.Register(this.OwnerRegisterModel).subscribe(
      (response)=>{
        this.Notifications.success("Your registered Successfully. Please Confirm your email");
        console.log(response);
        this.ValidationErrors = [];
        this.dialogHandler.CloseDialog();
      },
      (error) => {
        this.loading = false;
        this.ValidationErrors = error;
      }
    );
  }
  switchLang(lang: string) {
    this.selected = this.translate.setTranslationLang(lang);
  }
}
