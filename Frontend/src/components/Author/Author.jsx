import React from "react";
import styles from "../../components/Author/styles.module.css";

const Author = ({ author }) => {
  return (
    <span className={styles.name}>
      {`by ${author.name} ${author.surname} from ${author.country}`}
    </span>
  );
};

export default Author;
