import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from '../../../CommonServices/NotificationService/notifications.service';
import { ClientAccountService } from '../Authentication/client-account-service.service';
import { ConstantsService } from '../../../CommonServices/constants.service';
import { TranslationService } from '../../../CommonServices/translation-service.service';
@Injectable({
  providedIn: 'root'
})
export class ClientAdminGuard implements CanActivate {
  InLocalStorage: any;
  InSessionStorage: any;
  currentLang = this.translate.GetCurrentLang();
  constructor(private accountService: ClientAccountService, private Notifications: NotificationsService,
    public Constants: ConstantsService, private translate: TranslationService) {
    this.InLocalStorage = localStorage.getItem(this.Constants.Client);
    this.InSessionStorage = sessionStorage.getItem(this.Constants.Client);
  }
  canActivate(
    route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.accountService.currentUserOvservable.pipe(
      map(user => {
        if (user) {
          if (typeof user === "string") {
            user = JSON.parse(user);
          }
          for (let role of user.roles) {
            if (role == this.Constants.Admin_Role) return true
          }
        }
        this.Notifications.error(this.translate.GetTranslation(this.Constants.UnAuthorizedAdmin), "",
          this.translate.isRightToLeft(this.currentLang) ? "rtl" : "ltr");
        return false
      })
    );
    // if (this.InLocalStorage) {
    //   let User = JSON.parse(JSON.stringify(this.InLocalStorage));
    //   for (let role of User.roles) {
    //     if (role === this.Constants.Admin_Role) return true;
    //   }
    // } else if (this.InSessionStorage) {
    //   let User = JSON.parse(JSON.stringify(this.InSessionStorage));
    //   for (let role of User.roles) {
    //     if (role === this.Constants.Admin_Role) return true;
    //   }
    // }
    // this.Notifications.error(this.Constants.UnAuthorizedAdmin, "");
    // return false

  }

}
