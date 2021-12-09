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
}
