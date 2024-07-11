import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Book from "../Book/Book";
import { getBook, getBookbyId, takeBook } from "../../api/apiLibrary";

const BookPage = () => {
  const { id: bookId } = useParams();
  const [book, setBook] = useState({});

  useEffect(() => {
    async function asyncBook() {
      const response = await getBookbyId(bookId);
      setBook(response.data);
    }
    asyncBook();
  }, [bookId]);

  return (
    <div>
      {book?.id && (
        <Book
          book={book}
          imageBasePath={import.meta.env.VITE_LIBRARY_IMAGE_BASE_PATH}
        />
      )}
    </div>
  );
};

export default BookPage;
