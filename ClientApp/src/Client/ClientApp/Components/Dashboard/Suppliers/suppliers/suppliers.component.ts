import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, ColDefs, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, SweetAlertData, TableSlidingSections } from 'src/Interfaces/interfaces';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons'
import { MatTableDataSource } from '@angular/material/table';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { Suppliers } from '../../Models/supplier.model';
import { SuppliersService } from '../suppliers.service';
import { AddNewSupplierComponent } from '../add-new-supplier/add-new-supplier.component';
import { Spinner } from 'ngx-spinner';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { EditSupplierComponent } from '../edit-supplier/edit-supplier.component';
@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {
  faMobileAlt = faMobileAlt;
  faPhone = faPhone;
  faPenAlt = faPenAlt;
  faEdit = faEdit;
  faCheckCircle = faCheckCircle;
  faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split(".")[0];

  columns: ColDefs[] = [];
  AllSuppliers: Suppliers[] = [];
  isLoadingResults: boolean = true;
  SelectedRows: Suppliers[] = [];
  dataSource = new MatTableDataSource<any>();
  ShowProgressBar: boolean = true;
  AddedRow: any;
  PreventDeleteFor: any;
  FormBuilder: FormDefs = new FormDefs();
  Title: CardTitle[] = [];
  Subtitle: CardTitle[] = [];
  CollapsibleDataSections: TableSlidingSections[] = [];
  RowDeleted: boolean = false;
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private ServerResponseHandler: ServerResponseHandelerService,
    private SuppliersService: SuppliersService, private ClientValidaiton: ClientSideValidationService) {
    this.PreventDeleteFor = this.translate.GetTranslation(this.Constants.MainWarehouse);
  }

  ngOnInit(): void {
    this.Title = [{ text: this.Constants.Suppliers, needTranslation: true }];
    this.Subtitle = [{ text: this.Constants.Add_Edit_Delete, needTranslation: true },
    { text: this.Constants.Suppliers, needTranslation: true }]
    this.SuppliersService.GetAllSuppliers().subscribe(r => {

      this.AllSuppliers = r;
      this.dataSource.data = r;
      this.isLoadingResults = false;
      this.ShowProgressBar = false;
    }
    );
    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: '#' },
      { field: this.Constants.logo, display: this.Constants.logo },
      { field: this.Constants.businessName, display: this.Constants.businessName },
      { field: this.Constants.CellPhoneNumber, display: "", HeaderfaIcon: this.faMobileAlt },
      { field: this.Constants.balance, display: this.Constants.balance },
      { field: this.Constants.addedBy_UserName, display: this.Constants.addedBy_UserName },
      { field: this.Constants.dateCreated, display: this.Constants.dateCreated },
      { field: this.Constants.Notes, display: this.Constants.Notes },
    ];
    this.CollapsibleDataSections = [
      {
        sectionName: [{ text: this.Constants.SupplierDetails, needTranslation: true }], fxFlex: '48%', fxFlex_sm: "48%",
        keys: [this.Constants.businessName, this.Constants.firstName, this.Constants.lastName,
        this.Constants.CellPhoneNumber, this.Constants.TelephoneNumber,
        this.Constants.countryName, this.Constants.taxID, this.Constants.cr]
      },
      {
        sectionName: [{ text: this.Constants.AccountDetails, needTranslation: true }], fxFlex: '48%', fxFlex_sm: "48%",
        keys: [this.Constants.dateCreated, this.Constants.email, this.Constants.openingBalance,
        this.Constants.openingBalanceDate, this.Constants.balance, this.Constants.currency, this.Constants.Notes,
        this.Constants.addedBy_UserName]
      }
    ];
  }


  Delete(Supplier: Suppliers[]) {

    this.SelectedRows = Supplier;
    this.ShowProgressBar = true;

    this.spinner.fullScreenSpinner();
    this.SuppliersService.DeleteSupplier(Supplier[0].id).subscribe({
      next: r => {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
        this.dataSource.paginator?.getNumberOfPages();
        this.AllSuppliers = this.AllSuppliers.filter((item) => {
          return item.id !== Supplier[0].id;
        })
        this.dataSource.data = this.AllSuppliers;
        this.ShowProgressBar = false;
        Supplier = [];
        this.RowDeleted = true;
      },
      error: e => {
        this.ShowProgressBar = false;
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GetErrorNotification_swal(e);
        this.ShowProgressBar = false;
      }
    });
    this.RowDeleted = false;
  }
  Dbclick(row: Suppliers) {
    this.EditSupplier(row);
  }

  SelectRow(event: any) {
    this.SelectedRows = event;
  }
  EditSupplier(row: Suppliers) {
    this.ShowProgressBar = true;
    let x: DataToEdit_PassToBottomSheet<Suppliers> = { dataToEdit: row, Array: this.AllSuppliers, ShowProgressBar: this.ShowProgressBar }
    let ref = this.bottomSheet.open(EditSupplierComponent, {
      data: x
    });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<Suppliers>) => this.ShowProgressBar = r.ShowProgressBar);
  }

  AddSupplier(AddClicked: boolean) {
    if (AddClicked) {
      this.ShowProgressBar = true;
      let data: MatBottomSheetDismissData<Suppliers> = {
        dataSource: this.dataSource, ShowBrogressBar: this.ShowProgressBar,
        addedRow: this.AddedRow, data: this.AllSuppliers, SelectedRows: this.SelectedRows
      }
      const AddInventBottomSheet = this.bottomSheet.open(AddNewSupplierComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: MatBottomSheetDismissData<Suppliers>) => {
        this.ShowProgressBar = r.ShowBrogressBar;
        this.SelectedRows = [];
        this.AddedRow = r.addedRow;
        this.SelectedRows.push(r.addedRow);
      });
      this.ShowProgressBar = false;
    }
  }


}
