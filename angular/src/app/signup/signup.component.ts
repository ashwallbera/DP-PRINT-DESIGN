import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/_login/login.service';
import { LoginModel } from '../services/_login/login_model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  hide = true;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  signupForms: FormGroup;
  constructor(
    private _formBuilder: FormBuilder,
    public login_service: LoginService,
    private _router: Router
  ) {}

  ngOnInit() {
    this.signupForms = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required]),
      role: new FormControl('', [Validators.required]),
      
    });

    // this.firstFormGroup = this._formBuilder.group({
    //   firstCtrl: ['', Validators.required],
    // });
    // this.secondFormGroup = this._formBuilder.group({
    //   secondCtrl: ['', Validators.required],
    // });
  }

  getValues(val: LoginModel) {
    //this.addProductForm.get("username")?.value // get the specific form
    console.log(val);
    this.login_service.createuser(val);
    this._router.navigate(['/signin'])

  }
}
