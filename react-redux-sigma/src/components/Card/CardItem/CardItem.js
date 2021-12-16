import React, {useState} from 'react';
import 'antd/dist/antd.css';
import {Card, Row, Col, Button} from 'antd';
import {useHistory} from "react-router-dom";

const CardItem = (props) => {
    const [item, setItem] = useState(props.item)
    let test = null
    const history = useHistory()

    const asd = () => {
        const path = "edit"
        history.push(path, item)
    }

    return (
        <Row>
            {test}
            <Col span={22} offset={24}>
                <Card title={item.id}
                      extra={
                          <Button onClick={() => asd()} type="primary">Edit</Button>
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
