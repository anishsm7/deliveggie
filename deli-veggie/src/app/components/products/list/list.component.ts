import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product'
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['num','name'];
  dataSource: Product[] = [];

  constructor(private productService: ProductService,private router: Router) { }

  ngOnInit(): void {
    this.getAllProducts();;
  }

  getAllProducts() {
    this.productService.getProducts().subscribe(
      (data: Product[]) => {    
        this.dataSource = data.map(o => Object.assign({}, o));
      }
    );
  }

  getProductDetails(row : any)
  {
    this.router.navigateByUrl('/productdetails/'+row.id)
  }

}
