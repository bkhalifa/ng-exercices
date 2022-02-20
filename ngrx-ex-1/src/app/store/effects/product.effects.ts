import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { switchMap, map, catchError } from 'rxjs/operators';
import { ProductService } from 'src/app/products/product.service';
import * as ProductActions from '../actions/product.actions';
import { of } from 'rxjs';

@Injectable()
export class ProductEffect {
  constructor(private actions$: Actions, private productService: ProductService) { }


  @Effect() loadProducts$ = this.actions$.
    pipe(
      ofType(ProductActions.ProductioActionType.LOAD_PRODUCT),
      switchMap(() => this.productService.getProducts().pipe(
        map(products => new ProductActions.LoadProductActionSucess(products))
      )),
      catchError(error => of(new ProductActions.LaodProductActionFailure(error)))

    )

    @Effect() updateProducts$ = this.actions$.
    pipe(
      ofType(ProductActions.ProductioActionType.UPDATE_PRODUCT),
      switchMap((action: ProductActions.UpdateProduct) => this.productService.updateProduct(action.payload).pipe(
        map(product => new ProductActions.UpdateProductSucess(product))
      )),
      catchError(error => of(new ProductActions.UpdateProductFailure(error))
      )
    )

    @Effect() createProducts$ = this.actions$.
    pipe(
      ofType(ProductActions.ProductioActionType.CREATE_PRODUCT),
      switchMap((action: ProductActions.CreateProduct) => this.productService.createProduct(action.payload).pipe(
        map(product =>   new ProductActions.CreateProductSuccess(product)
        )
      )),
      catchError(error => of(new ProductActions.UpdateProductFailure(error))
      )
    )
}
