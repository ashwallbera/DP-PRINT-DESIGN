import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/_login/login.service';
import { LoginModel } from './services/_login/login_model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';
  constructor( private _router: Router) {}
  ngOnInit(): void {
    // localStorage.setItem('username', JSON.stringify(this.user_sample)); // use for login
    //  console.log(JSON.parse(""+localStorage.getItem('user')));
    //  console.log(localStorage.hasOwnProperty('user'));
    // localStorage.clear(); // Use for logout
    // console.log(localStorage.hasOwnProperty('username'));
    //this._router.navigate(['/', 'signin'])
    //this._router.navigate(['/', 'userpage'])
    if(localStorage.hasOwnProperty('user')){
      let user: LoginModel[] = JSON.parse(""+localStorage.getItem('user'));
      console.log(JSON.parse(""+localStorage.getItem('user')))
      if(user[0].role == "user"){
        this._router.navigate(['/', 'userpage']);
      }
      else if(user[0].role == "admin"){
        this._router.navigate(['/', 'admin']);
      }
      
    }
    else{
      this._router.navigate(['/', 'signin'])
    }

    
  }
}
