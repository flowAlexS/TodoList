import { useState } from "react";
import { GetCookie, SetCookie } from "./CookieHandler";
import PostAccount from "./HandleAuthentication";

const Register = () => {
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isInvalid, setIsInvalid] = useState(false);

    const handleRegistration = (e) => {
        const registerModel = { userName, email, password }
        let result = PostAccount(registerModel, "api/account/register");
        
        if (result === true)
        {
            window.location.reload();
        }
        else {
            setUserName('');
            setEmail('');
            setPassword('');
            setIsInvalid(true);
            setTimeout(() => setIsInvalid(false), 3000);
        }

        e.preventDefault();

    }

    return ( 
        <form onSubmit={handleRegistration}>
            <label>Username...</label>
            <input
            type="text"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required>
            </input>

            <label>Email...</label>
            <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required>
            </input>

            <label>Password...</label>
            <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required>
            </input>

            <button>
                Register
            </button>
            { isInvalid && <p>Invalid Data</p>}
        </form>
     );
}
 
export default Register;