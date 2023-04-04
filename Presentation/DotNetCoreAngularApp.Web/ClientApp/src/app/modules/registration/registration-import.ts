import { CommonModule } from '@angular/common';
import { RegistrationRoutingModule } from './registration-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';

var registrationModules = [
  CommonModule,
  SharedModule,
  RegistrationRoutingModule,
  HttpClientModule,
  MatButtonModule,
  MatFormFieldModule,
  FormsModule,
  ReactiveFormsModule,
  MatInputModule,
  MatIconModule,
  MatCheckboxModule,
  MatSelectModule,
  MatSnackBarModule,
];

export { registrationModules as RegistrationModules };
