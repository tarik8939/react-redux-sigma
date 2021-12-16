import React, {useEffect, useState} from 'react';
import 'antd/dist/antd.css';
import CardItem from "../CardItem/CardItem";
import {Col, Row} from 'antd';
import {useSelector} from "react-redux";

const CardList = (props) => {
    let [cards, setCards] = useState(useSelector(state => state.postReducer.posts))

    // const items = useSelector(state => state.postReducer.posts)
    const write = () => {
        return (cards.map((x) => (
            <CardItem key={x.id}/>
        )))
    }

    return (
        <div className="site-card-wrapper">
            <Row gutter={16}>
                <Col span={8}>
                    {/*{write()}*/}

                    {cards.map((x) => (
                        <CardItem item={x} key={x.id}/>
                    ))}
                </Col>
            </Row>
        </div>
    );
};

export default CardList;
