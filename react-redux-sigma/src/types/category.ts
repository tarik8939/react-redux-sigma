import {PostActionTypes, PostType} from "./post";

export interface CategoryType {
    categoryId: number;
    name: string;
    postCategories: PostCategoryType[]
}
export interface PostCategoryTypeDTO {
    categoryId: number;
}

export interface PostCategoryType {
    postId: number;
    post: PostType;
    categoryId: number;
    category: CategoryType
}

export interface InitialStateType {
    categories: CategoryType[];
}
export enum CategoryActionTypes {
    SET_CATEGORIES = 'SET_CATEGORIES',
}
export interface SetCategoryAction {
    type: CategoryActionTypes.SET_CATEGORIES;
    categories: CategoryType[];
}
export type CategoryAction = SetCategoryAction;
