import AuthorizedNavbar from "./AuthorizedNavbar";
import Todos from "./Todos";

const AuthorizedSection = ({ data }) => {
    // Route to the spefici area...

    return (
        <>
            <AuthorizedNavbar /> 
            <Todos data={data} />
        </>  
    );
}
 
export default AuthorizedSection;