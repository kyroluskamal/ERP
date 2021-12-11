import { AfterViewInit, Component, ElementRef, HostListener, Inject, OnInit, Renderer2, ViewChild, ViewContainerRef } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map, Observable, Subscription, tap } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { NotificationsService } from 'src/CommonServices/NotificationService/notifications.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CustomErrorStateMatcher } from 'src/Helpers/CustomErrorStateMatcher/custom-error-state-matcher';
import { ColDefs, ThemeColor } from 'src/Interfaces/interfaces';
import { Inventories } from '../../Models/inventories.model';
import { LightDarkThemeConverterService } from '../../light-dark-theme-converter.service';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'

import { MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';

@Component({
  selector: 'app-inventories',
  templateUrl: './inventories.component.html',
  styleUrls: ['./inventories.component.css']
})
export class InventoriesComponent implements OnInit, AfterViewInit {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split(".")[0];
  ServerErrors: string = "";
  MaxLength: number = 30;
  AddNewInventory: FormGroup = new FormGroup({});
  LangSubscibtion: Subscription = new Subscription();
  customErrorStateMatcher: CustomErrorStateMatcher = new CustomErrorStateMatcher()
  loading: boolean = false;
  TableAppearance: Subscription = new Subscription();
  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  AgGridTable_dir: Subscription;
  DarkOrLight: string = "";
  Table_Color_mode: string = "";
  TableDirection: 'rtl' | 'ltr';
  Theme_dir: 'rtl' | 'ltr';
  columns: ColDefs[] = [];
  displayedColumns: string[] = [];
  ShowHideColumns: string[] = [];
  AllInventories: Inventories[] = [];
  resultsLength = 0;
  isLoadingResults = true;
  SelectedRows: Inventories[] = [];
  dataSource = new MatTableDataSource<any>();
  ShowProgressBar: boolean = true;
  itemPageLabel = "";
  firstPageLabel = "";
  lastPageLabel = "";
  previousPageLabel = "";
  nextPageLabel = "";
  AddedRow: any;
  PreventDeleteFor: any;
  constructor(private NotificationService: NotificationsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories,
    private InventoriesService: InventoriesService) {

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
    let agGrid_dir: any = localStorage.getItem(this.Constants.Table_direction);
    this.TableDirection = agGrid_dir;
    this.AgGridTable_dir = this.LightOrDarkConverter.agGridTable_dir$.subscribe(x => {
      this.TableDirection = x;
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

    this.columns = [
      { field: 'id', display: '#' },
      { field: 'name', display: this.Constants.Name, preventDeleteFor: this.translate.GetTranslation(this.Constants.MainWarehouse) },
      { field: 'mobilePhone', display: "", HeaderfaIcon: this.faMobileAlt },
      { field: 'telephone', display: "", HeaderfaIcon: this.faPhone },
      { field: 'notes', display: this.Constants.Notes },
      { field: 'isActive', display: this.Constants.Active, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'isMainInventory', display: this.Constants.Main, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'addedBy_UserName', display: this.Constants.AddedBy },
    ];
    this.AddNewInventory = new FormGroup({
      Name: new FormControl(null),
      IsMain: new FormControl(null),
      Phone: new FormControl(null),
      Mobile: new FormControl(null),
      IsActive: new FormControl(null),
      Notes: new FormControl(null)
    });

    this.InventoriesService.GetAllInventories().pipe(tap(
      r => {
        for (let x of r) {
          if (x.name === this.Constants.MainWarehouse) {
            x.name = this.translate.GetTranslation(this.Constants.MainWarehouse);
            this.PreventDeleteFor = x;
          }
        }
      }
    )).subscribe(r => {
      console.log(r);
      this.AllInventories = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );
    console.log(this.AllInventories);
  }


  Delete(invent: Inventories) {
    this.ShowProgressBar = true;
    this.InventoriesService.DeleteWarehouse(invent.id).subscribe({
      next: r => {
        this.NotificationService.success(this.translate.GetTranslation(r.status),
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        this.AllInventories = this.AllInventories.filter((item) => {
          return item.id !== invent.id;
        })
        this.dataSource.data = this.AllInventories;
        this.ShowProgressBar = false;
      },
      error: e => {
        this.ShowProgressBar = false;
        if (Array.isArray(e)) {
          this.NotificationService.error(this.translate.GetTranslation(e[0].status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        } else
          this.NotificationService.error(this.translate.GetTranslation(e.error.status), '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');

        this.ShowProgressBar = false;
      }
    })
  }
  Dbclick(row: Inventories) {
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
    });

  }

  SelectRow(event: any) {
    this.SelectedRows = event;
  }
  EditInventory(row: Inventories) {
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
    });
  }


  ShiftDelete(requiredKeys: boolean) {
    if (this.SelectedRows.length > 0 && requiredKeys) {
      if (this.SelectedRows[0].name === this.Constants.MainWarehouse) {
        this.NotificationService.error(this.translate.GetTranslation(this.Constants.Delete_Default_inventory_Error), '',
          this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr')
      } else {
        this.Delete(this.SelectedRows[0]);
        this.SelectedRows = [];
      }
    }
  }
  ngAfterViewInit() {
    console.log(this.AllInventories)

  }
  AddNewInvetory() {
    this.ShowProgressBar = true;
    this.isLoadingResults = true;

    let CurrentUser: any = localStorage.getItem(this.Constants.Client);
    CurrentUser = JSON.parse(CurrentUser);
    let newInvent: Inventories = {
      id: 0,
      name: this.AddNewInventory.get("Name")?.value,
      mobilePhone: this.AddNewInventory.get("Mobile")?.value,
      telephone: this.AddNewInventory.get("Phone")?.value,
      isActive: Boolean(this.AddNewInventory.get("IsActive")?.value),
      isMainInventory: Boolean(this.AddNewInventory.get("IsMain")?.value),
      notes: this.AddNewInventory.get("Notes")?.value,
      addedBy_UserId: CurrentUser.userId,
      addedBy_UserName: CurrentUser.username,
      subdomain: this.Subdomain
    }
    this.InventoriesService.AddWarehouse(newInvent).subscribe(
      {
        next: (r) => {
          this.AllInventories.push(r);
          this.SelectedRows = [];
          this.SelectedRows.push(r);
          this.AddedRow = r;
          this.dataSource.data = this.AllInventories;
          this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          setTimeout(() => {
            this.dataSource.paginator?.lastPage();
          }, 500);

        },
        error: (e) => {
          let translatedError: string = "";
          if (Array.isArray(e)) {
            if (typeof (e[0].status) === "string")
              translatedError += this.translate.GetTranslation(e[0].status);
            if (e[0].errors) {
              if (e[0].errors.Name)
                for (let err of e[0].errors.Name) {
                  if (err === this.Constants.MaxLengthExceeded_ERROR)
                    translatedError += `(${this.translate.GetTranslation(this.Constants.WarehouseName)}) ${this.translate.GetTranslation(err)} ${this.MaxLength}
                  ${this.translate.GetTranslation(this.Constants.characters)}`;
                  else
                    translatedError += `(${this.translate.GetTranslation(this.Constants.WarehouseName)}) ${this.translate.GetTranslation(err)}`
                }
              if (e[0].errors.Telephone) {
                translatedError += ` (${this.translate.GetTranslation(this.Constants.TelephoneNumber)})
                ${this.translate.GetTranslation(e[0].errors.Telephone[0])}`;
              }
              if (e[0].errors.MobilePhone) {
                translatedError += ` (${this.translate.GetTranslation(this.Constants.CellPhoneNumber)})
                ${this.translate.GetTranslation(e[0].errors.MobilePhone[0])}`;
              }
            }
          } else if (e.error.status)
            translatedError += this.translate.GetTranslation(e.error.status);

          else if (e.status === 401 && e.error === null) {
            translatedError += this.translate.GetTranslation(this.Constants.Unauthorized_Error)
          }
          this.NotificationService.error(translatedError, '',
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
        }
      });
    this.AddNewInventory.reset();
    this.isLoadingResults = false;
    this.ShowProgressBar = false
  }

}
