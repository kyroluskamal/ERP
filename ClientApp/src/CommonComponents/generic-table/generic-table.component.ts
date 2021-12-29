import { Component, EventEmitter, HostListener, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Subscription } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, ColDefs, TableSlidingSections, ThemeColor } from 'src/Interfaces/interfaces';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatButton } from '@angular/material/button';
import { LightDarkThemeConverterService } from 'src/Client/ClientApp/Components/Dashboard/light-dark-theme-converter.service';
import { faEdit } from '@fortawesome/free-solid-svg-icons'
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'kiko-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class GenericTableComponent implements OnInit, OnChanges, OnDestroy {
  ThemeColors: ThemeColor = JSON.parse(JSON.stringify(localStorage.getItem(this.Constants.ChoosenThemeColors)));
  Subdomain: string = window.location.hostname.split(".")[0];
  faEdit = faEdit;
  ServerErrors: string = "";
  MaxLength: number = 30;
  TableAppearance: Subscription = new Subscription();
  ThemeSubscription: Subscription;
  ThemeColorSubscription: Subscription;
  ThemeDirection: Subscription;
  TableDir_subscriptions: Subscription;
  DarkOrLight: string = "";
  Table_Color_mode: string = "";
  TableDirection: 'rtl' | 'ltr';
  Theme_dir: 'rtl' | 'ltr';
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = [];
  ShowHideColumns: string[] = [];
  items: any[] = [];
  resultsLength = 0;
  SelectedRows: any[] = [];
  itemPageLabel = "";
  firstPageLabel = "";
  lastPageLabel = "";
  previousPageLabel = "";
  nextPageLabel = "";
  isLoadingRes: boolean = true;
  ShowProgressbar: boolean = true;
  SettingsMenuOpenned: boolean = false;
  RefField: string = "";
  PreventFor: string = "";
  AddButton_Text: CardTitle[] = [];
  MediaSubscription: Subscription = new Subscription();
  FilterSectionHeight: string = "";
  expandedElement: any | null = null;
  noData: boolean = true;
  ToolTipText: string = "";
  gridCols: number = 3;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<any>;
  @ViewChild("tableSettingsButton") tableSetting!: MatButton;
  @Input() columns: ColDefs[] = [];
  @Input() isLoadingResults: boolean = true;
  @Input() ShowProgressBar: boolean = true;
  @Input() NoData: boolean = false;
  @Input() data: any[] = []
  @Input() AddedRow: any;
  @Input() PreventDeleteForValue: any;
  @Input() PreventDeleteForKey: string = "";
  @Input() PreventDeleteForIndex: any;
  @Input() ReferencialField: string = "";
  @Input() ToolTipText_input: string = "";
  @Input() ShowFilterSection: boolean = true;
  @Input() ShowPaginator: boolean = true;
  @Input() datasource: MatTableDataSource<any> = new MatTableDataSource<any>();
  @Input() AddButtonText: CardTitle[] = [];
  @Input() HasCollabsableRow: boolean = false;
  @Input() RowDeleted: boolean = false;
  @Input() CollabsableDataSections: TableSlidingSections[] = [];
  @Output() rowsSelection: EventEmitter<any[]> = new EventEmitter();
  @Output() DoubleClickRow: EventEmitter<any> = new EventEmitter();
  @Output() DeleteClick: EventEmitter<any> = new EventEmitter();
  @Output() EditClick: EventEmitter<any> = new EventEmitter();
  @Output() ReferencialField_AddClick: EventEmitter<any> = new EventEmitter();
  @Output() ReferencialField_EditClick: EventEmitter<any> = new EventEmitter();
  @Output() ReferencialField_DeleteClick: EventEmitter<any> = new EventEmitter();
  @Output() ClickAddButton: EventEmitter<boolean> = new EventEmitter();
  constructor(
    public Constants: ConstantsService, private spinner: SpinnerService,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private LightOrDarkConverter: LightDarkThemeConverterService, private mediaObserver: MediaObserver,
  ) {

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
    let tableDir: any = localStorage.getItem(this.Constants.Table_direction);
    this.TableDirection = tableDir;
    this.TableDir_subscriptions = this.LightOrDarkConverter.agGridTable_dir$.subscribe(x => {
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
    this.dataSource = this.datasource;
    this.RefField = this.ReferencialField;
    this.noData = this.NoData;

  }

  ngOnDestroy(): void {
    this.ThemeSubscription.unsubscribe();
    this.ThemeColorSubscription.unsubscribe();
    this.TableDir_subscriptions.unsubscribe();
    this.TableAppearance.unsubscribe();
    this.ThemeDirection.unsubscribe();
  }
  ngOnInit(): void {

    setTimeout(() => {
      this.itemPageLabel = this.translate.GetTranslation(this.Constants.ItemPerPageLabal);
      this.firstPageLabel = this.translate.GetTranslation(this.Constants.FirstPage);
      this.lastPageLabel = this.translate.GetTranslation(this.Constants.LastPage);
      this.previousPageLabel = this.translate.GetTranslation(this.Constants.PreviousPage);
      this.nextPageLabel = this.translate.GetTranslation(this.Constants.NextPage);
    }, 1000);

    this.columns.filter((el) => {
      this.displayedColumns.push(el.field);
      this.ShowHideColumns.push(el.field)
    });
    if (this.HasCollabsableRow) {
      this.displayedColumns.unshift('expand');
    }
    // this.displayedColumns.push(this.Constants.Delete);
    // this.displayedColumns.push(this.Constants.Edit);
    // this.setDisplayedColumns();
    this.datasource.sort = this.sort;
    this.dataSource.sort = this.sort;
    this.ShowProgressbar = this.ShowProgressBar;
    this.isLoadingRes = this.isLoadingResults;
    this.RefField = this.ReferencialField;
    this.PreventFor = this.PreventDeleteForValue;
    this.AddButton_Text = this.AddButtonText;

    if (this.isLoadingResults) {
      this.spinner.InsideContainerSpinner();
    } else {
      this.spinner.removeSpinner();
    }
    this.ToolTipText = this.ToolTipText_input;
  }
  ngOnChanges(changes: SimpleChanges) {
    if (changes['data']) {
      this.dataSource = this.datasource;
      this.dataSource.sort = this.sort;
    }
    if (changes["AddedRow"]) {
      this.SelectedRows = [];
      this.SelectedRows.push(this.AddedRow);
    }
    if ("isLoadingResults" in changes) {
      this.isLoadingRes = this.isLoadingResults;
      if (this.isLoadingResults) {
        this.spinner.InsideContainerSpinner();
      } else this.spinner.removeSpinner();
    }
    if ("ShowProgressBar" in changes) {
      this.ShowProgressbar = this.ShowProgressBar;
    }
    if ("NoData" in changes) {
      this.noData = this.NoData;
    }
    if ("PreventDeleteForValue" in changes) {
      this.PreventFor = this.PreventDeleteForValue;
    }
    if ("ReferencialField" in changes) {
      this.RefField = this.ReferencialField;
    }
    if ("AddButtonText" in changes) {
      this.AddButton_Text = this.AddButtonText;
    }
    if ("ToolTipText_input" in changes) {
      this.ToolTipText = this.ToolTipText_input;
    }
    if ("RowDeleted" in changes) {
      this.SelectedRows = [];
    }
  }
  dropListDropped(event: CdkDragDrop<string[]>) {
    if (event) {
      moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
      moveItemInArray(this.ShowHideColumns, event.previousIndex, event.currentIndex);
    }
  }
  @HostListener('window:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    let Backspace = event.key === "Backspace";
    let Delete = event.key === "Delete";
    let Shift = event.shiftKey;
    if ((Backspace && Shift) || (Delete && Shift))
      this.ShiftDelete((Backspace && Shift) || (Delete && Shift));
    if (event.key === "Enter" && Shift)
      this.ShiftEnter(event.key === "Enter" && Shift);
    if (event.ctrlKey && event.key === "/") {
      this.AddClicked();
    }
    this.SelectionByKeyboard(event.key);
  }
  SelectRow(row: any) {
    if (this.SelectedRows.includes(row))
      this.SelectedRows.pop();
    else {
      this.SelectedRows = [];
      this.SelectedRows.push(row);
    }
    this.rowsSelection.emit(this.SelectedRows)
  }


  ngAfterViewInit() {
    this.MediaSubscription = this.mediaObserver.asObservable().subscribe(
      (response: MediaChange[]) => {
        if (response.some(x => x.mqAlias === 'xs')) {
          this.FilterSectionHeight = "100px"

        } else {
          this.FilterSectionHeight = '50px';
        }
      });
    setTimeout(() => {
      this.paginator._intl.itemsPerPageLabel = this.itemPageLabel
      this.paginator._intl.firstPageLabel = this.firstPageLabel;
      this.paginator._intl.lastPageLabel = this.lastPageLabel;
      this.paginator._intl.previousPageLabel = this.previousPageLabel;
      this.paginator._intl.nextPageLabel = this.nextPageLabel;
      this.dataSource.paginator = this.paginator;
    }, 1000);
    this.dataSource.sort = this.sort;
  }

  Dbclick(row: any) {
    this.DoubleClickRow.emit(row);
  }
  ShiftDelete(requiredKeys: boolean) {
    if (requiredKeys && this.SelectedRows.length > 0) {
      this.Delete();
    }
  }
  SelectionByKeyboard(key: string) {
    let PageData = (this.dataSource.sort?.direction === 'desc' || this.dataSource.sort?.direction === 'asc') ?
      this.dataSource._pageData(this.dataSource.sortData(this.dataSource.data, this.sort)) :
      this.dataSource._pageData(this.dataSource.data);

    let CurrentIndex = PageData.indexOf(this.SelectedRows[0]);
    if (this.SelectedRows.length > 0 && (key === this.Constants.ArrowDown
      || key === this.Constants.ArrowUp)) {
      //Case one:  ---------------------------------------------------------
      //If no rows are selected in the current page
      if (CurrentIndex === -1) {
        this.SelectedRows = [];
        this.SelectedRows.push(PageData[0]);
        //Case Tow: ----------------------------------------------------------
        //If the first row is selected in the current page
      } else if (CurrentIndex === 0) {
        //if the first row is selected and the ArrowDown is pressed
        if (key === this.Constants.ArrowDown) {
          this.SelectedRows = [];
          this.SelectedRows.push(PageData[CurrentIndex + 1]);
          //if the first row is selected and the ArrowUp is pressed
        } else if (key === this.Constants.ArrowUp) {
          if (this.dataSource.paginator?.hasPreviousPage()) {
            this.dataSource.paginator.previousPage();
            PageData = this.dataSource._pageData(this.dataSource.data);
            this.SelectedRows = [];
            this.SelectedRows.push(PageData[PageData.length - 1])
          }
        }
        //Case Three: ----------------------------------------- ------------------
        //if the last row is selected in the current page
      } else if (CurrentIndex === PageData.length - 1) {
        //if the last row is selected and the ArroDown is pressed
        if (key === this.Constants.ArrowDown) {
          if (this.dataSource.paginator?.hasNextPage()) {
            this.dataSource.paginator.nextPage();
            PageData = this.dataSource._pageData(this.dataSource.data);
            this.SelectedRows = [];
            this.SelectedRows.push(PageData[0]);
          }
        } else if (key === this.Constants.ArrowUp) {
          this.SelectedRows = []
          this.SelectedRows.push(PageData[CurrentIndex - 1])
        }
        //Case Four: --------------------------------------------------------------
        //if the selected row is in the middle of the page
      } else {
        if (key === this.Constants.ArrowDown) {
          this.SelectedRows = [];
          this.SelectedRows.push(PageData[CurrentIndex + 1]);
        } else if (key === this.Constants.ArrowUp) {
          this.SelectedRows = [];
          this.SelectedRows.push(PageData[CurrentIndex - 1])
        }
      }
      this.rowsSelection.emit(this.SelectedRows);
    } else if (this.SelectedRows.length === 0 && (key === this.Constants.ArrowDown || key === this.Constants.ArrowUp)) {
      this.SelectedRows.push(PageData[0]);
      this.rowsSelection.emit(this.SelectedRows);
    }

  }
  ShiftEnter(ShidtEnter: boolean) {
    if (ShidtEnter && this.SelectedRows.length > 0) {
      this.Dbclick(this.SelectedRows[0])
    }
  }
  Filter(value: string) {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  TableSettingClick() {
    this.tableSetting._elementRef.nativeElement.style = "transform: rotate(100deg); transition:300ms"
    this.tableSetting._elementRef.nativeElement.style = ""
  }
  Delete() {
    if (this.SelectedRows.length > 0) {
      this.DeleteClick.emit(this.SelectedRows);
    }
  }
  Edit() {
    if (this.SelectedRows.length > 0) {
      this.EditClick.emit(this.SelectedRows[0]);
    }
  }
  SettingChange(col: ColDefs, index: number) {
    let colIndex = this.displayedColumns.indexOf(col.field);
    if (colIndex !== -1) {
      this.displayedColumns = this.displayedColumns.filter((i) => {
        return i != col.field;
      })
    } else if (colIndex === -1) {
      this.displayedColumns.push(col.field);
      this.displayedColumns.sort((a, b) => this.ShowHideColumns.indexOf(a) -
        this.ShowHideColumns.indexOf(b));
    }
  }
  AddReferencialData(row: any) {
    this.ReferencialField_AddClick.emit(row);
  }
  EditReferencialData(row: any) {
    this.ReferencialField_EditClick.emit(row);
  }
  DeleteReferencialData(row: any) {
    this.ReferencialField_DeleteClick.emit(row);
  }
  AddClicked() {
    this.ClickAddButton.emit(true);
  }
}
