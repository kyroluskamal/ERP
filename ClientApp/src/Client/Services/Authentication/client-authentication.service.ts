import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClientRegister } from '../../Models/client-register.model';

@Injectable({
  providedIn: 'root'
})
export class ClientAuthenticationService {

  constructor(private httpClient: HttpClient) { }

  public OwnerRegister(clientRegisterModel: ClientRegister): Observable<any> {
    return this.httpClient.post<any>("/api/Identity", clientRegisterModel, { responseType: "json" });
  }
}
