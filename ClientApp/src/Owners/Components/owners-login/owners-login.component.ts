import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { ValidationErrorMessagesService } from '../../../CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from '../../../Helpers/CustomErrorStateMatcher/custom-error-state-matcher';

@Component({
  selector: 'app-owners-login',
  templateUrl: './owners-login.component.html',
  styleUrls: ['./owners-login.component.css']
})
export class OwnersLoginComponent implements OnInit {
  passwordHide: boolean = true;
  loginForm = new FormGroup({});
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()

  constructor(public formBuilder: FormBuilder,
    public dialogHandler: DialogHandlerService,
    public ValidationErrorMessage: ValidationErrorMessagesService) {
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Email: [null, [Validators.email, Validators.required]],
      Password: [null, [Validators.required]]
    });
  }
}
