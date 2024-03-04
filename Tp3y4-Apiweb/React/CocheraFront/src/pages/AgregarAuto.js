import React, { useState } from 'react';
import axios from 'axios';
import '../App.css'


export const AgregarAuto = ({upload}) => {
  const [auto, setAuto] = useState({
    marca: '',
    modelo: '',
    color: '',
    año: '',
    puerta: '',
  });
  const [mensaje, setMensaje] = useState('');
  const [mensajeTipo, setMensajeTipo] = useState('success'); // Agrega estado para manejar el tipo de mensaje
 

  const agregarAuto = async () => {
    try{
      const respuesta = await axios.post('https://localhost:7008/api/Autos/', auto);
      upload(respuesta.data);

      if (respuesta.status === 201) {
        setMensajeTipo('success'); // Establecer tipo de mensaje a éxito
        setMensaje('Agregado exitoso.');
        setTimeout(() => {
          setMensaje('');
        }, 3000); // Borra el mensaje después de 3 segundos
      }
    }
    catch {
      setMensajeTipo('error'); // Establecer tipo de mensaje a error
      setMensaje('Error al agregar.');
      setTimeout(() => {
        setMensaje('');
      }, 3000); // Borra el mensaje después de 3 segundos
    }
  };


  return (
  <div>
    <br></br>
    <h1 id='titulo-agregar'>Agregar Auto</h1>
    <div className="container">
      <div className='row'>
        <div className="col-md-6 offset-md-3 agregar">
          <div className={`notificacion ${mensajeTipo === 'success' ? 'success' : 'error'}`}>{mensaje}</div>
          <div className="card-body">
            <h5 className="card-title"> a ve</h5>
            <div id="card-content">
              <div className="mb-3">
                <label htmlFor="nombre" className="form-label">
                  Modelo
                </label>
                <input
                  type="text"
                  className="form-control"
                  name="razonSocial"
                  id="razonSocial"
                  placeholder="Ingrese Marca"
                  onChange={(e) => setAuto({ ...auto, modelo: e.target.value })}/>
              </div>
            </div>
          </div>

          <div className="card-body">
            <h5 className="card-title">ss</h5>
            <div id="card-content">
              <div className="mb-3">
                <label htmlFor="Marca" className="form-label">
                  Marca
                </label>
                <input
                  type="text"
                  className="form-control"
                  name="marca"
                  id="marca"
                  placeholder="Ingrese Marca"
                  onChange={(e) => setAuto({ ...auto, marca: e.target.value })}/>
              </div>
            </div>
          </div>
          
          <div className="card-body">
            <h5 className="card-title">we</h5>
            <div id="card-content">
              <div className="mb-3">
                <label htmlFor="Color" className="form-label">
                  Color
                </label>
                <input
                  type="text"
                  className="form-control"
                  name="color"
                  id="color"
                  placeholder="Ingrese color"
                  onChange={(e) => setAuto({ ...auto, color: e.target.value })}/>
              </div>
            </div>
          </div>



          <button className="btn btn-success" onClick={agregarAuto}>
            Agregar
          </button>
        </div>
      </div>
    </div>
    </div>
  );
};

export default AgregarAuto;
