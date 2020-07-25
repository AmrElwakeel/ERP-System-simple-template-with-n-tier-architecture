import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable,Injector } from '@angular/core';

import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {


    constructor(private injector:Injector){  }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        const token= this.injector.get(AuthService).getToken();

        if(token){
            const clone=req.clone({
                setHeaders:{
                    Authorization:`Bearer ${token}`
                }
            });
            return next.handle(clone);
        }else{
            return next.handle(req);
        }
        
    }
}