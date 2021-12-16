import React, {useEffect, useState} from 'react';
import {Form, Input, Button} from 'antd';
import 'antd/dist/antd.css';
import TextArea from "antd/es/input/TextArea";
import {useDispatch} from "react-redux";
import * as actions from '../../../store/actions/post'
import {useHistory} from "react-router-dom";

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

const EditCard = (props) => {
    const [card, setCard] = useState(props.location.state)
    const dispatch = useDispatch()
    const [form] = Form.useForm();
    const history = useHistory()

    const onFinish = (values) => {
        const editedPost = {...card, ...values}
        dispatch(actions.editPost(editedPost))
        goBack();
    };
    const onFill = () => {
        form.setFieldsValue({
            title: card.title,
            body: card.body,
        });
    };
    useEffect(()=> {
        onFill()
    },[])

    const goBack = () => {
        // history.goBack()
        history.push("/")
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
