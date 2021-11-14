import { Component, ElementRef, HostListener, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CellValueChangedEvent, ColDef, Column, ColumnApi, GridApi, GridReadyEvent, RowSelectedEvent, SelectCellEditor } from 'ag-grid-community';
import { Observable, Subscription, tap, throwError } from 'rxjs';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { IconButtonRendererComponent } from '../../AgFrameworkComponents/button-renderer-component/Icon-button-renderer.component';
import { ThemeColor } from '../../client-app-dashboard/client-app-dashboard.component';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { ItemMainGategory } from '../../Models/Items/item-main-gategory.model';
import { ItemSubCategory } from '../../Models/Items/item-sub-category.model';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-main-categories',
  templateUrl: './item-main-categories.component.html',
  styleUrls: ['./item-main-categories.component.css']
})
export class ItemMainCategoriesComponent implements OnInit, OnDestroy {
  ItemsMainCategories: Observable<ItemMainGategory[]> = new Observable<ItemMainGategory[]>();
  Items_Sub_Categories: Observable<ItemSubCategory[]> = new Observable<ItemSubCategory[]>();
  ItemMainCat: ItemMainGategory = new ItemMainGategory();

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
  columnDefs: ColDef[] = [
    {
      headerName: "#id", field: 'id',
      filter: true,
      flex: 1
    },
    {
      headerName: "Name", field: 'name',
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
      headerName: 'Delete', field: "delete",
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
  agFrameworks = {
    buttonRenderer: IconButtonRendererComponent
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
  columnDefs_Subcats: ColDef[] = [
    {
      headerName: "#id", field: 'id',
      filter: true,
      flex: 1
    },
    {
      headerName: "Name", field: 'name',
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
      headerName: "Main Category Id", field: 'itemMainCategoryId',
      flex: 2
    },
    {
      headerName: 'Delete',
      cellRenderer: 'buttonRenderer',
      cellRendererParams: {
        onClick: this.onDeleteButtonClick.bind(this),
        iconName: 'delete',
        preventionName: this.Constants.Uncategorized
      },
      filter: false,
      sortable: false,
      flex: 0,

    },
  ];


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
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
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
      x => this.ThemeColors = x
    );
    let agGrid_dir: any = localStorage.getItem(this.Constants.Table_direction);
    this.AgGridDir = agGrid_dir;
    this.AgGridTable_dir = this.LightOrDarkConverter.agGridTable_dir$.subscribe(x => {
      this.AgGridDir = x;
      // window.location.reload();
    });
    this.ItemsMainCategories = this.ItemService.GetAllGategories();

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
    if (this.NotUniqueMainCat(this.AddMainCatForm.get("CatName")?.value)) {
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
    let agGrid_dir: any = localStorage.getItem(this.Constants.Table_direction);
    this.AgGridDir = agGrid_dir;
    // this.gridApi.sizeColumnsToFit();
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
    this.gridApi.showLoadingOverlay();
    this.ShowProgressBar = true;
    if (String(event.data.name) === "") {
      console.log("empty is called");
      event.node.data.name = event.oldValue;
      this.gridApi.refreshCells();
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Required_field_Error), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      this.ShowProgressBar = false;
      this.gridApi.hideOverlay();
      return;
    }
    if (this.NotUniqueMainCat(String(event.data.name))) {
      console.log("Unique is called");
      this.NotificationService.error(this.translate.GetTranslation(this.Constants.Unique_Field_ERROR), '',
        this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
      event.node.data.name = event.oldValue;
      this.ShowProgressBar = false;
      this.gridApi.hideOverlay();
      return;
    }
    let MaindCat: ItemMainGategory = {
      id: event.data.id,
      name: event.data.name,
      subdomain: window.location.hostname.split('.')[0]
    }
    if (event.oldValue === event.newValue) return;
    this.ItemService.UpdateMainCat(MaindCat).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.Data_SAVED_success_status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        r.map((item: any) => {
          if (item.name === this.Constants.Uncategorized) {
            item.name = this.translate.GetTranslation(this.Constants.Uncategorized);
          }
        })

        console.log(r);
        this.gridApi.hideOverlay();
        this.gridApi.setRowData(r);
        this.ShowProgressBar = false;
      },
      error: (e) => {
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
        if (e[0].status === this.Constants.NullTenant || e.error.status === this.Constants.NullTenant)
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
              },
              error: e => {
                console.log(e);
              }
            }
          );
        },
        error: e => {
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

  ItemMainCatRowSelect(event: RowSelectedEvent) {
    this.gridApi_subCat.showLoadingOverlay();
    if (!event.node.isSelected()) {
      this.gridApi_subCat.hideOverlay();
      return
    };
    console.log(event);

    this.Items_Sub_Categories.subscribe(
      r => {
        this.gridApi_subCat.setRowData(
          r.filter((i) => {
            return i.itemMainCategoryId === Number(event.data.id);
          })
        )
      }
    );
    this.gridApi_subCat.hideOverlay();
  }

  externalFilterChanged_SubCAt(SubCatSearch: HTMLInputElement) {
    this.Items_Sub_Categories.subscribe(r => this.gridApi_subCat.setRowData(r));
    this.gridApi_subCat.setQuickFilter(SubCatSearch.value);
  }
  OnSubCatGridReady(event: GridReadyEvent) {
    this.gridApi_subCat = event.api;
    this.gridColumnApi_SubCat = event.columnApi;
    event.api.sizeColumnsToFit();
    let agGrid_dir: any = localStorage.getItem(this.Constants.Table_direction);
    this.AgGridDir = agGrid_dir;
  }
  //Helper Methods
  NotUniqueMainCat(value: string): boolean {
    let x: any = [];
    this.ItemsMainCategories.subscribe(

      r => {
        x = r.filter((item) => {
          console.log(item);
          return item.name === value;
        })
      }
    );
    console.log(x > 0);
    return x > 0;
  }
}
