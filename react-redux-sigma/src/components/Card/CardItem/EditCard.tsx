import React, {FC, useEffect, useState} from 'react';
import {Form, Input, Button} from 'antd';
import 'antd/dist/antd.css';
import TextArea from "antd/es/input/TextArea";
import {useDispatch} from "react-redux";
import actions from '../../../store/actions/index'

import {useHistory} from "react-router-dom";
import {PostType, PostType2} from "../../../types/post";
import {RouteComponentProps} from 'react-router-dom';
import {useTypedSelector} from "../../../hooks/useTypedSelector";
import {CategoryType, PostCategoryType, PostCategoryTypeDTO} from "../../../types/category";
import {Select} from 'antd';
import {UserType} from "../../../types/user";

const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 8,
    },
};
const tailLayout = {
    wrapperCol: {
        offset: 8,
        span: 16,
    },
};


const EditCard: FC<any> = (props) => {
    const [card] = useState<PostType>(props.location.state)
    const [categories] = useState<CategoryType[]>(useTypedSelector(state => state.categoryReducer.categories))
    const dispatch = useDispatch()
    const [form] = Form.useForm();
    const history = useHistory()

    const categoriesList = (
        categories.map((x: CategoryType) => (
            // <Select.Option key={x.categoryId} value={JSON.stringify(x)}>{x.name}</Select.Option>
            <Select.Option key={x.categoryId} value={x.categoryId}>{x.name}</Select.Option>
        ))
    );

    const selectedCategories = (
        card.postCategories.map((x: PostCategoryType) => (
            x.categoryId
        ))
    )

    const onFinish = (values: PostType2) => {

        let editedPost: PostType2 = {...card, ...values}

        if (editedPost.postCategories === undefined) {
            editedPost.postCategories = [...card.postCategories.map((x: PostCategoryTypeDTO) => ({
                categoryId: x.categoryId,
            }))]
        } else {
            // @ts-ignore
            editedPost.postCategories = [...values.postCategories.map((x:PostCategoryTypeDTO) => ({
                categoryId: x,
            }))]
        }

        dispatch(actions.updatePost(editedPost,editedPost.postId))
        // dispatch(actions.editPost(editedPost))
        // goBack();
    };
    const onFill = () => {
        form.setFieldsValue({
            title: card.title,
            body: card.body,
        });
    };
    useEffect(() => {
        onFill()
    }, [])

    const goBack = () => {
        history.push("/")
        // history.goBack()
    };
    return (
        <Form {...layout} form={form} name="control-hooks" style={{marginTop: 35}} onFinish={onFinish}>
            <Form.Item
                name="title"
                label="Title"
                rules={[
                    {
                        required: true,
                        type: "string",
                    },
                ]}
            >
                <Input/>
            </Form.Item>
            <Form.Item
                name="body"
                label="Body"
                rules={[
                    {
                        required: true,
                        type: "string",
                    },
                ]}
            >
                <TextArea style={{height: 150}}/>
            </Form.Item>

            <Form.Item label="Select" name="postCategories"
                       rules={[{type: 'array'}]}>
                <Select mode="multiple"
                        style={{width: '100%'}}
                        placeholder="Tags Mode"
                        defaultValue={selectedCategories}>
                    {categoriesList}
                </Select>
            </Form.Item>

            <Form.Item {...tailLayout}>
                <Button type="primary" htmlType="submit">
                    Submit
                </Button>
                <Button type="link" htmlType="button" onClick={onFill}>
                    Fill form
                </Button>
                <Button type="link" htmlType="button" onClick={goBack}>
                    Go back
                </Button>
            </Form.Item>
        </Form>

    );
};

export default EditCard;
