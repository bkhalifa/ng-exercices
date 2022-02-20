import { Action } from "@ngrx/store"
import { Product } from "src/app/products/product"

export const ProductioActionType = {
  INITALISE_PRODUCT: '[Product page] Initialise product',
  CURRENT_PRODUCT: '[Current Product] select product',
  SHOW_PRODUCT_CODE: '[Prodcut page] show produt code',
  LOAD_PRODUCT: '[Product API] load product;',
  LOAD_PRODUCT_SUCCESS: '[Product API] load product api success',
  LOAD_PRODUCT_FAILURE: '[Prodcuct API] load product failure',
  UPDATE_PRODUCT: '[Product API] update product',
  UPDATE_PRODUCT_SUCCESS: '[Product API] update product SUCESS',
  UPDATE_PRODUCT_FAILURE: '[Product API] update product FAILURE',
  CREATE_PRODUCT: '[Product API] create product',
  CREATE_PRODUCT_SUCCESS: '[Product API] create product SUCESS',
  CREATE_PRODUCT_FAILURE: '[Product API] create product FAILURE',
}

export class CurrentProductAction implements Action {
  type = ProductioActionType.CURRENT_PRODUCT;
  constructor(public payload: number) { }
}

export class InitialiseProduct implements Action {
  readonly type = ProductioActionType.INITALISE_PRODUCT;
}

export class ShowProductCodeAction implements Action {
  readonly type = ProductioActionType.SHOW_PRODUCT_CODE
}

export class LoadProductsAction implements Action {
  readonly type = ProductioActionType.LOAD_PRODUCT;
}

export class LoadProductActionSucess implements Action {
  readonly type = ProductioActionType.LOAD_PRODUCT_SUCCESS
  constructor(public paylaod: Product[]) { }
}

export class LaodProductActionFailure implements Action {
  readonly type = ProductioActionType.LOAD_PRODUCT_FAILURE
  constructor(public paylaod: boolean) { }
}

export class UpdateProduct implements Action {
  type = ProductioActionType.UPDATE_PRODUCT;
  constructor(public payload: Product) {}
}

export class UpdateProductSucess implements Action {
  type = ProductioActionType.UPDATE_PRODUCT_SUCCESS;
  constructor(public payload: Product) {}
}

export class UpdateProductFailure implements Action {
  type = ProductioActionType.UPDATE_PRODUCT_FAILURE;
  constructor(public error: string) {}
}

export class CreateProduct implements Action {
  type = ProductioActionType.CREATE_PRODUCT;
  constructor(public payload: Product) {}
}

export class CreateProductSuccess implements Action {
  type = ProductioActionType.CREATE_PRODUCT_SUCCESS;
  constructor(public payload: Product) {}
}

export class CreateProductFailure implements Action {
  type = ProductioActionType.CREATE_PRODUCT_FAILURE;
  constructor(public error: string) {}
}


export type ProductionActions =
  | CurrentProductAction
  | LoadProductsAction
  | ShowProductCodeAction
  | LoadProductActionSucess
  | LaodProductActionFailure
  | UpdateProduct
  | UpdateProductSucess
  | UpdateProductFailure
  | CreateProduct
  | CreateProductSuccess
  | CreateProductFailure

