import { useEffect, useState } from "react";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import { GetCookie } from "./CookieHandler";

const Todo = () => {
    const { id } = useParams();
    const [data, setData] = useState(null);
    const [isChanged, setIsChanged] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const auth = GetCookie();
                const response = await fetch(`api/todos/${id}`, {
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

    return (
        <section class="single_todo">
            { data &&
            <>
                <div className="single_todo--content" key={ data.id } >
                    <textarea
                        rows={1}
                        id="todoTitle"
                        value={data.title}>
                    </textarea>
                    <textarea
                        rows={10}
                        id="todoContent"
                        value={data.note}>
                        
                    </textarea>
                </div>
                <div className="single_todo--operations">
                    <button>Complete</button>
                    <button>Update</button>
                    <button>Delete</button>
                </div>
            </>}
        </section>
    );
}
 
export default Todo;