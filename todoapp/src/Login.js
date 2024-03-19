import { useState } from "react";

const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [isInvalid, setIsInvalid] = useState(false);

    const handleRegister = (e) => {
        const loginModel = { userName, password }

        fetch('api/account/login',
        {
            method: "POST",
            headers: {
                "Accept": "*/*",
                "Content-Type" : "application/json"
            },
            body: JSON.stringify(loginModel)
        })
        .then(res => {
            if (res.ok)
            {
                return res.json();
            }

            setPassword('');
            setUserName('');
            setIsInvalid(true);
            throw Error("Username or passwword incorrect");
        })
        .then(res => console.log(res))
        .catch(e => console.log(e.message));


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
        </form>        
    );
}
 
export default Login;