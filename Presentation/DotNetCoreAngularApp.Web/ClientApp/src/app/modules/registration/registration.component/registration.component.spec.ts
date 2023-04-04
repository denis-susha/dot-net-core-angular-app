import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { RegistrationComponent } from './registration.component';

describe('registration.componet', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [RegistrationComponent],
    }).compileComponents();
  });

  it('should be created', () => {
    const fixture = TestBed.createComponent(RegistrationComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
