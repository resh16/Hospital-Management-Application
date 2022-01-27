import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientNavbarComponent } from './patient-navbar.component';

describe('PatientNavbarComponent', () => {
  let component: PatientNavbarComponent;
  let fixture: ComponentFixture<PatientNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
