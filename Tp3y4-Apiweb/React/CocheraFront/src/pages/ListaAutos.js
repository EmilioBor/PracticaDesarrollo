import { useEffect, useState } from "react";
import axios from 'axios';

export const ListarCocheras = ({ apiData }) => {
  const [ cocheras, setCochera ] = useState([]);
  const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7008/api/Autos/listarAutos')
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
      <h1 id="lista-titulo">Lista de Autos</h1>
      <br></br>
        {loading && <p>Cargando cocheras...</p>}
        {error && <p>Error al cargar cocheras: {error}</p>}
      {/*Aca Va el boton de agregar cochera  */}
      <table className="table table-hover table-blue">
        <thead>
          <tr>
            <th scope="col"> Id</th>
            <th scope="col"> Marca Auto</th>
            <th scope="col"> Modelo Auto</th>
            <th scope="col"> Color Auto</th>
            <th scope="col"> Numero de Puertas</th>
            <th scope="col"> Nombre Cochera</th>
          </tr>
        </thead>
        <tbody className="tabla">
        {cocheras?.map((cochera) => (
        <tr key={cochera.id}>
            <td>{cochera.id}</td>
            <td>{cochera.marca}</td>
            <td>{cochera.modelo}</td>
            <td>{cochera.color}</td>
            <td>{cochera.puerta}</td>
            <td>{cochera.nombreCochera}</td>
        </tr>
        ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListarCocheras;