import React from "react";
import { Navigate } from "react-router-dom";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";

const ProtectedRoute = ({ component: Component, ...rest }) => {
  const { token, setToken } = useLocalStorageContext();
  const isAuthenticated = token !== null;

  return isAuthenticated ? <Component {...rest} /> : <Navigate to="/login" />;
};

export default ProtectedRoute;
