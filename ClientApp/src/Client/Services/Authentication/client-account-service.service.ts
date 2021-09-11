import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ClientRegister } from '../../../Client/Models/client-register.model';
import { Constants } from '../../../Helpers/constants';
import { ClientLogin } from '../../Models/client-login.model';
import { ClientWithToken } from '../../Models/client-with-token.model';


@Injectable({
  providedIn: 'root'
})
export class ClientAccountService {

  constructor(private httpClient: HttpClient) { }
  private currentUserSource = new ReplaySubject<ClientWithToken>(1);
  currentUserOvservable = this.currentUserSource.asObservable();

  Register(clientRegisterModel: ClientRegister): Observable<any> {
    return this.httpClient.post<any>(Constants.ClientRegister_APIurl, clientRegisterModel, { responseType: "json" })
     .pipe(
      map((Client: ClientWithToken) => {
        if (Client) {
          console.log(Client);
          //localStorage.setItem('Client', JSON.stringify(Client));
          //this.currentUserSource.next(Client);
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
}
