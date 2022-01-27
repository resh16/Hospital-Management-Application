import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-navbar',
  templateUrl: './doctor-navbar.component.html',
  styleUrls: ['./doctor-navbar.component.css']
})
export class DoctorNavbarComponent implements OnInit {

  constructor(public router:Router) { }

  ngOnInit(): void {
  }

  logout()
  {
    localStorage.clear();
    alert('Logging Out!');
    this.router.navigateByUrl('');
  }

}
