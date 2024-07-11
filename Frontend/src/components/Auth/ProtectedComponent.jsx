import React, { useEffect, useState } from "react";
import axios from "axios";

const ProtectedComponent = () => {
  const [data, setData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("/api/protected-endpoint");
        setData(response.data);
      } catch (error) {
        console.error("Error fetching protected data", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div>
      <h1>Protected Data</h1>
      {data ? <pre>{JSON.stringify(data, null, 2)}</pre> : <p>Loading...</p>}
    </div>
  );
};

export default ProtectedComponent;
