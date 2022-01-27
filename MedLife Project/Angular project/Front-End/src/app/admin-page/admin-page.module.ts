import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterComponent } from './register/register.component';
import { DoctorListComponent } from './doctor-list/doctor-list.component';
import { RouterModule } from '@angular/router';
import { AddDoctorProfileComponent } from './add-doctor-profile/add-doctor-profile.component';
import { AdminNavbarComponent } from './admin-navbar/admin-navbar.component';
import { SharedModule } from '../shared/shared.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PatientListComponent } from './patient-list/patient-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    
    RegisterComponent,
    DoctorListComponent,
    AddDoctorProfileComponent,
    AdminNavbarComponent,
    AdminHomeComponent,
    PatientListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
   
    
  ],
 
})
export class AdminPageModule { }
