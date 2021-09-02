import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { OwnersLoginComponent } from '../../Owners/Components/owners-login/owners-login.component';
import { RegisterComponent } from '../register/register.component';
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
    this.dialog.open(OwnersLoginComponent);
  }
  OnRegisterlick() {
    this.dialog.open(RegisterComponent);
  }
}
