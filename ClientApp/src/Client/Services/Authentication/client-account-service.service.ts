import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ClientRegister } from '../../../Client/Models/client-register.model';
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
   return this.httpClient.post<any>("/api/Identity", clientRegisterModel, { responseType: "json" })
     .pipe(
      map((Client: ClientWithToken) => {
        if (Client) {
          console.log(Client);
          localStorage.setItem('Client', JSON.stringify(Client));
          this.currentUserSource.next(Client);
        }
        return Client;
      })
   );
  }

  login(ClientLogin: ClientLogin) {
    return this.httpClient.post("/api/Identity", ClientLogin, { responseType: "json" }).pipe(
      map((response: any) => {
        const user: ClientWithToken = response;
        if (user) {
          localStorage.setItem('Client', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(Client: ClientWithToken) {
    this.currentUserSource.next(Client);
  }

  logout() {
    localStorage.removeItem('Client');
    this.currentUserSource.next();
  }
}
