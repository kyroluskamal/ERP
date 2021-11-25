import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { StorageMap } from '@ngx-pwa/local-storage';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { DialogHandlerService } from 'src/CommonServices/DialogHandler/dialog-handler.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from '../../../CommonServices/translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class IsLoggedInGuard implements CanActivate {
  constructor(
    private router: Router, private dialogHandler: DialogHandlerService, private Notifications: NotificationsService,
    public Constants: ConstantsService, private translate: TranslationService, private IndexedBd: StorageMap) { }
  IsLoggedIn: boolean = false;
  SessionStorageUser: boolean = false;
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.IndexedBd.get(this.Constants.Client).subscribe(r => console.log(r));
    if (localStorage.getItem(this.Constants.Client) || sessionStorage.getItem(this.Constants.Client)) {
      return true;
    }
    this.dialogHandler.OpenClientLoginDialog();
    this.Notifications.error(this.translate.GetTranslation(this.Constants.NotLoggedInUser), "",
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? "rtl" : "ltr");
    this.router.navigate(['/']);
    return false;
  }

}
