import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit {

  constructor(public service: ApiService) { }

  PatientsDetails:any[];

  ngOnInit(): void {

    this.service.GetPatientBookingDetails().subscribe(res => {
      this.PatientsDetails = res;
    });
  }

}
