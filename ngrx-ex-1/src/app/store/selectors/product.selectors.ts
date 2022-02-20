import { createSelector } from "@ngrx/store";
import { Product } from "../../products/product";
import { State } from "../reducers/index";


export const selectAllProducts = (state: State) => state.fromProduct.products;

export const selectShowCode = (state: State) => state.fromProduct.showProductCode;

export const selectProduct = (state: State) => state.fromProduct.currentProduct;

export const selectCurrentProduct = createSelector (
  selectProduct,
  selectAllProducts,
  (selectProduct: Product, allProducts: Product[]) => {
    if (selectProduct?.id > 0) {
    let product = allProducts.find((p: Product) => p.id === selectProduct.id);
    return product;
    } else {

      let  product = {id:0, description:'', productCode:'', productName:'new', starRating:0 };
      return product;
    }
  }
)
