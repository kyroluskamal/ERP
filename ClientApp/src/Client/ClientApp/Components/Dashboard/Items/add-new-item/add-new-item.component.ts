import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ThemeColor } from '../../client-app-dashboard/client-app-dashboard.component';
import { Inventories } from '../../Models/inventories.model';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { ItemsService } from '../items.service';
import { InventoriesService } from '../../Inventories/inventories.service'
import { ItemMainCategory, ItemSubCategory, ItemUnit } from '../../Models/item.model';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { ItemUnitsComponent } from '../item-units/item-units.component';
import { MatSelect } from '@angular/material/select';
import { ItemMainCategoriesComponent } from '../item-main-categories/item-main-categories.component';
import { Direction } from '@angular/cdk/bidi';
@Component({
  selector: 'app-add-new-item',
  templateUrl: './add-new-item.component.html',
  styleUrls: ['./add-new-item.component.css']
})
export class AddNewItemComponent implements OnInit, AfterViewInit {

  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));

  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  MaxLength: number = 30;

  GlobalSearchValue: string = "";
  AddItemMainDetails: FormGroup = new FormGroup({});
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  loading: boolean = false;
  TableAppearance: Subscription = new Subscription();
  ErrorGettingAllBands: any[] = [];
  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  AgGridTable_dir: Subscription;
  DarkOrLight: string = "";
  Table_Color_mode: string = "";
  AgGridDir: 'rtl' | 'ltr';
  Theme_dir: 'rtl' | 'ltr';
  ShowProgressBar: boolean = false;
  showOverlayFirstTime: boolean = true;
  AllInventories: Inventories[] = [];
  AllUnits: ItemUnit[] = [];
  SelectedUnits: ItemUnit[] = [];
  AllMainCategories: ItemMainCategory[] = [];
  AllSubCategories: ItemSubCategory[] = [];
  SelectedSubCats: ItemSubCategory[] = [];

  Direction: Direction = this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr';
  @ViewChild("itemUnitSelections") itemUnitSelections!: MatSelect;
  //Constructor ........................................................................
  constructor(public ItemService: ItemsService, private NotificationService: NotificationsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService,
    private InventoriesService: InventoriesService) {
    let tem: any = localStorage.getItem(this.Constants.BodyAppeareance);
    this.DarkOrLight = tem;

    let x: any = localStorage.getItem(this.Constants.ChoosenThemeColors)
    x = JSON.parse(x);
    this.ThemeColors = x;
    this.ThemeSubscription = this.LightOrDarkConverter.CurrentThemeClass$.subscribe(x => { this.DarkOrLight = x; console.log(this.DarkOrLight) });
    this.ThemeColorSubscription = this.LightOrDarkConverter.ThemeColors$.subscribe(
      x => {
        this.ThemeColors = x;
      }
    );
    let agGrid_dir: any = localStorage.getItem(this.Constants.Table_direction);
    this.AgGridDir = agGrid_dir;
    this.AgGridTable_dir = this.LightOrDarkConverter.agGridTable_dir$.subscribe(x => {
      this.AgGridDir = x;
      // window.location.reload();
    });

    let tableAppearence: any = localStorage.getItem(this.Constants.Table_Color_mode);
    this.Table_Color_mode = tableAppearence;
    this.TableAppearance = this.LightOrDarkConverter.TableTheme$.subscribe(
      r => this.Table_Color_mode = r
    );
    let themeDir: any = localStorage.getItem(this.Constants.dir);
    this.Theme_dir = themeDir;
    this.ThemeDirection = this.LightOrDarkConverter.ThemeDir$.subscribe(
      r => this.Theme_dir = r
    );
    this.InventoriesService.GetAllInventories().subscribe(r => {
      this.AllInventories = r;
      console.log(this.AllInventories)
    });
    this.ItemService.Get_All_ItemUnits().subscribe(r => {
      this.AllUnits = r;
    });
    this.ItemService.GetAllGategories().subscribe(r => this.AllMainCategories = r);
    this.ItemService.GetItems_All_SubCats().subscribe(r => this.AllSubCategories = r);
    this.AllMainCategories.map((item) => {
      if (item.name === this.Constants.Uncategorized)
        item.name = this.translate.GetTranslation(this.Constants.Uncategorized);
    })
  }
  ngAfterViewInit(): void {
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
    this.ThemeSubscription.unsubscribe();
    this.ThemeColorSubscription.unsubscribe();
    this.AgGridTable_dir.unsubscribe();
    this.TableAppearance.unsubscribe();
    this.ThemeDirection.unsubscribe();
  }
  ngOnInit(): void {
    this.showOverlayFirstTime = false;
    this.AddItemMainDetails = new FormGroup({
      Name: new FormControl('', [Validators.required, Validators.maxLength(this.MaxLength)]),
      IsOnline: new FormControl('', [Validators.required]),
      HasExpire: new FormControl('', [Validators.required])
    });
  }

  OpenItemUnitForm() {
    this.bottomSheet.open(ItemUnitsComponent, {
      direction: this.Direction,

    });
    this.itemUnitSelections.close();
    this.bottomSheet._openedBottomSheetRef?.afterDismissed().subscribe(
      () => this.ItemService.Get_All_ItemUnits().subscribe(r => this.AllUnits = r)
    )
  }

  OpenItemMainCats() {
    this.bottomSheet.open(ItemMainCategoriesComponent, {
      direction: this.Direction
    })
  }

  GetAllSubCats(MainCat: number) {
    console.log(MainCat);
    this.SelectedSubCats = this.AllSubCategories.filter(x => { return x.itemMainCategoryId === MainCat })
  }
}
