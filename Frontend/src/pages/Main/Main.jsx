import { useEffect, useState } from "react";
import styles from "./styles.module.css";
import { getBook, getCategories } from "../../api/apiLibrary";
import BooksList from "../../components/BooksList/BooksList";
import Skeleton from "../../components/Skeleton/Skeleton";
import Pagination from "../../components/Pagination/Pagination";
import Categories from "../../components/Categories/Categories";
import Search from "../../components/Search/Search";
import { useDebounce } from "../../helpers/hooks/useDebounce";
import { DEBOUNCE_DELAY, PAGE_SIZE } from "../../helpers/constants/constants";
import { useFetch } from "../../helpers/hooks/useFetch";

const Main = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [selectedCategory, setSelectedCategory] = useState("All");
  const [keywords, setKeywords] = useState("");

  const debouncedKeywords = useDebounce(keywords, DEBOUNCE_DELAY);

  const {data, error, isLoading} = useFetch(getBook, {
    pageNumber: currentPage,
    pageSize: PAGE_SIZE,
    genre: selectedCategory === "All" ? null : selectedCategory,
    name: debouncedKeywords,
  });

  const {data: dataCategories} = useFetch(getCategories);

  useEffect(() => {
    setCurrentPage(1);
  }, [selectedCategory, debouncedKeywords]);

  const handleNextPage = () => {
    if (currentPage < data.totalPages) {
      setCurrentPage(currentPage + 1);
    }
  };

  const handlePreviousPage = () => {
    if (currentPage > 1) {
      setCurrentPage(currentPage - 1);
    }
  };

  const handlePageClick = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  return (
    <main className={styles.main}>
      { dataCategories ? (<Categories
        categories={["All", ...dataCategories.data.genres]}
        selectedCategory={selectedCategory}
        setSelectedCategory={setSelectedCategory}
      />) : null}

      <Search keywords={keywords} setKeywords={setKeywords} />

      {isLoading ? (
        <Skeleton type={"item"} count={PAGE_SIZE} />
      ) : (
        <BooksList books={data?.data} />
      )}

      {
        <Pagination
          handlePreviousPage={handlePreviousPage}
          handleNextPage={handleNextPage}
          handlePageClick={handlePageClick}
          totalPages={data?.totalPages}
          currentPage={currentPage}
        />
      }
    </main>
  );
};

export default Main;
