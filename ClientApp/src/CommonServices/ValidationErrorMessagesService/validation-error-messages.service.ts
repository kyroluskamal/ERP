import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidationErrorMessagesService {

  constructor() { }

  getFormControl(controlName: string, formGroup: FormGroup): FormControl {
    return formGroup.get(controlName) as FormControl;
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
      case "CompanyName": {
        if (errorType == "required") return "<strong>Company Name</strong> is required";
        break;
      }
      case "Subdomain": {
        if (errorType == "required") return "<strong>Subdomain</strong> is required";
        break;
      }
      case "Username": {
        if (errorType == "required") return "<strong>Username</strong> is required";
        break;
      }
    }
    return "";
  }
}
