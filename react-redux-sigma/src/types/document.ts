import {PostType} from "./post";

export interface DocumentType{
    documentId: number;
    postId: number;
    post: PostType;
}
