import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {
  //subdomain: string = "";
  //IsOwnerRoute: boolean = false;
  //CurrentUrl: string;
  //@Input("apptitle") title: string = "";
  constructor(private location: Location) {
    //this.CurrentUrl = this.location.path();
  }

  ngOnInit(): void {
    //if (this.CurrentUrl.includes("/owners")) this.IsOwnerRoute = true;
    //this.subdomain = window.location.href.split("kherp.com")[0].split("https://")[1].split(".")[0];
  }
  GoToHome() {
    window.location.href = "/";
  }
}
