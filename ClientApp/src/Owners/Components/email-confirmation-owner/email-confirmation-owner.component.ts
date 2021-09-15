import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmailConfirmationModel } from '../../../Client/Models/email-confirmation-model.model';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from '../../../Helpers/constants';
import { OwnerAccountService } from '../../Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-email-confirmation-owner',
  templateUrl: './email-confirmation-owner.component.html',
  styleUrls: ['./email-confirmation-owner.component.css']
})
export class EmailConfirmationOwnerComponent implements OnInit {

  //properties
  EmailConfirmationModel: EmailConfirmationModel = new EmailConfirmationModel();
  Success: boolean = false;
  Fail: boolean = false;
  Error: any;
  //constructor
  constructor(private route: ActivatedRoute, private router: Router,
    private accountService: OwnerAccountService, public dialogHandler: DialogHandlerService) {
  }
  //ngOnInit
  ngOnInit(): void {
    const email = this.route.snapshot.queryParamMap.get(Constants.email);
    const token = this.route.snapshot.queryParamMap.get(Constants.token);
    if (email && token) {
      this.EmailConfirmationModel = { email: email, token: token }
      console.log(this.EmailConfirmationModel);
      this.emailConfirmation(this.EmailConfirmationModel);
    } else {
      this.router.navigateByUrl("/");
    }
  }

  emailConfirmation(emailConfimationModel: EmailConfirmationModel) {
    this.accountService.confirmEmail(emailConfimationModel).subscribe(
      (Response: any) => { this.Success = true },
      (error: any) => { this.Fail = true; this.Error = error[0].error; console.log(error) }
    );
  }
}
