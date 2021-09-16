import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ClientAccountService } from '../Client/Services/Authentication/client-account-service.service';
import { Constants } from '../Helpers/constants';
import { OwnerAccountService } from '../Owners/Services/Authentication/Owner-account-service.service';
import { Location } from '@angular/common'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
  //Properties
  title = 'KHerp';
  IsOwnerRoute: boolean = false;
  subdomain: string = ""
  error: any;
  //constructor
  constructor(private router: Router, public ClientAccountService: ClientAccountService,
    public OwnerAccountService: OwnerAccountService) {
    this.subdomain = window.location.host.split(".")[0];
  }

  //ngOnInit
  ngOnInit(): void {
    
    this.router.events
      .pipe(
        filter(e => e instanceof NavigationEnd)
      )
      .subscribe((navEnd: any) => {
        const navigation = this.router.getCurrentNavigation()?.extras;
        this.error = navigation?.state?.error;
        if (navEnd.url.includes("/owners")) this.IsOwnerRoute = true
        else this.IsOwnerRoute = false;
        
      });
    this.SetClientUser();
    this.SetOwnerUser();
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
  SetOwnerUser() {
    if (localStorage.getItem(Constants.Owner)) {
      const user: any = localStorage.getItem(Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(Constants.Owner)) {
      const user: any = sessionStorage.getItem(Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    }
  }
}
