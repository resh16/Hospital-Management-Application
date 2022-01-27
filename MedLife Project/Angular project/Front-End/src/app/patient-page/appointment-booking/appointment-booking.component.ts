import { Component, OnInit } from '@angular/core';
import {  NgForm } from '@angular/forms';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-appointment-booking',
  templateUrl: './appointment-booking.component.html',
  styleUrls: ['./appointment-booking.component.css']
})
export class AppointmentBookingComponent implements OnInit {

  constructor(public service: ApiService) { }

  ngOnInit(): void {

    this.resetForm();
  }


  resetForm(form ?:any){ //NgForm
    if(form != null)
    form.resetForm();
    this.service.formData2 = {
      
      Id!:null,
      DoctorId!:null,
      AppointmentOn!:null,
      HealthProblemId!:null,
      Others!:null
    }

  }


  OnSubmit(form:any){
    debugger
    this.insertRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.BookAppointment(form.value).subscribe(res => {
      alert("Appointment booked successfully");
      this.resetForm(form);
    })
  }

}
