import React from 'react';

const Cabecera = ({ onCerrarSesion, buttonText, showButton, onIniciarSesion }) => {
  return (
    <div style={{ width: '100%', backgroundColor: 'purple', color: 'white', display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '10px 20px', position: 'fixed', top: 0 }}>
      <div style={{ fontWeight: 'bold', paddingLeft: '20px' }}>Banco Zarpado</div>
      {showButton && <div style={{ textDecoration: 'underline', cursor: 'pointer', paddingRight: '50px' }} onClick={onIniciarSesion}>{buttonText}</div>}
    </div>
  );
};

export default Cabecera;