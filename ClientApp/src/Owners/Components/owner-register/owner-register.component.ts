import { Component, OnInit } from '@angular/core';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnersAuthenticationService } from '../../Services/owners-authentication.service';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent implements OnInit {

  constructor(private OwnerAuth: OwnersAuthenticationService) { }

  OwnerRegisterModel: OwnerRegister = new OwnerRegister();
  owner: any = null;
  ngOnInit(): void {
  }

  OnRegisterClick(event: any) {
    this.OwnerAuth.OwnerRegister(this.OwnerRegisterModel).subscribe(
      (response)=>{
        response = this.owner;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
