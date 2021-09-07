import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  constructor(public SnackBar: MatSnackBar) { }

  error(message: string, errorStatus:string, button: string) {
    this.SnackBar.open(message, button, {
      duration: 5000,
      horizontalPosition: "right",
      verticalPosition: "bottom",
      panelClass: "Error-Notification",
      data: {message, errorStatus}
    });
  }
}
