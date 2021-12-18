import { Injectable } from '@angular/core';
import { MaxMinLengthValidation } from 'src/Interfaces/interfaces';
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
  GeneralSuccessResponse(SuncessResponse: any) {
    console.log(SuncessResponse);
    this.NotificationService.success(this.translate.GetTranslation(SuncessResponse.status),
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }

  GetErrorNotification(e: any, MaxMinLenth: MaxMinLengthValidation[] = []) {
    let translatedError: string = "";
    if (Array.isArray(e)) {
      if (typeof (e[0].status) === "string")
        translatedError += `${this.translate.GetTranslation(e[0].status)} `;
      if (e[0].errors) {
        let keys = Object.keys(e[0].errors);
        for (let k of keys) {
          for (let err of e[0].errors[k]) {
            if (err === this.Constants.MaxLengthExceeded_ERROR) {
              let maxLength = MaxMinLenth.filter((i) => { return i.prop.toLowerCase() === k.toLowerCase() });
              translatedError += `( ${this.translate.GetTranslation(k.toLowerCase())} ) ${this.translate.GetTranslation(err)} ${maxLength[0].maxLength}
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
