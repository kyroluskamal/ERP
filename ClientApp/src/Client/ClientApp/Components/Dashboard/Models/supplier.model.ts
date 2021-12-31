import { Country, Currency } from "./generals.model";

export class Suppliers {
  id: number = 0;
  businessName: string = "";
  firstName: string = "";
  lastName: string = "";
  telephone: string = "";
  mobilePhone: string = "";
  taxID: string = "";
  cr: string = "";
  email: string = "";
  dateCreated: Date = new Date();
  openingBalanceDate: Date = new Date();
  openingBalance: number = 0;
  balance: number = 0;
  notes: string = "";
  currency: string = "";
  currencyId: number = 0;
  countryName: string = "";
  countryId: number = 0;
  countryNameCode: string = "";
  addedBy_UserId: number = 0;
  addedBy_UserName: string = "";
  logo: any;
  subdomain: string = "";
}
