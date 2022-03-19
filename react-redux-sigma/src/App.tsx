import logo from './logo.svg';
import './App.css';
import {Route, Switch, BrowserRouter} from 'react-router-dom';
import Layuot from "./hoc/Layout/Layuot";
import AlbumViewer from "./containers/Posts/PostsViewer";
import {Component, useState} from "react";
import EditCard from "./components/Card/CardItem/EditCard";
import NewCard from "./components/Card/CardItem/NewCard";
import {useTypedSelector} from "./hooks/useTypedSelector";

class App extends Component {
    render () {
        return (
            <BrowserRouter>
                <Layuot>
                    <Route path="/" exact component={AlbumViewer}/>
                    <Route path="/edit" component={EditCard}/>
                    <Route path="/addNew" component={NewCard}/>
                </Layuot>
            </BrowserRouter>
        );
    }
}

export default App;
