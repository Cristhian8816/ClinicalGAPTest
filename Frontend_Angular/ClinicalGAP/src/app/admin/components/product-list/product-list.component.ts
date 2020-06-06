import { Component, OnInit } from '@angular/core';

import { ProductsService } from './../../../core/services/products/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  products = [];
  displayedColumns: string[] = ['Patientid', 'Name', 'Phone NUmber', 'Address', 'actions'];

  constructor(
    private productServices: ProductsService
  ) { }

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.productServices.getAllProducts()
    .subscribe(products => {
      this.products = products;
    });
  }
  deleteProduct(id: string) {
    this.productServices.deleteProduct(id)
    .subscribe(rta => {
      this.fetchProducts();
    });
  }

}
