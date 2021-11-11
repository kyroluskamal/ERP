import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { ItemMainGategory } from '../Models/Items/item-main-gategory.model';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor(private httpClient: HttpClient, public Constants: ConstantsService) {

  }

  //#region Item Main Category
  GetAllGategories(): Observable<ItemMainGategory[]> {
    let subomain = window.location.hostname.split('.')[0];
    return this.httpClient.get<ItemMainGategory[]>(`${RouterConstants.ItemMainCategory_GetAll_API}?subomain=${subomain}`);
  }
  AddMainCat(CatName: string): Observable<ItemMainGategory> {
    let subdomain = window.location.hostname.split('.')[0];
    return this.httpClient.get<ItemMainGategory>(`${RouterConstants.ItemMainCategory_AddMainCat_API}?CatName=${CatName}&subdomain=${subdomain}`);
  }
  //#endregion
}
