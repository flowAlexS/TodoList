import { GetCookie } from "./CookieHandler";

const SetCompletion = async (todo) => {
    fetch(`/api/todos/${todo.id}`, {
        method: "PUT",
        headers: {
            "Accept": "*/*",
            "Authorization": `Bearer ${GetCookie().token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify(todo),
    })
    .then(res => res);
}

const DeleteTask = async (id) => {
    fetch(`/api/todos/${id}`, 
    {
        method: "DELETE",
        headers: {
            "Accept": "*/*",
            "Authorization": `Bearer ${GetCookie().token}`,
            "Content-Type": "application/json"
        },
    })
    .then(res => res);
}

const CreateTask = async (todo) => {
    fetch(`/api/todos/`, 
    {
        method: "POST",
        headers: {
            "Accept": "*/*",
            "Authorization": `Bearer ${GetCookie().token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify(todo),
    })
    .then(res => res.ok);
}

export { SetCompletion, DeleteTask, CreateTask };