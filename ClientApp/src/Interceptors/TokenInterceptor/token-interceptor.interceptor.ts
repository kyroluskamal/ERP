import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { OwnerAccountService } from '../../Owners/Services/Authentication/Owner-account-service.service';
import { take } from 'rxjs/operators';
import { OwnerWithToken } from '../../Owners/Models/owner-with-token.model';
import { ClientWithToken } from '../../Client/Models/client-with-token.model';
import { ClientAccountService } from '../../Client/MainDomain/Authentication/client-account-service.service';

@Injectable()
export class TokenInterceptorInterceptor implements HttpInterceptor {

  constructor(private OwnerAccountService: OwnerAccountService,
    private ClientAccountService: ClientAccountService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let owner: OwnerWithToken = new OwnerWithToken();
    let client: ClientWithToken = new ClientWithToken();

    this.OwnerAccountService.currentUserOvservable.pipe(take(1)).subscribe(user => owner = user);
    if (owner) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${owner.token}`
        }
      })
    }
    this.ClientAccountService.currentUserOvservable.pipe(take(1)).subscribe(user => client = user);
    if (client) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${client.token}`
        }
      })
    }
    return next.handle(request);
  }
}
