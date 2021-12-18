import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductModel } from './product_model';

let url = environment.api;
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiroot = url + '/api/Product';
  constructor(public httpClient: HttpClient) {}


  public getProduct() {
    return this.httpClient.get<ProductModel[]>(
      `${this.apiroot}`
    );
  }
}
