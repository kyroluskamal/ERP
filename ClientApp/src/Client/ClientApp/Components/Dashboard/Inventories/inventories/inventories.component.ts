import { AfterViewInit, Component, ElementRef, HostListener, Inject, OnInit, ViewChild } from '@angular/core';
import { CdkDragDrop, CdkDragStart, CdkDropList, moveItemInArray } from '@angular/cdk/drag-drop';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map, Subscription } from 'rxjs';
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
import { SuppliersService } from '../../Suppliers/suppliers.service';
import { faMobileAlt, faPhone, faPenAlt, faEdit } from '@fortawesome/free-solid-svg-icons'
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';
import { ClientWithToken } from 'src/Client/Models/client-models.model';

@Component({
  selector: 'app-inventories',
  templateUrl: './inventories.component.html',
  styleUrls: ['./inventories.component.css']
})
export class InventoriesComponent implements OnInit {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
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
  previousIndex: number = 0;
  columns: ColDefs[] = [];
  displayedColumns: string[] = [];
  AllInventories: Inventories[] = [];
  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;
  SelectedRows: Inventories[] = [];
  dataSource = new MatTableDataSource<Inventories>();
  ShowProgressBar: boolean = false;
  constructor(private NotificationService: NotificationsService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: Inventories,
    private InventoriesService: InventoriesService, private SuppliersSerive: SuppliersService) {
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
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Inventories>;

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
      { field: 'name', display: this.Constants.Name },
      { field: 'mobilePhone', display: "" },
      { field: 'telephone', display: "" },
      { field: 'notes', display: this.Constants.Notes },
      { field: 'isActive', display: this.Constants.Active },
      { field: 'isMainInventory', display: this.Constants.Main },
      { field: 'addedBy_UserId', display: this.Constants.AddedBy },
    ];
    this.AddNewInventory = new FormGroup({
      Name: new FormControl(null),
      IsMain: new FormControl(null),
      Phone: new FormControl(null),
      Mobile: new FormControl(null),
      IsActive: new FormControl(null),
      Notes: new FormControl(null)
    });
    for (let col of this.columns)
      this.displayedColumns.push(col.field)
    this.displayedColumns.push(this.Constants.Delete);
    this.displayedColumns.push(this.Constants.Edit);
    // this.setDisplayedColumns();
    this.dataSource.sort = this.sort;
    this.InventoriesService.GetAllInventories().subscribe(r => {
      this.AllInventories = r;
      this.dataSource.data = r as Inventories[];
      this.isLoadingResults = false;
      this.isRateLimitReached = r === null;
    }
    );

  }


  GetCurrentIndex(index: number) {
    this.previousIndex = index;
  }


  dropListDropped(event: CdkDragDrop<string[]>) {
    if (event) {
      moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
    }
  }


  Delete(index: number) {

  }
  Dbclick(row: Inventories) {
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
    });

  }

  SelectRow(row: Inventories) {
    if (this.SelectedRows.includes(row))
      this.SelectedRows.pop();
    else {
      this.SelectedRows = [];
      this.SelectedRows.push(row);
    }
  }
  EditInventory(row: Inventories) {
    this.bottomSheet.open(EditInventoryComponent, {
      data: row
    });
  }
  @HostListener('window:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    let Backspace = event.key === "Backspace";
    let Delete = event.key === "Delete";
    let Shift = event.shiftKey
    this.ShiftDelete((Backspace && Shift) || (Delete && Shift));
  }

  ShiftDelete(requiredKeys: boolean) {
    if (this.SelectedRows.length > 0 && requiredKeys) {
      console.log(requiredKeys);

    }
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator
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
    console.log(newInvent);
    this.InventoriesService.AddNewInvetore(newInvent).subscribe(
      {
        next: (r) => {
          this.AllInventories.push(r);
          this.dataSource.data = this.AllInventories;
          this.NotificationService.success(this.translate.GetTranslation(this.Constants.DataAddtionStatus_Success),
            this.translate.isRightToLeft(this.translate.GetCurrentLang()) ? 'rtl' : 'ltr');
          console.log(r);
        },
        error: (e) => {
          let translatedError: string = "";
          console.log(e);
          if (Array.isArray(e)) {
            if (Number.isNaN(e[0].status))
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
