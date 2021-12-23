import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConstantsService } from 'src/CommonServices/constants.service';
import { RouterConstants } from 'src/Helpers/RouterConstants';
import { AbstractApi } from 'src/Interfaces/interfaces';
import { Country } from '../Models/generals.model';

@Injectable({
  providedIn: 'root'
})
export class GeneralsService {

  public Country: Country[] = [];
  GeoData: any
  constructor(private httpClient: HttpClient, public Constants: ConstantsService) {
    this.Countries().subscribe(r => this.Country = r);
    this.Get_GEO_Data().subscribe((r) => this.GeoData = r)
  }

  Countries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(RouterConstants.Country_GetAll_API);
  }
  Get_GEO_Data() {
    return this.httpClient.get("https://ipgeolocation.abstractapi.com/v1/?api_key=f6114bfa576e4abebcba5885b9a3fd91");
  }

  GetCountryId_by_countryCode(): number {
    return this.Country.find(x => x.countryNameCode === this.GeoData.country_code)?.id!
  }
}
