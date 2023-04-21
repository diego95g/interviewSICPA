import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EnterpriseComponent } from './components/enterprise/enterprise.component';
import { LoginComponent } from './components/login/login.component';
import { DepartmentComponent } from './components/department/department.component';
import { EmployeeComponent } from './components/employee/employee.component';

const appRoutes:Routes=[
  {path: '', redirectTo: '/enterprise', pathMatch: 'full' },
  {path:'login', component:LoginComponent},
  {path:'enterprise', component:EnterpriseComponent},
  {path:'department/:id', component: DepartmentComponent },
  {path:'employee/:id', component:EmployeeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
