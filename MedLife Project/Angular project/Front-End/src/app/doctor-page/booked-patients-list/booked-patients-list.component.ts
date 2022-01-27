import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-booked-patients-list',
  templateUrl: './booked-patients-list.component.html',
  styleUrls: ['./booked-patients-list.component.css']
})
export class BookedPatientsListComponent implements OnInit {

  BookedPatients:any;

  constructor(public service:ApiService) { }

  ngOnInit(): void {
    this.service.ListBookedPatientsDetails().subscribe(res => {
      this.BookedPatients = res;
    })
  }

}
