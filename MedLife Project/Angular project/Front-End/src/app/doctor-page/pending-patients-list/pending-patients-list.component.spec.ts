import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingPatientsListComponent } from './pending-patients-list.component';

describe('PendingPatientsListComponent', () => {
  let component: PendingPatientsListComponent;
  let fixture: ComponentFixture<PendingPatientsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PendingPatientsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingPatientsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
