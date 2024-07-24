import axios from "axios";
import { BASE_URL, IDENTITY_SERVER_BASE_URL} from "../helpers/constants/constants";


const token = JSON.parse(localStorage.getItem("token"));

export const getBook = async ({
  pageNumber = 1,
  pageSize = 4,
  genre,
  name,
}) => {
  try {
    const response = await axios.get(`${BASE_URL}/Book`, {
      params: {
        pageNumber,
        pageSize,
        genre,
        name,
      },
    });

    return response.data;
  } catch (error) {
    console.log(error);
    throw error;
  }
};

export const getBookbyId = async (id) => {
  try {
    const response = await axios.get(`${BASE_URL}/Book/${id}`);
    return response;
  } catch (error) {
    console.log(error);
    throw error;
  }
};

export const getCategories = async () => {
  try {
    const response = await axios.get(
      `${BASE_URL}/Book/genres`,
      {},
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};

export const getImage = async ({ id }) => {
  try {
    const response = await axios.get(`${BASE_URL}/Image/${id}`);
    return response;
  } catch (error) {
    console.log(error);
    throw error;
  }
};

export const takeBook = async (idBook, userId) => {
  try {
    const response = await axios.put(
      `${BASE_URL}/Book/give/${idBook}/${userId}`,
      {},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};

export const returnBook = async (idBook, userId) => {
  try {
    const response = await axios.put(
      `${BASE_URL}/Book/return/${idBook}/${userId}`,
      {},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};

export const deleteBook = async (idBook) => {
  try {
    const response = await axios.delete(
      `${BASE_URL}/Book/${idBook}`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};

export const getUserBook = async (userId) => {
  try {
    const response = await axios.get(
      `${BASE_URL}/LibraryUser/userId/${userId}`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};

export const getTakenBooks = async (userId) => {
  try {
    const response = await fetch(`${BASE_URL}/LibraryUser/userId/${userId}`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        }
      }
    );
    const data = await response.json();
    return data.takenBooks;
  } catch (error) {
    console.error("Error fetching books:", error);
  }
};

export const getAuthors = async () => {
  try {
    const response = await axios.get(`${BASE_URL}/Author`);
    if (Array.isArray(response.data.authors)) {
      return response.data.authors;
    } else {
      console.error("Unexpected response format:", response.data);
      return [];
    }
  } catch (error) {
    console.error("Error fetching authors: ", error);
    return[];
  }
};

export const createAuthor = async (authorData) => {
  try {
    const response = await axios.post(`${BASE_URL}/Author`, authorData, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    return response;
  } catch (error) {
      return error.response ? error.response.data : error.message;
  }
};

export const uploadImage = async (formData) => {
  try {
    const response = await axios.post(
      `${BASE_URL}/Image/upload`,
      formData,
      {
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "multipart/form-data",
        },
      },
    );
    return response;
  } catch (error) {
      return error.response ? error.response.data : error.message;
  }
};

export const updateBook = async (bookData) => {
  try {

    const formData = new FormData();
    formData.append('Id', bookData.id);
    formData.append('ISBN', bookData.isbn);
    formData.append('Name', bookData.name);
    formData.append('Genre', bookData.genre);
    formData.append('Description', bookData.description);
    formData.append('AuthorId', bookData.authorId);
    if (bookData.file) {
      formData.append('File', bookData.file);
    }

    const response = await axios.put(
      `${BASE_URL}/Book`,
      { ...bookData },
      {
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "multipart/form-data",
        },
      },
    );
    return response;
  } catch (error) {
      return error.response ? error.response.data : error.message;
  }
};

export const createBook = async (bookData) => {
  try {
    const formData = new FormData();
    
    formData.append('ISBN', bookData.isbn);
    formData.append('Name', bookData.name);
    formData.append('Genre', bookData.genre);
    formData.append('Description', bookData.description);
    formData.append('AuthorId', bookData.authorId);
    
    if (bookData.file) {
      formData.append('File', bookData.file);
    }

    console.log(...formData);
    const response = await axios.post(
      `${BASE_URL}/Book`,
      {
        ...bookData,
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "multipart/form-data",
        },
      },
    );
    return response;
  } catch (error) {
      return error.response ? error.response.data : error.message;
  }
}

export const logout = async () => {
  try {
    await axios.post(`${IDENTITY_SERVER_BASE_URL}logout`);
    alert("Logout successful!");
  } catch (error) {
    alert("Logout failed");
  }
};

export const getBookId = async (userId) => {
  try {
    const response = await fetch(
      `${BASE_URL}/LibraryUser/userId/${userId}`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );

    const data = await response.json();
    
    return data;
  } catch (error) {
    return error;
  }
};

export const register = async (formData) => {
  try {
    const response = await axios.post(
      `${IDENTITY_SERVER_BASE_URL}register`,
      formData,
    );
  
    return response;
  } catch (error) {
    return error;
  }
}

export const login = async (formData) => {
  try {
    const response = await axios.post(
      `${IDENTITY_SERVER_BASE_URL}login`,
      formData,
    );
    return response;
  } catch (error) {
  }
};

