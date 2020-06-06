import { Component,
    Input,
    Output,
    EventEmitter,
    OnChanges,
    SimpleChanges,
    OnInit,
    DoCheck,
    OnDestroy
} from '@angular/core';

import { Product} from '../../../core/services/models/product.model';

import { CartService } from './../../../core/services/cart.service';

@Component({
    selector : 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent implements DoCheck, OnInit, OnDestroy {

    @Input() product: Product;
    @Output() productClicked: EventEmitter<any> = new EventEmitter();

    today = new Date();

    constructor(
        private cartService: CartService
    ) {
        console.log('1. constructor');
    }

    ngOnInit() {
        console.log('3. ngOnInit');
    }

    ngDoCheck() {
        console.log('4. ngOnInit');
    }

    ngOnDestroy() {
        console.log('5. OnDestroy');
    }

    addCart() {
        console.log('Añadir al carrito');
        this.cartService.addCart(this.product);
        // this.productClicked.emit(this.product.id);
    }
 }

