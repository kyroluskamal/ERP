import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StorageMap } from '@ngx-pwa/local-storage';
import { Observable, ReplaySubject, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import {
  ClientForgetPasswordModel, ClientRegister, ClientResetPasswordModel,
  ClientWithToken, EmailConfirmationModel, SendEmailConfirmationAgian, ClientLogin
} from 'src/Client/Models/client-models.model';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ConstantsService } from '../../../CommonServices/constants.service';



@Injectable({
  providedIn: 'root'
})
export class ClientAccountService {

  //constructor
  constructor(private httpClient: HttpClient, public Constants: ConstantsService,
    private router: Router, private IndexedBdStorage: StorageMap) {
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
    return this.httpClient.post(RouterConstants.ClientLoginMainDomain_APIurl, ClientLogin, { responseType: "json", observe: "response" }).pipe(
      map((response: any) => {
        console.log(response.headers);
        const user: ClientWithToken = response.body;
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
    var cookies = document.cookie.split(";");
    console.log(cookies);
    for (var i = 0; i < cookies.length; i++) {
      var cookie = cookies[i];
      var eqPos = cookie.indexOf("=");
      var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
      document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
    this.httpClient.get(RouterConstants.Client_Loggout);
    sessionStorage.removeItem(this.Constants.Client);
    localStorage.removeItem(this.Constants.Client);
    localStorage.removeItem("XSRF-REQUEST-TOKEN")
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
