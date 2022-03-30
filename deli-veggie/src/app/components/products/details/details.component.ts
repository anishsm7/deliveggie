import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product'
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  details: Product;
  id: string;
  displayedColumns: string[] = [];

  constructor(private productService: ProductService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    debugger;
    this.id = String(this.route.snapshot.paramMap.get('id'));
    this.getProductDetails();
  }

  getProductDetails() {
    this.productService.getProductDetaislById(this.id).subscribe(
      (data: Product) => {
        this.details = data;
      }
    );
  }

}
