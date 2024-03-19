import { useState, useEffect } from "react";
import { GetCookie } from "./CookieHandler";
import Todos from "./Todos";
import Authentication from "./Authentication";

const Home = () => {
    const [data, setData] = useState(null);

    var auth = GetCookie();
    console.log(auth);

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
        {data ? <Todos data={ data }/> : <Authentication />}
    </>
    )
}
 
export default Home;