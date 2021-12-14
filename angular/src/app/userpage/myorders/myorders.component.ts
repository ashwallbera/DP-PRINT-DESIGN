import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.scss']
})


export class MyordersComponent implements AfterViewInit {
  displayedColumns: string[] = ['order_no', 'order_name', 'customer_address', 'order_status'];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);

  @ViewChild(MatPaginator) paginator: MatPaginator;

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

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 2, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 3, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 4, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 5, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 6, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 7, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 8, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},
  {position: 9, name: 'BUSINESS CARD', weight: "BULACAN", symbol: 'DELIVERED'},

 
];
