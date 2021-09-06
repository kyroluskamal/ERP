import { EventEmitter, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
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
  constructor(public OwnerAuth: OwnersAuthenticationService,
    public formBuilder: FormBuilder, public dialogHandler: DialogHandlerService) {
  }

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
        // check whether our password and confirm password match
        validator: CustomValidators.passwordMatchValidator
      });
  }
  getFormControl(controlName: string): FormControl {
    return this.RegisterForm.get(controlName) as FormControl;
  }

  getErrorMessage(controlName: string, errorType: string) {
    switch (controlName) {
      case "Email": {
        if (errorType == "required") return "<strong>Email</strong> is required";
        if (errorType == "email") return "You have to <strong>enter valid Email</strong>";
        break;
      }
      case "Password": {
        if (errorType == "required") return "<strong>Password</strong> is required";
        if (errorType == "hasNumber") return "Password should have <strong> at least one number</strong>";
        if (errorType == "hasCapitalCase") return "Password should have <strong> at least one Capital letter</strong>";
        if (errorType == "hasSmallCase") return "Password should have <strong> at least one Small letter</strong>";
        if (errorType == "minlength") return "Password should <strong> at least 8 characters long</strong>";
        if (errorType == "hasSpecialCharacters") return "Password should have <strong> at least one special character</strong>";
        break;
      }
      case "ConfirmPassword": {
        if (errorType == "required") return "<strong>Password Confirmation</strong> is required";
        if (errorType == "NoPassswordMatch") return "Passowrd do not match";
        break;
      }
      case "Username": {
        if (errorType == "required") return "<strong>Username</strong> is required";
        break;
      }
    }
    return "";
  }

  OnRegisterClick(event: any) {
    this.OwnerAuth.OwnerRegister(this.RegisterForm.value).subscribe(
      (response)=>{
        this.ownerWithToken = response;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
