import { ConstantsService } from "src/CommonServices/constants.service";
import { RouterConstants } from "src/Helpers/RouterConstants";
interface ExpansionPanel {
  title: string;
  expanded: boolean;
  links: { link: string, LinkText: string, state: boolean }[];
  iconName: string;
}

let Constants = new ConstantsService();
export let SideNav_items: ExpansionPanel[] = [{
  title: "Products",
  expanded: false,
  links: [
    { link: RouterConstants.App_Items, LinkText: Constants.App_Items, state: false },
    {
      link: RouterConstants.App_Items + '/' + RouterConstants.App_ItemMainCategories,
      LinkText: Constants.App_ItemsMainCat, state: false
    },
    {
      link: RouterConstants.App_Items + '/' + RouterConstants.App_ItemUnits,
      LinkText: Constants.App_ItemsUnits, state: false
    },
    {
      link: RouterConstants.App_Items + '/' + RouterConstants.App_ItemBrands,
      LinkText: Constants.App_ItemsBrands, state: false
    }
  ],
  iconName: "inventory_2"
}];
