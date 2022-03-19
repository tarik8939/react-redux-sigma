import React, {Component} from 'react';
import {connect} from 'react-redux';

import actions from '../../store/actions/index'
import {Button, Col} from 'antd';
import CardList from "../../components/Card/CardList/CardList";
import {Link} from "react-router-dom";
import {PostType} from "../../types/post";
import {RootState} from "../../store";

interface PostsViewerProps {
    isloaded: boolean,
    posts: PostType[],
    onInitPosts: () => void,
    onInitCategories: () => void,
}

class PostsViewer extends Component<PostsViewerProps, {}> {

    componentDidMount ():void {
        if (!this.props.isloaded) {
            this.props.onInitPosts();
            this.props.onInitCategories();
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
        onInitCategories: () => dispatch(actions.initCategories())
    }
}


export default connect(mapStateToProps, mapDispatchToProps)(PostsViewer);
