export class ClientResetPasswordModel {
  email: string | null = "";
  token: string | null = "";
  Password: string = "";
  ConfirmPassword: string = "";
  IsCOC?: boolean = false;
  Subdomain?: string = "";
}
