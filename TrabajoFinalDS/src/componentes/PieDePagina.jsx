import React from 'react';

const PieDePagina = ({ valorDolar, clima, datoAdicional }) => {
  const texto = `Valor del dólar: ${valorDolar} - Clima en La Plata: ${clima} - ${datoAdicional}`;

  return (
    <div style={{ backgroundColor: '#f5f5f5', color: '#333', textAlign: 'center', padding: '20px', position: 'fixed', bottom: 0, width: '100%', fontFamily: 'Arial, sans-serif', fontSize: '14px' }}>
      {texto}
    </div>
  );
};

export default PieDePagina;