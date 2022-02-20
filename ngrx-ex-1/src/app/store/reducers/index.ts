import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import * as FromProduct from './product.reducers';


export interface State {
  fromProduct: FromProduct.State
}

export const reducers: ActionReducerMap<State> = {
  fromProduct: FromProduct.reducer
}


const debugMeta = (reducer: ActionReducer<any>) : ActionReducer<any> => {
  return (state, action) => {
    // console.log('state', state);
    // console.log('action', action);

    return reducer(state, action);
  }
}

 export const metaReducers: MetaReducer<State>[] = [debugMeta];
