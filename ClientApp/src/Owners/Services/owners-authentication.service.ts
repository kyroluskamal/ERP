import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OwnerRegister } from '../Models/owner-register.model';

@Injectable({
  providedIn: 'root'
})
export class OwnersAuthenticationService {

  constructor(private httpClient: HttpClient) { }

  public OwnerRegister(ownerRegisterModel: OwnerRegister): Observable<any> {
    return this.httpClient.post<any>("/api/Owners/Account", ownerRegisterModel, { responseType:"json" });
  }
}
