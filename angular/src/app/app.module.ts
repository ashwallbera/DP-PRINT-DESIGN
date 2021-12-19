import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SigninComponent } from './signin/signin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './signup/signup.component';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { UserpageModule } from './userpage/userpage.module';
import { AppRoutingModule } from './app-routing.module';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatStepperModule} from '@angular/material/stepper';
import { MatCardModule } from '@angular/material/card';
import { ShopNowDialogComponent } from './userpage/productservice/shop-now-dialog/shop-now-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { AdminModule } from './admin/admin.module';







// const appRoutes: Routes = [{ path: "userpage", loadChildren: () => 
// import("./userpage/userpage.module").then((m) => m.UserpageModule) }];

const appRoutes: Routes = [
//   { path: 'signin', component: SigninComponent },
//   { path: 'signup', component: SignupComponent },
//   { path: "userpage", loadChildren: () => 
//  import("./userpage/userpage.module").then((m) => m.UserpageModule) }
 
];


@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    LoadingScreenComponent,
    SignupComponent,
    ShopNowDialogComponent
  
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
    RouterModule.forRoot(appRoutes),
    MatSidenavModule,
    MatToolbarModule,
    MatMenuModule,
    MatDividerModule,
    MatListModule,
    MatSidenavModule,
    AppRoutingModule,
    UserpageModule,
    AdminModule,
    MatPaginatorModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    MatStepperModule,
    MatCardModule,
    MatDialogModule,
    MatSelectModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
