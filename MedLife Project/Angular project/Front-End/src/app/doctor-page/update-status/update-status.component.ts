import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-update-status',
  templateUrl: './update-status.component.html',
  styleUrls: ['./update-status.component.css']
})
export class UpdateStatusComponent implements OnInit {

  constructor(public service:ApiService,@Inject(MAT_DIALOG_DATA) public data:any) { }

  

  ngOnInit(): void {

    

    this.resetForm();
  }

  resetForm(form ?:any){ //NgForm
    if(form != null)
    form.resetForm();
    this.service.formData3 = {
      
    AppointmentId:null,
    StatusId:null,
    Priscription:null,

    }

  }


  OnSubmit(form:any){
    debugger
    this.insertRecord(form);
  }

  insertRecord(form:NgForm){
     debugger
    const fileData = new FormData();
    fileData.append('StatusId',form.value.StatusId)
    fileData.append('Priscription',form.value.Priscription)
    fileData.append('AppointmentId',this.data.id)
    

    this.service.UpdateStatus(fileData).subscribe(res => {
      alert("Appointment Status updated successfully");
      this.resetForm(form);
    })
  }

}


/* insertRecord(form:any){
  debugger
  const fileData = new FormData();
  debugger
   fileData.append('Image',this.FileToUpload, this.FileToUpload.name)
   fileData.append('DepartmentId',form.value.DepartmentId)
   fileData.append('Qualification',form.value.Qualification)
   fileData.append('Experience',form.value.Experience)
   fileData.append('Id',form.value.Id)
   
    

    this.service.AddDoctorProfile(fileData).subscribe(res=>{
      alert("Doctor Profile Successfully added");
    this.resetForm(fileData)
  })
} */