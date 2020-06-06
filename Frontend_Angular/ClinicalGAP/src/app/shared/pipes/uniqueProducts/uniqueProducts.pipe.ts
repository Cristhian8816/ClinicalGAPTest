import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../../../core/services/models/product.model';

@Pipe({
  name: 'uniqueProducts'
})
export class UniqueProductsPipe implements PipeTransform {

  uniqueProducts: Product[] = [];

  transform(value: Product[]): Product[] {
    return this.uniqueProducts;
  }

}
