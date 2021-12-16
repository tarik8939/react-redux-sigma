import * as actionTypes from '../actions/actionTypes';
import {loremIpsum} from "lorem-ipsum";

const initialState = {
    posts: [],
    isloaded: false
};

const setPosts = (state, action) => {
    return {
        posts: [
            ...action.posts
        ],
        isloaded: true
    }
}

const addPost = (state, action) => {
    return {
        ...state,
        posts: [...state.posts, {
            ...action.post,
            userId:1,
            id: state.posts.length + 1
        }]
    }
}

const editPost = (state, action) => {
    return {
        ...state,
        posts: [
            ...state.posts.map(post=>post.id===action.post.id ?
                {...action.post} : post
            )
        ]
    }
}


const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SET_POSTS:
            return setPosts(state, action);
        case actionTypes.ADD_POST:
            return addPost(state, action);
        case actionTypes.EDIT_POST:
            return editPost(state, action);
        default:
            return state;
    }
};

export default reducer;
