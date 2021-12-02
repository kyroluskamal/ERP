import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-on-app',
  templateUrl: './login-on-app.component.html',
  styleUrls: ['./login-on-app.component.css']
})
export class LoginOnAppComponent implements OnInit {
  //constructor
  Subdomain: any = window.location.hostname.split(".").pop();
  constructor(public router: Router) {

  }

  ngOnInit(): void {
    console.log(this.Subdomain);
  }


}
