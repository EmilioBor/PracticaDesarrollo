import React from 'react';
import { Routes, Route, Link, Navigate } from 'react-router-dom';
import Cabecera from './Cabecera';
import PieDePagina from './PieDePagina';
import VentanaMovimientos from './VentanaMovimientos';
import VentanaSaldo from './VentanaSaldo';
import Rectangulo from './Rectangulo';

const VentanaBotones = () => {
  const valorDolar = 100;
  const clima = 'Soleado';
  const datoAdicional = 'Sin demoras en las calles';

  const handleCerrarSesionClick = () => {
    // Lógica para manejar el clic en el botón de cerrar sesión
  };

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', minHeight: '100vh' }}>
      <Cabecera onCerrarSesion={handleCerrarSesionClick} />
      <Routes>
        <Route path="/movimientos" element={<VentanaMovimientos />} />
        <Route path="/saldo" element={<VentanaSaldo />} />
        <Route path="/" element={<Home />} />
        <Route path="*" element={<ErrorPage />} />
      </Routes>
      <PieDePagina valorDolar={valorDolar} clima={clima} datoAdicional={datoAdicional} />
    </div>
  );
};

const Home = () => (
  <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', minHeight: '100vh' }}>
    <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
      <Link to="/saldo" style={{ textDecoration: 'none' }}>
        <Rectangulo text="VER SALDO" />
      </Link>
      <Link to="/movimientos" style={{ textDecoration: 'none' }}>
        <Rectangulo text="VER MOVIMIENTOS" />
      </Link>
      <Rectangulo text="HACER TRANSFERENCIA" />
      <Rectangulo text="MI PERFIL" />
    </div>
  </div>
);

const ErrorPage = () => (
  <div>
    <h1>Página no encontrada</h1>
    <p>Lo sentimos, la página que intentaste acceder no existe.</p>
    <Link to="/">Volver a la página de inicio</Link>
  </div>
);

export default VentanaBotones;