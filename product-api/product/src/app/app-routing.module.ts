import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'products', component: ProductsComponent }
];

@NgModule({
  declarations: [
    HomeComponent,
    ProductsComponent
  ],
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
}), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
