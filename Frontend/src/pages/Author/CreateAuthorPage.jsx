import React, { useState } from "react";
import styles from "../../pages/Author/styles.module.css";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";
import { createAuthor } from "../../api/apiLibrary";

const CreateAuthorPage = () => {
  const [authorData, setAuthorData] = useState({
    Name: "",
    Surname: "",
    DateOfBirth: "",
    Country: "",
  });
  const { token, setToken } = useLocalStorageContext();
  const [message, setMessage] = useState("");

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setAuthorData({
      ...authorData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await createAuthor(authorData);
      setMessage(`Author created successfully`);
    } catch (error) {
      setMessage(
        `Error: ${error.response ? error.response.data : error.message}`,
      );
    }
  };
  
  return (
    <div className={styles.formContainer}>
      <h1>Create a New Author</h1>
      <form onSubmit={handleSubmit}>
        <div className={styles.formGroup}>
          <label>Name</label>
          <input
            type="text"
            name="Name"
            value={authorData.Name}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Surname</label>
          <input
            type="text"
            name="Surname"
            value={authorData.Surname}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Date of Birth</label>
          <input
            type="date"
            name="DateOfBirth"
            value={authorData.DateOfBirth}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Country</label>
          <input
            type="text"
            name="Country"
            value={authorData.Country}
            onChange={handleInputChange}
            required
          />
        </div>
        <button className={styles.button} type="submit">
          Create Author
        </button>
      </form>
      {message && <p className={styles.p}>{message}</p>}
    </div>
  );
};

export default CreateAuthorPage;
