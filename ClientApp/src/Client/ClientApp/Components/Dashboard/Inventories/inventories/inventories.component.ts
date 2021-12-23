import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, ColDefs, FormDefs, SweetAlertData } from 'src/Interfaces/interfaces';
import { Inventories, InventoryAddress } from '../../Models/inventories.model';
import { InventoriesService } from '../../Inventories/inventories.service'
import { MatBottomSheet, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'
import { MatTableDataSource } from '@angular/material/table';
import { EditInventoryComponent } from '../edit-inventory/edit-inventory.component';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { AddInventAddressComponent } from '../InventoryAddress/add-invent-address/add-invent-address.component';
import { EditInventAddressComponent } from '../InventoryAddress/edit-invent-address/edit-invent-address.component';
import { AddNewInventoryComponent } from '../add-new-inventory/add-new-inventory.component';

@Component({
  selector: 'app-inventories',
  templateUrl: './inventories.component.html',
  styleUrls: ['./inventories.component.css']
})
export class InventoriesComponent implements OnInit, AfterViewInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
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
  AddButtonText: CardTitle[] = [];
  constructor(
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private ServerResponseHandler: ServerResponseHandelerService,
    private InventoriesService: InventoriesService, private ClientValidaiton: ClientSideValidationService) {
  }

  ngOnInit(): void {
    this.InventoriesService.GetAllInventories().subscribe(r => {
      for (let x of r) {
        let add: InventoryAddress | undefined = x.inventoryAddress;
        if (add !== null) {
          x.inventAdd = (add?.buildingNo !== "" ? add?.buildingNo + '-' : '') +
            (add?.streetName !== '' ? this.translate.isRightToLeft(this.translate.GetCurrentLang()) ?
              this.translate.GetTranslation(this.Constants.St) + ' ' + add?.streetName : add?.streetName +
              ` ${this.translate.GetTranslation(this.Constants.St)} ` : '') +
            (add?.addressLine_1 !== '' ? add?.addressLine_1 + ', ' : '') +
            (add?.addressLine_2 !== '' ? add?.addressLine_2 + ', ' : '') +
            (add?.flatNo !== '' ? this.translate.GetTranslation(this.Constants.Flat_No) + ':' + add?.flatNo + ', ' : '') +
            (add?.city !== '' ? add?.city + ',' : '') +
            (add?.government !== '' ? add?.government + ', ' : '') +
            (add?.countryName !== null ? add?.countryName : '');
          x.inventAdd = x.inventAdd.trim();
          if (x.inventAdd[x.inventAdd.length - 1] === ",") {
            console.log(x.inventAdd.slice(0, x.inventAdd.length - 1))
            x.inventAdd = x.inventAdd.slice(0, x.inventAdd.length - 1) + ".";
          }
        } else {
          x.inventAdd = "";
        }

      }
      if (r[0].warehouseName === this.Constants.MainWarehouse) {
        r[0].warehouseName = this.translate.GetTranslation(this.Constants.MainWarehouse);
      }
      this.AllInventories = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );
    this.AddButtonText = [
      { text: this.Constants.Add, needTranslation: true },
      { text: this.Constants.Warehouse_Singular, needTranslation: true }
    ]
    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: '#' },
      { field: 'warehouseName', display: this.Constants.Name, preventDeleteFor: this.translate.GetTranslation(this.Constants.MainWarehouse) },
      { field: 'mobilePhone', display: "", HeaderfaIcon: this.faMobileAlt },
      { field: 'telephone', display: "", HeaderfaIcon: this.faPhone },
      { field: 'notes', display: this.Constants.Notes },
      { field: 'inventAdd', display: this.Constants.address },
      { field: 'isActive', display: this.Constants.Active, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'isMainInventory', display: this.Constants.Main, IsTrueOrFlase: true, True_faIcon: this.faCheckCircle, False_faIcon: this.faTimesCircle },
      { field: 'addedBy_UserName', display: this.Constants.AddedBy },
    ];
  }


  Delete(invent: Inventories) {
    this.ShowProgressBar = true;
    if (invent.id === 1) {
      this.ClientValidaiton.Error_swal(this.Constants.Delete_Default_inventory_Error)
        .then(r => { this.ShowProgressBar = false; });
      return;
    }
    this.ClientValidaiton.Warning(this.translate.GetTranslation(this.Constants.DeleteInventoryWarning))
      .then(r => {
        if (r.isConfirmed) {
          this.InventoriesService.DeleteWarehouse(invent.id).subscribe({
            next: r => {
              this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
              this.AllInventories = this.AllInventories.filter((item) => {
                return item.id !== invent.id;
              })
              this.dataSource.paginator?.getNumberOfPages();
              this.dataSource.data = this.AllInventories;
              this.ShowProgressBar = false;
              this.SelectedRows = [];
            },
            error: e => {
              this.ShowProgressBar = false;
              this.ServerResponseHandler.GetErrorNotification_swal(e);
              this.ShowProgressBar = false;
            }
          });
        }
        this.ShowProgressBar = false;
      })
  }
  Dbclick(row: Inventories) {
    let x: { dataToEdit: Inventories, Array: any[] } = { dataToEdit: row, Array: this.AllInventories }
    this.bottomSheet.open(EditInventoryComponent, {
      data: x
    });
  }

  SelectRow(event: any) {
    this.SelectedRows = event;
  }
  EditInventory(row: Inventories) {
    let x: { dataToEdit: Inventories, Array: any[] } = { dataToEdit: row, Array: this.AllInventories }
    this.bottomSheet.open(EditInventoryComponent, {
      data: x
    });
  }
  ShiftDelete(requiredKeys: boolean) {
    if (this.SelectedRows.length > 0 && requiredKeys) {
      this.Delete(this.SelectedRows[0]);
    }
  }
  ngAfterViewInit() {

  }
  AddNewInvent(AddClicked: boolean) {
    if (AddClicked) {
      this.ShowProgressBar = true;
      const AddInventBottomSheet = this.bottomSheet.open(AddNewInventoryComponent, {
        data: {
          dataSource: this.dataSource, ShowBrogressBar: this.ShowProgressBar,
          addedRow: this.AddedRow, AllInvent: this.AllInventories, SelectedRows: this.SelectedRows
        }
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: {
        dataSource: MatTableDataSource<Inventories>, ShowBrogressBar: boolean,
        addedRow: any, AllInvent: Inventories[], SelectedRows: Inventories[]
      }) => {
        this.ShowProgressBar = r.ShowBrogressBar;
        this.SelectedRows = [];
        this.AddedRow = r.addedRow;
        this.SelectedRows.push(r.addedRow);
      });
      this.ShowProgressBar = false;
    }
  }

  AddAddress(row: Inventories) {
    this.bottomSheet.open(AddInventAddressComponent, {
      data: row
    });
  }
  EditAdress(row: Inventories) {
    this.bottomSheet.open(EditInventAddressComponent, {
      data: row
    });
  }
  DeleteAddress(row: Inventories) {
    this.InventoriesService.DeleteAddress(row.inventoryAddress?.id!).subscribe({
      next: r => {
        this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
        row.inventAdd = "";
      },
      error: e => {
        this.ServerResponseHandler.GetErrorNotification_swal(e);
      }
    })
  }
}
