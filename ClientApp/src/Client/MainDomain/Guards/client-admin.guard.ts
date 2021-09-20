import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { Constants } from '../../../Helpers/constants';
import { ClientAccountService } from '../Authentication/client-account-service.service';
@Injectable({
  providedIn: 'root'
})
export class ClientAdminGuard implements CanActivate {
  constructor(private accountService: ClientAccountService, private Notifications: NotificationsService,
    private router: Router, private dialogHandler:DialogHandlerService, private location: Location) { }
  canActivate(
    route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree >
  {
    if (!localStorage.getItem(Constants.Client) && !sessionStorage.getItem(Constants.Client)) {
      this.router.navigateByUrl("/");
      this.dialogHandler.OpenClientLoginDialog();
      this.Notifications.error(Constants.NotLoggedInUser, "");
    }
    return this.accountService.currentUserOvservable.pipe(
      map(user => {
        const temp: any = user;
        user = JSON.parse(temp);
        for (let role of user.roles) {
          if (role == Constants.Admin_Role) return true
        }
        this.Notifications.error(Constants.UnAuthorizedAdmin, "");
        return false
      })
    );
  }
  
}
