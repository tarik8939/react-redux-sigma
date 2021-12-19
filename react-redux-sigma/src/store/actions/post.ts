import axios from 'axios'
import {
    addPostsAction,
    editPostsAction,
    PostAction,
    PostActionTypes, postType,
    setPostsAction
} from "../../types/post";
import {Dispatch} from "redux";


export const setPosts = (posts: postType[]): setPostsAction => {
    return {
        type: PostActionTypes.SET_POSTS,
        posts: posts
    };
};

export const addPost = (post: postType): addPostsAction => {
    return {
        type: PostActionTypes.ADD_POST,
        post: post
    };
};

export const editPost = (post: postType): editPostsAction => {
    return {
        type: PostActionTypes.EDIT_POST,
        post: post
    };
};

export const initPosts = () => {
    return (dispatch: Dispatch<PostAction>) => {
        axios.get<postType[]>('https://jsonplaceholder.typicode.com/posts?_limit=5')
            .then(response => {
                dispatch(setPosts(response.data))
            })
    };
};
