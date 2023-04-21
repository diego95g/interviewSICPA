import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Department } from '../models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:44316/api/Department";

  getDepartment(id:number){
    return this.http.get(this.url+ `/${id}`);
  }

  addDepartment(department:Department):Observable<Department>{
    console.log("ingresa en departamento");
    return this.http.post<Department>(this.url, department);
  }

  updateDepartment(id:number, department:Department):Observable<Department>{
    return this.http.put<Department>(this.url + `/${id}`, department);
  }
}
