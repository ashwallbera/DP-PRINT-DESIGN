import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './main/main.component';
import { ProductserviceComponent } from './productservice/productservice.component';


const routes: Routes = [
  // { path: 'dashboard', component: DashboardComponent },
  // {path: '',component:HeaderComponent},
  // {path: 'aboutus',component:AboutusComponent}
  {
    path: "",
    component: MainComponent,
    children: [
      {
        path: "home", component: HomeComponent
      },
      {
        path: "productservice", component: ProductserviceComponent
      }
    ],
  },
  { path: "**", redirectTo: "", pathMatch: "full" },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserpageRoutingModule {}
