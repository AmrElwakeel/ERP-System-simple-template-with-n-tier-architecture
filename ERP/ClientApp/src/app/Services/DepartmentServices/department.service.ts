import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../../Models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  URL : string='https://localhost:44302/api/department';
  constructor(private http:HttpClient) { }
  public getDepartment():Observable<Department[]>{
    return this.http.get<Department[]>(this.URL);
  }
}
