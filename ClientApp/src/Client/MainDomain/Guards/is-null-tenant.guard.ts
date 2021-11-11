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
    this.accountservice.IsTenantFound().subscribe({
      error: error => {
        if (error != null) {
          return true;
        }
        return false;
      }
    });
    return false;
  }

}
