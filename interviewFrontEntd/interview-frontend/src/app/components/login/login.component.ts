import { Component } from '@angular/core';
import {User} from '../../models/user';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  user:User=new User();

  constructor(private loginService:LoginService){}

  User_Login(){
    console.log(this.user.Email_User);
    console.log(this.user.Password_User);
    this.loginService.loginUser(this.user).subscribe(data=>{
      alert("Login Successfully")
    }, error=>alert("Sorry please enter correct email and password"))
  }
}
