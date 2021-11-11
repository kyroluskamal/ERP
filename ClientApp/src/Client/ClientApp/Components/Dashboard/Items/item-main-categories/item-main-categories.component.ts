import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';
import { catchError, map, Observable, Subscription, tap, throwError } from 'rxjs';
import { ClientAccountService } from 'src/Client/MainDomain/Authentication/client-account-service.service';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ItemMainGategory } from '../../Models/Items/item-main-gategory.model';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-main-categories',
  templateUrl: './item-main-categories.component.html',
  styleUrls: ['./item-main-categories.component.css']
})
export class ItemMainCategoriesComponent implements OnInit, OnDestroy {
  ItemsMainCategories: Observable<ItemMainGategory[]> = new Observable<ItemMainGategory[]>();
  ItemMainCat: ItemMainGategory = new ItemMainGategory();
  defaultColDef: ColDef = {
    flex: 1,
    minWidth: 120,
    filter: true,
    sortable: true
  };
  columnDefs: ColDef[] = [
    {
      headerName: "#id", field: 'id',
      filter: true,
      maxWidth: 100
    },
    { headerName: "Name", field: 'name', editable: true, filter: true },
  ];

  gridApi: GridApi = new GridApi();
  gridColumnApi: any;
  GlobalSearchValue: string = "";


  AddMainCatForm: FormGroup = new FormGroup({});
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  selected: any;
  loading: boolean = false;
  IsTenantFound: Subscription = new Subscription();
  ageType: any;
  ErrorGettingAllMainCats: any[] = [];


  //Constructor ........................................................................
  constructor(public ItemService: ItemsService, private NotificationService: NotificationsService,
    public Constants: ConstantsService, private clientAccountService: ClientAccountService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
  ) {
    this.ItemsMainCategories = this.ItemService.GetAllGategories();
  }
  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
    this.IsTenantFound.unsubscribe();
  }
  ngOnInit(): void {
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response) => {
        this.selected = response;
      }
    );
    this.AddMainCatForm = new FormGroup({
      CatName: new FormControl('', Validators.required)
    });

  }
  // @HostListener('window : load')
  // onWindowLoad() {
  //   console.log("Called")
  //   this.clientAccountService.IsTenantFound().subscribe(
  //     {
  //       error: error => { this.ErrorGettingAllMainCats = error; return }
  //     }
  //   );
  // }

  AddMainCategory() {

    this.loading = true;
    this.ItemService.AddMainCat(this.AddMainCatForm.get("CatName")?.value).subscribe({
      next: (response) => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.loading = false;
        this.ItemsMainCategories.subscribe((MainCatLists) => this.gridApi.setRowData(MainCatLists));
      },
      error: error => {
        this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.ErrorGettingAllMainCats = error;
      }
    });

  }

  GetMainCatId(MainCat: ItemMainGategory): string {
    return MainCat.id.toString();
  }
  OnGridReady(event: GridReadyEvent) {
    this.gridApi = event.api;
    this.gridColumnApi = event.columnApi;
    event.api.sizeColumnsToFit();
  }

  externalFilterChanged(MainCatSearch: HTMLInputElement) {
    this.gridApi.setQuickFilter(MainCatSearch.value)
  }


}
