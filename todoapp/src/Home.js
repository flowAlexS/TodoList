import { useState, useEffect } from "react";
import { GetCookie } from "./CookieHandler";
import Authentication from "./Authentication";
import AuthorizedSection from "./AuthorizedSection";

const Home = () => {
    const [data, setData] = useState(null);

    var auth = GetCookie();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const auth = GetCookie();
                const response = await fetch('api/todos', {
                    method: "GET",
                    headers: {
                        "Accept": "*/*",
                        "Authorization": `Bearer ${auth.token}`,
                        "Content-Type": "application/json"
                    }
                });

                if (!response.ok) {
                    throw new Error("Network response was not ok.");
                }

                const responseData = await response.json();
                setData(responseData);
            } catch (error) {
                console.error(error.message);
            }
        };

        fetchData();
    }, []);

    return ( <>
        {data ? <AuthorizedSection data={ data }/> : <Authentication />}
    </>
    )
}
 
export default Home;