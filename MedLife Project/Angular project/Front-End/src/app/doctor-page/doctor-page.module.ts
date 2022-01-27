import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookedPatientsListComponent } from './booked-patients-list/booked-patients-list.component';
import { DoctorNavbarComponent } from './doctor-navbar/doctor-navbar.component';
import { DoctorHomeComponent } from './doctor-home/doctor-home.component';
import { SharedModule } from '../shared/shared.module';
import { PendingPatientsListComponent } from './pending-patients-list/pending-patients-list.component';
import { UpdateStatusComponent } from './update-status/update-status.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    BookedPatientsListComponent,
    DoctorNavbarComponent,
    DoctorHomeComponent,
    PendingPatientsListComponent,
    UpdateStatusComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ]
})
export class DoctorPageModule { }
