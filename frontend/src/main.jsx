import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import App from "./Routes/App.jsx";
import "./index.css";
import Movie from "./Routes/Movie.jsx";
import Auth from "./Routes/Auth.jsx";
import Register from "./Routes/Register.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/movie/:movieId",
    element: <Movie />,
  },
  {
    path: "/auth",
    element: <Auth />,
  },
  {
    path: "/register",
    element: <Register />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
