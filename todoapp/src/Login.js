const Login = () => {
    return (
        <form>
            <label>Username...</label>
            <input
            type="text"
            required>
            </input>
            <label>Password...</label>
            <input
            type="password"
            required>
            </input>
            <button>
                Login
            </button>
        </form>        
    );
}
 
export default Login;