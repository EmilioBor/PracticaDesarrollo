// import React from 'react';

// const Movimiento = ({ fecha, numeroCuenta, movimientos }) => {
//   return (
//     <div
//       style={{
//         backgroundColor: 'white',
//         color: 'black',
//         borderRadius: '15px',
//         border: '2px solid purple',
//         padding: '20px',
//         textAlign: 'center',
//         width: '300px',
//         fontFamily: 'Arial, sans-serif',
//         fontSize: '1.2em',
//         fontWeight: 'bold',
//         marginBottom: '20px',
//       }}
//     >
//       <div>{fecha}</div>
//       <div style={{ marginTop: '10px', marginBottom: '10px' }}>Número de cuenta: {numeroCuenta}</div>
//       <div style={{ marginBottom: '10px' }}><strong>Movimientos</strong></div>
//       <ul style={{ listStyleType: 'none', padding: 0 }}>
//         {movimientos?.map((movimiento, index) => ( // Utiliza el operador de encadenamiento opcional (?.) para verificar si movimientos es undefined
//           <li key={index}>{movimiento}</li>
//         ))}
//       </ul>
//     </div>
//   );
// };

// export default Movimiento;

// -------------------------------------------------------------------------------------------------
import React, { useEffect, useState } from "react";
import axios from "axios";

const Movimiento = ({ fecha, numeroCuenta, movimientos, apiData }) => {
  // ----------------------------------------------------------------
  const [transacciones, setTransacciones] = useState([]);

  useEffect(() => {
    axios
      .get("URL")
      .then((response) => {
        setTransacciones(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [apiData]);
  // ----------------------------------------------------------------
  // ----------------------------------------------------------------

  return (
    <div
      style={{
        backgroundColor: "white",
        color: "black",
        borderRadius: "15px",
        border: "2px solid purple",
        padding: "20px",
        textAlign: "center",
        width: "300px",
        fontFamily: "Arial, sans-serif",
        fontSize: "1.2em",
        fontWeight: "bold",
        marginBottom: "20px",
      }}
    >
      <div>{fecha}</div>
      <div style={{ marginTop: "10px", marginBottom: "10px" }}>
        Número de cuenta: {numeroCuenta}
      </div>
      <div style={{ marginBottom: "10px" }}>
        <strong>Movimientos</strong>
      </div>
      <ul style={{ listStyleType: "none", padding: 0 }}>
        {movimientos?.map(
          (
            movimiento,
            index // Utiliza el operador de encadenamiento opcional (?.) para verificar si movimientos es undefined
          ) => (
            <li key={index}>{movimiento}</li>
          )
        )}
      </ul>
      <div></div>
      {/* ---------------------------------------------------------------- */}
      <div className="lista">
        <h2 id="lista-titulo">Lista de transacciones</h2>
        {
          <table className="table table-hover table-dark">
            <thead>
              <tr>
                <th scope="col">ID</th>
                <th scope="col">Monto</th>
                <th scope="col">FechaHora</th>
                <th scope="col">Tipo Transaccion</th>
                <th scope="col">Validacion Estado</th>
                <th scope="col">Aceptado Estado</th>
                <th scope="col">Cuenta Origen</th>
                <th scope="col">Cuenta Destino</th>
                <th scope="col">Registroestado</th>
              </tr>
            </thead>
            <tbody className="Tabla">
              {transacciones?.map((transaccion) => (
                <tr key={transaccion.id}>
                  <td>{transaccion.id}</td>
                  <td>{transaccion.monto}</td>
                  <td>{transaccion.fechaHora}</td>
                  <td>{transaccion.idTipo}</td>
                  <td>{transaccion.idValidacionEstado}</td>
                  {/* <td>{transaccion.idAceptadoEstado}</td> */}
                  <td>{transaccion.idAceptadoEstado}</td>
                  <td>{transaccion.idCuentaOrigen}</td>
                  <td>{transaccion.idCuentaDestino}</td>
                  <td>{transaccion.registroEstado}</td>
                </tr>
              ))}
            </tbody>
          </table>
        }
      </div>
    </div>
  );
};

export default Movimiento;
