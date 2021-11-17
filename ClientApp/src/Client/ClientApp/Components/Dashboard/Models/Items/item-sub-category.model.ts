import { ItemMainCategory } from "./item-main-category.model";

export class ItemSubCategory {
  id?: number = 0;
  name: string = "";
  itemMainCategoryId: number = 0;
  ItemMainCategory: ItemMainCategory = new ItemMainCategory();
  subdomain: string = "";
}
