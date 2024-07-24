import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import styles from "../../pages/Book/styles.module.css";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";
import { useFetch } from "../../helpers/hooks/useFetch";
import { getAuthors, getBookbyId, updateBook, uploadImage } from "../../api/apiLibrary";
import { BASE_URL } from "../../helpers/constants/constants";

const EditingBookPage = () => {
  const { id: bookId } = useParams();
  const navigate = useNavigate();

  const [bookData, setBookData] = useState({
    id: "00000000-0000-0000-0000-000000000000",
    isbn: "",
    name: "",
    genre: "",
    description: "",
    authorId: "",
    imageUrl: "", 
    file: null
  });

  const [selectedFile, setSelectedFile] = useState(null);
  const { token, setToken, userId, setUserId, role, setRole } = useLocalStorageContext();

  useEffect(() => {
    if (bookId) {
      const fetchBook = async () => {
        try {
          const response = await getBookbyId(bookId);
          setBookData({
            ...response.data,
            authorId: response.data.author.id || "",
            imageUrl: `${BASE_URL}/Image/${response.data.image.id}` || "", 
          });
        } catch (error) {
          console.error("Error fetching book: ", error);
        }
      };
      fetchBook();
    }
  }, [bookId]);

  const { data: authors } = useFetch(getAuthors);

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
    console.log(e.target.files[0]);
    setBookData({
      ...bookData,
      file: e.target.files[0],
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      let updatedBookData = { ...bookData };
      console.log(updatedBookData);

      updatedBookData.id = bookId;
      updatedBookData.author = undefined;
      updatedBookData.image = undefined;
      updatedBookData.libraryUser = undefined;
      updatedBookData.imageUrl = undefined;
      updatedBookData.isBookInLibrary = undefined;
      console.log(updatedBookData);

      const response = await updateBook(updatedBookData);
      console.log(response);
      window.location.reload();
    } catch (error) {
      console.error("Error updating book:", error);
    }
  };

  const handleCreateAuthor = () => {
    navigate("/create-author");
  };

    return (
        <div className={styles.formContainer}>
          <h1>{"Edit Book"}</h1>
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
                name="description"
                value={bookData.description}
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
                <option key={bookData.author?.id} value={bookData.author?.id}>
                  {bookData.author?.name} {bookData.author?.surname}
                </option>
                {authors?.length > 0 ? (
                  authors.map((author) => {
                    if (author?.id !== bookData.author?.id)
                      return (
                        <option key={author.id} value={author.id}>
                          {author.name} {author.surname}
                        </option>
                      );
                  })
                ) : (
                  <option value="" disabled>
                    No authors available
                  </option>
                )}
              </select>
            </div>
            <div className={styles.formGroup}>
              <label>Upload Image</label>
              {bookData.imageUrl && (
                <div className={styles.img} style={{ backgroundImage:`url(${bookData.imageUrl})`}}></div>
              )}
              <input type="file" accept="image/*" onChange={handleFileChange} />
              {selectedFile && <p>Selected file: {selectedFile.name}</p>}
            </div>
            <button className={styles.button} type="submit">Update Book</button>
          </form>
          <button className={styles.button} onClick={handleCreateAuthor}>Create New Author</button>
        </div>
      );
};

export default EditingBookPage;