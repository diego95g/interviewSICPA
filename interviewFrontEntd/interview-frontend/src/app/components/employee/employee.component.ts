import { Component } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  employee:Employee = new Employee();
  datatable:any = [];

  selectedPosition: string="";
  positions: string[] = ['Manager', 'Leader', 'Assistan'];

  id:any = this.route.snapshot.paramMap.get('id');

  constructor(private employeeService:EmployeeService, private router: Router, private route: ActivatedRoute, private location: Location){

  }

  ngOnInit(): void {
    this.onDataTable();
  }

  goBack(): void {
    this.location.back();
  }

  onDataTable(){
    this.employeeService.getEmployee(this.id).subscribe(res => {
      this.datatable = res;
      console.log(res);
    });
  }

  onAddEmployee(employee:Employee):void{
    employee.idDepartment=this.id;
    this.employeeService.addEmployee(employee).subscribe(res => {
      if(res){
        alert(`The employee ${employee.name} was successfully registered!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onUpdateEmployee(employee:Employee):void{
    this.employeeService.updateEmployee(employee.id, employee).subscribe(res => {
      if(res){
        alert(`The employee ${employee.id} was successfully modified!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onSetData(select:any){
    this.employee.id = select.id;
    this.employee.name = select.name;
    this.employee.age = select.age;
    this.employee.email = select.email;
    this.employee.status=select.status;
    this.employee.position=select.position;
    this.employee.surname=select.surname;
  }

  clear(){
    this.employee.id =0;
    this.employee.name = "";
    this.employee.age = 0;
    this.employee.email = "";
    this.employee.status = false;
    this.employee.position="";
    this.employee.surname="";
  }
}
