import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
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
  notFound: boolean;
  ServerError: boolean;
  constructor(private location: Location) {
    this.CurrentUrl = this.location.path();
    this.IsOwnerRoute = false;
    this.notFound = false;
    this.ServerError = false;
  }

  ngOnInit(): void {
    if (this.CurrentUrl.includes("/owners")) this.IsOwnerRoute = true;
    if (this.CurrentUrl.includes("/not-found")) this.notFound = true;
    if (this.CurrentUrl.includes("/server-error")) this.ServerError = true;
  }
}
