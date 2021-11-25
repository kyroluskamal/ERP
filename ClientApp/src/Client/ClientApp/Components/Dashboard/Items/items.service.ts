import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { Brands, ItemMainCategory, ItemSubCategory, ItemUnit } from '../Models/item.model';
import { CookieService } from "ngx-cookie-service"

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  subdomain = window.location.hostname.split(".")[0];

  constructor(private httpClient: HttpClient, public Constants: ConstantsService, private CookieServ: CookieService) {

  }

  //#region Item Main Category
  GetAllGategories(): Observable<ItemMainCategory[]> {
    return this.httpClient.get<ItemMainCategory[]>(`${RouterConstants.ItemMainCategory_GetAll_API}?subomain=${this.subdomain}`);
  }
  AddMainCat(NewCat: ItemMainCategory): Observable<ItemMainCategory> {
    return this.httpClient.post<ItemMainCategory>(`${RouterConstants.ItemMainCategory_AddMainCat_API}`, NewCat);
  }

  DeleteMainCat(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.ItemMainCategory_DELETE_MainCat_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  UpdateMainCat(ItemMainCat: ItemMainCategory): Observable<any> {
    return this.httpClient.put<ItemMainCategory>(RouterConstants.ItemMainCategory_UPDATE_MainCat_API, ItemMainCat, { responseType: 'json' });
  }
  //#endregion


  //#region Item Sub Cats
  GetItems_All_SubCats(): Observable<ItemSubCategory[]> {
    return this.httpClient.get<ItemSubCategory[]>(`${RouterConstants.Item_Sub_Category_GetAll_API}?subdomain=${this.subdomain}`);
  }

  AddNew_SubCAt(SubCategory: ItemSubCategory): Observable<ItemSubCategory> {
    return this.httpClient.post<ItemSubCategory>(`${RouterConstants.Item_Sub_Category_Add_API}`, SubCategory);
  }
  Update_SubCAt(SubCategory: ItemSubCategory): Observable<any> {
    return this.httpClient.put(`${RouterConstants.Item_Sub_Category_Update_API}`, SubCategory);
  }
  DeleteSubCat(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.Item_Sub_Category_Delete_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  //#endregion


  //#region Item Units
  Get_All_ItemUnits(): Observable<ItemUnit[]> {
    return this.httpClient.get<ItemUnit[]>(`${RouterConstants.Item_Unit_GetAll_API}?subdomain=${this.subdomain}`, { responseType: 'json' });
  }

  AddNew_ItemUnit(ItemUnit: ItemUnit): Observable<ItemUnit> {
    return this.httpClient.post<ItemUnit>(`${RouterConstants.Item_Unit_Add_API}`, ItemUnit, { headers: { 'Content-Type': 'application/json' } });
  }
  Update_ItemUnit(ItemUnit: ItemUnit): Observable<any> {
    return this.httpClient.put(`${RouterConstants.Item_Unit_Update_API}`, ItemUnit);
  }
  Delete_ItemUnit(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.Item_Unit_Delete_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  //#endregion
  //#region Item Brands
  Get_All_ItemBrands(): Observable<Brands[]> {
    return this.httpClient.get<Brands[]>(`${RouterConstants.Item_Brand_GetAll_API}?subdomain=${this.subdomain}`);
  }

  AddNew_ItemBrand(Brand: Brands): Observable<Brands> {
    return this.httpClient.post<Brands>(`${RouterConstants.Item_Brand_Add_API}`, Brand);
  }
  Update_ItemBrand(Brand: Brands): Observable<any> {
    return this.httpClient.put(`${RouterConstants.Item_Unit_Update_API}`, Brand);
  }
  Delete_ItemBrand(id: number): Observable<any> {
    return this.httpClient.delete(`${RouterConstants.Item_Brand_Delete_API}?Subdomain=${this.subdomain}&id=${id}`)
  }
  //#endregion
}
