import { Component, OnInit, AfterViewInit } from '@angular/core';

import { Product } from '../../../core/services/models/product.model';
import { ProductsService } from '../../../core/services/products/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  products: Product[] = [];
 constructor(
   private productsService: ProductsService
 ) { }

 ngOnInit(): void {
   this.fetchProducts();
 }

 fetchProducts() {
   this.productsService.getAllProducts()
   .subscribe(products => {
     this.products = products;
   });
 }
}
