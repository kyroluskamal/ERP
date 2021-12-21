import { Direction } from "@angular/cdk/bidi";
import { FormGroup } from "@angular/forms";
import { MatFormFieldAppearance } from "@angular/material/form-field";
import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { SweetAlertIcon, SweetAlertOptions } from "sweetalert2";

export interface ExpansionPanel {
  title: string;
  expanded: boolean;
  links: { link: string, LinkText: string, state: boolean }[];
  iconName: string;
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
  maxLength?: string = "";
  minLength?: string = "";
  min?: string = "";
  max?: string = "";
  SelectData?: any[] = [];
  PropertyNameToShowInSelection?: string = "";
  PropertyNameToSetInValue?: string = "";
  SelectionInsideButton_faIcon?: any;
  SelectionInsideButton_GoogleIcon?: string = "";
  SelectionButton_text?: string = "";
  SelectionText_IfNoData?: string = "";
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