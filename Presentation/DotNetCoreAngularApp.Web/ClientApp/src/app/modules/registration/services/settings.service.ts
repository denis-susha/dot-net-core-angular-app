import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ICountryModel } from 'src/app/models/settings/countryModel';
import { UrlConstants } from 'src/app/global/url-constants';
import { IProvinceModel } from 'src/app/models/settings/provinceModel';

@Injectable()
export class SettingsService {
  countryModel = new BehaviorSubject<ICountryModel[]>([] as ICountryModel[]);

  constructor(private httpClient: HttpClient) {}

  getCountries(): Observable<ICountryModel[]> {
    return this.httpClient.get<ICountryModel[]>(UrlConstants.getCountries);
  }

  getProvinces(countryCode: string): Observable<IProvinceModel[]> {
    return this.httpClient.get<IProvinceModel[]>(`${UrlConstants.getProvinces}?countryCode=${countryCode}`);
  }
}
