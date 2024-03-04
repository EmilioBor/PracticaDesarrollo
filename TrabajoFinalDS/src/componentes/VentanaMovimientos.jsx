import React from 'react';
import Movimiento from './Movimientos';
import Cabecera from './Cabecera';
import PieDePagina from './PieDePagina';
import BotonRegresar from './BotonRegresar';
import { Link } from 'react-router-dom';

const VentanaMovimientos = () => {
  const fecha = new Date().toLocaleDateString();
  const numeroCuenta = '1234567890'; // Ejemplo de número de cuenta
  const movimientos = ['Compra en el supermercado', 'Retiro de dinero en cajero automático', 'Pago de factura de luz']; // Ejemplo de lista de movimientos
  const handleCerrarSesionClick = () => {
    // Lógica para manejar el clic en el botón de cerrar sesión
  };
  const valorDolar = 100;
  const clima = 'Soleado';
  const datoAdicional = 'Sin demoras en las calles';

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', minHeight: '100vh' }}>
      <Cabecera onCerrarSesion={handleCerrarSesionClick} />
      <div style={{ marginTop: '20px' }}>
        <Movimiento fecha={fecha} numeroCuenta={numeroCuenta} movimientos={movimientos} />
      </div>
      <div style={{ marginTop: '20px' }}>
        {/* Utiliza Link para crear un enlace hacia la página principal */}
        <Link to="/" style={{ textDecoration: 'none' }}>
          {/* Usa tu componente BotonRegresar */}
          <BotonRegresar />
        </Link>
        </div>
      <PieDePagina valorDolar={valorDolar} clima={clima} datoAdicional={datoAdicional} />
    </div>
  );
};

export default VentanaMovimientos;