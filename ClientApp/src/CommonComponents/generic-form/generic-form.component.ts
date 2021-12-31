import { AfterViewInit, Component, ComponentFactoryResolver, EventEmitter, Inject, Input, LOCALE_ID, OnChanges, OnInit, Output, SimpleChanges, Type } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CardTitle, FormDefs, MatBottomSheetDismissData, SelectedDataTransfer, ThemeColor } from 'src/Interfaces/interfaces';
import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { ComponentType } from '@angular/cdk/portal';
import { FormControl } from '@angular/forms';

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
  oneFileName: string = "";
  @Input() Form: FormDefs = new FormDefs();
  @Input() Title: CardTitle[] = [];
  @Input() AllSelectedData: SelectedDataTransfer[] = [];
  @Input() showCloseButton: boolean = false;
  @Output() GetValue: EventEmitter<FormDefs> = new EventEmitter();
  @Output() BottomSheetDismissed: EventEmitter<boolean> = new EventEmitter();

  constructor(private _bottomSheetRef: MatBottomSheetRef<any>,
    public Constants: ConstantsService, private componentFactoryResolver: ComponentFactoryResolver,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, private bottomSheet: MatBottomSheet
  ) {
    console.log(this.Form)
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
  Search(event: any, PropertyToSearch: string) {
    console.log(event.target.value)
    let tempData = this.AllSelectedData.filter(x => { return x.property === PropertyToSearch })[0].SelectedData;
    let filteredData = tempData.filter(x => { return x[PropertyToSearch].toLowerCase().includes(event.target.value.toLowerCase()) })
    for (let section of this.FormSpec.formSections) {
      for (let field of section.formFieldsSpec) {
        if (field.SelectData) {
          if (field.PropertyNameToShowInSelection === PropertyToSearch) {
            if (event.target.value !== "")
              field.SelectData = [...filteredData];
            else if (event.target.value === "") {
              field.SelectData = [...tempData]
            }
          }
        }
      }
    }
  }
  BottomSheetDismiss() {
    this.BottomSheetDismissed.emit(true);
  }
  onFileSelected(event: any, formContolName: string) {
    let file: File = event.target.files[0];
    console.log(formContolName);
    this.oneFileName = file.name;
    const reader = new FileReader();
    reader.onload = (e: any) => {
      const bytes = e.target.result;
      this.FormSpec.form.get(formContolName)?.setValue(bytes);
    };
    reader.readAsDataURL(file);
    // var fileByteArray: any[] = [];
    // reader.readAsArrayBuffer(file);
    // reader.onloadend = (evt: any) => {
    //   if (evt.target.readyState == FileReader.DONE) {
    //     var arrayBuffer = evt.target.result;
    //     let array = new Uint8Array(arrayBuffer);
    //     for (var i = 0; i < array.length; i++) {
    //       fileByteArray.push(array[i]);
    //     }
    //     console.log(fileByteArray)
    //     this.FormSpec.form.get(formContolName)?.setValue(fileByteArray);
    //   }
    // }
  }
}
