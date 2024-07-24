import React, { useEffect, useState } from "react";
import Image from "../../components/Image/Image";
import Author from "../../components/Author/Author";
import styles from "../../components/Book/styles.module.css";
import {
  deleteBook,
  getBookId,
  returnBook,
  takeBook,
} from "../../api/apiLibrary";
import { Link, useNavigate } from "react-router-dom";
import Popup from "reactjs-popup";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";

const Book = ({ book, imageBasePath }) => {
  const [takenBooksId, setTakenBookId] = useState([]);
  const [isBookThereOnUser, setBookThereOnUser] = useState(false);
  const { token, setToken, userId, setUserId, role, setRole } =
    useLocalStorageContext();

  const navigate = useNavigate();

  const handleTake = async () => {
    try {
      await takeBook(book.id, userId);
      fetchBooks();
    } catch (error) {
      console.log(`Failed to take book: ${error.message}`);
    }
  };

  const handleReturn = async () => {
    try {
      await returnBook(book.id, userId);
      fetchBooks();
    } catch (error) {
      console.log(`Failed to return book: ${error.message}`);
    }
  };

  const handleDelete = async () => {
    try {
      await deleteBook(book.id);
      navigate("/");
    } catch (error) {
      console.log(`Failed to delete book: ${error.message}`);
    }
  };

  const fetchBooks = async () => {
    try {
      const response = await getBookId(userId);
      const takenBooks = response.takenBooks.map((takenBook) => takenBook.id);
      setTakenBookId(response);
      setBookThereOnUser(takenBooks.includes(book.id));
    } catch (error) {
      console.error("Error fetching books:", error);
    }
  };

  useEffect(() => {
    fetchBooks();
  }, []);

  return (
    <div className={styles.mainItem}>
      <div className={styles.image}>
        {book.image && <Image image={`${imageBasePath}${book.image.id}`} />}
      </div>
      <div className={styles.textBlock}>
        <div>
        <h1 className={styles.nameBook}>{book.name}</h1>
        <p>{book.author && <Author author={book.author} />}</p>
        <p className={styles.data}>{`Genre: ${book.genre}`}</p>
        <p className={styles.data}>{`Description: ${book.description}`}</p>
        </div>
        <div className={styles.contentBtns}>
          {isBookThereOnUser && (
            <button className={styles.button} onClick={handleReturn}>
              Return book
            </button>
          )}
          {!isBookThereOnUser && (
            <button className={styles.button} onClick={handleTake}>
              Take book
            </button>
          )}
          {role === "Admin" && (
            <Link className={styles.button} to={`/update-book/${book.id}`}>
              Edit book
            </Link>
          )}
          {role === "Admin" && (
            <Popup
              trigger={<button className={styles.button}>Delete book</button>}
              modal
              nested
            >
              {(close) => (
                <div className={styles.modal}>
                  <div className={styles.content}>Access?</div>
                  <div className={styles.buttons}>
                    <button
                      className={`${styles.button} ${styles.red}`}
                      onClick={handleDelete}
                    >
                      Delete book
                    </button>
                    <button
                      className={styles.button}
                      onClick={() => close()}
                    >
                      Close
                    </button>
                  </div>
                </div>
              )}
            </Popup>
          )}
        </div>
      </div>
    </div>
  );
};

export default Book;
