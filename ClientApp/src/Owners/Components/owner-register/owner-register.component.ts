import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../Helpers/CustomValidation/custom-validators';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnersAuthenticationService } from '../../Services/owners-authentication.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent implements OnInit {
  passwordHide: boolean = true;
  confirmPasswordHide: boolean = true;
  RegisterForm: FormGroup | any;
  ValidationErrors: string[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()

  constructor(public OwnerAuth: OwnersAuthenticationService,
    public formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService) { }

  OwnerRegisterModel: OwnerRegister = new OwnerRegister();
  ownerWithToken: any = null;

  ngOnInit(): void {
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
      Username: [null, [Validators.required]]
    },
      {
        validator: CustomValidators.passwordMatchValidator
      });
  }

  OnRegisterClick(event: any) {
    this.OwnerAuth.OwnerRegister(this.RegisterForm.value).subscribe(
      (response)=>{
        this.ownerWithToken = response;
        console.log(response);
      },
      (error) => {
        this.ValidationErrors = error;
      }
    );
  }
}
