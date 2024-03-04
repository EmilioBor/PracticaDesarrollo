import React from 'react';
import { Link } from 'react-router-dom'; // Importa Link de react-router-dom
import Saldo from './Saldo';
import Cabecera from './Cabecera';
import PieDePagina from './PieDePagina';
import BotonRegresar from './BotonRegresar'; // Importa tu componente BotonRegresar
import BotonConsultarMovimientos from './BotonConsultarMovimientos';

const VentanaSaldo = () => {
  const saldo = 10000;
  const valorDolar = 100;
  const clima = 'Soleado';
  const datoAdicional = 'Sin demoras en las calles';

  const handleCerrarSesionClick = () => {
    // Lógica para manejar el clic en el botón de cerrar sesión
  };

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', minHeight: '100vh' }}>
      <Cabecera onCerrarSesion={handleCerrarSesionClick} />
      <div style={{ marginTop: '20px' }}>
        <Saldo saldo={saldo} />
      </div>
      <div style={{ marginTop: '20px' }}>
        {/* Utiliza Link para crear un enlace hacia la página principal */}
        <Link to="/" style={{ textDecoration: 'none' }}>
          {/* Usa tu componente BotonRegresar */}
          <BotonRegresar />
        </Link>
      </div>
      <div style={{ marginTop: '20px' }}>
        {/* Utiliza Link para crear un enlace hacia la página principal */}
        <Link to="/Movimientos" style={{ textDecoration: 'none' }}>
          {/* Usa tu componente BotonRegresar */}
          <BotonConsultarMovimientos />
        </Link>
      </div>
      <PieDePagina valorDolar={valorDolar} clima={clima} datoAdicional={datoAdicional} />
    </div>
  );
};

export default VentanaSaldo;