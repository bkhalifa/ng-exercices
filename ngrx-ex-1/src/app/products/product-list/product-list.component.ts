import { Component, OnInit } from '@angular/core';

import { Observable, Subscription } from 'rxjs';

import { Product } from '../product';
import { ProductService } from '../product.service';
import  {State} from '../../store/reducers/index';

/* NgRx */
import { Store } from '@ngrx/store';
import { ShowProductCodeAction } from 'src/app/store/actions/product.actions';
import * as ProductionActions from '../../store/actions/product.actions';
import { selectAllProducts, selectCurrentProduct, selectShowCode } from '../../store/selectors/product.selectors';


@Component({
  selector: 'pm-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  pageTitle = 'Products';
  errorMessage: string;

  displayCode: boolean;

  products$: Observable<Product[]>;
  showProductCode$: Observable<boolean>;
  selectedProduct$: Observable<Product | null>;
  sub: Subscription;

  constructor(private store: Store<State>, private productService: ProductService) { }

  ngOnInit(): void {
  this.store.dispatch(new ProductionActions.LoadProductsAction())
  this.products$ = this.store.select(selectAllProducts);
  this.selectedProduct$ = this.store.select(selectCurrentProduct);
  this.showProductCode$ = this.store.select(selectShowCode);
  }


  checkChanged(): void {
    this.store.dispatch(new ShowProductCodeAction());
  }

  newProduct(): void {
   this.store.dispatch(new ProductionActions.InitialiseProduct());
  }

  productSelected(product: Product): void {
    this.store.dispatch(new ProductionActions.CurrentProductAction(product.id))
  }


}
