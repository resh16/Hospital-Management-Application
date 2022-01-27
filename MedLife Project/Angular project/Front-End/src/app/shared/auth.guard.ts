import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiService } from './Services/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(public router:Router,public service:ApiService){}
  

  canActivate(
    
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean  {
      debugger
      if(localStorage.getItem('token') != null){
        let roles = route.data['permittedRoles'] as Array<string>;
        if(roles){
         if(this.service.roleMatch(roles))
          return true;
         
         else{
           alert("Access Denied");
           return false;
         }
        }
        return true;
      }
        

      else{
        this.router.navigate(['/Home']);
        return false;
      }
  }
  
}
