import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
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

  refillForm(object: any, formGroup: FormGroup) {
    console.log(object);
    let keys = Object.keys(object);
    for (let k of keys) {
      if (formGroup.get(k))
        formGroup.get(k)?.setValue(object[k]);
    }
  }
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
  isEqual(ObjectToCompare: any, ObjectToCompareWith: any): boolean {
    let keys = Object.keys(ObjectToCompare);
    for (let k of keys) {
      if (k === "subdomain" || k === "Subdomain" || k === 'id' || k === "id") continue
      else {
        if (ObjectToCompare[k] !== ObjectToCompareWith[k]) {
          return false
        }
      }
    }
    return true
  }
  isUpdated(object: any, formGroup: FormGroup): boolean {
    let formControls: string[] = Object.keys(formGroup.controls);
    for (let c of formControls) {
      if (object[c] !== formGroup.get(c)?.value)
        return false
    }
    return true
  }
  FillObjectFromForm(object: any, formGroup: FormGroup) {
    console.log(object);
    console.log(formGroup);
    let formControls: string[] = Object.keys(formGroup.controls);
    let objectKeys: string[] = Object.keys(object);

    for (let c of objectKeys) {
      if (formControls.includes(c)) {

        if (typeof object[c] === 'number') {
          let x: number = Number(formGroup.get(c)?.value)
          if (isNaN(Number(formGroup.get(c)?.value)))
            x = 0
          object[c] = x;
        }
        else if (typeof object[c] === 'boolean')
          object[c] = Boolean(formGroup.get(c)?.value);
        else if (typeof object[c] === 'string')
          object[c] = formGroup.get(c)?.value === "" ? null : formGroup.get(c)?.value;
        else object[c] = formGroup.get(c)?.value;
      }
    }
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
  convertDataURIToBinary(dataURI: any) {
    var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
    var base64 = dataURI.substring(base64Index);
    var raw = window.atob(base64);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));

    for (let i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array;
  }
}
