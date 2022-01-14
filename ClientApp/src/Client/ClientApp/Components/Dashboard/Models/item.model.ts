import { TaxSettings } from "./generals.model";
import { Suppliers } from "./supplier.model";

let subdomain = window.location.hostname.split(".")[0];

export class ItemSubCategory
{
  id: number = 0;
  subCatName: string = "";
  itemMainCategoryId: number = 0;
  ItemMainCategory: ItemMainCategory = new ItemMainCategory();
  subdomain: string = subdomain;
}
export class AllItemNeededData
{
  brands: Brands[] = [];
  units: Units[] = [];
  itemMainCategories: ItemMainCategory[] = [];
  suppliers: Suppliers[] = [];
  itemSKUKeys: ItemSKUKeys[] = [];
}
export class ItemSuppliers
{
  item: Item = new Item();
  itemId: number = 0;
  suppliers: Suppliers = new Suppliers();;
  suppliersId: number = 0;
}
export class ItemMainCategory
{
  id: number = 0;
  mainCatName: string = "";
  itemSubCategory: ItemSubCategory[] = [];
  subdomain: string = subdomain;
}

export class ItemSKUKeys
{
  id: number = 0;
  key: string = "";
  itemSKUkeys_Per_ItemVariants?: ItemSKUkeys_Per_ItemVariants = new ItemSKUkeys_Per_ItemVariants();
}

export class ItemSKUkeys_Per_ItemVariants
{
  itemSKUKeys: ItemSKUKeys = new ItemSKUKeys();
  itemSKUKeysId: number = 0;
  itemVariants: ItemVariants = new ItemVariants();
  itemVariantsId: number = 0;
}

export class Item_per_MainCategory_Per_SubCategory
{
  item_Per_MainCategory: Item_Per_MainCategory = new Item_Per_MainCategory();
  itemMainCategoryId: number = 0;
  itemId: number = 0;
  itemSubCategory: ItemSubCategory = new ItemSubCategory();
  itemSubCategoryId: number = 0;
}

export class Units
{
  id: number = 0;
  wholeSaleUnit: string = "";
  retailUnit: string = "";
  numberInWholeSale: number = 0;
  numberInRetailSale: number = 0;
  conversionRate: number = this.numberInRetailSale * this.numberInWholeSale;
  subdomain: string = subdomain;
  Item_Units: Item_Units[] = [];
}

export class Brands
{
  id: number = 0;
  brandName: string = "";
  ItemBrands: ItemBrands[] = [];
  subdomain: string = subdomain;
}
export class Item
{
  id: number = 0;
  defaultInventoryId: number = 0;
  defaultInventoryName: string = "";
  itemName: string = "";
  hasExpire: boolean = false;
  isOnline: boolean = false;
  hasDescription: boolean = false;
  hasSpecialOffer: boolean = false;
  hasNote: boolean = false;
  HasSKU_number: boolean = false;
  hasInternalNote: boolean = false;
  dateCreated: Date = new Date();
  applicationUser: any;
  addedBy_UserId: number = 0;
  addedBy_UserName: string = "";
  itemNotes: ItemNotes = new ItemNotes();
  internalNotes: InternalNotes = new InternalNotes();
  itemDescription: ItemDescription = new ItemDescription();
  item_Units: any;
  itemBrands: any;
  item_Per_MainCategory: Item_Per_MainCategory = new Item_Per_MainCategory();
  notesForClients: string = "";
  internNotes: string = "";
  description: string = "";
  subCatsId: number[] = [];
  brandsIds: number[] = [];
  unitsIds: number[] = [];
  suppliersIds: number[] = [];
  itemSKUKeys: ItemSKUKeys[] = [];
}

export class ItemBrands
{
  id: number = 0;
  notes: string = "";
  item: Item = new Item();
  itemId: number = 0;
  brands: Brands = new Brands();
  brandsId: number = 0;
}
export class Item_Units
{
  id: number = 0;
  item: any;
  itemId: number = 0;
  units: any;
  unitsId: number = 0;
}

export class Item_Per_MainCategory
{
  itemMainCategory: ItemMainCategory = new ItemMainCategory();
  itemMainCategoryId: number = 0;
  item: Item = new Item();
  itemId: number = 0;
}
export class ItemNotes
{
  id: number = 0;
  notes: string = "";
  item: any;
  itemId: number = 0;
}
export class InternalNotes
{
  id: number = 0;
  notes: string = "";
  item: any;
  itemId: number = 0;
}

export class ItemDescription
{
  id: number = 0;
  description: string = "";
  item: any;
  itemId: number = 0;
}
export class ItemVariants
{
  id: number = 0;
  variantName: string = "";
  notifyLessThan: number = 0;
  lastPurchasePrice: number = 0;
  currentNoInWarehouse: number = 0;
  totalAmountInAllInvetroies: number = 0;
  profitMargin: number = 0;
  profitMarginType: number = 0;
  barcode: string = "";
  globalBarcode: string = "";
  itemBrands: any;
  itemId: number = 0;
  brandsId: number = 0;
  itemSKU: string = "";
  ItemSKUStructure: string = "";
  hasWholeSalePrice: boolean = false;
  hasRetailPrice: boolean = false;
  itemVariant_WholeSalePrice: any;
  itemsVariant_RetailPrice: any;
  itemSKUkeys_Per_ItemVariants: any;
  retailPrice: number = 0;
  wholeSalePrice: number = 0;
  ItemSKUKeys: any;
}
export class ItemsVariant_RetailPrice
{
  id: number = 0;
  retailPrice: number = 0;
  minRetailPrice: number = 0;
  discountAmount: number = 0;
  discountType: number = 0;
  itemVariants: any;
  itemVariantsId: number = 0;
}

export class ItemVariant_WholeSalePrice
{
  id: number = 0;
  wholeSalePrice: number = 0;
  minWholeSalePrice: number = 0;
  discountAmount: number = 0;
  discountType: number = 0;
  itemVariants: any;
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
