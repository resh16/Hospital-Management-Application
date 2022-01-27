import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.css']
})
export class AdminNavbarComponent implements OnInit {

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
