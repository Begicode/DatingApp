import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService:AccountService, private toastr: ToastrService){}

  //options that can be returned from a guard like observable, boolean, promise etc are shown below
  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user =>{
        if(user) return true;
        this.toastr.error('You shall not pass!')
      })
    );
  }
  
}
