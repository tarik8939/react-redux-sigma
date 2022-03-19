import {applyMiddleware, combineReducers, compose, createStore} from "redux";
import postReducer from "./reducers/post";
import categoryReducer from "./reducers/category";
import thunk from "redux-thunk";

declare global {
    interface Window {
        __REDUX_DEVTOOLS_EXTENSION_COMPOSE__?: typeof compose;
    }
}

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const rootReducer = combineReducers({
    postReducer: postReducer,
    categoryReducer: categoryReducer
});
export type RootState = ReturnType<typeof rootReducer>;
export const store = createStore(rootReducer, composeEnhancers(
    applyMiddleware(thunk)
));
