import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CardTitle, KeyValueForUniqueCheck, SweetAlertData } from 'src/Interfaces/interfaces';
import { ConstantsService } from './constants.service';
import { NotificationsService } from './NotificationService/notifications.service';
import { TranslationService } from './translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class ClientSideValidationService
{

  constructor(private NotificationService: NotificationsService, private Constants: ConstantsService,
    private translate: TranslationService) { }

  refillForm(object: any, formGroup: FormGroup)
  {
    let keys = Object.keys(object);
    for (let k of keys)
    {
      if (formGroup.get(k))
        formGroup.get(k)?.setValue(object[k]);
    }
  }
  isUnique(array: any[], keyToCheck: string, value: string, id?: number)
  {
    if (!id)
    {
      for (let el of array)
      {
        if (el[keyToCheck])
          if (el[keyToCheck] === value)
          {
            return false;
          }
      }
    } else
    {
      for (let el of array)
      {
        if (el[keyToCheck] && el['id'] !== id)
          if (el[keyToCheck] === value)
          {
            return false;
          }
      }
    }
    return true;
  }

  isUniqueMany(array: any[], keyValue: KeyValueForUniqueCheck[], id?: number)
  {
    let translatedMessage = "";
    let notUnique: boolean = false;
    for (let k of keyValue)
    {
      if (!this.isUnique(array, k.key, k.value, id))
      {
        translatedMessage += `<strong>( ${this.translate.GetTranslation(k.key.toLowerCase())} )</strong>
      ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR.toLowerCase())}<br/>`;
        notUnique = true;
      }
    }
    if (notUnique)

      this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}:`,
        this.translate.GetTranslation(this.Constants.OK), translatedMessage,
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
    return notUnique;
  }
  isEqual(ObjectToCompare: any, ObjectToCompareWith: any): boolean
  {
    let keys = Object.keys(ObjectToCompare);
    for (let k of keys)
    {
      if (k === "subdomain" || k === "Subdomain" || k === 'id' || k === "id") continue;
      else
      {
        if (ObjectToCompare[k] !== ObjectToCompareWith[k])
        {
          return false;
        }
      }
    }
    return true;
  }
  isUpdated(object: any, formGroup: FormGroup): boolean
  {
    let objectKeys: string[] = Object.keys(object);
    for (let k of objectKeys)
    {
      if (formGroup.get(k)?.value || formGroup.get(k)?.value === '')
        if (object[k] !== formGroup.get(k)?.value)
        {
          return true;
        }
    }
    return false;
  }
  FillObjectFromForm(object: any, formGroup: FormGroup)
  {
    let formControls: string[] = Object.keys(formGroup.controls);
    let objectKeys: string[] = Object.keys(object);

    for (let c of objectKeys)
    {
      if (formControls.includes(c))
      {

        if (typeof object[c] === 'number')
        {
          let x: number = Number(formGroup.get(c)?.value);
          if (isNaN(Number(formGroup.get(c)?.value)))
            x = 0;
          object[c] = x;
        }
        else if (typeof object[c] === 'boolean')
          object[c] = Boolean(formGroup.get(c)?.value);
        else if (typeof object[c] === 'string')
          object[c] = formGroup.get(c)?.value;
        else object[c] = formGroup.get(c)?.value;
      }
    }
  }
  notUniqueNotification(keyToCheck: string)
  {
    this.NotificationService.error(`( ${this.translate.GetTranslation(keyToCheck.toLowerCase())} )
          ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR.toLowerCase())}`, ' ',
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
  notUniqueNotification_Swal(keyToCheck: string)
  {
    this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}:`,
      this.translate.GetTranslation(this.Constants.OK), `<strong>( ${this.translate.GetTranslation(keyToCheck.toLowerCase())} )</strong>
    ${this.translate.GetTranslation(this.Constants.Unique_Field_ERROR.toLowerCase())}`,
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }

  GerneralClientSideError_swal(keyToCheck: string, Message: CardTitle[])
  {
    let translatedMessage = "";
    for (let t of Message)
    {
      if (t.needTranslation) translatedMessage += this.translate.GetTranslation(t.text.toLowerCase());
      else translatedMessage += t.text;
    }
    this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}:`,
      this.translate.GetTranslation(this.Constants.OK), `<strong>( ${this.translate.GetTranslation(keyToCheck.toLowerCase())} )</strong>
  ${translatedMessage}`, this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
  Warning(message: string)
  {
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
    };
    return this.NotificationService.Custom_Swal(this.translate.GetTranslation(this.Constants.warning), swalData);
  }

  Error_swal(message: string)
  {
    return this.NotificationService.Error_Swal(`${this.translate.GetTranslation(this.Constants.error)}: `,
      this.translate.GetTranslation(this.Constants.OK), this.translate.GetTranslation(message.toLowerCase()),
      this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
  }
  convertDataURIToBinary(dataURI: any)
  {
    var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
    var base64 = dataURI.substring(base64Index);
    var raw = window.atob(base64);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));

    for (let i = 0; i < rawLength; i++)
    {
      array[i] = raw.charCodeAt(i);
    }
    return array;
  }

  FillObjectFromAnotherObject(ObjectToFill: any, from: any)
  {
    let Keys: string[] = Object.keys(ObjectToFill);
    for (let k of Keys)
    {
      ObjectToFill[k] = from[k];
    }
  }
}
