import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import styles from "./styles.module.css";
import { register } from "../../../api/apiLibrary";

const Register = () => {
  const [formData, setFormData] = useState({
    userName: "",
    email: "",
    firstName: "",
    surname: "",
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
      await register(formData);
      navigate("/login");
      alert("Registration successful!");
    } catch (error) {
      console.log(error);
      alert("Registration failed");
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
        type="email"
        name="email"
        placeholder="Email"
        onChange={handleChange}
      />
      <input
        className={styles.input}
        type="text"
        name="firstName"
        placeholder="First Name"
        onChange={handleChange}
      />
      <input
        className={styles.input}
        type="text"
        name="surname"
        placeholder="Surname"
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
        Register
      </button>
    </form>
  );
};

export default Register;
