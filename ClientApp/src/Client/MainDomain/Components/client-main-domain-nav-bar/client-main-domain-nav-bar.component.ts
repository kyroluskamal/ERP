import { Component, Input, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';

@Component({
  selector: 'app-client-main-domain-nav-bar',
  templateUrl: './client-main-domain-nav-bar.component.html',
  styleUrls: ['./client-main-domain-nav-bar.component.css']
})
export class ClientMainDomainNavBarComponent implements OnInit {

  constructor(public dialogHandler: DialogHandlerService, public bottomSheet: MatBottomSheet) { }

  @Input("apptitle") title: string = "";
  ngOnInit(): void {
  }

  OnLoginClick() {
    this.dialogHandler.OpenClientLoginDialog();
  }
  OnRegisterlick() {
    this.dialogHandler.OpenClientRegisterDialog();
  }

}
