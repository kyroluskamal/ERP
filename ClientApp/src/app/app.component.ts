import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ClientAccountService } from '../Client/Services/Authentication/client-account-service.service';
import { OwnerAccountService } from '../Owners/Services/Authentication/Owner-account-service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
  title = 'KHerp';
  IsOwnerRoute: boolean;
  notFound: boolean;
  ServerError: boolean;
  constructor(private router: Router, public ClientAccountService: ClientAccountService,
    public OwnerAccountService: OwnerAccountService) {
    this.IsOwnerRoute = false;
    this.ServerError = false;
    this.notFound = false;
    
  }

  SetClientUser() {
    if (localStorage.getItem("Client")) {
      const user: any = localStorage.getItem("Client");
      this.ClientAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem("Client")) {
      const user: any = sessionStorage.getItem("Client");
      this.ClientAccountService.setCurrentUser(user);
    }
  }
  SetOwnerUser() {
    if (localStorage.getItem("Owner")) {
      const user: any = localStorage.getItem("Owner");
      this.OwnerAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem("Owner")) {
      const user: any = sessionStorage.getItem("Owner");
      this.OwnerAccountService.setCurrentUser(user);
    }
  }

  error: any;
  ngOnInit(): void {
    this.router.events
      .pipe(
        filter(e => e instanceof NavigationEnd)
      )
      .subscribe((navEnd: any) => {
        const navigation = this.router.getCurrentNavigation()?.extras;
        this.error = navigation?.state?.error;
        if (navEnd.urlAfterRedirects.includes("/owners")) this.IsOwnerRoute = true;
        if (navEnd.urlAfterRedirects.includes("/not-found")) this.notFound = true;
        else if (navEnd.urlAfterRedirects.includes("/server-error"))this.ServerError = true;
      });
    this.SetClientUser();
    this.SetOwnerUser();
  }
}
