export interface postType {
    id: number;
    userId: number;
    title: string;
    body: string;
}

export interface initialStateType {
    posts: postType[];
    isloaded: boolean;
}

export enum PostActionTypes {
    SET_POSTS = 'SET_POSTS',
    ADD_POST = 'ADD_POST',
    EDIT_POST = 'EDIT_POST'

}

export interface setPostsAction {
    type: PostActionTypes.SET_POSTS;
    posts: postType[];
}

export interface initPostsAction {
    posts: postType[];
}

export interface addPostsAction {
    type: PostActionTypes.ADD_POST;
    post: postType;
}

export interface editPostsAction {
    type: PostActionTypes.EDIT_POST;
    post: postType;
}
export type PostAction = setPostsAction | addPostsAction | editPostsAction;
