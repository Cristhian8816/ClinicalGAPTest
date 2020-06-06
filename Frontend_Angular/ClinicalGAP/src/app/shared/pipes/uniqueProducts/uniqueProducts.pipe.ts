import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../../../core/services/models/product.model';

@Pipe({
  name: 'uniqueProducts'
})
export class UniqueProductsPipe implements PipeTransform {

  uniqueProducts: Product[] = [];

  transform(value: Product[]): Product[] {
    value.forEach(product => {
      if (!this.uniqueProducts.find(p => p.id === product.id)) {
        product.quantity = 1;
        this.uniqueProducts.push(product);
      } else {
        this.uniqueProducts.find(p => p.id === product.id).quantity += 1;
      }
    });
    return this.uniqueProducts;
  }

}
