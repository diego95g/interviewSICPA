import { Component } from '@angular/core';
import { Enterprise } from 'src/app/models/enterprise';
import { EnterpriseServiceService } from 'src/app/services/enterprise-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-enterprise',
  templateUrl: './enterprise.component.html',
  styleUrls: ['./enterprise.component.css']
})
export class EnterpriseComponent {
  enterprise:Enterprise = new Enterprise();
  datatable:any = [];

  constructor(private enterpriseService:EnterpriseServiceService, private router: Router){

  }

  ngOnInit(): void {
    console.log("entra en on init")
    this.onDataTable();
  }

  onDataTable(){
    this.enterpriseService.getEnterprise().subscribe(res => {
      this.datatable = res;
      console.log(res);
    });
  }

  onAddEnterprise(enterprise:Enterprise):void{
    this.enterpriseService.addEnterprise(enterprise).subscribe(res => {
      if(res){
        alert(`The enterpise ${enterprise.name} was successfully registered!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onUpdateEnterprise(enterprise:Enterprise):void{
    this.enterpriseService.updateEnterprise(enterprise.id, enterprise).subscribe(res => {
      if(res){
        alert(`The enterprise ${enterprise.id} was successfully modified!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onSetData(select:any){
    this.enterprise.id = select.id;
    this.enterprise.name = select.name;
    this.enterprise.address = select.address;
    this.enterprise.phone = select.phone;
    this.enterprise.status=select.status;
  }

  clear(){
    this.enterprise.id =0;
    this.enterprise.name = "";
    this.enterprise.address = "";
    this.enterprise.phone = "";
    this.enterprise.status = false;
  }

  viewRecord(recordId: number) {
    this.router.navigate(['/department', recordId]);
  }

}
