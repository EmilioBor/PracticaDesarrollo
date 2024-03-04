import { useEffect, useState } from "react";


export function useFetch(url){
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [control, setControl] = useState(null);
    useEffect(()=>{
        const abortController = new AbortController();
        setControl(abortController);
        setLoading(true);
        fetch(url, {signal: abortController.signal })    
            .then((Response) => Response.json())
            .then((data) => setData(data))
            .catch((error) => {
                if(error.name === "AbortError"){
                    console.log("Request Cancelled");
                }
                setError(error)
            })
            .finally(()=> setLoading(false))

        return
    }, []);
    const handLeCancelRequest = () =>{
        if(control)
        control.abort();
        setError("Request cancelled");
    };

    return {data, loading, error, handLeCancelRequest};



}