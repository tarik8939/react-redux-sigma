import logo from './logo.svg';
import './App.css';
import {Route, Switch, BrowserRouter} from 'react-router-dom';
import Layuot from "./hoc/Layout/Layuot";
import AlbumViewer from "./containers/Posts/PostsViewer";
import {Component} from "react";
import EditCard from "./components/Card/CardItem/EditCard";
import NewCard from "./components/Card/CardItem/NewCard";

class App extends Component {
    render () {
        return (
            <BrowserRouter>
                <Layuot>
                    {/*<Switch>*/}
                    {/*<Route path="/" exact component={AlbumViewer}/>*/}
                    <Route path="/" exact component={AlbumViewer}/>
                    <Route path="/edit" component={EditCard}/>
                    <Route path="/addNew" component={NewCard}/>
                    {/*</Switch>*/}

                </Layuot>
            </BrowserRouter>
        );
    }
}

export default App;
