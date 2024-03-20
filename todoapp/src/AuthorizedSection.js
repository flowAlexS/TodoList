import AuthorizedNavbar from "./AuthorizedNavbar";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Todos from "./Todos";
import Todo from "./Todo";
import CreateTodo from "./CreateTodo";

const AuthorizedSection = ({ data }) => {

    return (
        <>
            <Router>
                <AuthorizedNavbar />
                <Switch>
                    <Route exact path="/create">
                        <CreateTodo />
                    </Route>
                    <Route exact path="/">
                        <Todos data={data} />
                    </Route>
                    <Route exact path="/:id">
                        <Todo />
                    </Route>
                </Switch>    
            </Router> 
        </>  
    );
}
 
export default AuthorizedSection;