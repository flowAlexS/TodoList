const Todos = ({ data }) => {
    console.log(data);


    return (
        <>
            <nav className="navbar">
                <a href="/">Todo app</a>
                <div className="nav-list">
                    <li className="nav__list">
                        <a className href="/">View All</a>
                        <a className href="/">Create Task</a>
                    </li>
                </div>
            </nav>
            { 
                data.map(todo => (
                    <a href="/">
                        <section className={todo.completed ? "todo--section todo--section__completed" : "todo--section todo--section__dark"} key={todo.id}>
                            <div class="todo--header">
                                <h2>{ todo.title }</h2>
                                <p> { todo.note } </p>
                            </div>
                            <div className="todo--commands">
                                <button className={todo.completed ? "completed" : ""}>{todo.completed ? "Uncomplete" : "Complete"}</button>
                            </div>
                        </section>
                    </a>
                ))};
        </>
    );
}
 
export default Todos;