import { Route, Routes } from 'react-router-dom';
import ListaAutos from './pages/ListaAutos';
import ListaCochera from './pages/ListaCochera';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from "react";
import './App.css';
import Layout from './pages/Layout';
import Inicio from './pages/Inicio';
import AgregarAuto from './pages/AgregarAuto';



function App() {
  const [apiData, setApiData] = useState([]);
  const handleDataUpload = (data) => {
    // Esta función se llama cuando se cargan datos en la API
    // Aquí puedes realizar cualquier acción adicional si es necesario
    // Luego, actualiza el estado apiData para desencadenar la recarga de la tabla.
    setApiData([...apiData, data]);
  };

  return (
    <div >
      <h1>Routes</h1>
      <Routes>
        <Route path="/" element={<Layout/>}>

          <Route path='/' element={<Inicio/>}></Route>
          <Route path='ListaAutos' element={<ListaAutos/>}></Route>
          <Route path='AgregarAuto' element={<AgregarAuto upload={handleDataUpload}/>}></Route>
          <Route path='ListaCochera' element={<ListaCochera apiData={apiData}/>}></Route>
          {/* <Route path='*' element={Default}></Route> */}

        </Route>
      </Routes>
    </div>
  );
}

export default App;
