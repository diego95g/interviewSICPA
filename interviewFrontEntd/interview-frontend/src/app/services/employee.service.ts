import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:44316/api/Employee";

  getEmployee(id:number){
    return this.http.get(this.url+ `/${id}`);
  }

  addEmployee(employee:Employee):Observable<Employee>{
    return this.http.post<Employee>(this.url, employee);
  }

  updateEmployee(id:number, employee:Employee):Observable<Employee>{
    return this.http.put<Employee>(this.url + `/${id}`, employee);
  }
}
