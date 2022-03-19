import {CategoryAction, CategoryActionTypes, InitialStateType, SetCategoryAction} from "../../types/category";

const InitialState: InitialStateType = {
    categories: [],
};

const setCategories = (state: InitialStateType, action: SetCategoryAction): InitialStateType => {
    return {
        categories: [
            ...action.categories
        ]
    }
}

const reducer = (state = InitialState, action: CategoryAction): InitialStateType => {
    switch (action.type) {
        case CategoryActionTypes.SET_CATEGORIES:
            return setCategories(state, action);
        default:
            return state;
    }
};

export default reducer;
