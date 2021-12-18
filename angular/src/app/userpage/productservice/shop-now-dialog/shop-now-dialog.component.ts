import { Component, OnInit,Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
  selector: 'app-shop-now-dialog',
  templateUrl: './shop-now-dialog.component.html',
  styleUrls: ['./shop-now-dialog.component.css'],
})
export class ShopNowDialogComponent implements OnInit {
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public product: ProductModel
  ) {
    console.log(product);
    console.log(product.id);
  }
  foods: any[] = [
    { value: 'steak-0', viewValue: 'Plastic Business Card' },
    { value: 'pizza-1', viewValue: 'Standard Business Card' },
    { value: 'tacos-2', viewValue: 'Premium Business Card' },
  ];
  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
  }
}
