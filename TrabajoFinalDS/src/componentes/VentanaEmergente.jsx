import React, { useState } from 'react';
import { Navigate } from 'react-router-dom';

const VentanaEmergente = ({ onIniciarSesion, onCancel }) => {
  const [dni, setDni] = useState('');
  const [redirectToBotones, setRedirectToBotones] = useState(false);

  const handleIniciarSesionClick = () => {
    if (dni.trim() !== '') {
      onIniciarSesion(dni);
      // Establece redirectToBotones en true para activar la redirección
      setRedirectToBotones(true);
    }
  };

  const handleCancelarClick = (event) => {
    event.preventDefault();
    setDni('');
    onCancel(); // Llama a la función para cancelar la ventana emergente
  };

  // Si redirectToBotones es true, redirige a VentanaBotones
  if (redirectToBotones) {
    return <Navigate to="/VentanaBotones" />;
  }

  return (
    <div style={{ position: 'fixed', top: 0, left: 0, width: '100%', height: '100%', backgroundColor: 'rgba(0, 0, 0, 0.5)', display: 'flex', justifyContent: 'center', alignItems: 'center', zIndex: '9999' }}>
      <div style={{ backgroundColor: 'white', padding: '40px', borderRadius: '10px', textAlign: 'center', boxShadow: '0px 0px 10px 0px rgba(0,0,0,0.5)' }}>
        <h2 style={{ margin: '0 0 20px' }}>INGRESAR DNI</h2>
        <input type="text" value={dni} onChange={(e) => setDni(e.target.value)} placeholder="Ingrese su DNI" style={{ marginBottom: '20px', width: '100%', padding: '10px', boxSizing: 'border-box', borderRadius: '5px', border: '1px solid #ccc' }} />
        <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
          <button onClick={handleIniciarSesionClick} style={{ padding: '10px 20px', backgroundColor: 'purple', color: 'white', border: 'none', borderRadius: '5px', cursor: 'pointer', marginBottom: '10px' }}>INICIAR SESIÓN</button>
          <button onClick={handleCancelarClick} style={{ textDecoration: 'none', color: 'blue', cursor: 'pointer', border: 'none' }}>Cancelar</button>
        </div>
      </div>
    </div>
  );
};

export default VentanaEmergente;