import { GetCookie } from "./CookieHandler";

const AuthorizedNavbar = () => {
    return (
        <nav className="navbar">
        <p>Hello <span class="special">{GetCookie().userName}</span></p>
        <div className="nav-list">
            <li className="nav__list">
                <a className href="/">View All</a>
                <a className href="/">Create Task</a>
            </li>
        </div>
    </nav>

    );
}
 
export default AuthorizedNavbar;