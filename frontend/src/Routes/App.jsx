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
          <Link to={`movie/${movie.id}`}>
            <MovieElement
              key={movie.id}
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
  return (
    <>
      <div className={"border-b-4 border-slate-800 p-6 flex justify-center"}>
        <h1 className={"text-5xl font-bold"}>All movies</h1>
      </div>
      <MovieList />
    </>
  );
}

export default App;
