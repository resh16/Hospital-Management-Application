import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  Patients:any[];

  constructor(public service:ApiService) { }

  ngOnInit(): void {
    debugger
    this.service.GetPatients().subscribe(res => {
      this.Patients = res;
    });
  }

}
