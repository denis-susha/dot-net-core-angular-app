import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationService } from '../services/registration.service';
import { SettingsService } from '../services/settings.service';
import { ICountryModel } from 'src/app/models/settings/countryModel';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IProvinceModel } from 'src/app/models/settings/provinceModel';
import { MatOptionSelectionChange } from '@angular/material/core';
import { TextConstants } from 'src/app/global/text-constants';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registration-address',
  templateUrl: './address.component.html',
})
export class AddressComponent implements OnInit {
  countries!: ICountryModel[];
  provinces!: IProvinceModel[];
  addressInfoForm!: FormGroup;

  constructor(
    private router: Router,
    private registrationService: RegistrationService,
    private settingsService: SettingsService,
    private _snackBar: MatSnackBar
  ) {
    settingsService.getCountries().subscribe(countries => {
      this.countries = countries;
    });
  }

  ngOnInit(): void {
    this.addressInfoForm = new FormGroup(
      {
        country: new FormControl('', [Validators.required]),
        province: new FormControl({ value: '', disabled: true }, [Validators.required]),
      },
      {
        updateOn: 'submit',
      }
    );
  }

  get country() {
    return this.addressInfoForm && this.addressInfoForm.get('country')!;
  }

  get province() {
    return this.addressInfoForm && this.addressInfoForm.get('province')!;
  }

  getCountryErrorMessage() {
    if (this.country && this.country.hasError('required')) {
      return TextConstants.countryIsrequired;
    }

    return '';
  }

  getProvinceErrorMessage() {
    if (this.province && this.province.hasError('required')) {
      return TextConstants.provinceIsrequired;
    }

    return '';
  }

  onCountrySelect(event: MatOptionSelectionChange) {
    if (event.isUserInput) {
      this.settingsService.getProvinces(event.source.value).subscribe(provinces => {
        this.provinces = provinces;
        this.province.enable();
      });
    }
  }

  onSubmit() {
    if (this.addressInfoForm.valid) {
      this.registrationService.updateAddressInfoInModel(this.province.value);
      this.registrationService.registerUser().subscribe({
        next: () => {
          this.openSnackBar('Success!');
          setTimeout(() => this.router.navigate(['/']), 3000);
        },
        error: (e: Error) => {
          this.openSnackBar(e.message);
        },
        complete: () => console.log('User has been registered.'),
      });
    }
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Ok', { duration: 3000 });
  }
}
