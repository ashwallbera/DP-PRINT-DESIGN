import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/_login/login.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';
  user_sample = {username: "ashwallbera",password:"Password1",role:"user"}
  constructor( private _router: Router) {}
  ngOnInit(): void {
    // localStorage.setItem('username', JSON.stringify(this.user_sample)); // use for login
     console.log(JSON.parse(""+localStorage.getItem('user')));
     console.log(localStorage.hasOwnProperty('user'));
    // localStorage.clear(); // Use for logout
    // console.log(localStorage.hasOwnProperty('username'));
    //this._router.navigate(['/', 'signin'])
    //this._router.navigate(['/', 'userpage'])
    if(localStorage.hasOwnProperty('user')){
      this._router.navigate(['/', 'userpage'])
    }
    else{
      this._router.navigate(['/', 'signin'])
    }

    
  }
}
