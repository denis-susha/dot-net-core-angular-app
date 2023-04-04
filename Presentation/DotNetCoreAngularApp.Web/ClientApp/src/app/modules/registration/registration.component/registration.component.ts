import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RegistrationComponent {
  constructor(private router: Router) {
    router.navigate(['/registration/email']);
  }
}
