import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ClientAccountService } from '../Authentication/client-account-service.service';

@Injectable({
  providedIn: 'root'
})
export class IsNullTenantGuard implements CanActivate {
  constructor(private accountservice: ClientAccountService) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.accountservice.IsTenantFound(window.location.hostname.split('.')[0]).subscribe({
      next: r => {
        return true;
      },
      error: error => {
        console.log(error);
        if (error != null) {
          window.location.href = window.location.protocol + "//" + (window.location.hostname.split(".").length > 1) ? window.location.hostname.split(".")[1] : window.location.hostname.split(".")[0] + ":" + window.location.port;
          return false;
        }
        return true;
      }
    });
    return true;
  }

}
