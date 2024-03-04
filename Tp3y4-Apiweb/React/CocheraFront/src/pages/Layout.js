import { Link, Outlet } from "react-router-dom"

const Layout = () =>{
    return <div>
                <nav>
                <ul>
                    <li>
                        <Link to ="/">Inicio</Link>
                    </li>
                </ul>
                <ul>
                    <li>
                        <Link to ="/ListaAutos">Lista Autos</Link>
                    </li>
                </ul>
                    
                <ul>
                    <li>
                        <Link to ="/ListaCochera">Lista Cocheras</Link>
                    </li>
                </ul>
            </nav>
        <hr/>
        <Outlet/>
    </div>
}

export default Layout; 