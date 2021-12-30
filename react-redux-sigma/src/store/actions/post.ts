import axios from 'axios'
import {
    AddPostsAction,
    EditPostsAction,
    PostAction,
    PostActionTypes, PostType,
    SetPostsAction
} from "../../types/post";
import {Dispatch} from "redux";


export const setPosts = (posts: PostType[]): SetPostsAction => {
    return {
        type: PostActionTypes.SET_POSTS,
        posts: posts
    };
};

export const addPost = (post: PostType): AddPostsAction => {
    return {
        type: PostActionTypes.ADD_POST,
        post: post
    };
};

export const editPost = (post: PostType): EditPostsAction => {
    return {
        type: PostActionTypes.EDIT_POST,
        post: post
    };
};

export const initPosts = () => {
    return (dispatch: Dispatch<PostAction>) => {
        axios.get<PostType[]>('https://jsonplaceholder.typicode.com/posts?_limit=5')
            .then(response => {
                dispatch(setPosts(response.data))
            })
    };
};
