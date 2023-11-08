import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Designation, Employee } from './employee.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private myhttp:HttpClient) { }
  employeeUrl:string='https://localhost:44319/api/Employee';
  designationUrl:string='https://localhost:44319/api/Designation';

  listEmployee:Employee[]=[];  //for getting data EmployeeList
  listDesignation:Designation[]=[];

  employeeData:Employee=new Employee();  //for post/insert data Employee

  saveEmployee()
  {
    return this.myhttp.post(this.employeeUrl,this.employeeData);
  }

  updateEmployee()
  {
    console.log(this.employeeData);
    return this.myhttp.put(`${this.employeeUrl}/${this.employeeData.id}`,this.employeeData);
  }

  getEmployees():Observable<Employee[]>
  {
    return this.myhttp.get<Employee[]>(this.employeeUrl);
  }

  getDesignations():Observable<Designation[]>
  {
    return this.myhttp.get<Designation[]>(this.designationUrl);
  }

  deleteEmployee(id:number)
  {
    return this.myhttp.delete(`${this.employeeUrl}/${id}`);
  }
}
