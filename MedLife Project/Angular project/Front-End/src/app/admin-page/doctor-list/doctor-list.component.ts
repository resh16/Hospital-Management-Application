import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  Doctors: any;
  

  
  
  constructor(public service: ApiService) { }

  imgUrl: any = this.service.imgUrl;

  ngOnInit(): void {
    debugger
     this.service.GetDoctors().subscribe(res => {
       this.Doctors = res;
     })

    
  }

  



}
