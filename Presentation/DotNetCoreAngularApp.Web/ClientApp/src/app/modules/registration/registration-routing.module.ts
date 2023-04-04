import { inject, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from './address.component/address.component';
import { EmailComponent } from './email.component/email.component';
import { RegistrationComponent } from './registration.component/registration.component';
import { RouteGuard } from './rout.guard';

const routes: Routes = [
  {
    path: '',
    component: RegistrationComponent,
    children: [
      { path: 'email', component: EmailComponent },
      {
        path: 'address',
        component: AddressComponent,
        canActivate: [() => inject(RouteGuard).canActivate()],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RegistrationRoutingModule {}
