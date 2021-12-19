import React, {FC, useState} from 'react';
import 'antd/dist/antd.css';
import CardItem from "../CardItem/CardItem";
import {Col, Row} from 'antd';
import {useTypedSelector} from "../../../hooks/useTypedSelector";

const CardList: FC = () => {
    let [cards, setCards] = useState(useTypedSelector(state => state.postReducer.posts))

    return (
        <div className="site-card-wrapper">
            <Row gutter={16}>
                <Col span={8}>
                    {cards.map((x) => (
                        <CardItem card={x} key={x.id}/>
                    ))}
                </Col>
            </Row>
        </div>
    );
};

export default CardList;
