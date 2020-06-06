import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';

import {ProductsService} from '../../../core/services/products/products.service';
import {Product} from '../../../core/services/models/product.model';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: Product;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      const id = params.id;
      this.fetchProduct(id);
      // this.product = this.productService.getProducts(id);
    } );
  }

  fetchProduct(id: string) {
    this.productService.getProduct(id)
    .subscribe(product => {
     this.product = product;
    });
  }

  creteProduct() {
    const newProduct: Product = {
      id: '222',
      image: 'assets/images/banner-1.jpg',
      title: 'Nuevo desde Angular',
      price: 70000,
      description: 'nuevo producto',
      quantity: 1,
  };
    this.productService.createProduct(newProduct)
    .subscribe(product => {
     console.log(product);
    });
  }

  updateProduct() {
    const updateProduct: Partial<Product> = {
      title: 'Edicion desde Angular',
      price: 123456,
      description: 'Editado producto'
  };
    this.productService.updateProduct('2', updateProduct)
  .subscribe(product => {
    console.log(product);
  });
  }

  deleteProduct() {
    this.productService.deleteProduct('1234')
    .subscribe(rta => {
      console.log(rta);
    });
  }
}
