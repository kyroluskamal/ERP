import { Country, Currency } from "./generals.model";

export class Suppliers {
  id: number = 0;
  businessName: string = "";
  firstName: string = "";
  lastName: string = "";
  telephone: string = "";
  mobilePhone: string = "";
  taxID: string = "";
  CR: string = "";
  email: string = "";
  dateCreated: Date = new Date();
  openingBalance: number = 0;
  notes: string = "";
  currency: string = "";
  currencyId: number = 0;
  country: string = "";
  countryId: number = 0;
  addedBy_UserId: number = 0;
  addedBy_UserName: string = "";
  subdomain: string = "";
}
