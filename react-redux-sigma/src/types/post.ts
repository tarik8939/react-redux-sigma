import {UserType} from "./user";
import { PostCategoryType, PostCategoryTypeDTO} from "./category";

export interface PostType {
    postId: number;
    userId: number;
    title: string;
    body: string;
    user: UserType;
    document?: DocumentType;
    postCategories: PostCategoryType[];
}

export interface PostType2 {
    postId: number;
    userId: number;
    title: string;
    body: string;
    postCategories: PostCategoryTypeDTO[];
}

export interface InitialStateType {
    posts: PostType[];
    isloaded: boolean;
}

export enum PostActionTypes {
    SET_POSTS = 'SET_POSTS',
    ADD_POST = 'ADD_POST',
    EDIT_POST = 'EDIT_POST'

}

export interface SetPostsAction {
    type: PostActionTypes.SET_POSTS;
    posts: PostType[];
}

export interface InitPostsAction {
    posts: PostType[];
}

export interface AddPostsAction {
    type: PostActionTypes.ADD_POST;
    post: PostType;
}

export interface EditPostsAction {
    type: PostActionTypes.EDIT_POST;
    post: PostType;
}
export type PostAction = SetPostsAction | AddPostsAction | EditPostsAction;
