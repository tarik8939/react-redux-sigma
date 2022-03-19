import {PostType} from "./post";

export interface UserType{
    userId: number;
    email: string;
    posts: PostType[]
}
