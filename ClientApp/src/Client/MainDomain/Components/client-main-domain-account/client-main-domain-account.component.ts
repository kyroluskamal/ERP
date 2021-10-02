import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';


@Component({
  selector: 'app-client-main-domain-account',
  templateUrl: './client-main-domain-account.component.html',
  styleUrls: ['./client-main-domain-account.component.css']
})
export class ClientMainDomainAccountComponent implements OnInit {

  constructor(public Constants: ConstantsService) { }

  ngOnInit(): void {

  }

}
