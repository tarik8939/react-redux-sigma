import {
    AddPostsAction,
    EditPostsAction,
    InitialStateType,
    PostAction,
    PostActionTypes,
    SetPostsAction
} from "../../types/post";

const InitialState: InitialStateType = {
    posts: [],
    isloaded: false
};
const setPosts = (state: InitialStateType, action: SetPostsAction): InitialStateType => {
    return {
        posts: [
            ...action.posts
        ],
        isloaded: true
    }
}

const addPost = (state: InitialStateType, action: AddPostsAction): InitialStateType => {
    return {
        ...state,
        posts: [...state.posts, {
            ...action.post,
            userId: 1,
            postId: state.posts.length + 1
        }]
    }
}

const editPost = (state: InitialStateType, action: EditPostsAction): InitialStateType => {
    return {
        ...state,
        posts: [
            ...state.posts.map(post => post.postId === action.post.postId ?
                {...action.post} : post
            )
        ]
    }
}


const reducer = (state = InitialState, action: PostAction): InitialStateType => {
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
