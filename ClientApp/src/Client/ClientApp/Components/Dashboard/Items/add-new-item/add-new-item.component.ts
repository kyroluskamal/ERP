import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators, } from '@angular/forms';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { TranslationService } from 'src/CommonServices/translation-service.service';
import { ValidationErrorMessagesService } from 'src/CommonServices/ValidationErrorMessagesService/validation-error-messages.service';
import { CardTitle, DataToEdit_PassToBottomSheet, FormArray_Add_Remove_TransferData, FormDefs, FormFields, FormFieldType, formSections, KikoStepper, MatBottomSheetDismissData, MatGroupOptionsForMatSelect, MaxMinLengthValidation, SelectedDataTransfer, StepperNextData } from 'src/Interfaces/interfaces';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA, } from '@angular/material/bottom-sheet';
import { faEnvelope, faMobileAlt, faPhone, faPenAlt, faEdit, faCheckCircle, faTimesCircle, faPhoneAlt, faLongArrowAltRight, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { ServerResponseHandelerService } from 'src/CommonServices/server-response-handeler.service';
import { ClientSideValidationService } from 'src/CommonServices/client-side-validation.service';
import { SpinnerService } from 'src/CommonServices/spinner.service';
import { Brands, Item, ItemMainCategory, ItemSKUKeys, ItemSubCategory, ItemVariants, Units } from '../../Models/item.model';
import { ItemsService } from '../items.service';
import { InventoriesService } from '../../Inventories/inventories.service';
import { AddNewInventoryComponent } from '../../Inventories/add-new-inventory/add-new-inventory.component';
import { Inventories } from '../../Models/inventories.model';
import { MatTableDataSource } from '@angular/material/table';
import { AddNewMainCatComponent } from '../item-main-categories/add-new-main-cat/add-new-main-cat.component';
import { AddNewSubCatComponent } from '../item-main-categories/add-new-sub-cat/add-new-sub-cat.component';
import { AddNewItemBrandComponent } from '../item-brands/add-new-item-brand/add-new-item-brand.component';
import { AddNewItemUnitsComponent } from '../item-units/add-new-item-units/add-new-item-units.component';
import { SuppliersService } from '../../Suppliers/suppliers.service';
import { AddNewSupplierComponent } from '../../Suppliers/add-new-supplier/add-new-supplier.component';
import { Suppliers } from '../../Models/supplier.model';
@Component({
  selector: 'app-add-new-item',
  templateUrl: './add-new-item.component.html',
  styleUrls: ['./add-new-item.component.css']
})
export class AddNewItemComponent implements OnInit
{
  Title: CardTitle[] = [];
  SubTitle: CardTitle[] = [];
  Stepper: KikoStepper = new KikoStepper();
  Subdomain: string = window.location.hostname.split('.')[0];
  AddNew: FormGroup = new FormGroup({});
  SecondStep: FormGroup = new FormGroup({});
  FormBuilder: FormDefs = new FormDefs();
  AllSelectionData: SelectedDataTransfer[] = [];
  AllSelectionData_secondStep: SelectedDataTransfer[] = [];
  SubCatsPerMainCat: ItemSubCategory[] = [];
  AllInvent: Inventories[] = [];
  ChipsEmpty: ItemSKUKeys[] = [];
  SelectionOptionGroups: MatGroupOptionsForMatSelect[] = [];
  constructor(private spinner: SpinnerService,
    public Constants: ConstantsService, private bottomSheet: MatBottomSheet,
    public ValidationErrorMessage: ValidationErrorMessagesService,
    public translate: TranslationService, @Inject(MAT_BOTTOM_SHEET_DATA) public data: MatBottomSheetDismissData<Item>,
    private ServerResponseHandler: ServerResponseHandelerService, private InventoriesService: InventoriesService,
    private _bottomSheetRef: MatBottomSheetRef<AddNewItemComponent>, private SuppliersService: SuppliersService,
    private ItemsService: ItemsService, private ClientValidaiton: ClientSideValidationService) { }
  ngOnInit(): void
  {

    setTimeout(() =>
    {
      for (let x of this.InventoriesService.AllInventories)
      {
        if (x.warehouseName === this.Constants.MainWarehouse)
          x.warehouseName = this.translate.GetTranslation(this.Constants.MainWarehouse);
      }
      for (let x of this.ItemsService.AllItemNeededData.itemMainCategories)
      {
        if (x.mainCatName === this.Constants.Uncategorized)
          x.mainCatName = this.translate.GetTranslation(this.Constants.Uncategorized.toLowerCase());
      }

      this.AllSelectionData = [
        { property: this.Constants.WarehouseName, SelectedData: this.InventoriesService.AllInventories },
        { property: this.Constants.SubCatName, SelectedData: this.SubCatsPerMainCat },
        { property: this.Constants.MainCatName, SelectedData: this.ItemsService.AllItemNeededData.itemMainCategories },
        { property: this.Constants.brandName, SelectedData: this.ItemsService.AllItemNeededData.brands },
        { property: this.Constants.wholeSaleUnit, SelectedData: this.ItemsService.AllItemNeededData.units },
        { property: this.Constants.businessName, SelectedData: this.ItemsService.AllItemNeededData.suppliers }
      ];
      this.AllSelectionData_secondStep = [{ property: 'name', SelectedData: [{ id: 1, name: "%" }, { id: 2, name: "$" }] }];
      /*................................................................................
        ............................. ItemDetails form..................................
        ................................................................................
      */
      this.AddNew = new FormGroup({
        defaultInventoryId: new FormControl(1, { updateOn: "change" }),
        itemName: new FormControl(null),
        MainCat_Singular: new FormControl(),
        subCatsId: new FormControl([], { updateOn: "change" }),
        brandsIds: new FormControl([1]),
        unitsIds: new FormControl([1]),
        suppliersIds: new FormControl([1]),
        itemSKUKeys: new FormControl([]),
        notesForClients: new FormControl(null),
        internNote: new FormControl(null),
        description: new FormControl(null),
        isOnline: new FormControl(null),
        hasExpire: new FormControl(null),
      });

      let dataForInventoriesBottomSheet: MatBottomSheetDismissData<Inventories> = {
        data: this.InventoriesService.AllInventories, ShowBrogressBar: false,
        addedRow: new Inventories(), dataSource: new MatTableDataSource<any>(),
        SelectedRows: this.InventoriesService.AllInventories
      };
      let dataForMainCatBottomSheet: MatBottomSheetDismissData<ItemMainCategory> = {
        data: this.ItemsService.AllItemNeededData.itemMainCategories, ShowBrogressBar: false,
        addedRow: new ItemMainCategory(), dataSource: new MatTableDataSource<any>(),
        SelectedRows: this.ItemsService.AllItemNeededData.itemMainCategories
      };
      let dataFor_Brands_BottomSheet: MatBottomSheetDismissData<Brands> = {
        data: this.ItemsService.AllItemNeededData.brands, ShowBrogressBar: false,
        addedRow: new Brands(), dataSource: new MatTableDataSource<any>(),
        SelectedRows: this.ItemsService.AllItemNeededData.brands
      };
      let dataFor_Units_BottomSheet: MatBottomSheetDismissData<Units> = {
        data: this.ItemsService.AllItemNeededData.units, ShowBrogressBar: false,
        addedRow: new Units(), dataSource: new MatTableDataSource<any>(),
        SelectedRows: this.ItemsService.AllItemNeededData.units
      };
      let dataFor_Suppliers_BottomSheet: MatBottomSheetDismissData<Suppliers> = {
        data: this.ItemsService.AllItemNeededData.suppliers, ShowBrogressBar: false,
        addedRow: new Suppliers(), dataSource: new MatTableDataSource<any>(),
        SelectedRows: this.ItemsService.AllItemNeededData.suppliers
      };

      this.Stepper = {
        isLinear: true,
        orientation: "horizontal",
        formDef: [
          {
            form: this.AddNew,
            Card_fxFlex: '100%',
            StepNoInStepper: 1,
            Form_fxLayout: 'row wrap',
            Form_fxLayoutAlign: 'space-between',
            Button_GoogleIcon: 'add_circle',
            AllSelectionData: this.AllSelectionData,
            Show_Add_Button_Stepper: false,
            Show_Back_Button_Stepper: false,
            Show_Reset_Button_Stepper: false,
            Show_Next_Button_Stepper: true,
            Next_Button_Stepper_text: [{ text: this.Constants.next, needTranslation: true }],
            stepperStepLabel: this.Constants.item_details,
            ButtonText: [this.Constants.add_new_item],
            formSections: [
              {
                fxFlex: "49%",
                fxFlex_sm: "100%",
                formFieldsSpec: [
                  {
                    type: "text",
                    fieldToolTip: '',
                    formControlName: this.Constants.itemName,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.itemName,
                    faIcon: faPenAlt,
                    required: false,
                    // errors: [{
                    //   type: 'required',
                    //   TranslatedMessage: [{ text: this.Constants.Required_field_Error, needTraslation: true }]
                    // },
                    // {
                    //   type: 'maxlength',
                    //   TranslatedMessage: [{ text: this.Constants.MaxLengthExceeded_ERROR, needTraslation: true }, { text: this.MaxLength.toString(), needTraslation: false }, { text: this.Constants.characters, needTraslation: true }]
                    // }],
                    // maxLength: "30"
                  },
                  {
                    type: "select",
                    fieldToolTip: '',
                    formControlName: this.Constants.defaultInventoryId,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.defaultInventoryId,
                    required: false,
                    SelectData: this.InventoriesService.AllInventories,
                    PropertyNameToSetInValue: 'id',
                    PropertyNameToShowInSelection: this.Constants.WarehouseName,
                    SelectionBottomSheetComponent: AddNewInventoryComponent,
                    SelectionButton_ToolTip: this.Constants.Add_New_Inventory,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    Selection_Multiple: false,
                    ShowSelectionAddButton: true,
                    SelectionDataSentToBottomSheet: dataForInventoriesBottomSheet
                  }, {
                    type: "select",
                    fieldToolTip: '',
                    formControlName: this.Constants.MainCat_Singular,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.Main_Categories,
                    required: false,
                    SelectData: this.ItemsService.AllItemNeededData.itemMainCategories,
                    PropertyNameToSetInValue: 'id',
                    PropertyNameToShowInSelection: this.Constants.MainCatName,
                    SelectionBottomSheetComponent: AddNewMainCatComponent,
                    SelectionButton_ToolTip: this.Constants.add_new_maincat,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    SelectionHasOptions: false,
                    Selection_Multiple: true,
                    ShowSelectionAddButton: true,
                    SelectionDataSentToBottomSheet: dataForMainCatBottomSheet
                  },
                  {
                    type: "select",
                    formControlName: this.Constants.subCatsId,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.subCatsId,
                    required: false,
                    SelectData: this.SubCatsPerMainCat,
                    PropertyNameToSetInValue: 'id',
                    disabled: this.SubCatsPerMainCat.length === 1,
                    PropertyNameToShowInSelection: this.Constants.SubCatName,
                    SelectionBottomSheetComponent: AddNewSubCatComponent,
                    SelectionText_IfNoData: this.Constants.select_main_cat_first,
                    SelectionButton_ToolTip: this.Constants.add_new_subcat,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    ShowSelectionSearchBox: true,
                    fieldToolTip: this.Constants.add_new_subcat_select_only_maincat,
                    Selection_Multiple: true,
                  },
                  {
                    type: "select",
                    fieldToolTip: '',
                    formControlName: this.Constants.brandsIds,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.brandsIds,
                    required: false,
                    SelectData: this.ItemsService.AllItemNeededData.brands,
                    PropertyNameToSetInValue: 'id',
                    PropertyNameToShowInSelection: this.Constants.brandName,
                    SelectionBottomSheetComponent: AddNewItemBrandComponent,
                    SelectionButton_ToolTip: this.Constants.add_new_brand,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    Selection_Multiple: true,
                    ShowSelectionAddButton: true,
                    SelectionText_IfNoData: this.Constants.NoItemBrandsAdded,
                    SelectionDataSentToBottomSheet: dataFor_Brands_BottomSheet
                  },
                  {
                    // ..................................................Item units
                    type: "select",
                    fieldToolTip: '',
                    formControlName: this.Constants.unitsIds,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.unitsIds,
                    required: false,
                    SelectData: this.ItemsService.AllItemNeededData.units,
                    PropertyNameToSetInValue: 'id',
                    PropertyNameToShowInSelection_many_index_tosearch: 1,
                    PropertyNameToShowInSelection_many: [
                      { prop: this.Constants.numberInWholeSale, separator: " " },
                      { prop: this.Constants.wholeSaleUnit, separator: " = " },
                      { prop: this.Constants.numberInRetailSale, separator: " " },
                      { prop: this.Constants.retailUnit, separator: "" },
                    ],
                    SelectionBottomSheetComponent: AddNewItemUnitsComponent,
                    SelectionButton_ToolTip: this.Constants.Add_New_Units,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    Selection_Multiple: true,
                    ShowSelectionAddButton: true,
                    SelectionText_IfNoData: this.Constants.NoUnitsAdded,
                    SelectionDataSentToBottomSheet: dataFor_Units_BottomSheet
                  }, {
                    type: FormFieldType.select,
                    fieldToolTip: '',
                    formControlName: this.Constants.suppliersIds,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%", fxFlex_xs: "100%",
                    mat_label: this.Constants.suppliersIds,
                    required: false,
                    SelectData: this.ItemsService.AllItemNeededData.suppliers,
                    PropertyNameToSetInValue: 'id',
                    PropertyNameToShowInSelection_many_index_tosearch: 0,
                    PropertyNameToShowInSelection_many: [
                      { prop: this.Constants.businessName, separator: " - " },
                      { prop: this.Constants.firstName, separator: " " },
                      { prop: this.Constants.lastName, separator: "" },
                    ],
                    SelectionBottomSheetComponent: AddNewSupplierComponent,
                    SelectionButton_ToolTip: this.Constants.add_new_supplier,
                    SelectionInsideButton_GoogleIcon: "add_box",
                    Selection_Multiple: true,
                    ShowSelectionAddButton: true,
                    SelectionText_IfNoData: this.Constants.NoSupplierAdded,
                    SelectionDataSentToBottomSheet: dataFor_Suppliers_BottomSheet
                  }, {
                    type: FormFieldType.chip_autocomplete,
                    fieldToolTip: '',
                    formControlName: this.Constants.itemSKUKeys,
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.itemSKUKeys,
                    required: false,
                    chipsFromDb: this.ItemsService.AllItemNeededData.itemSKUKeys,
                    ChipsFromDbUnFiltered: this.ItemsService.AllItemNeededData.itemSKUKeys,
                    chipsFill: this.ChipsEmpty,
                    chipPropertyToShowInSelection: "key",
                    chipPropertyToShowInValue: "id"
                  },
                  {
                    type: "checkbox",
                    appearance: this.Constants.FormFieldInputAppearance,
                    formControlName: this.Constants.isOnline,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.isOnline,
                    required: false,
                    fieldToolTip: ""
                  },
                  {
                    type: "checkbox",
                    appearance: this.Constants.FormFieldInputAppearance,
                    formControlName: this.Constants.hasExpire,
                    fxFlex: "49%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.hasExpire,
                    required: false,
                    fieldToolTip: ""
                  }
                ],
              }, {
                fxFlex: "49%",
                fxFlex_sm: "100%",
                formFieldsSpec: [
                  {
                    type: "textarea",
                    formControlName: this.Constants.Description.toLowerCase(),
                    fieldToolTip: '',
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "100%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.Description,
                    faIcon: faPenAlt,
                    cdkAutosizeMinRows: '3',
                    required: false,
                  },
                  {
                    type: "textarea",
                    formControlName: this.Constants.Description.toLowerCase(),
                    fieldToolTip: '',
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "100%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.internalNote,
                    faIcon: faPenAlt,
                    cdkAutosizeMinRows: '3',
                    required: false,
                  },
                  {
                    type: "textarea",
                    formControlName: this.Constants.notesForClients,
                    fieldToolTip: '',
                    appearance: this.Constants.FormFieldInputAppearance,
                    fxFlex: "100%",
                    fxFlex_xs: "100%",
                    mat_label: this.Constants.notesForClients,
                    faIcon: faPenAlt,
                    cdkAutosizeMinRows: '3',
                    required: false,
                  }
                ]
              }
            ],
          },
          {
            form: this.SecondStep,
            StepNoInStepper: 2,
            Card_fxFlex: '100%',
            Form_fxLayoutGap: '10px',
            Form_fxLayout: 'column',
            Form_fxLayoutAlign: 'space-between',
            Button_GoogleIcon: 'add_circle',
            AllSelectionData: this.AllSelectionData_secondStep,
            Show_Add_Button_Stepper: false,
            Show_Back_Button_Stepper: true,
            Show_Reset_Button_Stepper: false,
            Show_Next_Button_Stepper: true,
            Next_Button_Stepper_text: [{ text: this.Constants.next, needTranslation: true }],
            Back_Button_Stepper_text: [{ text: this.Constants.back, needTranslation: true }],
            stepperStepLabel: this.Constants.item_variants_per_brand,
            formGroupToAddInFormArray: this.AddItemVariantToFormArray(),
            ButtonText: [this.Constants.add_new_item],
            formSections: []
          }]
      };

      this.Title = [{ text: this.Constants.add_new_item, needTranslation: true },];
    }, 1000);
  }
  AddNewItem(formDefs: FormDefs)
  {
    this.spinner.fullScreenSpinnerForForm();
    this.data.ShowBrogressBar = true;
    let newItem = new Item();
    this.ClientValidaiton.FillObjectFromForm(newItem, formDefs.form);
    if (this.data)
      if (!this.ClientValidaiton.isUnique(this.data.data, this.Constants.wholeSaleUnit, formDefs.form.get(this.Constants.wholeSaleUnit)?.value))
      {
        this.spinner.removeSpinner();
        this.ClientValidaiton.notUniqueNotification_Swal(this.Constants.wholeSaleUnit);
        this.data.ShowBrogressBar = false;
        return;
      }
    // this.ItemsService.Addnew(newItem).subscribe({
    //   next: (r) =>
    //   {
    //     if (this.data)
    //     {
    //       this.data.data.push(r);
    //       this.data.SelectedRows = [];
    //       this.data.SelectedRows.push(r);
    //       this.data.addedRow = r;
    //       this.data.dataSource.data = this.data.data;
    //     } this.spinner.removeSpinner();
    //     this.ServerResponseHandler.DatatAddition_Success_Swal();
    //     setTimeout(() =>
    //     {
    //       this.data.dataSource.paginator?.lastPage();
    //     }, 500);
    //     this.AddNew.reset();
    //     this.AddNew.clearValidators();
    //     this.AddNew.get(this.Constants.numberInRetailSale)?.setValue(1);
    //     this.AddNew.get(this.Constants.numberInWholeSale)?.setValue(1);
    //   },
    //   error: (e) =>
    //   {
    //     this.spinner.removeSpinner();
    //     this.ClientValidaiton.refillForm(newItem, this.FormBuilder.form);
    //     let x: MaxMinLengthValidation[] = [
    //       { prop: this.Constants.wholeSaleUnit, maxLength: this.Constants.MaxLength30 },
    //       { prop: this.Constants.retailUnit, maxLength: this.Constants.MaxLength30 }
    //     ];
    //     this.ServerResponseHandler.GetErrorNotification_swal(e, x);
    //   }
    // });
    this.data.ShowBrogressBar = false;
  }
  CloseBottomSheet(event: boolean)
  {
    if (event)
    {
      this.data.ShowBrogressBar = false;
      this._bottomSheetRef.dismiss(this.data);
    }
  }
  DatChange(event: FormDefs)
  {
    console.log(event);
    if (event.StepNoInStepper === 1)
    {
      let MainCats: ItemMainCategory[] = [];
      this.SelectionOptionGroups = [];
      this.SubCatsPerMainCat = [];
      let ChosenMainCatsIds = event.form.get(this.Constants.MainCat_Singular)?.value;
      if (Array.isArray(ChosenMainCatsIds))
        for (let x of ChosenMainCatsIds)
        {
          MainCats.push(this.ItemsService.AllItemNeededData.itemMainCategories.filter(i => { return i.id === x; })[0]);
        }
      event.formSections[0].formFieldsSpec[3].SelectionHasOptions = true;

      for (let x of MainCats)
      {
        this.SubCatsPerMainCat.push(...x.itemSubCategory);
        this.SelectionOptionGroups.push({
          name: x.mainCatName,
          options: x.itemSubCategory,
          disabled: false
        });
      }
      let dataForSubCatBottomSheet: { data: MatBottomSheetDismissData<ItemSubCategory>, MainCat: ItemMainCategory; }
        = {
        data: {
          data: this.SubCatsPerMainCat, ShowBrogressBar: false,
          addedRow: new ItemSubCategory(), dataSource: new MatTableDataSource<any>(),
          SelectedRows: this.SubCatsPerMainCat
        },
        MainCat: MainCats[0]
      };
      event.formSections[0].formFieldsSpec[3].ShowSelectionAddButton = MainCats.length === 1;
      event.formSections[0].formFieldsSpec[3].SelectionDataSentToBottomSheet = dataForSubCatBottomSheet;
      event.formSections[0].formFieldsSpec[3].SelectionOptionGroups = this.SelectionOptionGroups;
      event.formSections[0].formFieldsSpec[3].SelectData = this.SubCatsPerMainCat;
      event.formSections[0].formFieldsSpec[3].disabled = false;
    }
  }

  ChipsHandle(event: FormDefs)
  {
    let value = event.form.get(this.Constants.itemSKUKeys)?.value;

    let chip: ItemSKUKeys = { id: 0, key: value };
    if (event.formSections[0].formFieldsSpec[7].chipsFill?.filter(i => { return i.key.toLowerCase() === chip.key.toLowerCase(); }).length === 0)
      event.formSections[0].formFieldsSpec[7].chipsFill?.push(chip);
    else return;
  }
  ResetClick(event: boolean)
  {
    console.log(this.FormBuilder);
    if (event)
      this.FormBuilder.formSections[0].formFieldsSpec[7].chipsFill = [];
  }

  NextClick(event: StepperNextData)
  {
    console.log(event);
    if (event.index === 0)
    {
      let ChoosenItemBrands: number[] = event.Stepper.formDef![0].form.get(this.Constants.brandsIds)?.value;
      event.Stepper.formDef![1].formSections = [];
      for (let brand of ChoosenItemBrands)
      {
        let formArray: FormArray = new FormArray([]);
        formArray.push(this.AddItemVariantToFormArray());
        event.Stepper.formDef![1].form.addControl(`itemvariants${brand}`, formArray);
        console.log(this.ItemsService.AllItemNeededData.brands.filter(i => { return i.id === brand; })[0].brandName!);
        let dataSource: MatTableDataSource<ItemVariants> = new MatTableDataSource<ItemVariants>();
        dataSource.data.push(new ItemVariants());
        let formSection: formSections = {
          sectionTitle: [
            { text: this.Constants.variants_fo_brand_, needTranslation: true },
            { text: " : ", needTranslation: false },
            { text: this.ItemsService.AllItemNeededData.brands.filter(i => { return i.id === brand; })[0].brandName, needTranslation: false }
          ],
          fxFlex: "100%",
          formFieldsSpec: [
            {
              columns: [{ field: this.Constants.variantName, display: this.Constants.variantName }],
              formControlName: "",
              type: FormFieldType.array,
              displayedColumns: [this.Constants.variantName],
              dataSource: dataSource,
              formArray: event.Stepper.formDef![1].form.get(`itemvariants${brand}`) as FormArray,
              formArrayName: `itemvariants${brand}`,
              appearance: this.Constants.FormFieldInputAppearance,
              fxFlex: "100%",
              fxFlex_xs: "100%",
              mat_label: this.Constants.variantName,
              required: false,
              fieldToolTip: "",
              formFields: [
                {
                  type: FormFieldType.text,
                  formControlName: this.Constants.variantName,
                  appearance: this.Constants.FormFieldInputAppearance,
                  fxFlex: "30%",
                  fxFlex_xs: "100%",
                  mat_label: this.Constants.variantName,
                  required: false,
                  fieldToolTip: ""
                },
                {
                  type: FormFieldType.number,
                  formControlName: this.Constants.notifyLessThan,
                  appearance: this.Constants.FormFieldInputAppearance,
                  fxFlex: "20%",
                  fxFlex_xs: "100%",
                  mat_label: this.Constants.notifyLessThan,
                  required: false,
                  fieldToolTip: '',
                  // errors: [
                  //   {
                  //     type: 'required',
                  //     TranslatedMessage: [
                  //       { text: this.Constants.Required_field_Error, needTraslation: true }
                  //     ]
                  //   },
                  // ]
                },
                {
                  type: FormFieldType.number,
                  formControlName: this.Constants.lastPurchasePrice,
                  appearance: this.Constants.FormFieldInputAppearance,
                  fxFlex: "20%",
                  fxFlex_xs: "100%",
                  mat_label: this.Constants.lastPurchasePrice,
                  required: false,
                  fieldToolTip: this.Constants.lastPurchasePrice_ToolTip,
                  // errors: [
                  //   {
                  //     type: 'required',
                  //     TranslatedMessage: [
                  //       { text: this.Constants.Required_field_Error, needTraslation: true }
                  //     ]
                  //   },
                  // ]
                },
                {
                  type: FormFieldType.number,
                  formControlName: this.Constants.profitMargin,
                  appearance: this.Constants.FormFieldInputAppearance,
                  fxFlex: "15%",
                  fxFlex_xs: "66%",
                  mat_label: this.Constants.profitMargin,
                  required: false,
                  fieldToolTip: "",
                  // errors: [
                  //   {
                  //     type: 'required',
                  //     TranslatedMessage: [
                  //       { text: this.Constants.Required_field_Error, needTraslation: true }
                  //     ]
                  //   },
                  // ]
                },
                {
                  type: FormFieldType.select,
                  formControlName: this.Constants.profitMarginType,
                  appearance: "outline",
                  fxFlex: "50px",
                  fxFlex_xs: "50px",
                  mat_label: "",
                  ShowSelectionSearchBox: true,
                  required: false,
                  SelectData: [{ id: 1, name: "%" }, { id: 2, name: "$" }],
                  PropertyNameToSetInValue: 'id',
                  PropertyNameToShowInSelection: this.Constants.Name.toLowerCase(),
                  fieldToolTip: ""
                }

              ]
            }
          ],
        };
        event.Stepper.formDef![1].formSections.push(formSection);
      }
      console.log(event);
    }
  }

  AddItemVariantToFormArray(): FormGroup
  {
    let newFormGroup = new FormGroup({
      variantName: new FormControl(null),
      notifyLessThan: new FormControl(0),
      lastPurchasePrice: new FormControl(0),
      profitMargin: new FormControl(0),
      profitMarginType: new FormControl(1)
    });
    return newFormGroup;
  }
}
