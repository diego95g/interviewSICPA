import { Injectable } from '@angular/core';
import { Enterprise } from '../models/enterprise';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EnterpriseServiceService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:44316/api/Enterprise";

  getEnterprise(){
    return this.http.get(this.url);
  }

  addEnterprise(enterprise:Enterprise):Observable<Enterprise>{
    console.log("enter add enterprise")
    return this.http.post<Enterprise>(this.url, enterprise);
  }

  updateEnterprise(id:number, enterprise:Enterprise):Observable<Enterprise>{
    return this.http.put<Enterprise>(this.url + `/${id}`, enterprise);
  }

}
