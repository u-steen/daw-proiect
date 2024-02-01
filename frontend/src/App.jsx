import { useEffect, useState } from "react";
import Loading from "./Components/Loading.jsx";

const Movie = ({ title, director, year }) => (
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
      console.log(result);
      const data = await result.json();
      console.log(data);
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
      <div className={"border-b-4 border-slate-800 p-6 flex justify-center"}>
        <h1 className={"text-5xl font-bold"}>All movies</h1>
      </div>
      {movies.map((movie) => {
        return (
          <Movie
            key={movie.id}
            title={movie.titlu}
            director={movie.director}
            year={movie.an}
          />
        );
      })}
    </div>
  );
};

function App() {
  return (
    <>
      <MovieList />
    </>
  );
}

export default App;
