
import { Injectable,Injector } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class AuthService{
    
    getToken():string{
        // return token=localStorage.getItem('Token');
        return '_token';
      }
}