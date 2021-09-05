import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Location } from '@angular/common';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'KHerp';
  CurrentUrl: string;
  IsOwnerRoute: boolean;
  constructor(private location: Location) {
    this.CurrentUrl = this.location.path();
    this.IsOwnerRoute = false;
  }

  ngOnInit(): void {
    /*this.router.events.subscribe((routerData) => {
      if (routerData instanceof NavigationEnd) {
        this.CurrentUrl = routerData.url;
      }
    });*/
    if (this.CurrentUrl.includes("/owners")) this.IsOwnerRoute = true;
  }

  
}
