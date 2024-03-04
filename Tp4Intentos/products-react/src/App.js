// import axios, {AxiosResponse} from 'axios';
// import { useEffect } from 'react';
// import { urlAuto } from './enpoints';


// import { useFetch } from "./useFetch.js";
import { Routes, Route, BrowserRouter} from 'react-router-dom';
import ShowProducts from './components/ShowProducts'

//import { urlAutos } from './endpoints';
// import someModule from './enpoints';


function App() {
//  const {data, loading, error,handLeCancelRequest } = useFetch('https://localhost:7105/IAutoRepository');

 
 
 return (
    <>
      {/* <h1>Mi app de react</h1>
        <button onClick={handLeCancelRequest}>Cancel Request</button>
      <ul>
        {error && <li>{error}</li>}
        {loading && <li>loading...</li>}
        {data?.map((user) => (
          <li key={user.id}>{user.marca}</li>
          ))}
      </ul> */}
      <BrowserRouter>
        <Routes>
            <Route path='/' element={ <ShowProducts></ShowProducts> }></Route>  
        </Routes>
      </BrowserRouter>
      <h1> Fetcj Like a PRO</h1>
      
        
    </>

    );
}

export default App;
