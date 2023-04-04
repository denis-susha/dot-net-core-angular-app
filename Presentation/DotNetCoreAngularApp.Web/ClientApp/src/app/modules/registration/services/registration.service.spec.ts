import { TestBed } from '@angular/core/testing';
import { RegistrationService } from './registration.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ILoginInfo } from 'src/app/models/registration/emailModel';

describe('RegistrationService', () => {
  let registrationService: RegistrationService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RegistrationService],
    });

    registrationService = TestBed.inject(RegistrationService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(registrationService).toBeTruthy();
  });

  it('update loginInfo model', () => {
    const model = {
      email: 'test@email.com',
      password: '1q',
      confirmPassword: '1q',
      acceptTerms: true,
    } as ILoginInfo;

    registrationService.updateLoginInfoInModel(model);

    registrationService.registrationModel.subscribe(m => {
      expect(m).toBeTruthy();
      expect(m.loginInfo).toEqual(model);
    });
  });

  it('update address model', () => {
    const provinceId = 1;

    registrationService.updateAddressInfoInModel(provinceId);

    registrationService.registrationModel.subscribe(m => {
      expect(m).toBeTruthy();
      expect(m.provinceId).toEqual(provinceId);
    });
  });
});
