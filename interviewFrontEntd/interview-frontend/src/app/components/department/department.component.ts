import { Component } from '@angular/core';
import { Department } from 'src/app/models/department';
import { DepartmentService } from 'src/app/services/department.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {
  department:Department = new Department();
  datatable:any = [];
  id:any = this.route.snapshot.paramMap.get('id');
  constructor(private departmentService:DepartmentService, private router: Router, private route: ActivatedRoute){

  }

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable(){
    this.departmentService.getDepartment(this.id).subscribe(res => {
      this.datatable = res;
      console.log(res);
    });
  }

  onAddDepartment(department:Department):void{
    department.idEnterprise=this.id;
    this.departmentService.addDepartment(department).subscribe(res => {
      if(res){
        alert(`The department ${department.name} was successfully registered!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(');
      }
    });
  }

  onUpdateDepartment(department:Department):void{
    this.departmentService.updateDepartment(department.id, department).subscribe(res => {
      if(res){
        alert(`The department ${department.id} was successfully modified!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onSetData(select:any){
    this.department.id = select.id;
    this.department.name = select.name;
    this.department.description = select.description;
    this.department.phone = select.phone;
    this.department.status=select.status;
  }

  clear(){
    this.department.id =0;
    this.department.name = "";
    this.department.description = "";
    this.department.phone = "";
    this.department.status = false;
  }

  viewRecord(recordId: number) {
    this.router.navigate(['/employee', recordId]);
  }

}
