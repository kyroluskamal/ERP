import { Component, Inject, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ThemeColor } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'

import { MatTableDataSource } from '@angular/material/table';
import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
@Component({
  selector: 'mat-card-title-only',
  templateUrl: './mat-card-title-only.component.html',
  styleUrls: ['./mat-card-title-only.component.css']
})
export class MatCardTitleOnlyComponent implements OnInit {

  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  LangSubscibtion: Subscription = new Subscription();

  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  DarkOrLight: string = "";
  Theme_dir: 'rtl' | 'ltr';
  @Input() Title: string = "";
  @Input() Subtitle: string = "";
  constructor(
    public Constants: ConstantsService,
    public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService,
  ) {

    let tem: any = localStorage.getItem(this.Constants.BodyAppeareance);
    this.DarkOrLight = tem;

    let x: any = localStorage.getItem(this.Constants.ChoosenThemeColors)
    x = JSON.parse(x);
    this.ThemeColors = x;
    this.ThemeSubscription = this.LightOrDarkConverter.CurrentThemeClass$.subscribe(x => { this.DarkOrLight = x; });
    this.ThemeColorSubscription = this.LightOrDarkConverter.ThemeColors$.subscribe(
      x => {
        this.ThemeColors = x;
      }
    );

    let themeDir: any = localStorage.getItem(this.Constants.dir);
    this.Theme_dir = themeDir;
    this.ThemeDirection = this.LightOrDarkConverter.ThemeDir$.subscribe(
      r => this.Theme_dir = r
    );

  }

  ngOnInit(): void {
  }

}
