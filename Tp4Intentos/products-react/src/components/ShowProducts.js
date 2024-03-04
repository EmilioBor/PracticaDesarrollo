import axios from 'axios';

import React, { useEffect, useState } from 'react'


const TableWithApiData = () => {
    const [data, setData] = useState([]);
    const [modalData, setModalData] = useState({
        // Estado para manejar los datos del modal
        id: null,
        marca: '',
        modelo: '',
        color: '',
        año: '',
        puerta: '',
      });
   
    
      const [modalVisible, setModalVisible] = useState(false);

      const mostrarModal = (product) => {
        setModalData(product);
        setModalVisible(true); 
      };
      const cerrarModal = () => {
        setModalData({
          id: null,
          marca: '',
          modelo: '',
          color: '',
          año: '',
          puerta: '',
        });
        setModalVisible(false); // Cierra el modal
        // También puedes cerrar el modal aquí si es necesario
      };
      const enviarDatos = async () => {
        try {
          // Realizar la solicitud PUT aquí con Axios para actualizar el producto
          // Utiliza el endpoint adecuado de tu API y el objeto modalData
          const response = await axios.put(`https://localhost:7105/IAutoRepository/${modalData.id}`, modalData);
          console.log('Respuesta del servidor:', response.data);
          cerrarModal();
          // Actualiza la lista de datos después de realizar la actualización
          // Puedes hacer esto llamando a la API nuevamente o actualizando el estado de alguna manera
        } catch (error) {
          console.error('Error al enviar datos:', error);
        }
      };


    //Utilizamos el gancho useStatepara crear una variable de estado dataque almacenará los datos de la API. 
    //setDataes una función que usaremos para actualizar esta variable de estado.
  
    useEffect(() => { //para realizar efectos secundarios en nuestro componente. 
      // Hacer la petición a la API
      axios.get('https://localhost:7105/api/IAutoRepository')
        .then(response => {
          // Almacenar los datos en el estado
          setData(response.data);
        })
        .catch(error => {
          console.error('Error fetching data:', error);
        });
    }, []);

// const mostrar = () => {
//     console.log("hola");
// }
  return (
    <div>
    <div>
          {/* <div className='App'>
              <div className='container-fluid'>
                  <div className='row mt-3'>
                      <div className='col-md-4 offset-md-4'>
                          <div className='d-grid mx-auto'>
                              <button className='btn btn-dark' data-bs-toggle='modal' data-bs-target='#modalProducts'>
                                  <i className='fa-solid fa-circle-plus'>hola</i>
                              </button>
                          </div>
                      </div>
                  </div>
              </div>
          </div> */}
          <div className='modal fade'>
              <table className="table table-dark table-striped">
                  <thead>
                      <tr>
                          <th scope="col">#</th>
                          <th scope="col">Marca</th>
                          <th scope="col">Modelo</th>
                          <th scope="col">Color</th>
                          <th scope="col">Año</th>
                          <th scope="col">Puerta</th>
                          <th scope="col">Modificaicones</th>
                      </tr>
                  </thead>
                  <tbody className='table-group-divider' >
                      {data?.map(products => (
                          <tr key={products.id}>
                              <td>{products.id}</td>
                              <td>{products.marca}</td>
                              <td>{products.modelo}</td>
                              <td>{products.color}</td>
                              <td>{products.año}</td>
                              <td>{products.puerta}</td>
                              
                              <td>
                                  <button className='btn btn-warning'>
                                      <i onClick={() => mostrarModal({ id: null, marca: '', modelo: '', color: '', año: '', puerta: '' })}></i>
                                  </button>
                                  &nbsp;
                                  <button className='btn btn-danger'>
                                      <i className='fa-solid fa-trash'></i>
                                  </button>

                              </td>
                          </tr>
                      ))}
                  </tbody>
              </table>
          </div>
      </div>
      {/* --------------------------------------------------------------------------------------------------------------------------------------------- */}
      <div className={`modal fade ${modalVisible ? 'show' : ''}`} id='modalProducts' tabIndex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true' style={{ display: modalVisible ? 'block' : 'none' }}>
      <div className='App'>
        <div className='container-fluid'>
          <div className='row mt-3'>
            <div className='col-md-4 offset-md-4'>
              <div className='d-grid mx-auto'>
              <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
            Launch demo modal
            </button>
                {/* <button
                  className='btn btn-dark'
                  data-bs-toggle='modal'
                  data-bs-target='#modalProducts'
                  onClick={() => mostrarModal({ id: null, marca: '', modelo: '', color: '', año: '', puerta: '' })}
                >
                  <i className='fa-solid fa-circle-plus'>Añadir</i>
                </button> */}
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className='modal fade' id='modalProducts' tabIndex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>
        <div className='modal-dialog'>
          <div className='modal-content'>
            <div className='modal-header'>
              <h5 className='modal-title' id='exampleModalLabel'>
                Detalles del Producto
              </h5>
              <button type='button' className='btn-close' data-bs-dismiss='modal' aria-label='Close' onClick={cerrarModal}></button>
            </div>
            <div className='modal-body'>
              <form>
                {/* Agrega campos de formulario para cada propiedad del producto */}
                <div className='mb-3'>
                  <label htmlFor='marca' className='form-label'>
                    Marca
                  </label>
                  <input
                    type='text'
                    className='form-control'
                    id='marca'
                    value={modalData.marca}
                    onChange={(e) => setModalData({ ...modalData, marca: e.target.value })}
                  />
                </div>
                <div className='mb-3'>
                  {/* Repite estos bloques para cada propiedad del producto */}
                  <label htmlFor='modelo' className='form-label'>
                    Modelo
                  </label>
                  <input
                    type='text'
                    className='form-control'
                    id='modelo'
                    value={modalData.modelo}
                    onChange={(e) => setModalData({ ...modalData, modelo: e.target.value })}
                  />
                </div>
                <div className='mb-3'>
                  {/* Repite estos bloques para cada propiedad del producto */}
                  <label htmlFor='modelo' className='form-label'>
                    Color
                  </label>
                  <input
                    type='text'
                    className='form-control'
                    id='modelo'
                    value={modalData.color}
                    onChange={(e) => setModalData({ ...modalData, color: e.target.value })}
                  />
                </div>
                <div className='mb-3'>
                  {/* Repite estos bloques para cada propiedad del producto */}
                  <label htmlFor='modelo' className='form-label'>
                    Año
                  </label>
                  <input
                    type='text'
                    className='form-control'
                    id='modelo'
                    value={modalData.año}
                    onChange={(e) => setModalData({ ...modalData, año: e.target.value })}
                  />
                </div>
                <div className='mb-3'>
                  {/* Repite estos bloques para cada propiedad del producto */}
                  <label htmlFor='modelo' className='form-label'>
                    Puerta
                  </label>
                  <input
                    type='text'
                    className='form-control'
                    id='modelo'
                    value={modalData.puerta}
                    onChange={(e) => setModalData({ ...modalData, puerta: e.target.value })}
                  />
                </div>

                <button type='button' className='btn btn-primary' onClick={enviarDatos}>
                  Guardar Cambios
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>

      <div>
        <table className='table table-dark table-striped'>
          {/* Resto del código de la tabla */}
        </table>
      </div>
    </div>
      {/* --------------------------------------------------------------------------------------------------------------------------------------------- */}


      <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                ...
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
            </div>
            </div>
        </div>
    </div>
      {/* --------------------------------------------------------------------------------------------------------------------------------------------- */}
      {/* --------------------------------------------------------------------------------------------------------------------------------------------- */}
      {/* --------------------------------------------------------------------------------------------------------------------------------------------- */}
        {/* <div className='modal fade' aria-hidden='true'>
            <div className='modal-dialog'>
                <div className='modal-content'>
                    <div className='modal-header'>
                        <label className='h5'></label>
                        <button type='button' className='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>
                    </div>
                    <div>
                        <input type='hidden' id='id'> </input>
                        <div className='input-group mb-3'>
                            <span className='input-group-text'> <i className='fa- solid fa-gift'></i></span>
                            <input type='text' id='marca' className='form-control' placeholder='Marca' value={data.marca} onChange={(e) => setData(e.target.value)}></input>
                        </div>
                        <div className='input-group mb-3'>
                            <span className='input-group-text'> <i className='fa- solid fa-comment'></i></span>
                            <input type='text' id='Modelo' className='form-control' placeholder='Modelo' value={data.modelo} onChange={(e) => setData(e.target.value)}></input>
                        </div>
                        <div className='input-group mb-3'>
                            <span className='input-group-text'> <i className='fa- solid fa-comment'></i></span>
                            <input type='text' id='Color' className='form-control' placeholder='Color' value={data.color} onChange={(e) => setData(e.target.value)}></input>
                        </div>
                        <div className='input-group mb-3'>
                            <span className='input-group-text'> <i className='fa- solid fa-comment'></i></span>
                            <input type='text' id='año' className='form-control' placeholder='Año' value={data.año} onChange={(e) => setData(e.target.value)}></input>
                        </div>
                        <div className='input-group mb-3'>
                            <span className='input-group-text'> <i className='fa- solid fa-comment'></i></span>
                            <input type='text' id='puerta' className='form-control' placeholder='Puerta' value={data.puerta} onChange={(e) => setData(e.target.value)}></input>
                        </div>
                    </div>
                </div>
            </div>
        </div> */}
     
    </div>


  )
} 

export default TableWithApiData