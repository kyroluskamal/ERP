import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { NotificationsService } from './NotificationService/notifications.service';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class ServerResponseHandelerService {

  constructor(private translate: TranslationService, private Constants: ConstantsService,
    private NotificationService: NotificationsService) { }

  DatatAddition_Success() {
    this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
  Data_Updaed_Success() {
    this.NotificationService.success(this.translate.GetTranslation(this.Constants.Data_SAVED_success_status),
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
  GetErrorNotification(e: any, maxLength: number = 30) {
    let translatedError: string = "";
    if (Array.isArray(e)) {
      if (typeof (e[0].status) === "string")
        translatedError += `${this.translate.GetTranslation(e[0].status)} `;
      if (e[0].errors) {
        let keys = Object.keys(e[0].errors);
        for (let k of keys) {
          for (let err of e[0].errors[k]) {
            if (err === this.Constants.MaxLengthExceeded_ERROR) {
              translatedError += `( ${this.translate.GetTranslation(k.toLowerCase())} ) ${this.translate.GetTranslation(err)} ${maxLength}
              ${this.translate.GetTranslation(this.Constants.characters)} `;
            } else
              translatedError += `( ${this.translate.GetTranslation(k.toLowerCase())} ) ${this.translate.GetTranslation(err)} `
          }
        }
      }
    } else if (e.error.status)
      translatedError += `${this.translate.GetTranslation(e.error.status)} `;

    else if (e.status === 401 && e.error === null) {
      translatedError += `${this.translate.GetTranslation(this.Constants.Unauthorized_Error)} `;
    }
    this.NotificationService.error(translatedError, '',
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
}
