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
import { ItemMainCategory, ItemSubCategory } from '../../../Models/item.model';
import { ItemsService } from '../../items.service';
import { EditMainCatComponent } from '../edit-main-cat/edit-main-cat.component';
import { AddNewMainCatComponent } from '../add-new-main-cat/add-new-main-cat.component';
import { EditSubCatComponent } from '../edit-sub-cat/edit-sub-cat.component';
import { AddNewSubCatComponent } from '../add-new-sub-cat/add-new-sub-cat.component';

@Component({
  selector: 'app-item-categories',
  templateUrl: './item-categories.component.html',
  styleUrls: ['./item-categories.component.css']
})
export class ItemCategoriesComponent implements OnInit
{

  Subdomain: string = window.location.hostname.split(".")[0];

  columns_MainCat: ColDefs[] = [];
  columns_SubCat: ColDefs[] = [];
  All_MainCat: ItemMainCategory[] = [];
  All_SubCat: ItemSubCategory[] = [];
  isLoadingResults_MainCat: boolean = true;
  isLoadingResults_SubCat: boolean = false;
  SelectedRows_MainCat: ItemMainCategory[] = [];
  SelectedRows_SubCat: ItemSubCategory[] = [];
  dataSource_MainCat = new MatTableDataSource<ItemMainCategory>();
  dataSource_SubCat = new MatTableDataSource<ItemSubCategory>();
  ShowProgressBar_MainCat: boolean = true;
  ShowProgressBar_SubCat: boolean = false;
  AddedRow_MainCat: ItemMainCategory = new ItemMainCategory();;
  AddedRow_SubCat: ItemSubCategory = new ItemSubCategory();
  PreventDeleteFor: any;
  ReferencialField: string = "inventoryAddress";
  Title_MainCat: CardTitle[] = [];
  Title_SubCat: CardTitle[] = [];
  Subtitle_MainCat: CardTitle[] = [];
  Subtitle_SubCat: CardTitle[] = [];
  RowDeleted_MainCat: boolean = false;
  RowDeleted_SubCat: boolean = false;
  ChangeSelectedRow: any;
  NoDataMessage: CardTitle[] = [];
  ChangeSelectedRow_SubCat: any;
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService, public translate: TranslationService,
    private ServerResponseHandler: ServerResponseHandelerService,
    private ItemService: ItemsService, private ClientValidaiton: ClientSideValidationService)
  {
  }

  ngOnInit(): void
  {
    this.NoDataMessage = [{ text: this.Constants.select_main_cat_first, needTranslation: true }];

    this.Title_MainCat = [{ text: this.Constants.Main_Categories, needTranslation: true }];
    this.Subtitle_MainCat = [{ text: this.Constants.Add_Edit_Delete, needTranslation: true },
    { text: this.Constants.Main_Categories, needTranslation: true }];
    this.Title_SubCat = [{ text: this.Constants.Sub_Categories, needTranslation: true }];
    this.Subtitle_SubCat = [{ text: this.Constants.Add_Edit_Delete, needTranslation: true },
    { text: this.Constants.Sub_Categories, needTranslation: true }];
    this.ItemService.GetAllGategories().subscribe(r =>
    {
      for (let main of r)
      {
        if (main.mainCatName.toLowerCase() === this.Constants.Uncategorized.toLowerCase())
        {
          main.mainCatName = this.translate.GetTranslation(this.Constants.Uncategorized.toLowerCase());
        }
        for (let subcat of main.itemSubCategory)
        {
          if (subcat.subCatName === this.Constants.default_subcategory)
          {
            subcat.subCatName = this.translate.GetTranslation(this.Constants.default_subcategory.toLowerCase());
          }
        }
      }
      this.All_MainCat = r;
      this.dataSource_MainCat.data = r;
      this.isLoadingResults_MainCat = false;
      this.ShowProgressBar_MainCat = false;
    }
    );

    this.isLoadingResults_MainCat = true;
    this.ShowProgressBar_MainCat = true;
    this.columns_MainCat = [
      { field: 'id', display: '#' },
      { field: this.Constants.Name.toLowerCase(), display: this.Constants.Name }
    ];
    this.columns_SubCat = [
      { field: this.Constants.Name.toLowerCase(), display: this.Constants.Name },
    ];

  }

  SelectRow_SubCat(event: ItemSubCategory[])
  {
    this.SelectedRows_SubCat = event;
  }
  DeleteMainCat(MainCat: ItemMainCategory[])
  {
    this.SelectedRows_MainCat = MainCat;
    this.ShowProgressBar_MainCat = true;
    if (MainCat[0].mainCatName === this.translate.GetTranslation(this.Constants.Uncategorized.toLowerCase()))
    {
      this.ClientValidaiton.Error_swal(this.Constants.delete_default_Main_cat)
        .then(r => { this.ShowProgressBar_MainCat = false; });
      return;
    }
    this.ClientValidaiton.Warning(this.translate.GetTranslation(this.Constants.DeleteMainCatWarning))
      .then(r =>
      {
        if (r.isConfirmed)
        {
          this.spinner.fullScreenSpinner();
          this.ItemService.DeleteMainCat(MainCat[0].id).subscribe({
            next: r =>
            {
              this.spinner.removeSpinner();
              this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
              this.All_MainCat = this.All_MainCat.filter((item) =>
              {
                return item.id !== MainCat[0].id;
              });
              this.ItemService.AllItemNeededData.itemMainCategories = this.All_MainCat;
              this.dataSource_MainCat.data = this.All_MainCat;
              this.dataSource_SubCat.data = [];
              this.All_SubCat = [];
              this.ShowProgressBar_MainCat = false;
              MainCat = [];
              this.RowDeleted_MainCat = true;
            },
            error: e =>
            {
              this.ShowProgressBar_MainCat = false;
              this.spinner.removeSpinner();
              this.ServerResponseHandler.GetErrorNotification_swal(e);
              this.ShowProgressBar_MainCat = false;
            }
          });
        } else
        {
          this.spinner.removeSpinner();
          this.RowDeleted_MainCat = false;
        }
        this.ShowProgressBar_MainCat = false;
      });
    this.RowDeleted_MainCat = false;
  }
  Delete_SubCat(SubCat: ItemSubCategory[])
  {
    this.SelectedRows_SubCat = SubCat;
    this.ShowProgressBar_SubCat = true;
    if (SubCat[0].subCatName === this.translate.GetTranslation(this.Constants.default_subcategory.toLowerCase()))
    {
      this.ClientValidaiton.Error_swal(this.Constants.delete_default_Sub_cat)
        .then(r => { this.ShowProgressBar_SubCat = false; });
      return;
    }
    this.ClientValidaiton.Warning(this.translate.GetTranslation(this.Constants.DeleteSubCatWarning))
      .then(r =>
      {
        if (r.isConfirmed)
        {
          this.spinner.fullScreenSpinner();
          this.ItemService.DeleteSubCat(SubCat[0].id!).subscribe({
            next: r =>
            {
              this.spinner.removeSpinner();
              this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
              this.All_SubCat = this.All_SubCat.filter((item) =>
              {
                return item.id !== SubCat[0].id;
              });
              for (let x of this.All_MainCat)
              {
                if (x.id === SubCat[0].itemMainCategoryId)
                  x.itemSubCategory = this.All_SubCat;
              }
              this.dataSource_MainCat.data = this.All_MainCat;
              this.dataSource_SubCat.data = this.All_SubCat;
              this.ShowProgressBar_SubCat = false;
              SubCat = [];
              this.RowDeleted_SubCat = true;
            },
            error: e =>
            {
              this.ShowProgressBar_SubCat = false;
              this.spinner.removeSpinner();
              this.ServerResponseHandler.GetErrorNotification_swal(e);
            }
          });
        } else
        {
          this.spinner.removeSpinner();
          this.RowDeleted_SubCat = false;
        }
        this.ShowProgressBar_SubCat = false;
      });
    this.RowDeleted_SubCat = false;
  }
  SelectRow_MainCat(event: ItemMainCategory[])
  {
    this.All_SubCat = [];
    this.SelectedRows_MainCat = event;
    this.ChangeSelectedRow_SubCat = null;
    this.dataSource_SubCat.data = [];
    if (event[0])
    {
      this.isLoadingResults_SubCat = true;
      this.ShowProgressBar_SubCat = true;
      this.All_SubCat = this.All_MainCat.filter((i) => { return i.id === event[0].id; })[0].itemSubCategory;
      this.dataSource_SubCat.data = this.All_SubCat;
      this.ShowProgressBar_SubCat = false;
      this.isLoadingResults_SubCat = false;
      this.SelectedRows_SubCat = [];
    } else
    {
      this.dataSource_SubCat.data = [];
      this.All_SubCat = [];
      this.SelectedRows_SubCat = [];
    }
  }
  EditMainCat(row: ItemMainCategory)
  {
    if (row.mainCatName === this.translate.GetTranslation(this.Constants.Uncategorized.toLowerCase()))
    {
      this.ClientValidaiton.Error_swal(this.Constants.delete_default_Main_cat)
        .then(r => { this.ShowProgressBar_MainCat = false; });
      return;
    }
    let x: DataToEdit_PassToBottomSheet<ItemMainCategory> = { dataToEdit: row, Array: this.All_MainCat, ShowProgressBar: this.ShowProgressBar_MainCat };
    const ref = this.bottomSheet.open(EditMainCatComponent, {
      data: x
    });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<ItemMainCategory>) =>
    {
      this.ShowProgressBar_MainCat = r.ShowProgressBar;
    });
  }
  Edit_SubCat(row: ItemSubCategory)
  {
    if (row.subCatName === this.translate.GetTranslation(this.Constants.default_subcategory.toLowerCase()))
    {
      this.ClientValidaiton.Error_swal(this.Constants.delete_default_Sub_cat)
        .then(r => { this.ShowProgressBar_SubCat = false; });
      return;
    }
    let x: DataToEdit_PassToBottomSheet<ItemSubCategory> = { dataToEdit: row, Array: this.All_SubCat, ShowProgressBar: this.ShowProgressBar_MainCat };
    const ref = this.bottomSheet.open(EditSubCatComponent, {
      data: x
    });
    ref.afterDismissed().subscribe((r: DataToEdit_PassToBottomSheet<ItemSubCategory>) =>
    {
      this.ShowProgressBar_SubCat = r.ShowProgressBar;
    });
  }
  ngAfterViewInit()
  {

  }
  AddNew_MainCat(AddClicked: boolean)
  {
    if (AddClicked)
    {
      this.ShowProgressBar_MainCat = true;
      let data: MatBottomSheetDismissData<ItemMainCategory> = {
        dataSource: this.dataSource_MainCat, ShowBrogressBar: this.ShowProgressBar_MainCat,
        addedRow: this.AddedRow_MainCat, data: this.All_MainCat, SelectedRows: this.SelectedRows_MainCat
      };
      const AddInventBottomSheet = this.bottomSheet.open(AddNewMainCatComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: MatBottomSheetDismissData<ItemMainCategory>) =>
      {
        this.ShowProgressBar_MainCat = r.ShowBrogressBar;
        this.SelectedRows_MainCat = [];
        this.AddedRow_MainCat = r.addedRow;
        this.ItemService.AllItemNeededData.itemMainCategories = r.data;
        this.SelectedRows_MainCat.push(r.addedRow);
        this.SelectRow_MainCat(this.SelectedRows_MainCat);
      });
      this.ShowProgressBar_MainCat = false;
    }
  }


  AddNew_SubCat(AddClicked: boolean)
  {

    if (AddClicked)
    {
      if (this.SelectedRows_MainCat.length === 0)
      {
        let message: CardTitle[] = [{ text: this.Constants.NotSelected_MainCat, needTranslation: true }];
        this.ClientValidaiton.GerneralClientSideError_swal(this.Constants.itemMainCategoryId, message);
        return;
      }
      this.ShowProgressBar_SubCat = true;
      let data: { data: MatBottomSheetDismissData<ItemSubCategory>, MainCat: ItemMainCategory; } = {
        data: {
          dataSource: this.dataSource_SubCat, ShowBrogressBar: this.ShowProgressBar_SubCat,
          addedRow: this.AddedRow_SubCat, data: this.All_SubCat, SelectedRows: this.SelectedRows_SubCat
        },
        MainCat: this.SelectedRows_MainCat[0]
      };
      const AddInventBottomSheet = this.bottomSheet.open(AddNewSubCatComponent, {
        data: data
      });
      AddInventBottomSheet.afterDismissed().subscribe((r: MatBottomSheetDismissData<ItemSubCategory>) =>
      {
        for (let x of this.All_MainCat)
        {
          if (x.id === r.addedRow.itemMainCategoryId)
          {
            x.itemSubCategory.push(r.addedRow);
          }
        }

        this.ShowProgressBar_SubCat = r.ShowBrogressBar;
        this.SelectedRows_SubCat = [];
        this.AddedRow_SubCat = r.addedRow;
        this.SelectedRows_SubCat.push(r.addedRow);
      });
      this.ShowProgressBar_SubCat = false;
    }
  }
}
