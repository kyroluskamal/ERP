import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Constants } from '../../../Helpers/constants';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-owner-main',
  templateUrl: './owner-main.component.html',
  styleUrls: ['./owner-main.component.css']
})
export class OwnerMainComponent implements OnInit {


  constructor(private OwnerAccountService : OwnerAccountService) {
  }

  ngOnInit(): void {
    this.SetOwnerUser();
  }
  SetOwnerUser() {
    if (localStorage.getItem(Constants.Owner)) {
      const user: any = localStorage.getItem(Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(Constants.Owner)) {
      const user: any = sessionStorage.getItem(Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    }
  }
}
