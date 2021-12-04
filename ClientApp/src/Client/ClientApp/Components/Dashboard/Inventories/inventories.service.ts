import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { Inventories } from '../Models/inventories.model';

@Injectable({
  providedIn: 'root'
})
export class InventoriesService {
  subdomain = window.location.hostname.split(".")[0];

  constructor(private httpClient: HttpClient, public Constants: ConstantsService) { }

  GetAllInventories(): Observable<Inventories[]> {
    return this.httpClient.get<Inventories[]>(`${RouterConstants.Inventories_GetAll_API}?subomain=${this.subdomain}`);
  }
}
