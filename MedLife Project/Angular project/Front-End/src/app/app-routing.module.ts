import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDoctorProfileComponent } from './admin-page/add-doctor-profile/add-doctor-profile.component';
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';

import { DoctorListComponent } from './admin-page/doctor-list/doctor-list.component';
import { PatientListComponent } from './admin-page/patient-list/patient-list.component';
import { RegisterComponent } from './admin-page/register/register.component';
import { AppointmentBookingComponent } from './patient-page/appointment-booking/appointment-booking.component';
import { PatientHomeComponent } from './patient-page/patient-home/patient-home.component';
import { PatientDetailsComponent } from './patient-page/patient-details/patient-details.component';


import { HeaderComponent } from './shared/header/header.component';
import { DoctorHomeComponent } from './doctor-page/doctor-home/doctor-home.component';
import { BookedPatientsListComponent } from './doctor-page/booked-patients-list/booked-patients-list.component';
import { PendingPatientsListComponent } from './doctor-page/pending-patients-list/pending-patients-list.component';
import { UpdateStatusComponent } from './doctor-page/update-status/update-status.component';
import { AuthGuard } from './shared/auth.guard';



const routes: Routes = [
  {path:'',component:HeaderComponent},
  {path:'Home',component:HeaderComponent},
  {path:'Admin',component:AdminHomeComponent ,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}},
  {path:'Admin/list-of-doctors',component:DoctorListComponent},
  {path:'Admin/list-of-patients',component:PatientListComponent},
  {path:'Admin/register',component:RegisterComponent},
  {path:'Admin/add-doctor-profile',component:AddDoctorProfileComponent},
  {path:'Patient',component:PatientHomeComponent },
 {path:'Patient/booking-details',component:PatientDetailsComponent},
  {path:'Patient/appointment-booking',component:AppointmentBookingComponent},
  {path:'Doctor',component:DoctorHomeComponent , canActivate:[AuthGuard],data:{permittedRoles:['Doctor']}},
  {path:'Doctor/booked-patients-list',component:BookedPatientsListComponent},
  {path:'Doctor/pending-patients-list',component:PendingPatientsListComponent},
  {path:'Doctor/updateStatus',component:UpdateStatusComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
