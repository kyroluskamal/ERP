import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { NotificationsService } from '../../CommonServices/NotificationService/notifications.service';
import { DialogHandlerService } from '../../CommonServices/DialogHandler/dialog-handler.service';
@Injectable()
export class ErrorHandlingInterceptor implements HttpInterceptor {
  
  constructor(private router: Router, private Notification: NotificationsService,
    private dialogHandler: DialogHandlerService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          const modalStateErrors = [];
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStateErrors.push(error.error.errors[key]);
                  }
                }
                this.Notification.error("Please correct the errors and try agaid", error.status);
                throw modalStateErrors.flat();
              } else if (error.error) {
                if (Array.isArray(error.error)) {
                  for (let i = 0; i < error.error.length; i++) {
                    if (error.error[i].description) {
                      modalStateErrors.push(error.error[i].description);
                    }
                  }
                } else {
                  modalStateErrors.push(error.error);
                  this.Notification.error(error.error, error.status);
                  throw modalStateErrors.flat();
                }
                this.Notification.error("Please correct the errors and try agaid", error.status);
                throw modalStateErrors.flat();

              } else {
                this.Notification.error(error.statusText, error.status);
              }
              break;
            case 401:
              modalStateErrors.push(error.error);
              this.Notification.error(error.error, error.status);
              throw modalStateErrors.flat();
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras: NavigationExtras = { state: { error: error.error } }
              this.dialogHandler.CloseDialog();
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default:
              this.Notification.error('Something unexpected went wrong', "");
              break;
          }
        }
        return throwError(error);
      })
    )
  }
}
