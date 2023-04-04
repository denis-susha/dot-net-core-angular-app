import { Injectable } from '@angular/core';
import { IRegistrationModel } from 'src/app/models/registration/registrationModel';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ILoginInfo } from 'src/app/models/registration/emailModel';
import { UrlConstants } from 'src/app/global/url-constants';

@Injectable()
export class RegistrationService {
  registrationModel = new BehaviorSubject<IRegistrationModel>({} as IRegistrationModel);

  constructor(private httpClient: HttpClient) {}

  updateLoginInfoInModel(model: ILoginInfo) {
    const tempData: IRegistrationModel = {
      ...this.registrationModel.getValue(),
      loginInfo: model,
    };
    this.registrationModel.next(tempData);
  }

  updateAddressInfoInModel(provinceId: number) {
    const tempData: IRegistrationModel = {
      ...this.registrationModel.getValue(),
      provinceId: provinceId,
    };
    this.registrationModel.next(tempData);
  }

  registerUser(): Observable<void> {
    return this.httpClient.post<void>(UrlConstants.registerUser, this.registrationModel.getValue());
  }
}
