export class TaxSettings {
  id: number = 0;
  name: string = "";
  percent: number = 0;
  inclusiveOrExclusive: number = 0;
}
export class Actions {
  id: number = 0;
  name: string = "";
}

export class AutomaticReminders {
  id: number = 0;
  emailsTemplates: EmailsTemplates = new EmailsTemplates();
  emailTemplateId: number = 0;
  whenRemidersSent: WhenRemidersSent = new WhenRemidersSent();
  whenOptionId: number = 0;
}
export class EmailsTemplates {
  id: number = 0;
  templateName: string = "";
  templateContent: string = "";
}
export class WhenRemidersSent {
  id: number = 0;
  whenOption: string = "";
}
export class Country {
  id: number = 0;
  countryNameCode: string = "";
  countryName: string = "";
  phoneCode: string = "";
  currencyCode: string = "";
  currency: Currency = new Currency();
  currencyId: number = 0;
}
export class Currency {
  id: number = 0;
  currencyName: string = "";
  currencyCode: string = "";
  currencySymbol: string = "";
}
export class PaymentMethods {
  id: number = 0;
  name: string = "";
}
export class Status {
  id: number = 0;
  name: string = "";
  color: string = "";
  OpenedOrClosed: boolean = false;
}
