import React, { createContext, useContext } from "react";
import useLocalStorage from "./useLocaleStorage";

const LocalStorageContext = createContext();

const LocalStorageProvider = ({ children }) => {
  const [token, setToken, removeToken] = useLocalStorage("token", "");
  const [userId, setUserId, removeUserId] = useLocalStorage("userId", "");
  const [role, setRole, removeRole] = useLocalStorage("role", "");

  return (
    <LocalStorageContext.Provider
      value={{
        token,
        setToken,
        removeToken,
        userId,
        setUserId,
        removeUserId,
        role,
        setRole,
        removeRole,
      }}
    >
      {children}
    </LocalStorageContext.Provider>
  );
};

const useLocalStorageContext = () => {
  return useContext(LocalStorageContext);
};

export { LocalStorageProvider, useLocalStorageContext };
