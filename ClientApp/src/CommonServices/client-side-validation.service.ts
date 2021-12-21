import { Injectable } from '@angular/core';
import { SweetAlertData } from 'src/Interfaces/interfaces';
import { SweetAlertOptions } from 'sweetalert2';
import { ConstantsService } from './constants.service';
import { NotificationsService } from './NotificationService/notifications.service';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class ClientSideValidationService {

  constructor(private NotificationService: NotificationsService, private Constants: ConstantsService,
    private translate: TranslationService) { }

  isUnique(array: any[], keyToCheck: string, value: string, id?: number) {
    if (!id) {
      for (let el of array) {
        if (el[keyToCheck])
          if (el[keyToCheck] === value) {
            return false
          }
      }
    } else {
      for (let el of array) {
        if (el[keyToCheck] && el['id'] !== id)
          if (el[keyToCheck] === value) {
            return false
          }
      }
    }
    return true;
  }

  notUniqueNotification(keyToCheck: string) {
    this.NotificationService.error(`( ${this.translate.GetTranslation(keyToCheck.toLowerCase())} )
          ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR)}`, ' ',
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
  }
  notUniqueNotification_Swal(keyToCheck: string) {
    this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}:`,
      this.translate.GetTranslation(this.Constants.OK), `<strong>( ${this.translate.GetTranslation(keyToCheck.toLowerCase())} )</strong>
    ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR)}`,
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
  }
  Warning(message: string) {
    let swalData: SweetAlertData = {
      OtherOptions: {
        icon: "warning",
        text: message,
        html: message,
        showCancelButton: true,
        showConfirmButton: true,
        cancelButtonText: this.translate.GetTranslation(this.Constants.cancel),
        confirmButtonText: this.translate.GetTranslation(this.Constants.confirm),
        allowEnterKey: true,
        allowEscapeKey: true,
        allowOutsideClick: true,
        showLoaderOnConfirm: true,
        customClass: { title: this.Constants.CSS_SwalWarningTitle }
      },
      direction: this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr'
    }
    return this.NotificationService.Custom_Swal(this.translate.GetTranslation(this.Constants.warning), swalData)
  }

  Error_swal(message: string) {
    return this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}:`,
      this.translate.GetTranslation(this.Constants.OK), this.translate.GetTranslation(message),
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
  }
}
