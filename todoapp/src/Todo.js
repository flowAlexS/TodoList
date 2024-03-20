import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom/cjs/react-router-dom.min";
import { GetCookie } from "./CookieHandler";
import { SetCompletion, DeleteTask } from "./TodoHandler";

const Todo = () => {
    const { id } = useParams();
    const [data, setData] = useState(null);
    const [isChanged, setIsChanged] = useState(false);
    const [title, setTitle] = useState('');
    const [note, setNote] = useState('');
    const [updated, setUpdated] = useState(false);
    const history = useHistory();

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

                setTitle(responseData.title);
                setNote(responseData.note);
            } catch (error) {
                console.error(error.message);
            }
        };

        fetchData();
    }, []);

    const handleComplete = async () => {
        let todo = data;
        todo.completed = !todo.completed;

        await SetCompletion(todo);
        window.location.reload();
    }

    const handleUpdate = async () => {
        let todo = { 'id':data.id, title, note, "completed":data.completed }
        await SetCompletion(todo);
        setUpdated(true);
        setInterval(() => setUpdated(false), 3000);
    }

    const handleDelete = async () => {
        await DeleteTask(data.id);
        history.push('/');
    }

    return (
        <section class="single_todo">
            { updated && <p>Task Updated</p>}
            { data &&
            <>
                <div className="single_todo--content" key={ data.id } >
                    <textarea
                        rows={1}
                        id="todoTitle"
                        value={title}
                        onChange={(e) => {
                            setTitle(e.target.value);
                            setIsChanged(true);
                        }}>
                    </textarea>
                    <textarea
                        rows={10}
                        id="todoContent"
                        value={note}
                        onChange={(e) =>{
                            setNote(e.target.value);
                            setIsChanged(true);
                        }}>
                        
                    </textarea>
                </div>
                <div className="single_todo--operations">
                    <button
                    className={data.completed && "done"}
                    onClick={handleComplete}
                    >{data.completed ? 'Done' : 'Not Done'}</button>
                    {
                        isChanged ? <button
                        onClick={handleUpdate}>Update</button>
                        : <button className="disabled" disabled>Update</button>
                    }
                    <button
                    onClick={handleDelete}>Delete</button>
                </div>
            </>}
        </section>
    );
}
 
export default Todo;