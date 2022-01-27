import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Guid } from 'guid-typescript';

import { ApiService } from 'src/app/shared/Services/api.service';


@Component({
  selector: 'app-add-doctor-profile',
  templateUrl: './add-doctor-profile.component.html',
  styleUrls: ['./add-doctor-profile.component.css']
})
export class AddDoctorProfileComponent implements OnInit {

  constructor( public service: ApiService) { }

  FileToUpload:any = null;
  
  ngOnInit(): void {
    this.resetForm();
    this.service.formData = {
      
      Id!:null,
      Qualification!:'',
      Experience!:0,
      Image!:null,
      DepartmentId!:0
    }
  }

  resetForm(form ?:any){ //NgForm
    if(form != null)
    form.resetForm();
    this.service.formData = {
      
      Id!:null,
      Qualification!:'',
      Experience!:0,
      Image!:null,
      DepartmentId!:0
    }

  }


  OnSubmit(form:any){
    debugger
    this.insertRecord(form);
  }

  insertRecord(form:any){
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
  }

  handleFileInput(e:any){
    console.log(e);
    this.FileToUpload = <File>e.target.files[0];
  }

}




/* onImageUpload() {
  const fileData = new FormData();
 debugger
  fileData.append('Image',this.FileToUpload, this.FileToUpload.name)
   fileData.append('ProductId',this.data.id)
   

 

     this.service.AddImage(fileData).subscribe((res)=>{
     console.log('Successfully Added Image!',res);
     alert("Successfully added");
   })
} */