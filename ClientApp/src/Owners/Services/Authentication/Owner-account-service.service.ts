import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ClientRegister } from '../../../Client/Models/client-register.model';
import { EmailConfirmationModel } from '../../../Client/Models/email-confirmation-model.model';
import { SendEmailConfirmationAgian } from '../../../Client/Models/send-email-confirmation-agian.model';
import { Constants } from '../../../Helpers/constants';
import { OwnerLogin } from '../../Models/owner-login.model';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnerWithToken } from '../../Models/owner-with-token.model';


@Injectable({
  providedIn: 'root'
})
export class OwnerAccountService {

  constructor(private httpClient: HttpClient) { }
  private currentUserSource = new ReplaySubject<OwnerWithToken>(1);
  currentUserOvservable = this.currentUserSource.asObservable();

  Register(ownerRegisterModel: OwnerRegister): Observable<any> {
    return this.httpClient.post<any>(Constants.OwnerRegister_APIurl, ownerRegisterModel, { responseType: "json" }).pipe(
      map((Owner: OwnerWithToken) => {
        if (Owner) {
          console.log(Owner);
        }
        return Owner;
      })
    );
  }
  login(UserLogin: OwnerLogin, RememberMe: boolean) {
    return this.httpClient.post(Constants.OwnerLogin_APIurl, UserLogin, { responseType: "json" }).pipe(
      map((response: any) => {
        const user: OwnerWithToken = response;
        if (user) {
          if (RememberMe)
            localStorage.setItem(Constants.Owner, JSON.stringify(user));
          else
            sessionStorage.setItem(Constants.Owner, JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return response;
      })
    )
  }

  setCurrentUser(Client: OwnerWithToken) {
    this.currentUserSource.next(Client);
  }

  logout() {
    sessionStorage.removeItem(Constants.Owner);
    localStorage.removeItem(Constants.Owner);
    this.currentUserSource.next(undefined);
  }

  confirmEmail(emailConfirmationModel: EmailConfirmationModel) {
    return this.httpClient.post(Constants.Owner_EmailConfirmationUrl_APIURL, emailConfirmationModel, { responseType: "json" });
  }

  SendConfirmationAgain(sendEmailConfirmationAgian: SendEmailConfirmationAgian) {
    return this.httpClient.post(Constants.Owner_ResendEmailConfirmation_APIURL, sendEmailConfirmationAgian, { responseType: "json" })
  }
}
