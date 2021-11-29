import { Component, OnInit } from '@angular/core';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';

@Component({
  selector: 'app-items-component',
  templateUrl: './items-component.component.html',
  styleUrls: ['./items-component.component.css']
})
export class ItemsComponentComponent implements OnInit {

  constructor(private ClientAccountService: ClientAccountService) {
    this.ClientAccountService.currentUserOvservable.subscribe(
      r => console.log(r)
    );
  }

  ngOnInit(): void {
  }

}
