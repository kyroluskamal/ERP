import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormDefs, MaxMinLengthValidation, SelectedDataTransfer } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { ItemsService } from '../../items.service';
import { ItemMainCategory } from '../../../Models/item.model';
@Component({
  selector: 'app-edit-main-cat',
  templateUrl: './edit-main-cat.component.html',
  styleUrls: ['./edit-main-cat.component.css']
})
export class EditMainCatComponent implements OnInit
{

  Title: CardTitle[] = [];
  Subdomain: string = window.location.hostname.split('.')[0];
  Edit: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();

  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, private ItemService: ItemsService,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: DataToEdit_PassToBottomSheet<ItemMainCategory>,
    private ServerResponseHandler: ServerResponseHandelerService,
    private _bottomSheetRef: MatBottomSheetRef<EditMainCatComponent>,
    private ClientValidaiton: ClientSideValidationService) { }

  ngOnInit(): void
  {
    this._bottomSheetRef.backdropClick().subscribe(
      (r) =>
      {
        this.data.ShowProgressBar = false;
        this.spinner.removeSpinner(); this._bottomSheetRef.dismiss(this.data);
      });
    this.Edit = new FormGroup({
      mainCatName: new FormControl(this.data.dataToEdit.mainCatName
        , [Validators.required, Validators.maxLength(this.Constants.MaxLength30)]
      ),
    });
    this.Title = [{ text: this.Constants.Edit, needTranslation: true },
    { text: ": ", needTranslation: false }, { text: this.data.dataToEdit.mainCatName, needTranslation: false }
    ];
    this.FormBuilder = {
      form: this.Edit,
      Card_fxFlex: '100%',
      Form_fxLayout: 'row wrap',
      Form_fxLayoutAlign: 'space-between',
      Button_GoogleIcon: 'save',
      ButtonText: [this.Constants.Save],
      formSections: [
        {
          fxFlex: "100%",
          formFieldsSpec: [
            {
              type: "text",
              fieldToolTip: '',
              formControlName: this.Constants.MainCatName,
              appearance: this.Constants.FormFieldInputAppearance,
              faIcon: faPenAlt,
              fxFlex: "100%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.MainCatName,
              required: false,
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

  Edit_MainCat(EditedObj: FormDefs)
  {
    if (!this.ClientValidaiton.isUpdated(this.data.dataToEdit, EditedObj.form))
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
      return;
    }
    this.spinner.fullScreenSpinnerForForm();
    if (!(this.ClientValidaiton.isUnique(this.data.Array, this.Constants.Name.toLowerCase(),
      this.Edit.get(this.Constants.Name.toLowerCase())?.value, this.data.dataToEdit.id)))
    {
      this.spinner.removeSpinner();
      this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.Name.toLowerCase());
      this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
      return;
    }
    let UpdatedItem: ItemMainCategory = { ...this.data.dataToEdit };
    this.ClientValidaiton.FillObjectFromForm(UpdatedItem, EditedObj.form);
    UpdatedItem.subdomain = this.Subdomain;
    this.ItemService.UpdateMainCat(UpdatedItem).subscribe({
      next: (r) =>
      {
        if (r.status)
          if (r.status !== this.Constants.SameObject)
          {
            for (let x of this.ItemService.AllItemNeededData.itemMainCategories)
            {
              if (x.id === this.data.dataToEdit.id)
                x.mainCatName = UpdatedItem.mainCatName;;
            }
            this.spinner.removeSpinner();
            this.ServerResponseHandler.GeneralSuccessResponse_Swal(r);
            this.ClientValidaiton.FillObjectFromAnotherObject(this.data.dataToEdit, UpdatedItem);
          }
        this.spinner.removeSpinner();
        this.data.ShowProgressBar = false;
        this._bottomSheetRef.dismiss(this.data);
      },
      error: (e) =>
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.refillForm(this.data.dataToEdit, EditedObj.form);
        let x: MaxMinLengthValidation[] = [
          { prop: this.Constants.MainCatName, maxLength: this.Constants.MaxLength30 },
        ];
        this.ServerResponseHandler.GetErrorNotification_swal(e, x);
      }
    });
  }
  CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.data.ShowProgressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }

}
