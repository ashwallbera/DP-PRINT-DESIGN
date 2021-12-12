import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
})
export class SigninComponent implements OnInit {
  addProductForm: FormGroup;
  constructor() {
    this.addProductForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      
    });
  }

  ngOnInit(): void {}

  getValues(val: any) {
    console.log(val);
  }

  public checkError = (controlName: string, errorName: string)=>{
    return this.addProductForm.controls[controlName].hasError(errorName);
  }
}
