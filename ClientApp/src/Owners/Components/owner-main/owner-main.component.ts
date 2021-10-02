import { Component, Input, OnInit } from '@angular/core';
import { ConstantsService } from '../../../CommonServices/constants.service';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-owner-main',
  templateUrl: './owner-main.component.html',
  styleUrls: ['./owner-main.component.css']
})
export class OwnerMainComponent implements OnInit {


  constructor(private OwnerAccountService: OwnerAccountService, public Constants: ConstantsService) {
  }

  ngOnInit(): void {
    this.SetOwnerUser();
  }
  SetOwnerUser() {
    if (localStorage.getItem(this.Constants.Owner)) {
      const user: any = localStorage.getItem(this.Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    } else if (sessionStorage.getItem(this.Constants.Owner)) {
      const user: any = sessionStorage.getItem(this.Constants.Owner);
      this.OwnerAccountService.setCurrentUser(user);
    }
  }
}
