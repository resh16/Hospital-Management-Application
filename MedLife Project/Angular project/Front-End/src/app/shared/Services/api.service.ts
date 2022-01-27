import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import{HttpClient, HttpHeaderResponse, HttpHeaders} from "@angular/common/http";
import { AddProfile } from '../Models/add-profile.model';
import { environment } from './../../../environments/environment'

import { map } from 'rxjs';
import { AppointmentBooking } from '../Models/appointment-booking.model';
import { UpdateStatus } from '../Models/update-status.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

 formData : AddProfile;
 formData2: AppointmentBooking;
 formData3:UpdateStatus;

 headerForForm = new HttpHeaders().set('Content-Type','application/json')

 imgUrl = environment.baseURL + "api/MedLife/GetDoctors/"

baseURL = environment.baseURL;


  constructor(private fb : FormBuilder, private http:HttpClient ) { }

  formsModel = this.fb.group({
    UserName:['',Validators.required],
    Name:['',Validators.required],
    Age:[0,Validators.required],
    Gender:['',Validators.required],
    Email:['',[Validators.required,Validators.email]],
    Password:['',[Validators.required,Validators.minLength(5)]],
    ConformPassword:['',[Validators.required,Validators.minLength(5)]],
    Role:['',Validators.required]



  })

  comparePasswords(fb:FormGroup){
    let ConformPasswordCtrl = fb.get('ConformPassword');

    if(ConformPasswordCtrl.errors == null || 'passwordMismatch' in ConformPasswordCtrl.errors){
      if(fb.get('Password').value != ConformPasswordCtrl.value)
       ConformPasswordCtrl.setErrors({ passwordMismatch:true});

      else
       ConformPasswordCtrl.setErrors(null);
    }
  }


register(){

  var body = {
    userName: this.formsModel.value.UserName,
    name : this.formsModel.value.Name,
    age : this.formsModel.value.Age,
    gender: this.formsModel.value.Gender,
    email: this.formsModel.value.Email,
    password: this.formsModel.value.Password,
    conform_Pwd : this.formsModel.value.ConformPassword,
    role: this.formsModel.value.Role
  };
  return this.http.post(this.baseURL + 'Register',body);

}


roleMatch(allowedRoles: any): boolean {
  debugger
  var isMatch = false;
  var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
  var userRole = payLoad["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  debugger;
  allowedRoles.forEach( (element: any) => {
    if (userRole == element){
      isMatch = true;
      return false;
    }
    return null
  });

  return isMatch;
}



Login(formData:any){
  return this.http.post(this.baseURL + 'Login',formData);
}


// Add doctor Profile

AddDoctorProfile(formData:any){
  debugger
 return  this.http.post(this.baseURL + 'api/MedLife/AddDoctorsProfile',formData);
}


// get Doctors list

 GetDoctors(){
  debugger
  return this.http.get<any>(this.baseURL + "api/MedLife/ListDoctors")
  .pipe(map((res:any)=>{
    return res;
  }))
 
} 





// get patients list
GetPatients(){
  return this.http.get<any>(this.baseURL + "api/MedLife/ListPatients")
  .pipe(map((res:any)=>{
    return res;
  }))
}

// Get Patient Booking details

GetPatientBookingDetails(){
  return this.http.get<any>(this.baseURL + "api/MedLife/PatientDetails")
  .pipe(map((res:any)=>{
    return res;
  }))

}

//List Booked Patients
ListBookedPatientsDetails(){
  return this.http.get<any>(this.baseURL + "api/MedLife/ListConformedPatients")
  .pipe(map((res:any)=>{
    return res;
  }))

}

//List Pending Patients
ListPendingPatientsDetails(){
  return this.http.get<any>(this.baseURL + "api/MedLife/ListPendingPatients")
  .pipe(map((res:any)=>{
    return res;
  }))

}




//book Appointment

BookAppointment(formData2:any){
 debugger
  //var tokenHeader = new HttpHeaders({'Authorization':'Bearer'+ localStorage.getItem('token')})
 return  this.http.post(this.baseURL + 'api/MedLife/BookAppointment',formData2);
}


//update status

UpdateStatus(formData3:any){
 debugger
 console.log(formData3);
  return  this.http.post(this.baseURL + 'api/MedLife/ModifyStatus2',formData3);
 }
 
 
}
