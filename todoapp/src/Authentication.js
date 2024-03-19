import Login from "./Login";

const Authentication = () => {
    return ( 
        <div className="authentication">
            <div className="authentication-header">
                <button>Login</button>
                <button>Register</button>
            </div>
            <div className="authentication-form">
                <Login />
            </div>
        </div>
     );

}
 
export default Authentication;