import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { RouterProvider } from "react-router-dom";
import { AppRouter } from "./appRouter.jsx";
import { LocalStorageProvider } from "./helpers/hooks/loginProvider.jsx";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <LocalStorageProvider>
      <RouterProvider router={AppRouter} />
    </LocalStorageProvider>
  </React.StrictMode>,
);
