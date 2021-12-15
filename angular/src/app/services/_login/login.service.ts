import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginModel } from './login_model';
let url = environment.api;
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  apiroot = url + '/api/Users';
  constructor(public httpClient: HttpClient) {}

  public verifyuser(id: string, password: string) {
    const headers = {  'accept': 'text/plain' }
    return this.httpClient.get<LoginModel[]>(
      `${this.apiroot}/${id}/${password}`
    );
  }
}

// public createSubProduct(subProduct: SubProduct): void {
//   this.httpClient
//     .post<SubProduct>(
//       `${this.url}/${subProduct.parentProductId}/SubProducts`,
//       {
//         id: Guid.create().toString(),
//         parentProductId: subProduct.parentProductId,
//         productId: subProduct.productId,
//         quantity: subProduct.quantity,
//       }
//     )
//     .subscribe((data) => {});
// }

// public updateSubProduct(subProduct: SubProduct): void {
//   this.httpClient
//     .put<SubProduct>(
//       `${this.url}/${subProduct.parentProductId}/SubProducts/${subProduct.id}`,
//       {
//         id: subProduct.id,
//         parentProductId: subProduct.parentProductId,
//         productId: subProduct.productId,
//         quantity: subProduct.quantity,
//       }
//     )
//     .subscribe({
//       next: data => {

//       },
//       error: error => {
//           this.createSubProduct(subProduct);
//       }
//   });
// }

// public deleteSubProduct(parentId: string, subProductId): void {
//   this.httpClient
//     .delete<SubProduct>(
//       `${this.url}/${parentId}/SubProducts/${subProductId}`
//     )
//     .subscribe();
// }

// public getAllProductTypes(){
//   return this.httpClient.get<ProductType[]>(`${this.type}`);
// }

// public getProductTypeById(id: string){
//   return this.httpClient.get<ProductType[]>(`${this.type}/${id}`);
// }
