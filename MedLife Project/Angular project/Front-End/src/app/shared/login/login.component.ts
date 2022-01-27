
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router} from '@angular/router';
import { ApiService } from '../Services/api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public service:ApiService, public router:Router) { }
  
   

  formModel = {
    UserName:'',
    Password:''
  }

  ngOnInit(): void {
   
  }


  OnSubmit(form:NgForm){
   
    debugger
    this.service.Login(form.value).subscribe(
      (res:any)=>{
        localStorage.setItem('token',res.token);
       var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
       var userRole = payLoad["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        alert("Successfully LoggedIn");
        debugger
          if(userRole == "Admin")
          {
            this.router.navigateByUrl('/Admin');
          }
          else if(userRole == "Doctor")
          {
            this.router.navigateByUrl('/Doctor');
          }
          else if(userRole == "Patient")
          {
            this.router.navigateByUrl('/Patient');
          }
          else
          {
            this.router.navigateByUrl('/Home');
          }
        
      },
      err => {
        if(err.status == 400){
          alert("User name and Password Incorrect");
          console.log("user name, password required");
        }
      
    
        else
          alert("Somthing went wrong, try again");

          console.log(err);
     }
    )
  }
}

