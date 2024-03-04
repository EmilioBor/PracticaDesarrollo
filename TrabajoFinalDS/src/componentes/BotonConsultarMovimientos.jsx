import React from 'react';

const BotonConsultarMovimientos = ({ onClick }) => {
  return (
    <button
      style={{
        backgroundColor: 'purple',
        color: 'white',
        border: 'none',
        borderRadius: '5px',
        padding: '10px 20px',
        fontSize: '1em',
        fontWeight: 'bold',
        cursor: 'pointer',
        marginTop: '10px',
      }}
      onClick={onClick}
    >
      CONSULTAR MOVIMIENTOS
    </button>
  );
};

export default BotonConsultarMovimientos;