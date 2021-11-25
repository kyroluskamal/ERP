import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CellValueChangedEvent, ColDef, ColumnApi, GridApi, GridReadyEvent, RowNode } from 'ag-grid-community';
import { Observable, Subscription } from 'rxjs';

import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { IconButtonRendererComponent } from '../../AgFrameworkComponents/button-renderer-component/Icon-button-renderer.component';
import { NumberCellEditorComponent } from '../../AgFrameworkComponents/number-cell-editor/number-cell-editor.component';
import { SelectableEditroAgFramweworkComponent } from '../../AgFrameworkComponents/selectable-editro-ag-framwework/selectable-editro-ag-framwework.component';
import { ThemeColor } from '../../client-app-dashboard/client-app-dashboard.component';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { ItemUnit } from '../../Models/item.model';
import { ItemsService } from '../items.service';
@Component({
  selector: 'app-item-units',
  templateUrl: './item-units.component.html',
  styleUrls: ['./item-units.component.css'],
})
export class ItemUnitsComponent implements OnInit, OnDestroy {

  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));

  ItemsUnits: Observable<ItemUnit[]> = new Observable<ItemUnit[]>();
  ItemUnit: ItemUnit = new ItemUnit();
  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  MaxlengthVlue: number = 30;
  defaultColDef: ColDef = {
    suppressKeyboardEvent: params => {
      if (!params.editing) {
        let isBackspaceKey = params.event.key === "Delete";
        let isDeleteKey = params.event.key === "Backspace";
        let shiftKey = params.event.shiftKey;
        if (isBackspaceKey && shiftKey) {
          this.onDeleteButtonClick(params);
          return true
        }

        if (isDeleteKey && shiftKey) {
          this.onDeleteButtonClick(params);
          return true
        }
      }
      return false;
    },

  };
  columnDefs: ColDef[] = [];
  agFrameworks = {
    buttonRenderer: IconButtonRendererComponent,
    SelectableEditor: SelectableEditroAgFramweworkComponent,
    NumberCellEditor: NumberCellEditorComponent
  }


  overlayLoadingTemplate: string = "";

  overlayLoadingTemplate_SubCat: string = "";

  gridApi: GridApi = new GridApi();
  gridColumnApi: ColumnApi = new ColumnApi();
  GlobalSearchValue: string = "";


  Add_Item_Unit: FormGroup = new FormGroup({});
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  selected: any;
  loading: boolean = false;
  loading_subcat: boolean = false;
  IsTenantFound: Subscription = new Subscription();
  TableAppearance: Subscription = new Subscription();
  ErrorGettingAllMainCats: any[] = [];
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

  //Constructor ........................................................................
  constructor(public ItemService: ItemsService, private NotificationService: NotificationsService,
    public Constants: ConstantsService, private clientAccountService: ClientAccountService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService) {

    this.ItemsUnits = this.ItemService.Get_All_ItemUnits();
    this.ItemsUnits.subscribe({
      error: e => {
        if (e.status === 401 && e.error === null)
          this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unauthorized_Error), "",
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
      }
    });
    let tem: any = localStorage.getItem(this.Constants.BodyAppeareance);
    this.DarkOrLight = tem;
    console.log(document.cookie);
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
    this.columnDefs = [
      {
        headerName: "#", field: 'id',
        filter: true,
        flex: 2,
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.WholeSaleUnit), field: 'wholeSaleUnit',
        editable: true, filter: true,
        flex: 4
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.NumberInWholeSale), field: 'numberInWholeSale',
        editable: true, filter: true,
        flex: 4
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.RetailUnit), field: 'retailUnit',
        editable: true, filter: true,
        flex: 4
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.NumberInRetailSale), field: 'numberInRetailSale',
        editable: true, filter: true,
        flex: 4,

      },
      {
        headerName: this.translate.GetTranslation(this.Constants.ConversionRate), field: 'conversionRate',
        editable: false, filter: true,
        flex: 3,
        valueGetter: (params) => { return params.data.numberInWholeSale * params.data.numberInRetailSale }
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Delete), field: "delete",
        cellRenderer: 'buttonRenderer',
        cellRendererParams: {
          onClick: this.onDeleteButtonClick.bind(this),
          iconName: 'delete',
        },
        flex: 2
      },

    ];
    this.overlayLoadingTemplate = `<span class="ag-overlay-loading-center" [dir]=${this.translate.isRightToLeft(this.translate.GetCurrentLang())}>
      ${this.translate.GetTranslation(this.Constants.loading)}</span>`;
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
    this.IsTenantFound.unsubscribe();
    this.ThemeSubscription.unsubscribe();
    this.ThemeColorSubscription.unsubscribe();
    this.AgGridTable_dir.unsubscribe();
    this.TableAppearance.unsubscribe();
    this.ThemeDirection.unsubscribe();
  }
  ngOnInit(): void {
    this.showOverlayFirstTime = false;
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.Add_Item_Unit = new FormGroup({
      WholeSaleName: new FormControl('', [Validators.required, Validators.maxLength(this.MaxlengthVlue)]), // Validation implementation complete
      RetailSaleName: new FormControl('', [Validators.required, Validators.maxLength(this.MaxlengthVlue)]),
      NumberInWholeSale: new FormControl('', [Validators.required, Validators.pattern("[1-9][0-9]*"), Validators.min(1)]),
      NumberInRetailSale: new FormControl('', [Validators.required, Validators.pattern("[1-9][0-9]*"), Validators.min(1)]),
    });


  }

  AddMItemUnit() {
    console.log(this.Add_Item_Unit.get("NumberInWholeSale")?.errors);
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    this.loading = true;
    let IsUnique: boolean = false;
    this.gridApi.forEachNode((node) => {
      if (node.data.wholeSaleName === this.Add_Item_Unit.get("WholeSaleName")?.value) {
        IsUnique = true;
      }
    });
    if (IsUnique) {
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.loading = false;
      this.ShowProgressBar = false;
      this.Add_Item_Unit.get("WholeSaleName")?.setErrors({ WholeSaleNameUnique: true });
      this.Add_Item_Unit.get("WholeSaleName")?.setValue("");
      this.gridApi.hideOverlay();
      return;
    }
    let itemUnit: ItemUnit = {
      Id: 1,
      WholeSaleUnit: this.Add_Item_Unit.get("WholeSaleName")?.value,
      RetailUnit: this.Add_Item_Unit.get("RetailSaleName")?.value,
      NumberInWholeSale: Number(this.Add_Item_Unit.get("NumberInWholeSale")?.value),
      NumberInRetailSale: Number(this.Add_Item_Unit.get("NumberInRetailSale")?.value),
      ConversionRate: Number(this.Add_Item_Unit.get("NumberInWholeSale")?.value) * Number(this.Add_Item_Unit.get("NumberInRetailSale")?.value),
      Subdomain: window.location.hostname.split('.')[0]
    }
    console.log(itemUnit);
    this.ItemService.AddNew_ItemUnit(itemUnit).subscribe({
      next: (response) => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.applyTransaction({ add: [response] })
        this.ShowProgressBar = false;
      },
      error: error => {
        let translatedError: string = "";

        if (Array.isArray(error)) {
          if (error[0].errors) { //Check model state errors
            //Wholesale unit required from server
            if (error[0].errors.WholeSaleUnit) {
              if (error[0].errors.WholeSaleUnit[0] === this.Constants.Required_field_Error) {
                translatedError += "(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.WholeSaleUnit[0]);
                //Wholesale unit MaxLength from server
              } else if (error[0].errors.WholeSaleUnit[0] === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += "(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") " +
                  this.translate.GetTranslation(error[0].errors.WholeSaleUnit[0]) + this.MaxlengthVlue
                  + this.translate.GetTranslation(this.Constants.characters);
            }
            //Retail unit required from server
            if (error[0].errors.RetailUnit) {
              if (error[0].errors.RetailUnit[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.RetailUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.RetailUnit[0]);
              //Retail unit MaxLength from server
              else if (error[0].errors.RetailUnit[0] === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.RetailUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.RetailUnit[0]) + this.MaxlengthVlue
                  + this.translate.GetTranslation(this.Constants.characters);
            }

            //Number in Wholesale unit required from server
            if (error[0].errors.NumberInWholeSale) {
              if (error[0].errors.NumberInWholeSale[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInWholeSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInWholeSale[0])
              //Retail unit Negative number from server
              else if (error[0].errors.NumberInWholeSale[0] === this.Constants.Negative_Value_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInWholeSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInWholeSale[0]);
            }
            if (error[0].errors.NumberInRetailSale) {
              if (error[0].errors.NumberInRetailSale[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInRetailSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInRetailSale[0])
              //Retail unit Negative number from server
              else if (error[0].errors.NumberInRetailSale[0] === this.Constants.Negative_Value_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInRetailSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInRetailSale[0]);
            }
          } else if (error[0].status)
            translatedError += this.translate.GetTranslation(error[0].status);
        } else if (error.error.status)
          translatedError += this.translate.GetTranslation(error.error.status);
        else if (error.status === 401 && error.error === null) {
          console.log(error);
          translatedError += this.translate.GetTranslation(this.Constants.Unauthorized_Error);
        }
        this.NotificationService.error(translatedError, '', this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')

        if (error[0].status === this.Constants.NullTenant)
          this.ErrorGettingAllMainCats = error;
        this.gridApi.hideOverlay();
        this.loading = false;
        this.ShowProgressBar = false;
      }
    });
    this.Add_Item_Unit.reset();
    this.loading = false;
    this.gridApi.hideOverlay();
    this.ShowProgressBar = false;
  }

  OnGridReady(event: GridReadyEvent) {
    this.gridApi = event.api;
    this.gridColumnApi = event.columnApi;
  }

  externalFilterChanged(UnitSearch: HTMLInputElement) {
    this.gridApi.setQuickFilter(UnitSearch.value);
  }

  UpdateItemUnit(event: CellValueChangedEvent) {
    console.log(event);
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    // Prevent leaving cell empty
    if (String(event.value) === "") {
      if (event.node.data.wholeSaleUnit === "") event.node.data.wholeSaleUnit = event.oldValue;
      else if (event.node.data.retailUnit === "") event.node.data.retailUnit = event.oldValue;
      else if (event.node.data.numberInWholeSale === "") event.node.data.numberInWholeSale = event.oldValue;
      else if (event.node.data.numberInRetailSale === "") event.node.data.numberInRetailSale = event.oldValue;
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Required_field_Error), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.ShowProgressBar = false;
      this.gridApi.hideOverlay();
      this.gridApi.refreshCells();
      return;
    }
    //Check if Wholesale unit is unique
    let IsUnique: boolean = false;
    let Nodes: RowNode[] = [];
    this.gridApi.forEachNode((node) => {
      if (!node.isSelected())
        Nodes.push(node)
    });
    for (let node of Nodes) {
      if (String(node.data.wholeSaleUnit).toLowerCase() === String(event.newValue).toLowerCase()) {
        IsUnique = true; break;
      }
    }
    console.log(Nodes);
    if (IsUnique) {
      this.NotificationService.error("(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") " +
        this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.wholeSaleUnit = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      return;
    }
    //Check if the length of Wholesale and retails is 30
    if (String(event.node.data.wholeSaleUnit).length > this.MaxlengthVlue) {
      this.NotificationService.error("(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") " +
        this.translate.GetTranslation(this.Constants.MaxLengthExceeded_ERROR) + this.MaxlengthVlue
        + this.translate.GetTranslation(this.Constants.characters), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.wholeSaleUnit = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.hideOverlay();
      this.gridApi.refreshCells();
      return;
    }
    else if (String(event.node.data.retailUnit).length > this.MaxlengthVlue) {
      this.NotificationService.error("(" + this.translate.GetTranslation(this.Constants.RetailUnit) + ") " +
        this.translate.GetTranslation(this.Constants.MaxLengthExceeded_ERROR) + this.MaxlengthVlue
        + this.translate.GetTranslation(this.Constants.characters), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.retailUnit = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      return;
    }
    //Check if the numberInWholeSale and numberInRetailSale are numbers
    console.log(!isNaN(event.node.data.numberInRetailSale));
    if (isNaN(Number(event.node.data.numberInWholeSale))) {
      event.node.data.numberInWholeSale = event.oldValue;
      console.log(event.node.data.numberInWholeSale);
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      this.gridApi.refreshClientSideRowModel();
      this.NotificationService.error(" (" + this.translate.GetTranslation(this.Constants.NumberInWholeSale) + ") "
        + this.translate.GetTranslation(this.Constants.Negative_Value_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      return;
    }
    if (isNaN(Number(event.node.data.numberInRetailSale))) {
      this.NotificationService.error("(" + this.translate.GetTranslation(this.Constants.NumberInRetailSale) + ") " +
        this.translate.GetTranslation(this.Constants.Negative_Value_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.numberInRetailSale = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      return;
    }
    let ItemUnit: ItemUnit = {
      Id: Number(event.data.id),
      WholeSaleUnit: String(event.data.wholeSaleUnit),
      RetailUnit: String(event.data.retailUnit),
      NumberInRetailSale: Number(event.data.numberInRetailSale),
      NumberInWholeSale: Number(event.data.numberInWholeSale),
      ConversionRate: Number(event.data.numberInRetailSale) * Number(event.data.numberInWholeSale),
      Subdomain: window.location.hostname.split('.')[0]
    }
    if (event.oldValue === event.newValue) return;
    this.ItemService.Update_ItemUnit(ItemUnit).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(r.status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.hideOverlay();
        this.gridApi.refreshCells();
        this.ShowProgressBar = false;
      },
      error: (error) => {
        let translatedError: string = "";
        if (error[0].status) {
          if (error[0].status === this.Constants.Unique_Field_ERROR)
            translatedError += " (" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") "
              + this.translate.GetTranslation(error[0].status)
          event.node.data.wholeSaleUnit = event.oldValue;
          this.gridApi.refreshCells();
        }
        console.log(error);
        if (Array.isArray(error)) {
          if (error[0].errors) { //Check model state errors
            //Wholesale unit required from server
            if (error[0].errors.WholeSaleUnit) {
              if (error[0].errors.WholeSaleUnit[0] === this.Constants.Required_field_Error) {
                translatedError += "(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.WholeSaleUnit[0]);
                //Wholesale unit MaxLength from server
              } else if (error[0].errors.WholeSaleUnit[0] === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += "(" + this.translate.GetTranslation(this.Constants.WholeSaleUnit) + ") " +
                  this.translate.GetTranslation(error[0].errors.WholeSaleUnit[0]) + this.MaxlengthVlue
                  + this.translate.GetTranslation(this.Constants.characters);
              event.node.data.wholeSaleUnit = event.oldValue;
            }
            //Retail unit required from server
            if (error[0].errors.RetailUnit) {
              if (error[0].errors.RetailUnit[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.RetailUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.RetailUnit[0]);
              //Retail unit MaxLength from server
              else if (error[0].errors.RetailUnit[0] === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.RetailUnit) + ") "
                  + this.translate.GetTranslation(error[0].errors.RetailUnit[0]) + this.MaxlengthVlue
                  + this.translate.GetTranslation(this.Constants.characters);
              event.node.data.retailUnit = event.oldValue;
            }

            //Number in Wholesale unit required from server
            if (error[0].errors.NumberInWholeSale) {
              if (error[0].errors.NumberInWholeSale[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInWholeSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInWholeSale[0])
              //Retail unit Negative number from server
              else if (error[0].errors.NumberInWholeSale[0] === this.Constants.Negative_Value_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInWholeSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInWholeSale[0]);
              event.node.data.numberInWholeSale = event.oldValue;
            }
            if (error[0].errors.NumberInRetailSale) {
              if (error[0].errors.NumberInRetailSale[0] === this.Constants.Required_field_Error)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInRetailSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInRetailSale[0])
              //Retail unit Negative number from server
              else if (error[0].errors.NumberInRetailSale[0] === this.Constants.Negative_Value_ERROR)
                translatedError += " (" + this.translate.GetTranslation(this.Constants.NumberInRetailSale) + ") "
                  + this.translate.GetTranslation(error[0].errors.NumberInRetailSale[0]);
              event.node.data.numberInRetailSale = event.oldValue;
            }
            if (error[0].errors["$.NumberInWholeSale"] || error[0].errors["$.NumberInRetailSale"]) {
              if (error[0].errors["$.NumberInRetailSale"]) event.node.data.numberInRetailSale = event.oldValue;
              if (error[0].errors["$.NumberInWholeSale"]) event.node.data.numberInWholeSale = event.oldValue;
              translatedError += this.translate.GetTranslation(this.Constants.Negative_Value_ERROR);
            } else {

            }
          }
        } else if (error[0].status)
          translatedError += this.translate.GetTranslation(error[0].status);
        else if (error.error.status)
          translatedError += this.translate.GetTranslation(error.error.status);
        else if (error.status === 401 && error.error === null) {
          console.log(error);
          translatedError += this.translate.GetTranslation(this.Constants.Unauthorized_Error);
        }
        this.NotificationService.error(translatedError, '', this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
        if (error[0].status === this.Constants.NullTenant)
          this.ErrorGettingAllMainCats = error;
        this.NotificationService.error(translatedError, '', this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
        console.log(error);
        this.ShowProgressBar = false;
        this.gridApi.hideOverlay();
        this.gridApi.refreshCells();
      }
    })
    this.ShowProgressBar = false;
    this.gridApi.hideOverlay();
    this.gridApi.refreshCells();
  }

  onDeleteButtonClick(event: any) {
    this.ShowProgressBar = true;
    this.gridApi.showLoadingOverlay();
    this.ItemService.Delete_ItemUnit(event.data.id).subscribe(
      {
        next: r => {
          this.NotificationService.success(this.translate.GetTranslation(r.status),
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          this.gridApi.applyTransaction({ remove: [event.node.data] });
          this.gridApi.hideOverlay();
          this.ShowProgressBar = false
        },
        error: e => {
          this.ShowProgressBar = false;
          this.gridApi.hideOverlay()
          console.log(e);
          if (Array.isArray(e)) {
            this.NotificationService.error(this.translate.GetTranslation(e[0].status), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          }
          else if (e.error.status)
            this.NotificationService.error(this.translate.GetTranslation(e.error.status), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          else if (e.status === 401 && e.error === null) {
            console.log(e);
            this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unauthorized_Error), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          }
          if (e[0].status === this.Constants.NullTenant || e.error.status === this.Constants.NullTenant)
            this.ErrorGettingAllMainCats = e;
          this.ShowProgressBar = false;
        }
      }
    );
    this.gridApi.refreshClientSideRowModel();
  }
  CheckIfUniqe(event: any) {
    let IsUnique: boolean = false;
    this.gridApi.forEachNode((node) => {
      if (String(node.data.wholeSaleUnit).toLowerCase() === String(this.Add_Item_Unit.get("WholeSaleName")?.value).toLowerCase()) {
        IsUnique = true;
      }
    });
    if (IsUnique) {
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.loading = false;
      this.ShowProgressBar = false;
      this.Add_Item_Unit.get("WholeSaleName")?.setErrors({ WholeSaleNameUnique: true });
      this.gridApi.hideOverlay();
      return;
    } else {
      this.Add_Item_Unit.get("WholeSaleName")?.setErrors({ WholeSaleNameUnique: false });
    }
    this.Add_Item_Unit.get("WholeSaleName")?.updateValueAndValidity();
  }
}
