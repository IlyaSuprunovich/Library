import React, { useState, useEffect } from "react";
import styles from "../../pages/Book/styles.module.css";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";
import { createBook, getAuthors, updateBook, uploadImage } from "../../api/apiLibrary";

const AddBookPage = () => {
  const [bookData, setBookData] = useState({
    id: "00000000-0000-0000-0000-000000000000",
    isbn: "",
    name: "",
    genre: "",
    description: "",
    author: {
      name: "",
      surname: "",
      dateOfBirth: "",
      country: "",
      books: [],
    },
    authorId: "",
    countBook: "",
    imageId: "00000000-0000-0000-0000-000000000000",
  });

  const [authors, setAuthors] = useState([]);
  const [message, setMessage] = useState("");
  const [selectedFile, setSelectedFile] = useState(null);
  const { token, setToken } = useLocalStorageContext();

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const response = await getAuthors();
        if (Array.isArray(response)) {
          setAuthors(response);
        } else {
          console.error("Unexpected response format:", response.data);
          setAuthors([]);
        }
      } catch (error) {
        console.error("Error fetching authors: ", error);
        setAuthors([]);
      }
    };
    fetchAuthors();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setBookData({
      ...bookData,
      [name]: value,
    });
  };

  const handleAuthorChange = (e) => {
    setBookData({
      ...bookData,
      authorId: e.target.value,
    });
  };

  const handleFileChange = (e) => {
    setSelectedFile(e.target.files[0]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      authors.forEach((author) => {
        if (author.id === bookData.authorId) {
          bookData.author = author;
          bookData.author.books = [];
        }
      });

      const response = await createBook(bookData);

      const bookId = response.data;
      bookData.id = bookId;
      if (selectedFile) {
        const formData = new FormData();
        formData.append("file", selectedFile);
        formData.append("bookId", bookId);

        const uploadResponse = await uploadImage(formData);

        const imageId = uploadResponse.data;
        bookData.imageId = imageId;

        await updateBook(bookData);
      }

      setMessage(`Book added successfully`);
    } catch (error) {
      console.log(error);
      setMessage(
        `Error: ${error.response ? error.response.data : error.message}`,
      );
    }
  };

  const handleCreateAuthor = () => {
    navigate("/create-author");
  };

  return (
    <div className={styles.formContainer}>
      <h1>Add a New Book</h1>
      <form onSubmit={handleSubmit}>
        <div className={styles.formGroup}>
          <label>ISBN</label>
          <input
            type="text"
            name="isbn"
            value={bookData.isbn}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Name</label>
          <input
            type="text"
            name="name"
            value={bookData.name}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Genre</label>
          <input
            type="text"
            name="genre"
            value={bookData.genre}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={styles.formGroup}>
          <label>Description</label>
          <textarea
            className={styles.textarea}
            name="description"
            value={bookData.description}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>
        <div className={styles.formGroup}>
          <label>Count Book</label>
          <textarea
            className={styles.textarea}
            name="countBook"
            value={bookData.countBook}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>
        <div className={styles.formGroup}>
          <label>Author</label>
          <select
            name="authorId"
            value={bookData.authorId}
            onChange={handleAuthorChange}
            required
          >
            <option value="">Select an author</option>
            {authors.length > 0 ? (
              authors.map((author) => (
                <option key={author.id} value={author.id}>
                  {author.name} {author.surname}
                </option>
              ))
            ) : (
              <option value="" disabled>
                No authors available
              </option>
            )}
          </select>
        </div>
        <div className={styles.formGroup}>
          <label>Upload Image</label>
          <input type="file" accept="image/*" onChange={handleFileChange} />
        </div>
        <button className={styles.button} type="submit">
          Add Book
        </button>
      </form>
      <button className={styles.button} onClick={handleCreateAuthor}>
        Create New Author
      </button>
      {message && <p className={styles.p}>{message}</p>}
    </div>
  );
};

export default AddBookPage;
