import { Direction } from "@angular/cdk/bidi";
import { ComponentType } from "@angular/cdk/portal";
import { Type } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { MatFormFieldAppearance } from "@angular/material/form-field";
import { MatTableDataSource } from "@angular/material/table";
import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { SweetAlertIcon, SweetAlertOptions } from "sweetalert2";

export interface ExpansionPanel {
  title: string;
  expanded: boolean;
  links: { link: string, LinkText: string, state: boolean }[];
  GoogleIconName?: string;
  faIcon?: any;
}

export interface ThemeColor {
  colorName: string
  value: string;
  choosen: boolean;
  bg: string;
  color: string;
}

export interface ColDefs {
  field: string;
  display: string;
  HeaderfaIcon?: any;
  HeaderGoogleIcon?: string;
  IsTrueOrFlase?: boolean;
  True_faIcon?: any;
  False_faIcon?: any;
  True_GoogleIcon?: string;
  False_GoogleIcon?: string;
  preventDeleteFor?: string;
}

export class FormDefs {
  form: FormGroup = new FormGroup({});
  Card_fxFlex?: string;
  Form_fxLayout: string = "";
  Form_fxLayoutAlign: string = "";
  Button_faIcon?: any;
  Button_GoogleIcon?: string;
  ButtonText: string[] = [];
  formSections: formSections[] = [];
}

export class formSections {
  sectionTitle?: CardTitle[] = [];
  fxFlex: string = "";
  formFieldsSpec: FormFields[] = [];
}
export class FormFields {
  type: string = "";
  formControlName: string = "";
  appearance: MatFormFieldAppearance = "outline";
  fxFlex?: string;
  fxFlex_gt_xs?: string;
  fxFlex_xs?: string;
  mat_label: string = "";
  faIcon?: any;
  GoogleIcon?: string;
  errors?: MatError[];
  hint?: MatFormHint = new MatFormHint();
  cdkAutosizeMinRows?: string = "";
  required: boolean = false;
  maxLength?: number = 0;
  minLength?: number = 0;
  min?: string = "";
  max?: string = "";
  SelectData?: any[] = [];
  PropertyNameToShowInSelection?: string = "";
  PropertyNameToSetInValue?: string = "";
  SelectionInsideButton_faIcon?: any;
  SelectionInsideButton_GoogleIcon?: string = "";
  SelectionButton_text?: string = "";
  SelectionText_IfNoData?: string = "";
  SelectionBottomSheetComponent?: ComponentType<unknown>;
  UploadInputText?: CardTitle[] = [];
}
export class MatFormHint {
  text_no_translation?: string = "";
  text_to_translation: string = "";
  dir: Direction = "ltr";
  align: 'start' | 'end' = "end";
}
export class MatError {
  type: string = "";
  TranslatedMessage: { text: string, needTraslation: boolean }[] = [];
}

export interface CardTitle {
  text: string;
  needTranslation: boolean;
}
export interface MaxMinLengthValidation {
  prop: string; maxLength?: number; minLength?: number;
}

export interface SweetAlertData {
  title?: CardTitle[];
  text?: CardTitle[];
  ConfirmButton_FaIcon?: any;
  ConfirmButton_GoogleIcon?: string;
  CancelButton_FaIcon?: any;
  CancelButton_GoogleIcon?: string;
  DenyButton_FaIcon?: any;
  DenyButton_GoogleIcon?: string;
  OtherOptions: SweetAlertOptions,
  direction: string
}

export interface SelectedDataTransfer {
  property: string;
  SelectedData: any[];
}

export interface AbstractApi {
  ip_address: string;
  city: string;
  city_geoname_id: number;
  region: string;
  region_iso_code: string;
  region_geoname_id: number;
  postal_code: string,
  country: string;
  country_code: string;
  country_geoname_id: number;
  country_is_eu: boolean;
  continent: string;
  continent_code: string;
  continent_geoname_id: number;
  longitude: number;
  latitude: number;
  security: {
    is_vpn: boolean;
  },
  timezone: {
    name: string;
    abbreviation: string;
    gmt_offset: number;
    current_time: string;
    is_dst: boolean;
  },
  flag: {
    emoji: string;
    unicode: string;
    png: string;
    svg: string;
  },
  currency: {
    currency_name: string;
    currency_code: string;
  },
  connection: {
    autonomous_system_number: number;
    autonomous_system_organization: string;
    connection_type: string;
    isp_name: string;
    organization_name: string;
  }
}

export interface TableSlidingSections {
  sectionName: CardTitle[];
  fxFlex?: string;
  fxFlex_sm?: string;
  girdCols?: number;
  keys: string[];
}

export interface MatBottomSheetDismissData<T> {
  dataSource: MatTableDataSource<T>;
  ShowBrogressBar: boolean;
  addedRow: any;
  data: T[];
  SelectedRows: T[];
}

export interface DataToEdit_PassToBottomSheet<T> { dataToEdit: T, Array: T[], ShowProgressBar: boolean }