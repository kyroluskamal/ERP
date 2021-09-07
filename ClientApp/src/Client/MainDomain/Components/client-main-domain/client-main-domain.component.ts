import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-client-main-domain',
  templateUrl: './client-main-domain.component.html',
  styleUrls: ['./client-main-domain.component.css']
})
export class ClientMainDomainComponent implements OnInit {
  @Input("apptitle") title: string = "";
  notFound: boolean = false;
  CurrentUrl: string = "";
  constructor(private location: Location) {
    this.CurrentUrl = this.location.path();
  }

  ngOnInit(): void {
    if (this.CurrentUrl.includes("/not-found")) this.notFound = true;
    else this.notFound = false;
  }

}
