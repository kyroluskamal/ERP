import { Country } from "./generals.model";

export class Inventories {
  id: number = 0;
  warehouseName: string = "";
  mobilePhone: string = "";
  telephone: string = "";
  notes: string = "";
  isActive: boolean = false;
  isMainInventory: boolean = false;
  addedBy_UserId?: number = 0;
  subdomain: string = "";
  addedBy_UserName: string = "";
  inventoryAddress?: InventoryAddress = new InventoryAddress();
  inventoryAddressId?: number = 0;
  inventAdd?: string = "";
}
export class InventoryAddress {
  id: number = 0;
  buildingNo: string = "";
  flatNo: string = "";
  addressLine_1: string = "";
  addressLine_2: string = ""
  postalCode: string = "";
  country?: Country = new Country();
  countryId?: number = 0;
  city: string = "";
  government: string = "";
  streetName: string = "";
  inventories: Inventories = new Inventories();
  inventoriesId: number = 0;
  subdomain: string = "";
}
