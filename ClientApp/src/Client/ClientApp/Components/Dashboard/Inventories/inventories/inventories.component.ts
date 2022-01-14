import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, ColDefs, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, SweetAlertData } from 'src/Interfaces/interfaces';
import { Inventories, InventoryAddress } from '../../Models/inventories.model';
import { InventoriesService } from '../../Inventories/inventories.service';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { AddInventAddressComponent } from '../InventoryAddress/add-invent-address/add-invent-address.component';
import { EditInventAddressComponent } from '../InventoryAddress/edit-invent-address/edit-invent-address.component';
import { AddNewInventoryComponent } from '../add-new-inventory/add-new-inventory.component';
import { SpinnerService } from 'src/CommonServices/spinner.service';

@Component({
  selector: 'app-inventories',
  templateUrl: './inventories.component.html',
  styleUrls: ['./inventories.component.css']
})
export class InventoriesComponent implements OnInit, AfterViewInit
{

  Subdomain: string = window.location.hostname.split(".")[0];

  columns: ColDefs[] = [];
  AllInventories: Inventories[] = [];
  isLoadingResults: boolean = true;
  SelectedRows: Inventories[] = [];
  dataSource = new MatTableDataSource<any>();
  ShowProgressBar: boolean = true;
  AddedRow: any;
  PreventDeleteFor: any;
  ReferencialField: string = "inventoryAddress";
  FormBuilder: FormDefs = new FormDefs();
  Title: CardTitle[] = [];
  Subtitle: CardTitle[] = [];
  RowDeleted: boolean = false;
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private ServerResponseHandler: ServerResponseHandelerService,
    private InventoriesService: InventoriesService, private ClientValidaiton: ClientSideValidationService)
  {
  }

  ngOnInit(): void
  {

    this.Title = [{ text: this.Constants.Warehouses, needTranslation: true }];
    this.Subtitle = [{ text: this.Constants.Add_Edit_Delete, needTranslation: true },
    { text: this.Constants.Warehouses, needTranslation: true }];
    this.InventoriesService.GetAllInventories().subscribe(r =>
    {
      for (let x of r)
      {
        let add: InventoryAddress | undefined = x.inventoryAddress;
        if (add !== null)
        {
          x.inventAdd = (add?.buildingNo !== "" ? add?.buildingNo + '-' : '') +
            (add?.streetName !== '' ? this.translate.isRightToLeft(this.translate.GetCurrentLang()) ?
              this.translate.GetTranslation(this.Constants.St) + ' ' + add?.streetName + ", " : add?.streetName +
              ` ${this.translate.GetTranslation(this.Constants.St)}, ` : '') +
            (add?.addressLine_1 !== '' ? add?.addressLine_1 + ', ' : '') +
            (add?.addressLine_2 !== '' ? add?.addressLine_2 + ', ' : '') +
            (add?.flatNo !== '' ? this.translate.GetTranslation(this.Constants.Flat_No) + ':' + add?.flatNo + ', ' : '') +
            (add?.city !== '' ? add?.city + ',' : '') +
            (add?.government !== '' ? add?.government + ', ' : '') +
            (add?.countryName !== null ? add?.countryName : '');
          x.inventAdd = x.inventAdd.trim();
          if (x.inventAdd[x.inventAdd.length - 1] === ",")
          {
            x.inventAdd = x.inventAdd.slice(0, x.inventAdd.length - 1) + ".";
          }
        } else
        {
          x.inventAdd = "";
        }

      }
      if (r[0].warehouseName === this.Constants.MainWarehouse)
      {
        r[0].warehouseName = this.translate.GetTranslation(this.Constants.MainWarehouse);
      }
      this.AllInventories = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );


    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: '#' },
      { field: 'warehouseName', display: this.Constants.Name, preventDeleteFor: this.translate.GetTranslation(this.Constants.MainWarehouse) },
      { field: 'mobilePhone', display: "", HeaderfaIcon: faMobileAlt },
      { field: 'telephone', display: "", HeaderfaIcon: faPhone },
      { field: 'notes', display: this.Constants.Notes },
      { field: 'inventAdd', display: this.Constants.address },
      { field: 'isActive', display: this.Constants.Active, IsTrueOrFlase: true, True_faIcon: faCheckCircle, False_faIcon: faTimesCircle },
      { field: 'isMainInventory', display: this.Constants.Main, IsTrueOrFlase: true, True_faIcon: faCheckCircle, False_faIcon: faTimesCircle },
      { field: 'addedBy_UserName', display: this.Constants.addedBy_UserName },
    ];
  }


  Delete(invent: Inventories[])
  {
    this.SelectedRows = invent;
    this.ShowProgressBar = true;
    if (invent[0].warehouseName === this.translate.GetTranslation(this.Constants.MainWarehouse))
    {
      this.ClientValidaiton.Error_swal(this.Constants.Delete_Default_inventory_Error.toLowerCase())
        .then(r => { this.ShowProgressBar = false; });
      return;
    }
    this.ClientValidaiton.Warning(this.translate.GetTranslation(this.Constants.DeleteInventoryWarning))
      .then(r =>
      {
        if (r.isConfirmed)
        {
          this.spinner.fullScreenSpinner();
          this.InventoriesService.DeleteWarehouse(invent[0].id).subscribe({
            next: r =>
            {
              this.spinner.removeSpinner();
              this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
              this.AllInventories = this.AllInventories.filter((item) =>
              {
                return item.id !== invent[0].id;
              });
              this.InventoriesService.AllInventories = this.InventoriesService.AllInventories.filter(i => { return i.id !== invent[0].id; });
              this.dataSource.paginator?.getNumberOfPages();
              this.dataSource.data = this.AllInventories;
              this.ShowProgressBar = false;
              invent = [];
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
        } else
        {
          this.spinner.removeSpinner();
          this.RowDeleted = false;
        }
        this.ShowProgressBar = false;
      });
    this.RowDeleted = false;
  }

  SelectRow(event: any)
  {
    this.SelectedRows = event;
  }
  EditInventory(row: Inventories)
  {
    if (row.warehouseName === this.translate.GetTranslation(this.Constants.MainWarehouse))
    {
      this.ClientValidaiton.Error_swal(this.Constants.Delete_Default_inventory_Error)
        .then(r => { this.ShowProgressBar = false; });
      return;
    }
    let x: DataToEdit_PassToBottomSheet<Inventories> = { dataToEdit: row, Array: this.AllInventories, ShowProgressBar: this.ShowProgressBar };
    const ref = this.bottomSheet.open(EditInventoryComponent, {
      data: x
    });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<Inventories>) => { this.ShowProgressBar = r.ShowProgressBar; });
  }

  ngAfterViewInit()
  {

  }
  AddNewInvent(AddClicked: boolean)
  {
    if (AddClicked)
    {

      this.ShowProgressBar = true;
      let data: MatBottomSheetDismissData<Inventories> = {
        dataSource: this.dataSource, ShowBrogressBar: this.ShowProgressBar,
        addedRow: this.AddedRow, data: this.AllInventories, SelectedRows: this.SelectedRows
      };
      const AddInventBottomSheet = this.bottomSheet.open(AddNewInventoryComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: MatBottomSheetDismissData<Inventories>) =>
      {
        this.ShowProgressBar = r.ShowBrogressBar;
        this.SelectedRows = [];
        this.AddedRow = r.addedRow;
        this.SelectedRows.push(r.addedRow);
      });
      this.ShowProgressBar = false;
    }
  }

  AddAddress(row: Inventories)
  {
    this.bottomSheet.open(AddInventAddressComponent, {
      data: row
    });
  }
  EditAdress(row: Inventories)
  {

    this.bottomSheet.open(EditInventAddressComponent, {
      data: row
    });
  }
  DeleteAddress(row: Inventories)
  {
    this.spinner.fullScreenSpinner();
    this.InventoriesService.DeleteAddress(row.inventoryAddress?.id!).subscribe({
      next: r =>
      {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
        row.inventAdd = "";
      },
      error: e =>
      {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GetErrorNotification_swal(e);
      }
    });
  }
}
