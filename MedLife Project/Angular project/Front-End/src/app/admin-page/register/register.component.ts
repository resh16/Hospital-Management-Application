import { Component, OnInit } from '@angular/core';

import { ApiService } from 'src/app/shared/Services/api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public service:ApiService) { }

  ngOnInit(): void {
   this.service.formsModel.reset();
  }

  OnSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        if (res.status='Success'){
          alert('Registration successfull');
          this.service.formsModel.reset();
          

        } else{
          res.errors.forEach((element:any )=> {
            switch (element.code){
              case 'DuplicateUserName':
                alert('UserName already taken');
                break;
              default :
                  alert('Registration failed');
                  break;           
                 }
          });
          
        }
      },
      err => {
        console.log(err);
      });
  }


}
