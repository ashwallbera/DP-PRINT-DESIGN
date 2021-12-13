import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
})
export class SigninComponent implements OnInit {
  addProductForm: FormGroup;
  constructor( private _router: Router) {
    this.addProductForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      
    });
  }

  ngOnInit(): void {}

  getValues(val: any) {
    console.log(val);
    this._router.navigate(['/user'])
    .then(nav => {
      console.log("SUCCESS "+nav); // true if navigation is successful
    }, err => {
      console.log(err) // when there's an error
    });

  }

  public checkError = (controlName: string, errorName: string)=>{
    return this.addProductForm.controls[controlName].hasError(errorName);
  }




}
