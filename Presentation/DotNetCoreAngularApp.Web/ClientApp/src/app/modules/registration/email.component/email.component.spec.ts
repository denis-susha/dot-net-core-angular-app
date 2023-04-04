import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { EmailComponent } from './email.component';
import { RegistrationService } from '../services/registration.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('registration.email.componet', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule,
        MatButtonModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        MatIconModule,
        MatCheckboxModule,
        MatSelectModule,
        MatSnackBarModule,
        BrowserAnimationsModule,
      ],
      declarations: [EmailComponent],
      providers: [RegistrationService],
    }).compileComponents();
  });

  it('should be created', () => {
    const fixture = TestBed.createComponent(EmailComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render header a h1 tag', () => {
    const fixture = TestBed.createComponent(EmailComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Step 1');
  });
});
