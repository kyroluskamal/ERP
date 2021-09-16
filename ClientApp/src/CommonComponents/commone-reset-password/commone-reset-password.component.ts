import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ClientAccountService } from '../../Client/Services/Authentication/client-account-service.service';
import { DialogHandlerService } from '../../CommonServices/DialogHandler/dialog-handler.service';
import { Constants } from '../../Helpers/constants';
import { OwnerAccountService } from '../../Owners/Services/Authentication/Owner-account-service.service';

@Component({
  selector: 'app-commone-reset-password',
  templateUrl: './commone-reset-password.component.html',
  styleUrls: ['./commone-reset-password.component.css']
})
export class CommoneResetPasswordComponent implements OnInit {

  //constructor
  constructor(private router: Router, public ClientAccountService: ClientAccountService,
    public OwnerAccountService: OwnerAccountService, public dialogHandler: DialogHandlerService,
    private route: ActivatedRoute) {
  }

  //ngOnInit
  ngOnInit(): void {
    const email = this.route.snapshot.queryParamMap.get(Constants.email);
    const token = this.route.snapshot.queryParamMap.get(Constants.token);
    if (email && token) {
      this.route.url.subscribe(
        (response) => {
          if (response[0].path === Constants.Owner) {
            this.dialogHandler.OpenOwnerResetPassword();
          } else if (response[0].path === Constants.Client) {
            this.dialogHandler.OpenClientResetPassword();
          }
        }
      );
    } else {
      this.router.navigateByUrl("/");
    }
    
  }

}
