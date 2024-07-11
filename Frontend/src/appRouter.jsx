import React from "react";
import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import BookPage from "./components/BookPage/BookPage";
import Main from "./pages/Main/Main";
import Register from "./components/Auth/Register/Register";
import Login from "./components/Auth/Login/Login";
import ProtectedRoute from "./components/Auth/ProtectedRoute";
import ProtectedComponent from "./components/Auth/ProtectedComponent";
import AddBookPage from "./pages/Book/AddBookPage";
import CreateAuthorPage from "./pages/Author/CreateAuthorPage";
import EditingBookPage from "./pages/Book/EditingBookPage";
import UserTakenBooks from "./pages/User/UserTakenBooks";

export const AppRouter = createBrowserRouter([
  {
    element: <App />,
    children: [
      { path: "/", element: <Main /> },
      { path: "/book/:id", element: <BookPage /> },
      { path: "/register", element: <Register /> },
      { path: "/login", element: <Login /> },
      {
        path: "/protected",
        element: <ProtectedRoute component={ProtectedComponent} />,
      },
      { path: "/add-book", element: <AddBookPage /> },
      { path: "/create-author", element: <CreateAuthorPage /> },
      { path: "/update-book/:id", element: <EditingBookPage /> },
      { path: `/my-books/:id`, element: <UserTakenBooks /> },
    ],
  },
]);
