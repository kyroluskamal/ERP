import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service'; import { CardTitle, ColDefs, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, SweetAlertData } from 'src/Interfaces/interfaces'; import { MatBottomSheet } from '@angular/material/bottom-sheet'; import { faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { ItemsService } from '../../items.service';
import { Brands } from '../../../Models/item.model';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { EditItemBrandComponent } from '../edit-item-brand/edit-item-brand.component';
import { AddNewItemBrandComponent } from '../add-new-item-brand/add-new-item-brand.component';
@Component({
  selector: 'app-item-brands',
  templateUrl: './item-brands.component.html',
  styleUrls: ['./item-brands.component.css']
})
export class ItemBrandsComponent implements OnInit
{

  faMobileAlt = faMobileAlt; faPhone = faPhone; faPenAlt = faPenAlt; faEdit = faEdit;
  faCheckCircle = faCheckCircle; faTimesCircle = faTimesCircle;
  Subdomain: string = window.location.hostname.split(".")[0];
  columns: ColDefs[] = [];
  AllItems: Brands[] = [];
  isLoadingResults: boolean = true;
  SelectedRows: Brands[] = [];
  dataSource = new MatTableDataSource<Brands>();
  ShowProgressBar: boolean = true;
  AddedRow: any;
  PreventDeleteFor: any;
  ReferencialField: string = "inventoryAddress";
  FormBuilder: FormDefs = new FormDefs(); Title: CardTitle[] = [];

  Subtitle: CardTitle[] = [];
  RowDeleted: boolean = false;

  constructor(private spinner: SpinnerService, public Constants: ConstantsService,
    private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, private ServerResponseHandler: ServerResponseHandelerService,
    private ItemsService: ItemsService, private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {
    this.Title = [{ text: this.Constants.Brand_Names, needTranslation: true }];
    this.Subtitle = [
      { text: this.Constants.Add_Edit_Delete, needTranslation: true },
      { text: this.Constants.Brand_Names, needTranslation: true },
    ];
    this.ItemsService.Get_All_ItemBrands().subscribe(r =>
    {
      this.AllItems = r;
      this.dataSource.data = r;
      this.isLoadingResults = false; this.ShowProgressBar = false;
    });
    this.isLoadingResults = true;
    this.ShowProgressBar = true;
    this.columns = [
      { field: 'id', display: '#' },
      { field: this.Constants.Name.toLowerCase(), display: this.Constants.Name },
    ];
  }
  Delete(brand: Brands[])
  {
    this.SelectedRows = brand;
    this.ShowProgressBar = true;


    this.spinner.fullScreenSpinner();
    this.ItemsService.Delete_ItemBrand(brand[0].id).subscribe({
      next: r =>
      {
        this.spinner.removeSpinner();
        this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
        this.AllItems = this.AllItems.filter((item) =>
        {
          return item.id !== brand[0].id;
        });
        this.dataSource.paginator?.getNumberOfPages();
        this.dataSource.data = this.AllItems;
        this.ShowProgressBar = false;
        brand = [];
        this.RowDeleted = true;
      }, error: e => { this.ShowProgressBar = false; this.spinner.removeSpinner(); this.ServerResponseHandler.GetErrorNotification_swal(e); this.ShowProgressBar = false; }
    });


    this.ShowProgressBar = false;
    this.RowDeleted = false;
  }

  SelectRow(event: any) { this.SelectedRows = event; }

  Edit(row: Brands)
  {
    let x: DataToEdit_PassToBottomSheet<Brands> = {
      dataToEdit: row, Array: this.AllItems, ShowProgressBar: this.ShowProgressBar
    };
    const ref = this.bottomSheet.open(EditItemBrandComponent, { data: x });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<Brands>) =>
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
      let data: MatBottomSheetDismissData<Brands> = {
        dataSource: this.dataSource,
        ShowBrogressBar: this.ShowProgressBar, addedRow: this.AddedRow, data: this.AllItems, SelectedRows: this.SelectedRows
      };
      const AddInventBottomSheet = this.bottomSheet.open(AddNewItemBrandComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: MatBottomSheetDismissData<Brands>) =>
      {
        this.ShowProgressBar = r.ShowBrogressBar;
        this.SelectedRows = [];
        this.AddedRow = r.addedRow; this.SelectedRows.push(r.addedRow);
      });
      this.ShowProgressBar = false;
    }
  }

}
