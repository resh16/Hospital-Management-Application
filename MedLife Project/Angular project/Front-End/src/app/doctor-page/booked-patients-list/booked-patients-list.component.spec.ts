import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookedPatientsListComponent } from './booked-patients-list.component';

describe('BookedPatientsListComponent', () => {
  let component: BookedPatientsListComponent;
  let fixture: ComponentFixture<BookedPatientsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookedPatientsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookedPatientsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
