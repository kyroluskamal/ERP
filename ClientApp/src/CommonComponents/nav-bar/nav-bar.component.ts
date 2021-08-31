import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor( public dialog: MatDialog /*, public dilogConfig: MatDialogConfig*/, public bottomSheet: MatBottomSheet) { }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
  }

  OnLoginClick() {
    this.dialog.open(LoginComponent);
  }
}
