let subdomain = window.location.hostname.split(".")[0];

export class ItemSubCategory {
  id?: number = 0;
  name: string = "";
  itemMainCategoryId: number = 0;
  ItemMainCategory: ItemMainCategory = new ItemMainCategory();
  subdomain: string = subdomain;
}

export class ItemMainCategory {
  id: number = 0;
  name: string = "";
  subdomain: string = subdomain;
}

export class ItemUnit {
  Id: number = 0;
  WholeSaleUnit: string = "";
  RetailUnit: string = "";
  NumberInWholeSale: number = 0;
  NumberInRetailSale: number = 0;
  ConversionRate: number = this.NumberInRetailSale * this.NumberInWholeSale;
  Subdomain: string = subdomain;

}
