import { ConstantsService } from "src/CommonServices/constants.service";
interface ExpansionPanel {
  title: string;
  expanded: boolean;
  links: { link: string; state: boolean }[];
  iconName: string;
}
export class SideNavItems {
  constructor(public Constants: ConstantsService) {

  }
  public SideNavItems: ExpansionPanel[] = [{
    title: "Products",
    expanded: false,
    links: [{ link: this.Constants.App_Items, state: false },
    { link: this.Constants.App_Items, state: false }],
    iconName: "inventory_2"
  }];
}
let constants = new ConstantsService();
export let SideNav_items = new SideNavItems(constants).SideNavItems;
