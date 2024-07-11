import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";
import styles from "./styles.module.css";

const BookItem = ({ item }) => {

const { token, setToken } = useLocalStorageContext();
  return (
    <li className={styles.item}>
      {item?.image?.id && <div
        className={styles.wrapper}
        style={{
          backgroundImage:`url(${import.meta.env.VITE_LIBRARY_IMAGE_BASE_PATH}${item?.image?.id})`,
        }}
      ></div>}
      <div className={styles.info}>
        {token ? (
          <a href={`/Book/${item.id}`}>
            <h3 className={styles.title}>{item.name}</h3>
          </a>
        ) : (
          <h3 className={styles.title}>{item.name}</h3>
        )}
        <p className={styles.extra}>
          by {item.author.name} {item.author.surname}
        </p>
        <div>
          {item.isBookInLibrary ? <p>in stock</p> : <p>out of stock</p>}
        </div>
      </div>
    </li>
  );
};

export default BookItem;
