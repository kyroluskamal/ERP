import { Component, Inject, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Constants } from '../../../../Helpers/constants';
import { ClientAccountService } from '../../Authentication/client-account-service.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-client-main-domain',
  templateUrl: './client-main-domain.component.html',
  styleUrls: ['./client-main-domain.component.css']
})
export class ClientMainDomainComponent implements OnInit {
  //Properties
  title = 'KHerp';
  IsOwnerRoute: boolean = false;
  subdomain: string = ""
  error: any;
  //constructor
  constructor(private router: Router, public ClientAccountService: ClientAccountService,
     private titleService: Title) {
    this.subdomain = window.location.host.split(".")[0];
    console.log(this.subdomain);
  }

  //ngOnInit
  ngOnInit(): void {
    this.SetClientUser();
  }
  //Functions
  SetClientUser() {
    if (localStorage.getItem(Constants.Client)) {
      const user: any = localStorage.getItem(Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(Constants.Client)) {
      const user: any = sessionStorage.getItem(Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    }
  }
}
