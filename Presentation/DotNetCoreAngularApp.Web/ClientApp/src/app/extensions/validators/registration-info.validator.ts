import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function registrationInfoValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const email = control.get('email');
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (password && confirmPassword && password.value !== confirmPassword.value) {
      confirmPassword.setErrors({ confirmPassword: true });
    }

    return email && password && confirmPassword && password.value !== confirmPassword.value
      ? { confirmPassword: true }
      : null;
  };
}
