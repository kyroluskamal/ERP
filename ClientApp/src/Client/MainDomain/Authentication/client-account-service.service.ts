import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ClientRegister } from '../../../Client/Models/client-register.model';
import { ConstantsService } from '../../../CommonServices/constants.service';
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
  constructor(private httpClient: HttpClient, public Constants: ConstantsService,
    private router: Router) {
  }
  private currentUserSource = new ReplaySubject<ClientWithToken | any>(1);
  currentUserOvservable = this.currentUserSource.asObservable();

  Register(clientRegisterModel: ClientRegister): Observable<any> {
    return this.httpClient.post<any>(RouterConstants.ClientRegister_APIurl, clientRegisterModel, { responseType: "json" })
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
    return this.httpClient.post(RouterConstants.ClientLoginMainDomain_APIurl, ClientLogin, { responseType: "json" }).pipe(
      map((response: any) => {
        const user: ClientWithToken = response;
        if (user) {
          if (RememberMe)
            localStorage.setItem(this.Constants.Client, JSON.stringify(user));
          else
            sessionStorage.setItem(this.Constants.Client, JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(Client: ClientWithToken) {
    this.currentUserSource.next(Client);
  }

  logout() {
    sessionStorage.removeItem(this.Constants.Client);
    localStorage.removeItem(this.Constants.Client);
    this.currentUserSource.next(null);
  }
  confirmEmail(emailConfirmationModel: EmailConfirmationModel) {
    return this.httpClient.post(RouterConstants.Client_EmailConfirmationUrl_APIURL, emailConfirmationModel, { responseType: "json" });
  }

  SendConfirmationAgain(sendEmailConfirmationAgian: SendEmailConfirmationAgian) {
    return this.httpClient.post(RouterConstants.Client_ResendEmailConfirmation_APIURL, sendEmailConfirmationAgian, { responseType: "json" })
  }
  ClientForgetPassord(ForgetPassowrdModel: ClientForgetPasswordModel) {
    return this.httpClient.post(RouterConstants.Client_ForgetPassword_APIURL, ForgetPassowrdModel, { responseType: "json" });
  }

  ClientResetPassword(clientResetPasswordModel: ClientResetPasswordModel) {
    return this.httpClient.post(RouterConstants.Client_ResetPassword_APIURL, clientResetPasswordModel, { responseType: "json" });
  }

  IsTenantFound(subdomain: string): Observable<any> {
    return this.httpClient.get(`${RouterConstants.IsTenantFound_APIURL}?subdomain=${subdomain}`);
  }
}
