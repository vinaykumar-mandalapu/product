import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  public products: Product[] = [];

  constructor(http: HttpClient) {
    http.get<Product[]>('https://localhost:44396/api/products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

}

interface Product {
  id: number;
  name: string;
  type: string;
  price: number;
  quantity: number;
  modifiedDate: string;
}
