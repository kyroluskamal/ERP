import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { DialogHandlerService } from '../../../CommonServices/DialogHandler/dialog-handler.service';
@Component({
  selector: 'app-owner-nav-bar',
  templateUrl: './owner-nav-bar.component.html',
  styleUrls: ['./owner-nav-bar.component.css']
})
export class OwnerNavBarComponent implements OnInit {
  constructor(public dialogHandler: DialogHandlerService, public bottomSheet: MatBottomSheet) { }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
  }

  OnLoginClick() {
    this.dialogHandler.OpenOwnerLoginDialog();
  }
  OnRegisterlick() {
    this.dialogHandler.OpenOwnerRegisterDialog();
  }
}
