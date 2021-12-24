import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductService } from 'src/app/services/_product-management/product.service';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { ShopNowDialogComponent } from './shop-now-dialog/shop-now-dialog.component';

@Component({
  selector: 'app-productservice',
  templateUrl: './productservice.component.html',
  styleUrls: ['./productservice.component.scss'],
})
export class ProductserviceComponent implements OnInit {
  products: ProductModel[] = [];
  constructor(
    public dialog: MatDialog,
    public product_service: ProductService
  ) {
    product_service.getProduct().subscribe((data) => {
      this.products = data;
    });
  }

  openDialog(product: any) {
    console.log(product);
    this.dialog.open(ShopNowDialogComponent, {
      data:product
    });
  }

  ngOnInit(): void {}
}
