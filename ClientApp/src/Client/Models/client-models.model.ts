export class ApplicationUser {
  Id: number = 0;
  UserName: string = "";
  NormalizedUserName: string = "";
  Email: string = "";
  Token: string = "";
}

export class ClientLogin {
  Email: string = "";
  Password: string = "";
  Subdomain?: string = "";
  IsCOC?: boolean = false;
}

export class ClientRegister {
  Email: string = "";
  Password: string = "";
  ConfirmPassword: string = "";
  CompanyName: string = "";
  Subdomain: string = "";
  UserName: string = "";
  ClientUrl = "";
}
export class ClientForgetPasswordModel {
  Email: string | null = "";
  ClientUrl: string = "";
  IsCOC?: boolean = false;
  Subdomain?: string = "";
}

export class ClientWithToken {
  UserId: number = 0;
  Username: string = "";
  Token: string = "";
  roles: string[] = [];
  subdomain: string = "";
}
export class EmailConfirmationModel {
  email: string = "";
  token: string = "";
  IsCOC?: boolean = false;
  Subdomain?: string = "";
}
export class SendEmailConfirmationAgian {
  Email: string = "";
  ClientUrl: string = "";
  IsCOC?: boolean = false;
  Subdomain?: string = "";
}
export class ClientResetPasswordModel {
  email: string | null = "";
  token: string | null = "";
  Password: string = "";
  ConfirmPassword: string = "";
  IsCOC?: boolean = false;
  Subdomain?: string = "";
}

