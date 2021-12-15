import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { NotificationsService } from './NotificationService/notifications.service';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class ClientSideValidationService {

  constructor(private NotificationService: NotificationsService, private Constants: ConstantsService,
    private translate: TranslationService) { }

  isUnique(array: any[], keyToCheck: string, value: string) {
    for (let el of array) {
      console.log(el[keyToCheck]);
      if (el[keyToCheck])
        if (el[keyToCheck] === value) {

          return false
        }
    }
    return true;
  }
  notUniqueNotification(keyToCheck: string) {
    this.NotificationService.error(`( ${this.translate.GetTranslation(keyToCheck)} )
          ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR)}`, ' ',
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
  }

}
