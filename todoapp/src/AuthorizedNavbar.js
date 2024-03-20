import { GetCookie } from "./CookieHandler";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

const AuthorizedNavbar = () => {
    return (
        <nav className="navbar">
        <p>Hello <span class="special">{GetCookie().userName}</span></p>
        <div className="nav-list">
            <li className="nav__list">
                <Link to="/">View All</Link>
                <Link to="/create">Create Task</Link>
            </li>
        </div>
    </nav>

    );
}
 
export default AuthorizedNavbar;