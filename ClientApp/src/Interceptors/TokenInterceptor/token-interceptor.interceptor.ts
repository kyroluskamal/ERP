import { Injectable } from '@angular/core';
import
  {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
  } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { OwnerAccountService } from '../../Owners/Services/Authentication/Owner-account-service.service';
import { take } from 'rxjs/operators';
import { OwnerWithToken } from '../../Owners/Models/owner-with-token.model';
import { ClientAccountService } from '../../Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
@Injectable()
export class TokenInterceptorInterceptor implements HttpInterceptor
{
  Client: any;
  Owner: any;
  constructor(private OwnerAccountService: OwnerAccountService,
    private ClientAccountService: ClientAccountService, private Constants: ConstantsService)
  {
    this.Owner = localStorage.getItem(this.Constants.Owner);
    if (this.Owner)
      this.Owner = JSON.parse(this.Owner);
    this.Client = localStorage.getItem(this.Constants.Client);
    if (this.Client)
      this.Client = JSON.parse(this.Client);
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>>
  {
    if (this.Owner)
    {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer 5V4fqC2YbK${this.Owner.token}`
        }
      });
    }
    if (this.Client)
    {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer 5V4fqC2YbK${this.Client.token}`
        }
      });
    }
    return next.handle(request);
  }
}
