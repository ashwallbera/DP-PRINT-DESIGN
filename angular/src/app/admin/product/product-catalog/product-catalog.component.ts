import { Component, Inject, OnInit } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Specification } from 'src/app/services/_product-management/specification_model';
import { Identification } from 'src/app/services/_product-management/identification_model';
@Component({
  selector: 'app-product-catalog',
  templateUrl: './product-catalog.component.html',
  styleUrls: ['./product-catalog.component.css'],
})
export class ProductCatalogComponent implements OnInit{
  constructor(@Inject(MAT_DIALOG_DATA) public product: ProductModel) {}
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  specification: Specification[];
  identification: Identification[];
  ngOnInit(): void {
      this.specification = this.product.specification;
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Add our fruit
    if (value) {
      this.specification.push({id:"",name: value,identification: this.identification});
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
}

interface Fruit{
  name: string;
}
