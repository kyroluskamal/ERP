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
import { ItemMainCategory, ItemSubCategory } from '../../Models/item.model';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-brands',
  templateUrl: './item-brands.component.html',
  styleUrls: ['./item-brands.component.css']
})
export class ItemBrandsComponent implements OnInit, OnDestroy {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));

  ItemsMainCategories: Observable<ItemMainCategory[]> = new Observable<ItemMainCategory[]>();
  Items_Sub_Categories: Observable<ItemSubCategory[]> = new Observable<ItemSubCategory[]>();
  ItemMainCat: ItemMainCategory = new ItemMainCategory();
  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  NoUniqueSubCat_Per_MainCat: boolean = false;
  NotSelected_MainCat: boolean = false;
  SelectMainCat_Through_SubCat: boolean = false;
  AllMainCats: ItemMainCategory[] = [];
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

  defaultColDef_SubCat: ColDef = {
    filter: true,
    sortable: true,
    suppressKeyboardEvent: params => {
      if (!params.editing) {
        let isBackspaceKey = params.event.key === "Delete";
        let isDeleteKey = params.event.key === "Backspace";
        let shiftKey = params.event.shiftKey;
        if (isBackspaceKey && shiftKey) {
          this.Delete_SubCat(params);
          return true
        }

        if (isDeleteKey && shiftKey) {
          this.Delete_SubCat(params);
          return true
        }
      }
      return false;
    }
  };
  columnDefs_Subcats: ColDef[] = [];
  overlayLoadingTemplate: string = "";

  overlayLoadingTemplate_SubCat: string = "";

  gridApi: GridApi = new GridApi();
  gridApi_subCat: GridApi = new GridApi();
  gridColumnApi: ColumnApi = new ColumnApi();
  gridColumnApi_SubCat: any;
  GlobalSearchValue: string = "";


  AddMainCatForm: FormGroup = new FormGroup({});
  Add_Sub_CatForm: FormGroup = new FormGroup({});
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
  ShowProgressBar_subcat: boolean = false;
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
    this.ItemsMainCategories = this.ItemService.GetAllGategories();
    this.ItemsMainCategories.subscribe(r => this.AllMainCats = r);
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
    this.Items_Sub_Categories = this.ItemService.GetItems_All_SubCats();
    this.columnDefs = [
      {
        headerName: "#", field: 'id',
        filter: true,
        flex: 1,

      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Name), field: 'name',
        editable: ({ node }) => {
          if (node.data.name === this.translate.GetTranslation(this.Constants.Uncategorized)) {
            this.NotificationService.error(this.translate.GetTranslation(this.Constants.UnCategorized_Can_tDeleted_Or_Updated), "",
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
            return false
          }
          return true
        }, filter: true,
        flex: 3
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Delete), field: "delete",
        cellRenderer: 'buttonRenderer',
        cellRendererParams: {
          onClick: this.onDeleteButtonClick.bind(this),
          iconName: 'delete',
          preventionName: this.Constants.Uncategorized
        },
        filter: false,
        sortable: false,
        flex: 1
      },

    ];
    this.columnDefs_Subcats = [
      {
        headerName: "#", field: 'id',
        filter: true,
        flex: 1
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Name), field: 'name',
        editable: ({ node }) => {
          if (node.data.name === this.translate.GetTranslation(this.Constants.Uncategorized)) {
            this.NotificationService.error(this.translate.GetTranslation(this.Constants.UnCategorized_Can_tDeleted_Or_Updated), "",
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
            return false
          }
          return true
        }, filter: true,
        flex: 2
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.MainCat_Singular), field: 'itemMainCategoryId',
        flex: 2
      },
      {
        headerName: this.translate.GetTranslation(this.Constants.Delete),
        cellRenderer: 'buttonRenderer',
        cellRendererParams: {
          onClick: this.Delete_SubCat.bind(this),
          iconName: 'delete',
          preventionName: this.Constants.Uncategorized
        },
        filter: false,
        sortable: false,
        flex: 1,

      },
    ];
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
    this.AddMainCatForm = new FormGroup({
      CatName: new FormControl('', Validators.required)
    });
    this.Add_Sub_CatForm = new FormGroup({
      SubCatName: new FormControl('', Validators.required)
    });

  }

  AddMainCategory() {
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    this.loading = true;
    let IsUnique: boolean = false;
    this.gridApi.forEachNode((node) => {
      if (String(node.data.name).toLowerCase() === String(this.AddMainCatForm.get("CatName")?.value).toLowerCase()) {
        IsUnique = true;
      }
    });
    if (IsUnique) {
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.loading = false;
      this.ShowProgressBar = false;
      this.AddMainCatForm.get("CatName")?.setValue("");
      this.gridApi.hideOverlay();
      return;
    }

    this.ItemService.AddMainCat(this.AddMainCatForm.get("CatName")?.value).subscribe({
      next: (response) => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.loading = false;
        this.ItemsMainCategories.subscribe((MainCatLists) => {
          MainCatLists.map((item) => {
            if (item.name === this.Constants.Uncategorized) {
              item.name = this.translate.GetTranslation(this.Constants.Uncategorized);
            }
          })
          this.gridApi.hideOverlay();
          this.gridApi.setRowData(MainCatLists);
        });
        this.ShowProgressBar = false;
      },
      error: error => {
        console.log(error);
        if (Array.isArray(error)) {
          this.NotificationService.error(this.translate.GetTranslation(error[0].status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        } else
          this.NotificationService.error(this.translate.GetTranslation(error.error.status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        if (error[0].status === this.Constants.NullTenant || error.error.status === this.Constants.NullTenant)
          this.ErrorGettingAllMainCats = error;
        this.gridApi.hideOverlay();
        this.loading = false;
        this.ShowProgressBar = false;
      }
    });
    this.AddMainCatForm.get("CatName")?.setValue("");
    this.loading = false;
    this.gridApi.hideOverlay();
    this.ShowProgressBar = false;
  }

  OnGridReady(event: GridReadyEvent) {
    this.gridApi = event.api;
    this.gridColumnApi = event.columnApi;
    this.ItemsMainCategories.subscribe(
      r => {
        r.map((item) => {
          if (item.name === this.Constants.Uncategorized) {
            item.name = this.translate.GetTranslation(this.Constants.Uncategorized);
          }
        })
        this.gridApi.setRowData(r);
      }
    );
  }

  externalFilterChanged(MainCatSearch: HTMLInputElement) {
    this.gridApi.setQuickFilter(MainCatSearch.value);
  }

  UpdateItemMainCat(event: CellValueChangedEvent) {
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
    for (let node of Nodes) { if (String(node.data.name).toLowerCase() === String(event.data.name).toLowerCase()) { IsUnique = true; break; } }
    console.log(IsUnique);
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
    let MaindCat: ItemMainCategory = {
      id: event.data.id,
      name: event.data.name,
      subdomain: window.location.hostname.split('.')[0]
    }
    if (event.oldValue === event.newValue) return;
    this.ItemService.UpdateMainCat(MaindCat).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(r.status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.gridApi.hideOverlay();
        this.gridApi.refreshCells();
        this.ShowProgressBar = false;
      },
      error: (e) => {
        this.gridApi.refreshCells();
        event.node.data.name = event.oldValue;
        console.log(e);
        if (Array.isArray(e)) {
          if (e[0].title === this.Constants.Model_state_errors) {
            let NotifTranslation = "";
            console.log(e[0].errors);
            for (let err of e[0].errors.Name) {
              NotifTranslation += this.translate.GetTranslation(err);
            }
            this.NotificationService.error(NotifTranslation, '',
              this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          }
          this.NotificationService.error(this.translate.GetTranslation(e[0].status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          this.gridApi.hideOverlay();
        } else
          this.NotificationService.error(this.translate.GetTranslation(e.error.status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        if (e[0].status === this.Constants.NullTenant)
          this.ErrorGettingAllMainCats = e;
        console.log(e);
        this.ShowProgressBar = false;
        this.gridApi.hideOverlay();
      }
    })
    this.ShowProgressBar = false;
    this.gridApi.hideOverlay();
    this.gridApi.refreshCells();
  }

  onDeleteButtonClick(event: any) {
    this.ShowProgressBar = true;
    this.ItemService.DeleteMainCat(event.data.id).subscribe(
      {
        next: r => {
          this.NotificationService.success(this.translate.GetTranslation(this.Constants.Data_Deleted_success_status),
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          this.ItemsMainCategories.subscribe(
            {
              next: MainCatlist => {
                MainCatlist = MainCatlist.filter(function (item) {
                  return item.id !== event.data.id
                });
                MainCatlist.map((item) => {
                  if (item.name === this.Constants.Uncategorized) {
                    item.name = this.translate.GetTranslation(this.Constants.Uncategorized);
                  }
                });
                this.gridApi.showLoadingOverlay();
                this.gridApi.setRowData(MainCatlist);
                this.ShowProgressBar = false;
                //deleteing associated subcategories from the grid api
                this.ShowProgressBar_subcat = true;
                this.gridApi_subCat.showLoadingOverlay();
                let SubCats: any[] = [];
                this.gridApi_subCat.forEachNode((node) => {
                  console.log(node);
                  if (node.data.itemMainCategoryId === event.data.id)
                    SubCats.push(node.data);
                });
                console.log(SubCats);

                this.gridApi_subCat.applyTransaction({ remove: SubCats });
                this.Items_Sub_Categories.subscribe(r => this.gridApi_subCat.setRowData(r));
                this.gridApi_subCat.hideOverlay();
                this.ShowProgressBar_subcat = false;
              },
              error: e => {
                console.log(e);
              }
            }
          );
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
            this.ErrorGettingAllMainCats = e;
          this.ShowProgressBar = false;
        }
      }
    );

  }
}
