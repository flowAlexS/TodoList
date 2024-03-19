import { useState } from "react";
import { SetCookie } from "./CookieHandler";

const Register = () => {
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
 
    const handleRegistration = (e) => {
        e.preventDefault();

        const registerModel = { userName, email, password }
        
        console.log(registerModel);

        fetch('api/account/register', {
            method: "POST",
            headers: {
                "Accept": "*/*",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(registerModel)
        })
        .then(res => {
            if (res.ok)
            {
                console.log(res.json());
                return res.json();
            }

            throw Error('Something went wrong');
            setUserName('');
            setEmail('');
            setPassword('');
        })
        .then(res => SetCookie(res))
        .catch(e => {
            console.log(e.message);
        });
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
        </form>
     );
}
 
export default Register;