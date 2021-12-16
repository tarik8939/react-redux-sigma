import {
    addPostsAction,
    editPostsAction,
    initialStateType,
    PostAction,
    PostActionTypes,
    setPostsAction
} from "../../types/post";

const initialState: initialStateType = {
    posts: [],
    isloaded: false
};
const setPosts = (state: initialStateType, action: setPostsAction): initialStateType => {
    return {
        posts: [
            ...action.posts
        ],
        isloaded: true
    }
}

const addPost = (state: initialStateType, action: addPostsAction): initialStateType => {
    return {
        ...state,
        posts: [...state.posts, {
            ...action.post,
            userId: 1,
            id: state.posts.length + 1
        }]
    }
}

const editPost = (state: initialStateType, action: editPostsAction): initialStateType => {
    return {
        ...state,
        posts: [
            ...state.posts.map(post => post.id === action.post.id ?
                {...action.post} : post
            )
        ]
    }
}


const reducer = (state = initialState, action: PostAction): initialStateType => {
    switch (action.type) {
        case PostActionTypes.SET_POSTS:
            return setPosts(state, action);
        case PostActionTypes.ADD_POST:
            return addPost(state, action);
        case PostActionTypes.EDIT_POST:
            return editPost(state, action);
        default:
            return state;
    }
};

export default reducer;
