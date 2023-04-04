import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IRegistrationModel } from 'src/app/models/registration/registrationModel';
import { RegistrationService } from './services/registration.service';

@Injectable()
export class RouteGuard {
  registrationModel: IRegistrationModel = {} as IRegistrationModel;

  constructor(private registrationService: RegistrationService, private router: Router) {
    registrationService.registrationModel.subscribe(model => {
      this.registrationModel = model;
    });
  }

  canActivate(): boolean {
    if (!!this.registrationModel && !!this.registrationModel.loginInfo) {
      return true;
    } else {
      this.router.navigate(['/registration/email']);
      return false;
    }
  }
}
