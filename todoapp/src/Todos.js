import { Link } from "react-router-dom/cjs/react-router-dom.min";
import { GetCookie } from "./CookieHandler";

const Todos = ({ data }) => {
    const handleCompletion = (todo) => {
        todo.completed = !todo.completed;

        fetch(`/api/todos/${todo.id}`, {
            method: "PUT",
            headers: {
                "Accept": "*/*",
                "Authorization": `Bearer ${GetCookie().token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(todo),
        })
        .then(() => {
            window.location.reload();
        });
    }

    return (
        <>
            { 
                data.map(todo => (
                    <section className={todo.completed ? "todo--section todo--section__completed" : "todo--section todo--section__dark"}
                    key= { todo.id }>
                        <Link to={ `/${todo.id}` }>
                            <div class="todo--header">
                                <h2>{ todo.title }</h2>
                                <p> { todo.note } </p>
                            </div>
                        </Link>
                        <div className="todo--commands">
                            <button
                            onClick={(e) => handleCompletion(todo)}>{todo.completed ? "Uncomplete" : "Complete"}</button>
                        </div>
                    </section>
                ))};
        </>
    );
}
 
export default Todos;