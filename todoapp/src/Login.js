import { useState } from "react";
import { SetCookie, GetCookie } from "./CookieHandler";
import PostAccount from "./HandleAuthentication";

const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [isInvalid, setIsInvalid] = useState(false);

    const handleRegister = (e) => {
        const loginModel = { userName, password }
        let result = PostAccount(loginModel, "api/account/login");

        if (result)
        {
            window.location.reload();
        }
        else
        {
            setPassword('');
            setUserName('');
            setIsInvalid(true);
            setTimeout(() => setIsInvalid(false), 3000);
        }

        e.preventDefault();
    }

    return (
        <form onSubmit={handleRegister}>
            <label>Username...</label>
            <input
            type="text"
            required
            value={userName}
            onChange={(e) => setUserName(e.target.value)}>
            </input>
            <label>Password...</label>
            <input
            type="password" 
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}>
            </input>
            <button>
                Login
            </button>
            { isInvalid && <p> Invalid username or password </p> }
        </form>      
    );
}
 
export default Login;