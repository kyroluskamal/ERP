import { IconDefinition } from "@fortawesome/fontawesome-svg-core";

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
