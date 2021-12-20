import { Component, OnInit, Input } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { Category } from 'src/app/services/_product-management/category_model';

@Component({
  selector: 'app-chip-list',
  templateUrl: './chip-list.component.html',
  styleUrls: ['./chip-list.component.css'],
})
export class ChipListComponent implements OnInit {
  @Input() product: ProductModel; // Pass by Admin Product Component 
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  category: Category[];
  constructor() {
    
  }

  ngOnInit(): void {
    this.category = this.product.category; // Add current category
  }
 
  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Add our fruit
    if (value) {
      this.category.push({ id:"asdasd",name: value });
    }

    // Clear the input value
    event.chipInput!.clear();
  }

  remove(category: Category): void {
    const index = this.category.indexOf(category);

    if (index >= 0) {
      this.category.splice(index, 1);
    }
  }
}

interface Fruit {
  name: string;
}
