import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-main',
  templateUrl: './client-main.component.html',
  styleUrls: ['./client-main.component.css']
})
export class ClientMainComponent implements OnInit {
  subdomain: string = "";
  @Input("apptitle") title: string = "";
  constructor() { }

  ngOnInit(): void {
    this.subdomain = window.location.href.split("kherp.com")[0].split("https://")[1].split(".")[0];
  }

}
