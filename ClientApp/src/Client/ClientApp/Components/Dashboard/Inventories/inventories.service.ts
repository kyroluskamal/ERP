import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { Inventories, InventoryAddress } from '../Models/inventories.model';

@Injectable({
  providedIn: 'root'
})
export class InventoriesService {
  subdomain = window.location.hostname.split(".")[0];

  constructor(private httpClient: HttpClient, public Constants: ConstantsService) { }

  GetAllInventories(): Observable<Inventories[]> {
    return this.httpClient.get<Inventories[]>(`${RouterConstants.Inventories_GetAll_API}?subomain=${this.subdomain}`);
  }

  AddWarehouse(newInvent: Inventories): Observable<Inventories> {
    return this.httpClient.post<Inventories>(RouterConstants.Inventories_Add_API, newInvent)
  }
  DeleteWarehouse(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.Inventories_Delete_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  UpdateWarehouse(UpdatedInvent: Inventories): Observable<any> {
    return this.httpClient.put(`${RouterConstants.Inventories_Update_API}`, UpdatedInvent);
  }

  //#region Inventory Address
  GetAllAddresses(): Observable<InventoryAddress[]> {
    return this.httpClient.get<InventoryAddress[]>(`${RouterConstants.InventoryAddress_GET_API}?subomain=${this.subdomain}`);
  }
  AddAddress(newAddress: InventoryAddress) {
    return this.httpClient.post<InventoryAddress>(RouterConstants.InventoryAddress_Add_API, newAddress)
  }
  UpdateAddress(AddToUpdate: InventoryAddress): Observable<any> {
    return this.httpClient.put(`${RouterConstants.InventoryAddress_UPDATE_API}`, AddToUpdate);
  }
  DeleteAddress(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.InventoryAddress_DELETE_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  //#endregion
}
