// src/components/Login.js
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import styles from "./styles.module.css";
import { useLocalStorageContext } from "../../../helpers/hooks/loginProvider";
import { login } from "../../../api/apiLibrary";

const Login = () => {
  const { token, setToken, userId, setUserId, role, setRole } =
    useLocalStorageContext();
  const [formData, setFormData] = useState({
    userName: "",
    password: "",
  });
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await login(formData);
      setToken(response.data.token);

      const arrayToken = response.data.token.split(".");
      const tokenPayload = JSON.parse(atob(arrayToken[1]));
      setRole(
        tokenPayload[
          `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`
        ],
      );
      setUserId(
        tokenPayload[
          `http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier`
        ],
      );

      alert("Login successful!");
      navigate("/");
    } catch (error) {
      alert("Login failed");
    }
  };

  return (
    <form className={styles.registerForm} onSubmit={handleSubmit}>
      <input
        className={styles.input}
        type="text"
        name="userName"
        placeholder="Username"
        onChange={handleChange}
      />
      <input
        className={styles.input}
        type="password"
        name="password"
        placeholder="Password"
        onChange={handleChange}
      />
      <button className={styles.button} type="submit">
        Login
      </button>
    </form>
  );
};

export default Login;
