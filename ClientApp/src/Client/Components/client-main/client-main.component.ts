import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-main',
  templateUrl: './client-main.component.html',
  styleUrls: ['./client-main.component.css']
})
export class ClientMainComponent implements OnInit {
  IsSubdomain: boolean = false;

  constructor() {
  }

  ngOnInit(): void {
    this.IsSubdomain = window.location.hostname.split(".")[0] !== window.location.hostname;
    console.log(window.location.hostname.split(".")[0]);
    console.log(window.location.hostname);
  }

}
