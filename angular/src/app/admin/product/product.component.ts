import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { ProductService } from 'src/app/services/_product-management/product.service';
import { ProductModel } from 'src/app/services/_product-management/product_model';
import { ProductCatalogComponent } from './product-catalog/product-catalog.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class AdminProductComponent implements AfterViewInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'description',
    'action',
  ];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource = new MatTableDataSource<ProductModel>();
  products: ProductModel[] = [];
  constructor(
    public product_service: ProductService,
    public dialog: MatDialog
  ) {
    product_service.getProduct().subscribe((data) => {
      this.products = data;
      this.dataSource.data = data;
    });
  }
  openDialog(product: any) {
   this.dialog.open(ProductCatalogComponent,{
     data:product
   });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: string;
  symbol: string;
}

