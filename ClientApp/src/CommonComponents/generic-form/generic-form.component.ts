import { AfterViewInit, Component, ComponentFactoryResolver, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, Type } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CardTitle, FormDefs, SelectedDataTransfer, ThemeColor } from 'src/Interfaces/interfaces';

import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { ComponentType } from '@angular/cdk/portal';

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
  temp: any[] = [];
  @Input() Form: FormDefs = new FormDefs();
  @Input() Title: CardTitle[] = [];
  @Input() AllSelectedData: SelectedDataTransfer[] = [];
  @Output() GetValue: EventEmitter<FormDefs> = new EventEmitter();
  constructor(
    public Constants: ConstantsService, private componentFactoryResolver: ComponentFactoryResolver,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, private bottomSheet: MatBottomSheet
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
    this.FormSpec = this.Form;
  }
  ngAfterViewInit(): void {
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes["Form"]) {
      this.FormSpec = this.Form;
      console.log(this.FormSpec)
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

  OpenButtomSheet(component: ComponentType<unknown>) {
    this.bottomSheet.open(component);
  }
  Search(value: string, PropertyToSearch: string) {
    let tempData = this.AllSelectedData.filter(x => { return x.property === PropertyToSearch })[0].SelectedData;
    let filteredData = tempData.filter(x => { return x[PropertyToSearch].toLowerCase().includes(value.toLowerCase()) })
    for (let field of this.FormSpec.formFieldsSpec) {
      if (field.SelectData) {
        if (field.PropertyNameToShowInSelection === PropertyToSearch) {
          if (value !== "")
            field.SelectData = [...filteredData];
          else if (value === "") {
            field.SelectData = [...tempData]
          }
        }
      }
    }
  }
}
