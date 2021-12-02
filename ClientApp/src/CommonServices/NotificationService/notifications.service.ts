import { Direction } from '@angular/cdk/bidi';
import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  constructor(public SnackBar: MatSnackBar) { }

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

}
