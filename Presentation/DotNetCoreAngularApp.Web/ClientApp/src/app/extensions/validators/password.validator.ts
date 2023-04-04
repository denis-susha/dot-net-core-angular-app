import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function passwordValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null;
    }

    const hasLetter = /[a-zA-Z]+/.test(value);
    const hasDigit = /[0-9]+/.test(value);

    const isValid = hasLetter && hasDigit;

    return !isValid ? { password: true } : null;
  };
}
