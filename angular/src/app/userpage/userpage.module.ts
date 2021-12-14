import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserpageRoutingModule } from './userpage-routing.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule, MatNavList } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './main/main.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { ProductserviceComponent } from './productservice/productservice.component';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { MyordersComponent } from './myorders/myorders.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';
import { ViewOrderDialogComponent } from './myorders/view-order-dialog/view-order-dialog.component';


@NgModule({
  declarations: [
    HeaderComponent,
    HomeComponent,
    MainComponent,
    SidenavComponent,
    ProductserviceComponent,
    MyordersComponent,
    ViewOrderDialogComponent,
  ],
  imports: [
    CommonModule,
    UserpageRoutingModule,
    MatSidenavModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    MatDividerModule,
    MatListModule,
    RouterModule,
    MatCardModule,
    MatGridListModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    MatCheckboxModule,
    MatDialogModule
  ],
})
export class UserpageModule {}
