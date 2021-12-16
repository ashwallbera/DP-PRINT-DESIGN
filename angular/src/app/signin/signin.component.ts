import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/_login/login.service';
import { LoginModel } from '../services/_login/login_model';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
})
export class SigninComponent implements OnInit {
  error = false;
  hide = true;
  addProductForm: FormGroup;
  constructor(private _router: Router, public login: LoginService) {
    this.addProductForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
    if(localStorage.hasOwnProperty('user')){
      this._router.navigate(['/userpage'])
    }
  }

  getValues(val: LoginModel) {
    //this.addProductForm.get("username")?.value // get the specific form
    console.log(val);
    console.log(val.username);

    this.login.verifyuser(val.username, val.password).subscribe({
      next: (data) => {
        if (data.length != 0) {
          console.log(data);
          console.log('verified');
          localStorage.setItem('user', JSON.stringify(val));
          this._router.navigate(['/userpage']).then(
            (nav) => {
              console.log('SUCCESS ' + nav); // true if navigation is successful
            },
            (err) => {
              console.log(err); // when there's an error
            }
          );
        }
      },
      error: (error) => {
        this.addProductForm.get('username')?.setErrors({ incorrect: true });
        this.addProductForm.get('password')?.setErrors({ incorrect: true });
        this.error = true;
        console.error('There was an error!', error);
      },
    });
  }

  public checkError = (controlName: string, errorName: string) => {
    return this.addProductForm.controls[controlName].hasError(errorName);
  };

  getErrorMessage() {
    if (this.error ) {
      return 'USERNAME OR PASSWORD INCORRECT';
    }
    return '';
  }
}
