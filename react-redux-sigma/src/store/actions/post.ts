import axios from 'axios'
import {
    AddPostsAction,
    EditPostsAction,
    PostAction,
    PostActionTypes, PostType, PostType2,
    SetPostsAction
} from "../../types/post";
import {Dispatch} from "redux";
import post from "../reducers/post";


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
    // const asd = {
    //     userId: post.userId,
    //     title: post.title,
    //     body: post.body,
    //     categoryDtos: [...post.postCategories]
    // };
    // console.log(`editPost ${JSON.stringify(asd, null, 2)}`)


    return {
        type: PostActionTypes.EDIT_POST,
        post: post
    };

    // return {
    //     type: PostActionTypes.EDIT_POST,
    //     post: axios.put<any>(`https://localhost:5001/posts/${post.postId}`, asd, {
    //         headers: {'Content-Type': 'application/json-patch+json'}
    //     }).then(value => console.log(value.data)).catch(reason => console.log(reason.response))
    // };
};

export const updatePost = (post: PostType2, postId: number) => {
    const editedpost = {
        userId: post.userId,
        title: post.title,
        body: post.body,
        categoryDtos: [...post.postCategories]
    };
    console.log(post)
    console.log(`action ${JSON.stringify(editedpost, null, 2)}`)
    return (dispatch: Dispatch<PostAction>) => {
        return axios.put<PostType>(`https://localhost:5001/posts/${postId}`, editedpost, {
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        }).then(response => {
            console.log(response.data)
            dispatch(editPost(response.data))
            // initPosts()
        }).catch(reason => console.log(reason.response))
    };
}

export const initPosts = () => {
    return (dispatch: Dispatch<any>) => {
        axios.get<PostType[]>("https://localhost:5001/posts")
            .then(response => {
                dispatch(setPosts(response.data))
            })
    };
};
