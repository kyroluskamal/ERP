import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CardTitle, FormDefs, ThemeColor } from 'src/Interfaces/interfaces';

import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';

@Component({
  selector: 'kiko-form',
  templateUrl: './generic-form.component.html',
  styleUrls: ['./generic-form.component.css']
})
export class GenericFormComponent implements OnInit, OnChanges, AfterViewInit {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  DarkOrLight: string = "";
  Theme_dir: 'rtl' | 'ltr';
  loading: boolean = false;
  FormSpec: FormDefs = new FormDefs();

  @Input() Form: FormDefs = new FormDefs();
  @Input() Title: CardTitle[] = [];
  @Output() GetValue: EventEmitter<FormDefs> = new EventEmitter();
  constructor(
    public Constants: ConstantsService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
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
  ngAfterViewInit(): void {
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes["Form"]) {
      this.FormSpec = this.Form;
    }
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
    this.ThemeSubscription.unsubscribe();
    this.ThemeColorSubscription.unsubscribe();

    this.ThemeDirection.unsubscribe();
  }
  ngOnInit(): void {
    this.FormSpec = this.Form;
  }

  SendData() {
    this.GetValue.emit(this.FormSpec);
  }
}
