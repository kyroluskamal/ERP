import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ClientRegister } from '../../../Client/Models/client-register.model';
import { Constants } from '../../../Helpers/constants';
import { ClientForgetPasswordModel } from '../../Models/client-forget-password-model.model';
import { ClientLogin } from '../../Models/client-login.model';
import { ClientResetPasswordModel } from '../../Models/client-reset-password-model.model';
import { ClientWithToken } from '../../Models/client-with-token.model';
import { EmailConfirmationModel } from '../../Models/email-confirmation-model.model';
import { SendEmailConfirmationAgian } from '../../Models/send-email-confirmation-agian.model';


@Injectable({
  providedIn: 'root'
})
export class ClientAccountService {

  //constructor
  constructor(private httpClient: HttpClient) {
    
    
  }
  private currentUserSource = new ReplaySubject<ClientWithToken>(1);
  currentUserOvservable = this.currentUserSource.asObservable();
  
  Register(clientRegisterModel: ClientRegister): Observable<any> {
    return this.httpClient.post<any>(Constants.ClientRegister_APIurl, clientRegisterModel, { responseType: "json" })
     .pipe(
      map((Client: ClientWithToken) => {
        if (Client) {
          console.log(Client);
        }
        return Client;
      })
   );
  }

  loginMainDomain(ClientLogin: ClientLogin, RememberMe: boolean) {
    return this.httpClient.post(Constants.ClientLoginMainDomain_APIurl, ClientLogin, { responseType: "json" }).pipe(
      map((response: any) => {
        const user: ClientWithToken = response;
        if (user) {
          if (RememberMe)
            localStorage.setItem(Constants.Client, JSON.stringify(user));
          else
            sessionStorage.setItem(Constants.Client, JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return response;
      })
    )
  }

  setCurrentUser(Client: ClientWithToken) {
    this.currentUserSource.next(Client);
  }

  logout() {
    sessionStorage.removeItem(Constants.Client);
    localStorage.removeItem(Constants.Client);
    this.currentUserSource.next(undefined);
  }
  confirmEmail(emailConfirmationModel: EmailConfirmationModel) {
    return this.httpClient.post(Constants.Client_EmailConfirmationUrl_APIURL, emailConfirmationModel, { responseType: "json" });
  }

  SendConfirmationAgain(sendEmailConfirmationAgian: SendEmailConfirmationAgian) {
    return this.httpClient.post(Constants.Client_ResendEmailConfirmation_APIURL, sendEmailConfirmationAgian, { responseType: "json" })
  }
  ClientForgetPassord(ForgetPassowrdModel: ClientForgetPasswordModel) {
    return this.httpClient.post(Constants.Client_ForgetPassword_APIURL, ForgetPassowrdModel, { responseType: "json" });
  }

  ClientResetPassword(clientResetPasswordModel: ClientResetPasswordModel) {
    return this.httpClient.post(Constants.Client_ResetPassword_APIURL, clientResetPasswordModel, { responseType: "json" });
  }
}
