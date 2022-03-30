import { Injectable } from '@angular/core';
import { Product } from '../../app/models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(public httpClient: HttpClient,) { } 

  getProductDetaislById(productId:string): Observable<Product> {  
    return this.httpClient.get<Product>(environment.apiUrl + '/Product/' + productId);  
  }

  getProducts(): Observable<Product[]> {
    debugger;  
    return this.httpClient.get<Product[]>(environment.apiUrl + '/Product');  
  } 
}
