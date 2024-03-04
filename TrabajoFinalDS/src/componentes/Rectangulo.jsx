import React from 'react';

const Rectangulo = ({ text }) => {
  const words = text.split(' ');
  return (
    <div
      style={{
        backgroundColor: 'purple',
        color: 'white',
        borderRadius: '15px',
        border: '2px solid black',
        padding: '20px',
        margin: '20px',
        textAlign: 'center',
        width: '300px',
        height: '100px',
        cursor: 'pointer',
        fontSize: '1.5em',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center', // Alinea los elementos horizontalmente
        fontFamily: 'Arial, sans-serif',
        fontWeight: 'bold',
      }}
    >
      {words.map((word, index) => (
        <div key={index}>{word}</div>
      ))}
    </div>
  );
};

export default Rectangulo;