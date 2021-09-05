import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';

@Component({
  selector: 'app-client-login',
  templateUrl: './client-login.component.html',
  styleUrls: ['./client-login.component.css']
})
export class ClientLoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [Validators.required, Validators.min(3)])
  });
  hide: boolean = true;

  constructor(public dialogHandler: DialogHandlerService) {
  }

  ngOnInit(): void { }

  get emailInput() { return this.loginForm.get('email'); }
  get passwordInput() { return this.loginForm.get('password'); }

  Close() {
    this.dialogHandler.CloseDialog();
  }

}
