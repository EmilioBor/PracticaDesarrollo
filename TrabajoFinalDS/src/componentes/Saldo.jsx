import React from 'react';

const Saldo = ({ saldo }) => {
  return (
    <div
      style={{
        backgroundColor: 'white',
        color: 'black',
        borderRadius: '15px',
        border: '2px solid purple',
        padding: '20px',
        textAlign: 'center',
        width: '300px',
        fontFamily: 'Arial, sans-serif',
        fontSize: '1.5em',
        fontWeight: 'bold',
      }}
    >
      <div>SALDO</div>
      <div style={{ marginTop: '20px' }}>Tu saldo actual es de:</div>
      <div style={{ fontSize: '2em', marginTop: '20px' }}>${saldo}</div>
    </div>
  );
};

export default Saldo;