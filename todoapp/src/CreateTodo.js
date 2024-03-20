import { useState } from "react";
import { CreateTask } from "./TodoHandler";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

const CreateTodo = () => {
    const [title, setTitle] = useState('');
    const [note, setNote] = useState('');
    const history = useHistory();

    const handleCreate = (e) => {
        e.preventDefault();
        let todo = { title, note, "completed": false };
        var res = CreateTask(todo);
        console.log(res);
        history.push('/');
    }

    return (
        <section className="single_todo">
            <form onSubmit={handleCreate}>
                <textarea
                    rows={1}
                    id="todoTitle"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}>
                </textarea>

                <textarea
                    rows={10}
                    className="textarea__bordered"
                    id="todoContent"
                    value={note}
                    onChange={(e) => setNote(e.target.value)}>
                </textarea>

                <button>
                    Create
                </button>
            </form>
        </section>
     );
}
 
export default CreateTodo;