import BookItem from "../BookItem/BookItem";
import styles from "../../components/BooksList/styles.module.css";

const BooksList = ({ books }) => {
  if (books != null) {
    const authorsById = {};

    books.forEach((book) => {
      if (book.author && book.author.$id) {
        authorsById[book.author.$id] = book.author;
      }
    });

    books.forEach((book) => {
      if (book.author && book.author.$ref) {
        const refId = book.author.$ref;
        book.author = authorsById[refId] || book.author;
      }
    });
  }

  return (
    <ul className={styles.list}>
      {books?.map((item) => {
        return <BookItem key={item.id} item={item} />;
      })}
    </ul>
  );
};

export default BooksList;
