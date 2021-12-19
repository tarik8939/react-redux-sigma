import React, {Component} from 'react';
import {connect} from 'react-redux';

import * as actions from '../../store/actions/post'
import {Button, Col} from 'antd';
import CardList from "../../components/Card/CardList/CardList";
import {Link} from "react-router-dom";
import {postType} from "../../types/post";
import {RootState} from "../../store";

interface PostsViewerProps {
    isloaded: boolean,
    posts:postType[],
    onInitPosts: () => void,
}

class PostsViewer extends Component<PostsViewerProps, {}> {

    componentDidMount ():void {
        if (!this.props.isloaded) {
            this.props.onInitPosts();
        }
    }

    render () {

        const writePosts = () => {
            if (this.props.isloaded) {
                return <CardList />
            }
        }

        return (
            <div>
                <h1>Hello</h1>
                <Col span={7} offset={8}>
                    <Link to={"/addNew"}>
                        <Button type="primary" block>
                            Add new post
                        </Button>
                    </Link>
                </Col>
                {writePosts()}
            </div>
        );
    }
}

const mapStateToProps = (state: RootState) => {
    return {
        posts: state.postReducer.posts,
        isloaded: state.postReducer.isloaded

    };
}
//TODO:must be typed
// const mapDispatchToProps = (dispatch: Dispatch<PostAction>) => {
const mapDispatchToProps = (dispatch:any)=> {
    return {
        onInitPosts: () => dispatch(actions.initPosts()),
    }
}


export default connect(mapStateToProps, mapDispatchToProps)(PostsViewer);
