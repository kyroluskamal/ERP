import { Component, Inject, Input, OnDestroy, OnInit } from '@angular/core';
import { ClientAccountService } from '../../Authentication/client-account-service.service';
import { Title } from '@angular/platform-browser';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

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
    private titleService: Title, public Constants: ConstantsService) {
    this.subdomain = window.location.host.split(".")[0];
    console.log(this.subdomain);
  }


  //ngOnInit
  ngOnInit(): void {
    this.SetClientUser();
    if (localStorage.getItem(this.Constants.Client)) {
      const user: any = localStorage.getItem(this.Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(this.Constants.Client)) {
      const user: any = sessionStorage.getItem(this.Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    }
  }
  //Functions
  SetClientUser() {
    if (localStorage.getItem(this.Constants.Client)) {
      const user: any = localStorage.getItem(this.Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(this.Constants.Client)) {
      const user: any = sessionStorage.getItem(this.Constants.Client);
      this.ClientAccountService.setCurrentUser(user);
    }
  }

}
