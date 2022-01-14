import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, ColDefs, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, SweetAlertData } from 'src/Interfaces/interfaces';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { Item, Units } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';
import { EditItemUnitsComponent } from '../edit-item-units/edit-item-units.component';
import { AddNewItemUnitsComponent } from '../add-new-item-units/add-new-item-units.component';
@Component({
  selector: 'app-item-units',
  templateUrl: './item-units.component.html',
  styleUrls: ['./item-units.component.css']
})
export class ItemUnitsComponent implements OnInit
{

  Subdomain: string = window.location.hostname.split(".")[0];
  columns: ColDefs[] = [];
  AllItems: Units[] = [];
  isLoadingResults: boolean = true;
  SelectedRows: Units[] = [];
  dataSource = new MatTableDataSource<Units>();
  ShowProgressBar: boolean = true;
  AddedRow: any;
  FormBuilder: FormDefs = new FormDefs();
  Title: CardTitle[] = [];
  Subtitle: CardTitle[] = [];
  RowDeleted: boolean = false;

  constructor(private spinner: SpinnerService, public Constants: ConstantsService,
    private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService,
    private ServerResponseHandler: ServerResponseHandelerService,
    private ItemService: ItemsService, private ClientValidaiton: ClientSideValidationService)
  {

  }

  ngOnInit(): void
  {
    this.Title = [{ text: this.Constants.Item_Units, needTranslation: true }];
    this.Subtitle = [{ text: this.Constants.Add_Edit_Delete, needTranslation: true },
    { text: this.Constants.Item_Units, needTranslation: true }
    ];
    this.ItemService.Get_All_ItemUnits().subscribe(
      r =>
      {
        this.AllItems = r;
        this.dataSource.data = r;
        this.isLoadingResults = false;
        this.ShowProgressBar = false;
      });
    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: "#" },
      { field: this.Constants.wholeSaleUnit, display: this.Constants.wholeSaleUnit },
      { field: this.Constants.numberInWholeSale, display: this.Constants.numberInWholeSale },
      { field: this.Constants.retailUnit, display: this.Constants.retailUnit },
      { field: this.Constants.numberInRetailSale, display: this.Constants.numberInRetailSale },
      { field: this.Constants.conversionRate, display: this.Constants.conversionRate },
    ];
  }
  Delete(Units: Units[])
  {
    this.SelectedRows = Units;
    this.ShowProgressBar = true;
    this.spinner.fullScreenSpinner();
    this.ItemService.Delete_ItemUnit(Units[0].id).subscribe({
      next: r =>
      {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
        this.AllItems = this.AllItems.filter((item) => { return item.id !== Units[0].id; });

        this.dataSource.data = this.AllItems;
        this.ShowProgressBar = false;
        Units = [];
        this.RowDeleted = true;
      },
      error: e =>
      {
        this.ShowProgressBar = false;
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GetErrorNotification_swal(e);
        this.ShowProgressBar = false;
      }
    });

    this.RowDeleted = false;
  }
  SelectRow(event: any) { this.SelectedRows = event; }

  Edit(row: Units)
  {
    let x: DataToEdit_PassToBottomSheet<Units> = {
      dataToEdit: row,
      Array: this.AllItems, ShowProgressBar: this.ShowProgressBar
    };
    const ref = this.bottomSheet.open(EditItemUnitsComponent, { data: x });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<Units>) =>
    {
      this.ShowProgressBar = r.ShowProgressBar;
    });
  }
  ngAfterViewInit() { }
  AddNew(AddClicked: boolean)
  {
    if (AddClicked)
    {
      this.ShowProgressBar = true;
      let data: MatBottomSheetDismissData<Units> = {
        dataSource: this.dataSource, ShowBrogressBar: this.ShowProgressBar,
        addedRow: this.AddedRow, data: this.AllItems, SelectedRows: this.SelectedRows
      };
      const AddInventBottomSheet = this.bottomSheet.open(AddNewItemUnitsComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe(
        (r: MatBottomSheetDismissData<Units>) =>
        {
          this.ShowProgressBar = r.ShowBrogressBar;
          this.SelectedRows = [];
          this.AddedRow = r.addedRow;
          this.SelectedRows.push(r.addedRow);
        });
      this.ShowProgressBar = false;
    }
  }


}
