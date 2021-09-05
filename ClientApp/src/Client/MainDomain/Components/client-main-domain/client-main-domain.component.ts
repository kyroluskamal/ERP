import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-main-domain',
  templateUrl: './client-main-domain.component.html',
  styleUrls: ['./client-main-domain.component.css']
})
export class ClientMainDomainComponent implements OnInit {
  @Input("apptitle") title: string = "";
  constructor() { }

  ngOnInit(): void {
  }

}
