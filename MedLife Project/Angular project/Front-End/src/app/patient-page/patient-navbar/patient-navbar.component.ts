import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-navbar',
  templateUrl: './patient-navbar.component.html',
  styleUrls: ['./patient-navbar.component.css']
})
export class PatientNavbarComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit(): void {
  }

  logout()
  {
    localStorage.clear();
    alert('Logging Out!');
    this.router.navigateByUrl('');
  }

}
