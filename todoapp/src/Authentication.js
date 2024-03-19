import { useState } from "react";
import Login from "./Login";
import Register from "./Register";
import { GetCookie } from "./CookieHandler";

const Authentication = () => {
    var [isLogin, setIsLogin] = useState(true);
    
    const handleHeaderClick = () => {
        setIsLogin(!isLogin);
    }

    console.log(GetCookie());

    return ( 
        <div className="authentication">
            <div className="authentication-header">
                <button className = { isLogin ? 'selected' : '' }
                onClick = {handleHeaderClick }>Login</button>
                <button className = { !isLogin ? 'selected' : '' }
                onClick = { handleHeaderClick }>Register</button>
            </div>
            <div className="authentication-form">
                {isLogin ? <Login /> : <Register />}
            </div>
        </div>
     );

}
 
export default Authentication;