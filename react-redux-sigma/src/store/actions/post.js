import * as actionTypes from './actionTypes'
import axios from 'axios'

export const setPosts = (posts) =>{
    return{
        type: actionTypes.SET_POSTS,
        posts: posts
    };
};

export const addPost = (post) =>{
    return{
        type: actionTypes.ADD_POST,
        post: post
    };
};

export const editPost = (post) =>{
    return{
        type: actionTypes.EDIT_POST,
        post: post
    };
};

export const initPosts = () =>{
    return dispatch => {
        axios.get('https://jsonplaceholder.typicode.com/posts?_limit=5')
            .then(response =>{
                dispatch(setPosts(response.data))
            })
    };
};
