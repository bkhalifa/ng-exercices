import { Product } from "src/app/products/product";
import { ProductioActionType } from "../actions/product.actions";

export interface State {
  products: Product[],
  showProductCode: boolean,
  currentProductId: number,
  currentProduct: Product,
  error: string

}

const initialState: State = {
  products: [],
  showProductCode: true,
  currentProductId: 0,
  currentProduct: null,
  error:''
}

export function reducer(state = initialState, action: any): State {

  switch (action.type) {

    case ProductioActionType.LOAD_PRODUCT_SUCCESS: {
      return {
        ...state,
        products: action.paylaod
      }
    }

    case ProductioActionType.SHOW_PRODUCT_CODE: {
      return {
        ...state,
        showProductCode:  initialState.showProductCode = !initialState.showProductCode
      }
    }

    case ProductioActionType.LOAD_PRODUCT: {
      return {
        ...state,
        currentProductId: action.paylaod
      }
    }

    case ProductioActionType.CURRENT_PRODUCT: {
     const newProduct =  state.products.filter((item:Product) => item.id === action.payload)[0];
      return {
        ...state,
        currentProduct: newProduct,
        currentProductId: action.payload
      }
    }

    case ProductioActionType.LOAD_PRODUCT_SUCCESS: {
      return {
        ...state,
         currentProduct: action.payload
      }
    }


    case ProductioActionType.UPDATE_PRODUCT_SUCCESS: {
      const updateProducts = state.products.map( item => item.id === action.payload.id ? action.payload : item)
      return {
        ...state,
         products: updateProducts,
         currentProduct: action.payload,
         error:''
      }
    }

    case ProductioActionType.UPDATE_PRODUCT_FAILURE: {
      return {
        ...state,
        error: action.paylaod
      }
    }

    case ProductioActionType.INITALISE_PRODUCT: {
      return {
        ...state,
        currentProduct: {id:0, description:'', productCode:'', productName:'new', starRating:0 }
      }
    }

    case ProductioActionType.CREATE_PRODUCT_SUCCESS: {
      const newProducts = [...state.products, action.payload]
      return {
        ...state,
         products: newProducts,
         error:''
      }
    }

    case ProductioActionType.CREATE_PRODUCT_FAILURE: {
      return {
        ...state,
        error: action.paylaod
      }
    }

    default: {
      return {
        ...state
      }
    }


  }

}
