import { useEffect, useState } from "react";
import Loading from "../Components/Loading.jsx";
import { Link } from "react-router-dom";

const MovieElement = ({ title, director, year }) => (
  <div className={"p-7 border-slate-800 border-b-2 hover:bg-blue-400"}>
    <h1 className={"text-3xl"}>{title}</h1>
    <h2 className={"text-xl"}>
      made by {director} and released in {year}
    </h2>
  </div>
);

const MovieList = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch("http://localhost:5070/api/movie");
      const data = await result.json();
      setMovies(data);
      setLoading(false);
    };
    fetchData();
  }, []);

  if (loading)
    return (
      <div className={"flex align-middle justify-center p-16"}>
        <Loading />
      </div>
    );

  return (
    <div className={"bg-blue-200 w-3/4 mx-auto my-0"}>
      {movies.map((movie) => {
        return (
          <Link key={movie.id} to={`movie/${movie.id}`}>
            <MovieElement
              title={movie.titlu}
              director={movie.director}
              year={movie.an}
            />
          </Link>
        );
      })}
    </div>
  );
};

function App() {
  const [loginStatus, setLoginStatus] = useState("");
  useEffect(() => {
    const token = localStorage.getItem("userToken");
    console.log("Token: ", token);
    if (token) setLoginStatus("Log out");
    else setLoginStatus("Log In");
  }, []);

  return (
    <>
      <div className="flex">
        {loginStatus === "Log In" ? (
          <Link to="/auth">
            <h3 className="text-xl ml-4 py-4 px-6 bg-slate-200 hover:bg-slate-300">
              Log In / Register
            </h3>
          </Link>
        ) : (
          <h3 className="text-xl ml-4 py-4 px-6 bg-slate-200 hover:bg-slate-300">
            Log Out
          </h3>
        )}
      </div>
      <div
        className={"border-b-4 border-slate-800 p-6 pt-12 flex justify-center"}
      >
        <h1 className={"text-5xl font-bold"}>All movies</h1>
      </div>
      <MovieList />
    </>
  );
}

export default App;
