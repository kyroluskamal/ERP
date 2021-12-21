import { Direction } from '@angular/cdk/bidi';
import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
import { SweetAlertData, ThemeColor } from 'src/Interfaces/interfaces';
import Swal, { SweetAlertCustomClass } from 'sweetalert2';
import { ConstantsService } from '../constants.service';
import { TranslationService } from '../translation-service.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  ThemeColorSubscription: Subscription;

  constructor(public SnackBar: MatSnackBar, private Constants: ConstantsService,
    private LightOrDarkConverter: LightDarkThemeConverterService) {
    let x: any = localStorage.getItem(this.Constants.ChoosenThemeColors)
    x = JSON.parse(x);
    this.ThemeColors = x;
    this.ThemeColorSubscription = this.LightOrDarkConverter.ThemeColors$.subscribe(
      x => {
        this.ThemeColors = x;
      }
    );
  }

  error(message: string, errorStatus: string, direction: any) {
    this.SnackBar.open(message, "✖", {
      duration: 5000,
      direction: direction,
      horizontalPosition: "right",
      verticalPosition: "bottom",
      panelClass: "Error-Notification",
      data: { message, errorStatus }
    });
  }

  success(message: string, direction: any) {
    this.SnackBar.open(message, "✖", {
      duration: 5000,
      direction: direction,
      horizontalPosition: "right",
      verticalPosition: "bottom",
      panelClass: "Success-Notification",
      data: { message }
    });
  }

  Error_Swal(title: string, confirmText: string, message: string, direction: string) {
    return Swal.fire({
      title: title,
      icon: "error",
      html: message,
      color: "black",
      showCancelButton: false,
      showConfirmButton: true,
      confirmButtonText: confirmText,
      allowEnterKey: true,
      allowEscapeKey: true,
      allowOutsideClick: true,
      customClass: { container: direction, title: this.Constants.CSS_SwalErrorTitle },
      confirmButtonColor: this.ThemeColors.value
    })
  }
  Success_Swal(message: string, direction: string) {
    return Swal.fire({
      icon: "success",
      html: message,
      color: "black",
      showCancelButton: false,
      showConfirmButton: false,
      allowEnterKey: true,
      allowEscapeKey: true,
      allowOutsideClick: true,
      scrollbarPadding: false,
      timer: 2000,
      customClass: { container: direction, htmlContainer: "SwalHtmlContent" },
      confirmButtonColor: this.ThemeColors.value
    })
  }

  Custom_Swal(title: string, SwalConfig: SweetAlertData) {
    return Swal.fire({
      title: title,
      icon: SwalConfig.OtherOptions.icon,
      iconColor: SwalConfig.OtherOptions.iconColor,
      iconHtml: SwalConfig.OtherOptions.iconHtml,
      text: SwalConfig.OtherOptions.text,
      html: SwalConfig.OtherOptions.html,
      color: "black",
      showCancelButton: SwalConfig.OtherOptions.showCancelButton,
      cancelButtonColor: SwalConfig.OtherOptions.cancelButtonColor,
      cancelButtonText: SwalConfig.OtherOptions.cancelButtonText,
      showConfirmButton: SwalConfig.OtherOptions.showConfirmButton,
      confirmButtonText: SwalConfig.OtherOptions.confirmButtonText,
      confirmButtonColor: this.ThemeColors.value,
      allowEnterKey: SwalConfig.OtherOptions.allowEnterKey,
      allowEscapeKey: SwalConfig.OtherOptions.allowEscapeKey,
      allowOutsideClick: SwalConfig.OtherOptions.allowOutsideClick,
      showLoaderOnConfirm: SwalConfig.OtherOptions.showLoaderOnConfirm,
      showLoaderOnDeny: SwalConfig.OtherOptions.showLoaderOnDeny,
      timer: SwalConfig.OtherOptions.timer,
      customClass: { container: SwalConfig.direction, title: SwalConfig.OtherOptions.customClass?.title }
    })
  }
}
