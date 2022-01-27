import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentBookingComponent } from './appointment-booking/appointment-booking.component';

import { PatientNavbarComponent } from './patient-navbar/patient-navbar.component';
import { PatientHomeComponent } from './patient-home/patient-home.component';
import { SharedModule } from '../shared/shared.module';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppointmentBookingComponent,
    PatientNavbarComponent,
    PatientHomeComponent,
    PatientDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PatientPageModule { }
