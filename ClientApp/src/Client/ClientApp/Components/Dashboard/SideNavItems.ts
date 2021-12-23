import { ConstantsService } from "src/CommonServices/constants.service";
import { RouterConstants } from "src/Helpers/RouterConstants";
import { faParachuteBox } from '@fortawesome/free-solid-svg-icons';
import { ExpansionPanel } from "src/Interfaces/interfaces";


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
    },
    {
      link: RouterConstants.App_Items + '/' + RouterConstants.App_AddNewItem,
      LinkText: Constants.App_AddNewItem, state: false
    }
  ],
  GoogleIconName: "inventory_2"
}, {
  title: "Warehouses",
  expanded: false,
  links: [
    { link: RouterConstants.App_Warehouses, LinkText: Constants.App_Warehouses, state: false }
  ],
  GoogleIconName: "warehouse"
}, {
  title: "Suppliers",
  expanded: false,
  links: [
    { link: RouterConstants.App_Suppliers, LinkText: Constants.App_Suppliers, state: false }
  ],
  faIcon: faParachuteBox
}];
