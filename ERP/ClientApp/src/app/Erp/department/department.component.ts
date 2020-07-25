import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../Services/Department/department.service';
import { Department } from '../../Models/department';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  constructor(private service:DepartmentService) { }

  public departments:Department[];

  ngOnInit(): void {
    this.getDepartments();
  }

  getDepartments():void{
    this.service.getDepartment()
    .subscribe(data=>this.departments=data);
  }
}
