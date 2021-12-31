import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { Suppliers } from '../Models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {
  subdomain = window.location.hostname.split(".")[0];

  constructor(private httpClient: HttpClient, public Constants: ConstantsService) { }

  GetAllSuppliers(): Observable<Suppliers[]> {
    return this.httpClient.get<Suppliers[]>(`${RouterConstants.Suppliers_GetAll_API}?subomain=${this.subdomain}`);
  }
  AddNewSupplier(newSupplier: Suppliers): Observable<Suppliers> {
    return this.httpClient.post<Suppliers>(RouterConstants.Suppliers_ADD_API, newSupplier);
  }

  DeleteSupplier(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.Suppliers_DELETE_API}?Subdomain=${this.subdomain}&id=${id}`)
  }

  UpdateSupplier(UpdatedItem: Suppliers): Observable<any> {
    return this.httpClient.put(`${RouterConstants.Suppliers_UPDATE_API}`, UpdatedItem);
  }
}
