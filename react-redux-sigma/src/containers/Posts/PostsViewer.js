import React, {Component} from 'react';
import {connect} from 'react-redux';

import * as actions from '../../store/actions/post'
import {Button, Col} from 'antd';
import CardList from "../../components/Card/CardList/CardList";
import {Link} from "react-router-dom";


class PostsViewer extends Component {

    componentDidMount () {
        if (!this.props.isloaded) {
            this.props.onInitPosts();
        }
    }

    render () {

        const writePosts = () => {
            if (this.props.isloaded) {
                return <CardList items={this.props.posts}/>
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

const mapStateToProps = state => {
    return {
        posts: state.postReducer.posts,
        isloaded: state.postReducer.isloaded

    };
}

const mapDispatchToProps = dispatch => {
    return {
        onInitPosts: () => dispatch(actions.initPosts())
    }
}


export default connect(mapStateToProps, mapDispatchToProps)(PostsViewer);
