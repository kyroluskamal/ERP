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
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
@Injectable()
export class ErrorHandlingInterceptor implements HttpInterceptor {

  current_lang: any;
  constructor(private router: Router, private Notification: NotificationsService,
    private dialogHandler: DialogHandlerService, private Constants: ConstantsService) {
    this.current_lang = localStorage.getItem('lang');
  }
  TempTranslation_Ar(key: string) {
    switch (key) {
      case this.Constants.NullTenant: return this.Constants.NullTenant_errorMessage_Ar;
      case this.Constants.DataAddtionStatus_error: return this.Constants.DataAddtionStatus_Error_Message_Ar;
      case this.Constants.Required_field_Error: return this.Constants.Required_field_Error_Message_Ar;
      case this.Constants.Data_Deleted_ERROR_status: return this.Constants.Data_Deleted_ERROR_Message_Ar;
      case this.Constants.Data_NOTFOUND_ERROR_status: return this.Constants.Data_NOTFOUND_ERROR_Message_Ar;
      case this.Constants.HackTrying_Error: return this.Constants.HackTrying_Error_message_Ar;
      default: return this.Constants.Something_nexpected_went_wrong_Arabic;
    }
  }

  TempTranslation_En(key: string) {
    switch (key) {
      case this.Constants.NullTenant: return this.Constants.NullTenant_errorMessage_En;
      case this.Constants.DataAddtionStatus_error: return this.Constants.DataAddtionStatus_Error_Message_En;
      case this.Constants.Required_field_Error: return this.Constants.Required_field_Error_Message_En;
      case this.Constants.Data_Deleted_ERROR_status: return this.Constants.Data_Deleted_ERROR_Message_En;
      case this.Constants.Data_NOTFOUND_ERROR_status: return this.Constants.Data_NOTFOUND_ERROR_Message_EN;
      case this.Constants.HackTrying_Error: return this.Constants.HackTrying_Error_message_EN;

      default: return this.Constants.Something_nexpected_went_wrong_EN;
    }
  }

  TranslatedError(key: string, lang: any) {
    switch (lang) {
      case "ar": return this.TempTranslation_Ar(key);
      case "en": return this.TempTranslation_En(key);
      default: return "";
    }
  }

  isRightToLeft(lang: any) {
    switch (lang) {
      case 'ar': return true;
      case 'arc': return true;
      case 'dv': return true;
      case 'fa': return true;
      case 'ha': return true;
      case 'he': return true;
      case 'khw': return true;
      case 'ks': return true;
      case 'ku': return true;
      case 'ps': return true;
      case 'ur': return true;
      case 'yi': return true;
      default: return false;
    }
  }
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          const modalStateErrors = [];
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                modalStateErrors.push(error.error);
                // for (const key in error.error.errors) {
                //   if (error.error.errors[key]) {
                //     modalStateErrors.push(error.error.errors[key]);
                //   }
                // }
                this.Notification.error(this.TranslatedError(this.Constants.PleaseCorrectErrors, this.current_lang),
                  error.status, this.isRightToLeft(this.current_lang));
                throw modalStateErrors.flat();
              } else if (error.error) {
                if (Array.isArray(error.error)) {
                  for (let i = 0; i < error.error.length; i++) {
                    if (error.error[i].status) {
                      modalStateErrors.push(error.error[i].status);
                    }
                  }
                } else {
                  modalStateErrors.push(error.error);
                  this.Notification.error(this.TranslatedError(error.error.status, this.current_lang),
                    error.status, this.isRightToLeft(this.current_lang) ? 'rtl' : 'ltr');
                  throw modalStateErrors.flat();
                }
                this.Notification.error(this.TranslatedError(this.Constants.PleaseCorrectErrors, this.current_lang), error.status, this.isRightToLeft(this.current_lang));
                throw modalStateErrors.flat();

              } else {
                this.Notification.error(this.TranslatedError(error.error.status, this.current_lang), error.status, this.isRightToLeft(this.current_lang) ? 'rtl' : 'ltr');
              }
              break;
            case 401:
              modalStateErrors.push(error.error);
              this.Notification.error(error.error.error, error.status, "ltr");
              console.log(error.error.error);
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
              this.Notification.error(this.TranslatedError(this.Constants.Something_nexpected_went_wrong, this.current_lang), "", this.isRightToLeft(this.current_lang));
              break;
          }
        }
        return throwError(() => error);
      })
    )
  }
}
