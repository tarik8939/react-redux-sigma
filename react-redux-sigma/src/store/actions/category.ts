import {PostAction, PostType} from "../../types/post";
import {CategoryAction, CategoryActionTypes, CategoryType, SetCategoryAction} from "../../types/category";
import {Dispatch} from "redux";
import axios from "axios";
import {setPosts} from "./post";

export const setCategories = (categories: CategoryType[]): SetCategoryAction => {
    return {
        type: CategoryActionTypes.SET_CATEGORIES,
        categories: categories
    };
};

export const initCategories = () => {
    return (dispatch: Dispatch<CategoryAction>) => {
        axios.get<CategoryType[]>("https://localhost:5001/categories")
            .then(response => {
                dispatch(setCategories(response.data))
            })
    };
};
