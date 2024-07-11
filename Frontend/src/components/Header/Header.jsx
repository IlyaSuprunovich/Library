import { Link, useNavigate } from "react-router-dom";
import { formatDate } from "../../helpers/formatDate";
import styles from "./styles.module.css";
import { useLocalStorageContext } from "../../helpers/hooks/loginProvider";
import { logout } from "../../api/apiLibrary";

const Header = () => {
  const {
    token,
    removeToken,
    userId,
    removeUserId,
    role,
    removeRole,
  } = useLocalStorageContext();

  const navigate = useNavigate();

  const handleLogout = async () => {
    try {
      await logout();
      removeToken();
      removeUserId();
      removeRole();
      navigate("/");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <header className={styles.header}>
      <div>
        <Link to={`/`} className={styles.title}>
          LIBRARY WEB-API
        </Link>
        <p className={styles.date}>{formatDate(new Date())}</p>
      </div>
      <div className={styles.navigate}>
        {userId && (
          <Link className={styles.button} to={`my-books/${userId}`}>
            My books
          </Link>
        )}
        {role == "Admin" && (
          <Link className={styles.button} to={`/add-book`}>
            Add book
          </Link>
        )}
        {
            !token && (
            <Link className={styles.button} to={`/register`}>
                Register
            </Link>
        )}
        {
            !token && (
            <Link className={styles.button} to={`/login`}>
                Log In
            </Link>
        )}
        {userId && (
          <button
            onClick={handleLogout}
            className={styles.button}
          >
            Log Out
          </button>
        )}
      </div>
    </header>
  );
};

export default Header;
