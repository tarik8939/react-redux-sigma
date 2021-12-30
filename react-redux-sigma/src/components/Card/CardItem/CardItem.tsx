import React, {FC, useState} from 'react';
import 'antd/dist/antd.css';
import {Card, Row, Col, Button} from 'antd';
import {useHistory} from "react-router-dom";
import {PostType} from '../../../types/post'

interface ICardItem {
    card: PostType
}

const CardItem: FC<ICardItem> = ({card}) => {
    const [item, setItem] = useState<PostType>(card)
    let test = null
    const history = useHistory()

    const redirect = () => {
        const path = "edit"
        history.push(path, item)
    }

    return (
        <Row>
            {test}
            <Col span={22} offset={24}>
                <Card title={item.id}
                      extra={
                          <Button onClick={() => redirect()} type="primary">Edit</Button>
                      }
                      bordered={true} style={{marginBottom: 5}}>

                    <h3>{item.title}</h3>
                    <p>{item.body}</p>
                </Card>
            </Col>
        </Row>
    );
};

export default CardItem;
