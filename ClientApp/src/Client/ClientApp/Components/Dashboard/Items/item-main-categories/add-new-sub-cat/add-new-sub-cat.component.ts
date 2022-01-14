import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormDefs, MatBottomSheetDismissData, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { ItemsService } from '../../items.service';
import { ItemMainCategory, ItemSubCategory } from '../../../Models/item.model';
@Component({
  selector: 'app-add-new-sub-cat',
  templateUrl: './add-new-sub-cat.component.html',
  styleUrls: ['./add-new-sub-cat.component.css']
})
export class AddNewSubCatComponent implements OnInit
{
  Title: CardTitle[] = [];
  Subdomain: string = window.location.hostname.split('.')[0];
  AddNew: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: { data: MatBottomSheetDismissData<ItemSubCategory>, MainCat: ItemMainCategory; },
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewSubCatComponent>,
    private ItemsService: ItemsService, private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {
    this.AllSelectionData = [{ property: this.Constants.Name.toLowerCase(), SelectedData: this.ItemsService.AllItemNeededData.itemMainCategories }];
    this._bottomSheetRef.backdropClick().subscribe((r) =>
    {
      this.data.data.ShowBrogressBar = false;
      this.spinner.removeSpinner();
      this._bottomSheetRef.dismiss(this.data);
    });
    this.AddNew = new FormGroup({
      subCatName: new FormControl(null
        , [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]
      )
    });
    this.Title = [{ text: this.Constants.add_new_subcat, needTranslation: true },];
    this.FormBuilder = {
      form: this.AddNew,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'add_circle',
      ButtonText: [this.Constants.Add, this.Constants.Sub_Categories_Singular],
      formSections: [
        {
          fxFlex: "100%",
          formFieldsSpec: [
            {
              type: "text",
              fieldToolTip: '',
              formControlName: this.Constants.SubCatName,
              appearance: this.Constants.FormFieldInputAppearance,
              faIcon: faPenAlt,
              fxFlex: "100%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.SubCatName,
              required: true,
              errors: [{
                type: 'required',
                TranslatedMessage: [
                  { text: this.Constants.Required_field_Error, needTraslation: true }]
              },
              {
                type: 'maxlength',
                TranslatedMessage: [
                  { text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true },
                  { text: this.Constants.MaxLength30.toString(), needTraslation: false },
                  { text: this.Constants.characters, needTraslation: true }]
              }],
              maxLength: this.Constants.MaxLength30
            },
          ],
        }],
    };
  }
  AddNew_SubCat(formDefs: FormDefs)
  {
    this.spinner.fullScreenSpinnerForForm();
    this.data.data.ShowBrogressBar = true;
    let newItem = new ItemSubCategory();
    this.ClientValidaiton.FillObjectFromForm(newItem, formDefs.form);
    newItem.itemMainCategoryId = this.data.MainCat.id;
    newItem.ItemMainCategory = this.data.MainCat;
    if (this.data)
      if (!this.ClientValidaiton.isUnique(this.data.data.data, this.Constants.Name.toLowerCase(), formDefs.form.get(this.Constants.Name.toLowerCase())?.value))
      {
        this.spinner.removeSpinner();
        let message: CardTitle[] = [{ text: this.Constants.Unique_SubCat_Per_MainCat_ERROR, needTranslation: true }];
        this.ClientValidaiton.GerneralClientSideError_swal(this.Constants.Name.toLowerCase(), message);
        this.data.data.ShowBrogressBar = false;
        return;
      }
    this.ItemsService.AddNew_SubCAt(newItem).subscribe({
      next: (r) =>
      {
        if (this.data)
        {
          this.data.data.data.push(r);
          this.data.data.SelectedRows = [];
          this.data.data.SelectedRows.push(r);
          this.data.data.addedRow = r;
          this.data.data.dataSource.data = this.data.data.data;
          for (let x of this.ItemsService.AllItemNeededData.itemMainCategories)
          {
            if (x.id === r.itemMainCategoryId)
            {
              x.itemSubCategory.push(r);
            }
          }
        } this.spinner.removeSpinner();
        this.ServerResponseHandler.DatatAddition_Success_Swal();
        setTimeout(() =>
        {
          this.data.data.dataSource.paginator?.lastPage();
        }, 500);
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(newItem, this.FormBuilder.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.SubCatName, maxLength: this.Constants.MaxLength30 },
        ];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
    this.data.data.ShowBrogressBar = false;
  }
  CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.spinner.removeSpinner();
      this.data.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }
}
