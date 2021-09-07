import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { ValidationErrorMessagesService } from '../../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from '../../../../Helpers/CustomValidation/custom-validators';
import { ClientRegister } from '../../../Models/client-register.model';
import { ClientAuthenticationService } from '../../../Services/Authentication/client-authentication.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  passwordHide: boolean = true;
  confirmPasswordHide: boolean = true;
  RegisterForm: FormGroup = new FormGroup({});
  ValidationErrors: string[] = [];
  customErrorStateMatcher: CustomErrorStateMatcher= new CustomErrorStateMatcher()

  constructor(public ClientAuth: ClientAuthenticationService,
    public formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService  ) {
  }

  ClientRegisterModel: ClientRegister = new ClientRegister();
  clientWithToken: any = null;

  ngOnInit(): void {
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
      CompanyName: [null, [Validators.required]],
      Subdomain: [null, [Validators.required]],
      Username: [null, [Validators.required]]
    },
      {
        validator: CustomValidators.passwordMatchValidator
      });
  }
  OnRegisterClick(event: any) {
    this.ClientAuth.OwnerRegister(this.RegisterForm.value).subscribe(
      (response) => {
        this.clientWithToken = response;
        console.log(response);
        this.ValidationErrors = [];
      },
      (error) => {
        console.log("This erorr" + error);
        this.ValidationErrors = error;
      }
    );
  }
}
