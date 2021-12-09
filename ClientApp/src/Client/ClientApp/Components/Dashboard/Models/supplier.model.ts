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
  hasNotes: boolean = false;
  currency: Currency = new Currency();
  currencyId: number = 0;
  country: Country = new Country();
  countryId: number = 0;
  userId: number = 0;
}
