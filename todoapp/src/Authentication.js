import { useState } from "react";
import Login from "./Login";
import Register from "./Register";
import Navbar from "./Navbar";

const Authentication = () => {
    var [isLogin, setIsLogin] = useState(true);
    
    return ( 
        <>
        <Navbar />
        <div className="authentication">
            <div className="authentication-header">
                <button className = { isLogin ? 'selected' : '' }
                onClick = {() => setIsLogin(true) }>Login</button>
                <button className = { !isLogin ? 'selected' : '' }
                onClick = {() => setIsLogin(false) }>Register</button>
            </div>
            <div className="authentication-form">
                {isLogin ? <Login /> : <Register />}
            </div>
        </div>
        </>
     );

}
 
export default Authentication;