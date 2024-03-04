import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  Navigate,
} from "react-router-dom";
import Cabecera from "./componentes/Cabecera";
import PieDePagina from "./componentes/PieDePagina";
import VentanaMovimientos from "./componentes/VentanaMovimientos";
import VentanaSaldo from "./componentes/VentanaSaldo";
import Rectangulo from "./componentes/Rectangulo";
import { useState } from "react";

function App() {
  // ---------------------------------------------------
  const [apiData, setApiData] = useState([]);
  const handleDataUpload = (data) => {
    setApiData([...apiData, data]);
  };
  // ---------------------------------------------------

  const valorDolar = 100;
  const clima = "Soleado";
  const datoAdicional = "Sin demoras en las calles";

  const handleCerrarSesionClick = () => {
    // Lógica para manejar el clic en el botón de cerrar sesión
  };

  return (
    <Router>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          minHeight: "100vh",
        }}
      >
        <Cabecera onCerrarSesion={handleCerrarSesionClick} />
        <Routes>
          <Route
            path="/movimientos"
            element={<VentanaMovimientos apiData={apiData} />}
          />
          <Route path="/saldo" element={<VentanaSaldo />} />{" "}
          {/* Agrega la ruta para VentanaSaldo */}
          <Route path="/" element={<Home />} />
          <Route path="*" element={<Navigate to="/" />} />
        </Routes>
        <PieDePagina
          valorDolar={valorDolar}
          clima={clima}
          datoAdicional={datoAdicional}
        />
      </div>
    </Router>
  );
}

const Home = () => (
  <div
    style={{
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
      justifyContent: "center",
      minHeight: "100vh",
    }}
  >
    <div
      style={{
        display: "flex",
        flexWrap: "wrap",
        justifyContent: "center",
        alignItems: "center",
        width: "100%",
      }}
    >
      <Link to="/saldo" style={{ textDecoration: "none" }}>
        <Rectangulo text="VER SALDO" />
      </Link>
      <Link to="/movimientos" style={{ textDecoration: "none" }}>
        <Rectangulo text="VER MOVIMIENTOS" />
      </Link>
      <Rectangulo text="HACER TRANSFERENCIA" />
      <Rectangulo text="MI PERFIL" />
    </div>
  </div>
);

export default App;

// import React, { useState } from 'react';
// import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
// import Cabecera from './componentes/Cabecera';
// import PieDePagina from './componentes/PieDePagina';
// import VentanaEmergente from './componentes/VentanaEmergente';
// import VentanaBotones from './componentes/VentanaBotones';

// const App = () => {
//   const [isLoggedIn, setIsLoggedIn] = useState(false);
//   const [mostrarVentanaEmergente, setMostrarVentanaEmergente] = useState(false);

//   const valorDolar = 100;
//   const clima = 'Soleado';
//   const datoAdicional = 'Sin demoras en las calles';

//   const handleCerrarSesionClick = () => {
//     // Lógica para manejar el clic en el botón de cerrar sesión
//   };

//   const handleIniciarSesionClick = (dni) => {
//     setIsLoggedIn(true);
//     setMostrarVentanaEmergente(false);
//     return <Link to="/componentes/VentanaBotones" />;
//   };

//   const handleCancelarVentanaEmergente = () => {
//     setMostrarVentanaEmergente(false); // Ocultar la ventana emergente
//   };

//   return (
//     <Router>
//       <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', minHeight: '100vh' }}>
//         <Cabecera onCerrarSesion={handleCerrarSesionClick} buttonText={isLoggedIn ? "CERRAR SESIÓN" : "INICIAR SESIÓN"} showButton={!isLoggedIn} onIniciarSesion={() => setMostrarVentanaEmergente(true)} />
//         <Routes>
//           <Route path="/VentanaBotones" element={<VentanaBotones />} />
//         </Routes>
//         <PieDePagina valorDolar={valorDolar} clima={clima} datoAdicional={datoAdicional} />
//         {mostrarVentanaEmergente && <VentanaEmergente onIniciarSesion={handleIniciarSesionClick} onCancel={handleCancelarVentanaEmergente} />}
//       </div>
//     </Router>
//   );
// };

// export default App;
