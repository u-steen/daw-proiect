import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Loading from "../Components/Loading";

const Movie = () => {
  const [loading, setLoading] = useState(true);
  const [movie, setMovie] = useState();
  const { movieId } = useParams();
  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch(`http://localhost:5070/api/movie/${movieId}`);
      const data = await result.json();
      setLoading(false);
      setMovie(data);
      console.log(movie);
    };
    fetchData();
  }, []);

  if (loading)
    return (
      <div className="flex justify-center pt-10">
        <Loading />
      </div>
    );
  return (
    <div className="w-3/4 mx-auto">
      <div className="flex justify-center items-baseline gap-3 bg-blue-200 border-b-2 border-b-slate-900">
        <h1 className="text-4xl">{movie.titlu | upperCase}</h1>
        <p>{movie.an}</p>
      </div>
      <h3>Director: {movie.director}</h3>
      <h3>Review-uri:</h3>
    </div>
  );
};

export default Movie;
