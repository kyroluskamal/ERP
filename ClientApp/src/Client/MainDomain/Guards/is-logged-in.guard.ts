import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';

@Injectable({
  providedIn: 'root'
})
export class IsLoggedInGuard implements CanActivate {
  constructor(
    private router: Router, private dialogHandler: DialogHandlerService, private Notifications: NotificationsService,
    public Constants: ConstantsService) { }
  IsLoggedIn: boolean = false;
  SessionStorageUser: boolean = false;
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (localStorage.getItem(this.Constants.Client)) {
      return true;
    } else if (sessionStorage.getItem(this.Constants.Client)) {
      return true;
    }
    this.dialogHandler.OpenClientLoginDialog();
    this.Notifications.error(this.Constants.NotLoggedInUser, "");
    this.router.navigate(['/']);
    return false;
  }

}
