import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CellValueChangedEvent, ColDef, ColumnApi, GridApi, GridReadyEvent, RowNode, RowSelectedEvent, SelectCellEditor, SideBarDef } from 'ag-grid-community';
import { Observable, Subscription } from 'rxjs';

import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { CustomValidators } from 'src/Helpers/CustomValidation/custom-validators';
import { IconButtonRendererComponent } from '../../AgFrameworkComponents/button-renderer-component/Icon-button-renderer.component';
import { SelectableEditroAgFramweworkComponent } from '../../AgFrameworkComponents/selectable-editro-ag-framwework/selectable-editro-ag-framwework.component';
import { ThemeColor } from '../../client-app-dashboard/client-app-dashboard.component';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { Brands, ItemMainCategory, ItemSubCategory } from '../../Models/item.model';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-brands',
  templateUrl: './item-brands.component.html',
  styleUrls: ['./item-brands.component.css']
})
export class ItemBrandsComponent implements OnInit, OnDestroy {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));

  ItemBrands: Observable<Brands[]> = new Observable<Brands[]>();
  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  MaxLength: number = 30;
  defaultColDef: ColDef = {
    filter: true,
    sortable: true,
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
    }
  };
  columnDefs: ColDef[] = [];
  agFrameworks = {
    buttonRenderer: IconButtonRendererComponent,
    SelectableEditor: SelectableEditroAgFramweworkComponent
  }

  overlayLoadingTemplate: string = "";

  gridApi: GridApi = new GridApi();
  gridColumnApi: ColumnApi = new ColumnApi();
  GlobalSearchValue: string = "";
  AddBrandForm: FormGroup = new FormGroup({});
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

  //Constructor ........................................................................
  constructor(public ItemService: ItemsService, private NotificationService: NotificationsService,
    public Constants: ConstantsService, private clientAccountService: ClientAccountService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService) {
    this.overlayLoadingTemplate = `<span class="ag-overlay-loading-center" [dir]=${this.translate.isRightToLeft(this.translate.GetCurrentLang())}>
      ${this.translate.GetTranslation(this.Constants.loading)}</span>`;

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
    this.ItemBrands = this.ItemService.Get_All_ItemBrands();
    this.ItemBrands.subscribe({
      error: e => {
        if (e.status === 401 && e.error === null)
          this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unauthorized_Error), "",
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
      }
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
        flex: 1,
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Name), field: 'name',
        editable: true, filter: true,
        flex: 3
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Delete), field: "delete",
        cellRenderer: 'buttonRenderer',
        cellRendererParams: {
          onClick: this.onDeleteButtonClick.bind(this),
          iconName: 'delete',
        },
        filter: false,
        sortable: false,
        flex: 1
      }
    ];
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
    this.AddBrandForm = new FormGroup({
      BrandName: new FormControl('', [Validators.required, Validators.maxLength(this.MaxLength)])
    });
  }

  AddBrand() {
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    this.loading = true;
    let IsUnique: boolean = false;
    this.gridApi.forEachNode((node) => {
      if (String(node.data.name).toLowerCase() === String(this.AddBrandForm.get("BrandName")?.value).toLowerCase()) {
        IsUnique = true;
      }
    });
    if (IsUnique) {
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.loading = false;
      this.ShowProgressBar = false;
      this.AddBrandForm.get("BrandName")?.setValue("");
      this.gridApi.hideOverlay();
      return;
    }
    let newBrand: Brands = {
      id: 0,
      name: this.AddBrandForm.get("BrandName")?.value,
      subdomain: this.Subdomain
    }
    this.ItemService.AddNew_ItemBrand(newBrand).subscribe({
      next: (r) => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.applyTransaction({ add: [r] });
        this.loading = false;
        this.ShowProgressBar = false;
        this.AddBrandForm.reset();
      },
      error: error => {
        let translatedError: string = "";
        console.log(error);
        if (Array.isArray(error)) {
          if (Number.isNaN(error[0].status))
            translatedError += this.translate.GetTranslation(error[0].status);
          if (error[0].errors)
            for (let err of error[0].errors.Name) {
              if (err === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += `${this.translate.GetTranslation(err)} ${this.MaxLength}
                  ${this.translate.GetTranslation(this.Constants.characters)}
                `;
              else
                translatedError += this.translate.GetTranslation(err)
            }
        } else if (error.error.status)
          translatedError += this.translate.GetTranslation(error.error.status);

        else if (error.status === 401 && error.error === null) {
          translatedError += this.translate.GetTranslation(this.Constants.Unauthorized_Error)

        }
        if (error[0].status === this.Constants.NullTenant)
          this.ErrorGettingAllBands = error;
        this.NotificationService.error(translatedError, '',
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.hideOverlay();
        this.loading = false;
        this.ShowProgressBar = false;
      }
    });
    this.AddBrandForm.get("BrandName")?.setValue("");
    this.loading = false;
    this.gridApi.hideOverlay();
    this.ShowProgressBar = false;
  }

  OnGridReady(event: GridReadyEvent) {
    this.gridApi = event.api;
    this.gridColumnApi = event.columnApi;
  }

  externalFilterChanged(BrandSearch: HTMLInputElement) {
    this.gridApi.setQuickFilter(BrandSearch.value);
  }

  UpdateBrand(event: CellValueChangedEvent) {
    console.log(event);
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    //Prevent leaving cell empty
    if (String(event.data.name) === "") {
      event.node.data.name = event.oldValue;
      this.gridApi.refreshCells();
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Required_field_Error), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.ShowProgressBar = false;
      this.gridApi.hideOverlay();
      return;
    }
    let IsUnique: boolean = false;
    let Nodes: RowNode[] = [];
    this.gridApi.forEachNode((node) => {
      if (!node.isSelected())
        Nodes.push(node)
    });
    for (let node of Nodes) {
      if (String(node.data.name).toLowerCase() === String(event.data.name).toLowerCase()) { IsUnique = true; break; }
    }
    //Check if it is unique category
    if (IsUnique) {
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.name = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      return;
    }
    if (String(event.data.name).length > 30) {
      this.NotificationService.error(`${this.translate.GetTranslation(this.Constants.MaxLengthExceeded_ERROR)}
       ${this.MaxLength} ${this.translate.GetTranslation(this.Constants.characters)}`, '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.name = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.refreshCells();
      this.gridApi.hideOverlay();
      return;
    }
    let Brand: Brands = {
      id: Number(event.data.id),
      name: String(event.data.name),
      subdomain: this.Subdomain
    }
    if (event.oldValue === event.newValue) return;
    this.ItemService.Update_ItemBrand(Brand).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(r.status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.hideOverlay();
        this.gridApi.refreshCells();
        this.ShowProgressBar = false;
      },
      error: (e) => {
        let translatedError: string = "";
        event.node.data.name = event.oldValue;
        this.gridApi.refreshCells();
        console.log(e);
        if (Array.isArray(e)) {
          if (e[0].title === this.Constants.Model_state_errors) {
            console.log(e[0].errors);
            for (let err of e[0].errors.Name) {
              if (err === this.Constants.MaxLengthExceeded_ERROR)
                translatedError += `${this.translate.GetTranslation(err)} ${this.MaxLength}
                  ${this.translate.GetTranslation(this.Constants.characters)}
                `;
              else
                translatedError += this.translate.GetTranslation(err);
            }
          }
          if (Number.isNaN(e[0].status))
            translatedError += this.translate.GetTranslation(e[0].status);

          this.gridApi.hideOverlay();
        } else
          translatedError += this.translate.GetTranslation(e.error.status);
        if (e[0].status === this.Constants.NullTenant)
          this.ErrorGettingAllBands = e;
        console.log(e);
        this.NotificationService.error(translatedError, '',
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
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
    this.ItemService.Delete_ItemBrand(event.data.id).subscribe(
      {
        next: r => {
          this.NotificationService.success(this.translate.GetTranslation(this.Constants.Data_Deleted_success_status),
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          this.gridApi.applyTransaction({ remove: [event.node.data] });
        },
        error: e => {
          this.ShowProgressBar = false;
          console.log(e);
          if (Array.isArray(e)) {
            this.NotificationService.error(this.translate.GetTranslation(e[0].status), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          } else
            this.NotificationService.error(this.translate.GetTranslation(e.error.status), '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          if (e[0].status === this.Constants.NullTenant || e.error.status === this.Constants.NullTenant)
            this.ErrorGettingAllBands = e;
          this.ShowProgressBar = false;
        }
      }
    );
    this.ShowProgressBar = false;
  }
}
