import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Department } from '../../Models/department';

import {map, catchError, tap}  from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  URL : string='https://localhost:44302/api/department';
  constructor(private http:HttpClient) { }

  public getDepartment():Observable<Department[]>{
    return this.http.get<Department[]>(this.URL)
    .pipe(
      tap(_=>console.log('Fetching departments data.....')),
      catchError(this.handleError<Department[]>('getDepartments',[]))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return(errorResponse:HttpErrorResponse):Observable<T>=>{
      if(errorResponse.error instanceof ErrorEvent){
        console.error('Client side error : ',errorResponse.error.message);
      }else{
        console.error('Server side error : ',errorResponse.error);
      }
      return of(result as T);
    }
  }


}
