import { useEffect, useState } from "react";
import axios from 'axios';

export const ListarCocheras = ({ apiData }) => {
  const [ cocheras, setCochera ] = useState([]);
  const [ id , setId ] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);


  

    const buscarCochera =  () => {
        axios.get(`https://localhost:7008/buscarPorID/${id}`)
        .then((response) => {
            setCochera([response.data]); // Considerando que la respuesta es un objeto
        })
        .catch((error) => {
            console.error(error);
        });
    };

    useEffect(() => {
        axios.get('https://localhost:7008/api/Cochera/listar')
          .then((cochera) => {
            setCochera(cochera.data);
          })
          .catch((error) => {
            console.error(error);
            setError("Hubo un error al cargar las cocheras");
          })
          .finally(() => {
            setLoading(false);
          });
      }, [apiData]);

      if (loading) {
        return <p>Cargando...</p>;
      }
      
      if (error) {
        return <p>{error}</p>;
      }








  return (
    <div>
        <h2>Registros de la transacción seleccionada</h2>
      <input
        type="text"
        value={id}
        onChange={(e) => setId(e.target.value)}
        placeholder="id"
      />
      <button
        className="btn btn-info"
        onClick={() => buscarCochera()}
      >
        Obtener cochera
      </button>


      <h1 id="lista-titulo">Lista de Cocheras</h1>
      <br></br>
        {loading && <p>Cargando cocheras...</p>}
        {error && <p>Error al cargar cocheras: {error}</p>}
      {/*Aca Va el boton de agregar cochera  */}
      <table className="table table-hover table-blue">
        <thead>
          <tr>
            <th scope="col"> Id</th>
            <th scope="col"> Nombre Cochera</th>
          </tr>
        </thead>
        <tbody className="tabla">
        {cocheras?.map((cochera) => (
        <tr key={cochera.id}>
            <td>{cochera.id}</td>
            <td>{cochera.razonSocial}</td>
        </tr>
        ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListarCocheras;