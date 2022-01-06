import { TaxSettings } from "./generals.model";

let subdomain = window.location.hostname.split(".")[0];

export class ItemSubCategory
{
  id: number = 0;
  name: string = "";
  itemMainCategoryId: number = 0;
  ItemMainCategory: ItemMainCategory = new ItemMainCategory();
  subdomain: string = subdomain;
}

export class Item_Per_MainCategory
{
  itemMainCategory: ItemMainCategory = new ItemMainCategory();
  itemMainCategoryId: number = 0;
  item: Item = new Item();
  itemId: number = 0;
}
export class ItemMainCategory
{
  id: number = 0;
  name: string = "";
  itemSubCategory: ItemSubCategory[] = [];
  subdomain: string = subdomain;
}


export class Item_per_MainCategory_Per_SubCategory
{
  item_Per_MainCategory: Item_Per_MainCategory = new Item_Per_MainCategory();
  itemMainCategoryId: number = 0;
  itemId: number = 0;
  itemSubCategory: ItemSubCategory = new ItemSubCategory();
  itemSubCategoryId: number = 0;
}

export class ItemUnit
{
  id: number = 0;
  wholeSaleUnit: string = "";
  retailUnit: string = "";
  numberInWholeSale: number = 0;
  numberInRetailSale: number = 0;
  conversionRate: number = this.numberInRetailSale * this.numberInWholeSale;
  subdomain: string = subdomain;
}

export class Brands
{
  id: number = 0;
  name: string = "";
  subdomain: string = subdomain;
}
export class Item
{
  id: number = 0;
  defaultInventoryId: number = 0;
  name: string = "";
  hasExpire: boolean = false;
  isOnline: boolean = false;
  hasDescription: boolean = false;
  hasSpecialOffer: boolean = false;
  hasNote: boolean = false;
  addByUserId: number = 0;
}


export class ItemVariants
{
  id: number = 0;
  name: string = "";
  notifyLessThan: number = 0;
  lastPurchasePrice: number = 0;
  totalAmountInAllInvetroies?: number = 0;
  profitMargin: number = 0;
  profitMarginType: number = 0;
  barcode: number = 0;
  itemSKU: string = "";
  item: Item = new Item();
  itemId: number = 0;
  hasWholeSalePrice: boolean = false;
  hasRetailPrice: boolean = false;
}
export class ItemsVariant_RetailPrice
{
  id: number = 0;
  retailPrice: number = 0;
  minRetailPrice: number = 0;
  discountAmount: number = 0;
  discountType: number = 0;
  itemVariants: ItemVariants = new ItemVariants();
  itemVariantsId: number = 0;
}

export class ItemVariant_WholeSalePrice
{
  id: number = 0;
  wholeSalePrice: number = 0;
  minWholeSalePrice: number = 0;
  discountAmount: number = 0;
  discountType: number = 0;
  itemVariants: ItemVariants = new ItemVariants();
  itemVariantsId: number = 0;
}

export class ItemTaxSettings
{
  id: number = 0;
  item: Item = new Item();
  itemId: number = 0;
  TaxSettings: TaxSettings = new TaxSettings();
  TaxSettingsId: number = 0;
}
