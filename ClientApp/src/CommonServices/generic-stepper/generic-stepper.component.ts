import { BreakpointObserver } from '@angular/cdk/layout';
import { StepperOrientation } from '@angular/cdk/stepper';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { map, Observable, Subscription } from 'rxjs';
import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { FormArray_Add_Remove_TransferData, FormDefs, KikoStepper, StepperNextData, ThemeColor } from 'src/Interfaces/interfaces';
import { ConstantsService } from '../constants.service';
import { TranslationService } from '../translation-service.service';
import { ValidationErrorMessagesService } from '../ValidationErrorMessagesService/validation-error-messages.service';

@Component({
  selector: 'kiko-stepper',
  templateUrl: './generic-stepper.component.html',
  styleUrls: ['./generic-stepper.component.css']
})
export class GenericStepperComponent implements OnInit
{
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher();
  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  DarkOrLight: string = "";
  Theme_dir: 'rtl' | 'ltr';
  stepperOrientation: Observable<StepperOrientation>;
  FormDef: FormDefs = new FormDefs();
  @Input() Stepper: KikoStepper = new KikoStepper;
  @Output() FormDefs: EventEmitter<FormDefs> = new EventEmitter();
  @Output() ChipsHandler: EventEmitter<FormDefs> = new EventEmitter();
  @Output() ResetClick: EventEmitter<boolean> = new EventEmitter();
  @Output() NextClick: EventEmitter<StepperNextData> = new EventEmitter();
  @Output() FormArrayAddButtonClick: EventEmitter<StepperNextData> = new EventEmitter();
  constructor(
    public Constants: ConstantsService, breakpointObserver: BreakpointObserver,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, private bottomSheet: MatBottomSheet)
  {
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({ matches }) => (matches ? 'horizontal' : 'vertical')));
    let tem: any = localStorage.getItem(this.Constants.BodyAppeareance);
    this.DarkOrLight = tem;

    let x: any = localStorage.getItem(this.Constants.ChoosenThemeColors);
    x = JSON.parse(x);
    this.ThemeColors = x;
    this.ThemeSubscription = this.LightOrDarkConverter.CurrentThemeClass$.subscribe(x => { this.DarkOrLight = x; });
    this.ThemeColorSubscription = this.LightOrDarkConverter.ThemeColors$.subscribe(
      x =>
      {
        this.ThemeColors = x;
      }
    );

    let themeDir: any = localStorage.getItem(this.Constants.dir);
    this.Theme_dir = themeDir;
    this.ThemeDirection = this.LightOrDarkConverter.ThemeDir$.subscribe(
      r => { this.Theme_dir = r; console.log(this.Theme_dir); }
    );
  }

  ngOnInit(): void
  {
  }
  SendData(event: FormDefs)
  {
    this.FormDef = event;
    this.FormDefs.emit(event);
  }
  SendNext(stepper: KikoStepper, i: number)
  {
    this.NextClick.emit({ Stepper: stepper, index: i });
  }
  SendFinal(form: FormDefs, i: number)
  {
    console.log(`index  = ${i}`);
    console.log(form);
  }
  ChipsHandle(event: FormDefs)
  {
    this.ChipsHandler.emit(event);
  }
  resetChips()
  {
    for (let s of this.FormDef.formSections)
    {
      for (let x of s.formFieldsSpec)
      {
        if (x.chipsFill) x.chipsFill = [];
      }
    }
  }
  FormArrayAdd_Click(event: FormGroup, stepper: KikoStepper, index: number)
  {
    this.FormArrayAddButtonClick.emit({ Stepper: stepper, index: index });
  }

}
