import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { passwordValidator } from 'src/app/extensions/validators/password.validator';
import { registrationInfoValidator } from 'src/app/extensions/validators/registration-info.validator';
import { TextConstants } from 'src/app/global/text-constants';
import { ILoginInfo } from 'src/app/models/registration/emailModel';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css'],
})
export class EmailComponent implements OnInit {
  hidePassword = true;
  registrationInfoForm!: FormGroup;

  constructor(private router: Router, private registrationService: RegistrationService) {}

  ngOnInit(): void {
    this.registrationInfoForm = new FormGroup(
      {
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, passwordValidator()]),
        confirmPassword: new FormControl('', [Validators.required]),
        acceptTerms: new FormControl(false, []),
      },
      { validators: registrationInfoValidator(), updateOn: 'submit' }
    );
  }

  get email() {
    return this.registrationInfoForm && this.registrationInfoForm.get('email')!;
  }

  get password() {
    return this.registrationInfoForm && this.registrationInfoForm.get('password')!;
  }

  get confirmPassword() {
    return this.registrationInfoForm && this.registrationInfoForm.get('confirmPassword')!;
  }

  get acceptTerms() {
    return this.registrationInfoForm && this.registrationInfoForm.get('acceptTerms')!;
  }

  getEmailErrorMessage() {
    if (this.email && this.email.hasError('required')) {
      return TextConstants.requiredField;
    }

    return this.email && this.email.hasError('email') ? TextConstants.loginValidationError : '';
  }

  getPasswordErrorMessage() {
    if (this.password && this.password.hasError('required')) {
      return TextConstants.requiredField;
    }

    return this.password && this.password.hasError('password') ? TextConstants.passwordValidationError : '';
  }

  getConfirmPasswordErrorMessage() {
    if (this.confirmPassword && this.confirmPassword.hasError('required')) {
      return TextConstants.requiredField;
    }

    return this.confirmPassword && this.confirmPassword.hasError('confirmPassword')
      ? TextConstants.confirmPasswordValidationError
      : '';
  }

  getAcceptTermsErrorMessage() {
    if (this.acceptTerms && this.acceptTerms.hasError('required')) {
      return TextConstants.required;
    }

    return '';
  }

  onSubmit() {
    this.acceptTerms.addValidators([Validators.requiredTrue]);

    if (this.registrationInfoForm.valid && this.acceptTerms.value) {
      const model = {
        email: this.email.value,
        password: this.password.value,
        confirmPassword: this.confirmPassword.value,
        acceptTerms: this.acceptTerms.value,
      } as ILoginInfo;

      this.registrationService.updateLoginInfoInModel(model);
      this.router.navigate(['/registration/address']);
    }

    if (!this.acceptTerms.value) {
      this.acceptTerms.setErrors({ required: true });
    }
  }
}
