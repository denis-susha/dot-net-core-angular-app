import { NgModule } from '@angular/core';
import { EmailComponent } from './email.component/email.component';
import { AddressComponent } from './address.component/address.component';
import { RegistrationService } from './services/registration.service';
import { RegistrationComponent } from './registration.component/registration.component';
import { RouteGuard } from './rout.guard';
import { SettingsService } from './services/settings.service';
import { RegistrationModules } from './registration-import';

@NgModule({
  imports: [RegistrationModules],
  declarations: [RegistrationComponent, EmailComponent, AddressComponent],
  exports: [],
  providers: [RegistrationService, SettingsService, RouteGuard],
})
export class RegistrationModule {}
