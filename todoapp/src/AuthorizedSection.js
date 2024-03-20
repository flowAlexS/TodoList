import AuthorizedNavbar from "./AuthorizedNavbar";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Todos from "./Todos";
import Todo from "./Todo";

const AuthorizedSection = ({ data }) => {
    // Route to the spefici area...

    return (
        <>
            <AuthorizedNavbar />
            <Router>
                <Switch>
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