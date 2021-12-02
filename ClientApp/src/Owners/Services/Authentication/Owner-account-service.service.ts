import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { EmailConfirmationModel, SendEmailConfirmationAgian } from 'src/Client/Models/client-models.model';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ConstantsService } from '../../../CommonServices/constants.service';
import { ForgetPasswordModel } from '../../Models/forget-password-model.model';
import { OwnerLogin } from '../../Models/owner-login.model';
import { OwnerRegister } from '../../Models/owner-register.model';
import { OwnerResetPasswordModel } from '../../Models/owner-reset-password-model.model';
import { OwnerWithToken } from '../../Models/owner-with-token.model';


@Injectable({
  providedIn: 'root'
})
export class OwnerAccountService {

  constructor(private httpClient: HttpClient, public Constants: ConstantsService) { }
  private currentUserSource = new ReplaySubject<OwnerWithToken | any>(1);
  currentUserOvservable = this.currentUserSource.asObservable();

  Register(ownerRegisterModel: OwnerRegister): Observable<any> {
    return this.httpClient.post<any>(RouterConstants.OwnerRegister_APIurl, ownerRegisterModel, { responseType: "json" }).pipe(
      map((Owner: OwnerWithToken) => {
        if (Owner) {
          console.log(Owner);
        }
        return Owner;
      })
    );
  }
  login(UserLogin: OwnerLogin, RememberMe: boolean) {
    return this.httpClient.post(RouterConstants.OwnerLogin_APIurl, UserLogin, { responseType: "json" }).pipe(
      map((response: any) => {
        const user: OwnerWithToken = response;
        if (user) {
          if (RememberMe)
            localStorage.setItem(this.Constants.Owner, JSON.stringify(user));
          else
            sessionStorage.setItem(this.Constants.Owner, JSON.stringify(user));
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
    sessionStorage.removeItem(this.Constants.Owner);
    localStorage.removeItem(this.Constants.Owner);
    this.currentUserSource.next(null);
  }

  confirmEmail(emailConfirmationModel: EmailConfirmationModel) {
    return this.httpClient.post(RouterConstants.Owner_EmailConfirmationUrl_APIURL, emailConfirmationModel, { responseType: "json" });
  }

  SendConfirmationAgain(sendEmailConfirmationAgian: SendEmailConfirmationAgian) {
    return this.httpClient.post(RouterConstants.Owner_ResendEmailConfirmation_APIURL, sendEmailConfirmationAgian, { responseType: "json" })
  }

  OwnerForgetPassord(ForgetPassowrdModel: ForgetPasswordModel) {
    return this.httpClient.post(RouterConstants.Owner_ForgetPassword_APIURL, ForgetPassowrdModel, { responseType: "json" });
  }

  OwnerResetPassword(ownerResetPasswordModel: OwnerResetPasswordModel) {
    return this.httpClient.post(RouterConstants.Owner_ResetPassword_APIURL, ownerResetPasswordModel, { responseType: "json" });
  }
}
