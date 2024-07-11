import React from "react";
import { useParams } from "react-router-dom";
import BooksList from "../../components/BooksList/BooksList";
import styles from "./styles.module.css";
import { useFetch } from "../../helpers/hooks/useFetch";
import { getTakenBooks } from "../../api/apiLibrary";

const UserTakenBooks = () => {
  const { id: userId } = useParams();
  const {data: takenBooks} = useFetch(getTakenBooks, userId);

  return (
    <div>
      <h1 className={styles.title}>Your books</h1>
      <BooksList className={styles.list} books={takenBooks} />
    </div>
  );
};

export default UserTakenBooks;
