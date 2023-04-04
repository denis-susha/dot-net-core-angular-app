import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { SettingsService } from './settings.service';
import { ICountryModel } from 'src/app/models/settings/countryModel';
import { UrlConstants } from 'src/app/global/url-constants';
import { IProvinceModel } from 'src/app/models/settings/provinceModel';

describe('SettingsService', () => {
  let settingsService: SettingsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SettingsService],
    });

    settingsService = TestBed.inject(SettingsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(settingsService).toBeTruthy();
  });

  it('get countries', () => {
    const dummyCountries: ICountryModel[] = [
      {
        countryCode: 'C1',
        name: 'Country 1',
      },
      {
        countryCode: 'C2',
        name: 'Country 2',
      },
    ];

    settingsService.getCountries().subscribe(countries => {
      expect(countries.length).toBe(2);
      expect(countries).toEqual(dummyCountries);
    });
    const request = httpMock.expectOne(UrlConstants.getCountries);
    expect(request.request.method).toBe('GET');
    request.flush(dummyCountries);
  });

  it('get provinces', () => {
    const dummyProvinces: IProvinceModel[] = [
      {
        provinceId: 1,
        countryCode: 'C1',
        name: 'Province 1.1',
      },
      {
        provinceId: 2,
        countryCode: 'C1',
        name: 'Province 1.2',
      },
    ];
    const countryCode = 'C1';

    settingsService.getProvinces(countryCode).subscribe(countries => {
      expect(countries.length).toBe(2);
      expect(countries).toEqual(dummyProvinces);
    });
    const request = httpMock.expectOne(`${UrlConstants.getProvinces}?countryCode=${countryCode}`);
    expect(request.request.method).toBe('GET');
    request.flush(dummyProvinces);
  });
});
