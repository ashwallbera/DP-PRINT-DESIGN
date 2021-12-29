import { Component, Inject, OnInit } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Specification } from 'src/app/services/_product-management/specification_model';
import { Identification } from 'src/app/services/_product-management/identification_model';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-product-catalog',
  templateUrl: './product-catalog.component.html',
  styleUrls: ['./product-catalog.component.css'],
})
export class ProductCatalogComponent implements OnInit {
  identityForm: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) public product: ProductModel,
    public formBuilder: FormBuilder
  ) {
    this.identityForm = this.formBuilder.group({
      name: '',
      identityArray: this.formBuilder.array([]),
    });

    
  }
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  specification: Specification[];
  identification: Identification[];
  ngOnInit(): void {
    this.specification = this.product.specification;
    //DYNAMIC FORM
    this.addIdentityFormMethod();
   
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Add our specification
    if (value) {
      this.specification.push({
        id: '',
        name: value,
        identification: this.identification,
      });
    }

    // Clear the input value
    event.chipInput!.clear();
  }

  remove(specification: Specification): void {
    const index = this.specification.indexOf(specification);

    if (index >= 0) {
      this.specification.splice(index, 1);
    }
  }

  /** DYNAMIC FORM TO ADD SPECIFICATION */

  // to get the FormArray in HTML
  identityFormMethod(): FormArray {
    return this.identityForm.get('identityArray') as FormArray;
  }

  // Add FORM
  addIdentityFormMethod() {
    this.identityFormMethod().push(this.newIdentityFormArrayMethod());
  }

  // INSTANCE OF FORM
  newIdentityFormArrayMethod(): FormGroup {
    return this.formBuilder.group({
      identificationfc: 'asd', // sample here is SELECT FORM
      //formControllName2: "1", //  sample here is INPUT FORM
    });
  }
}