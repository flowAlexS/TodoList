import AuthorizedNavbar from "./AuthorizedNavbar";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Todos from "./Todos";

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
                    </Route>
                </Switch>    
            </Router> 
        </>  
    );
}
 
export default AuthorizedSection;