import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import Loading from "../Components/Loading";

const ReviewList = ({ reviews }) => {
  return (
    <div>
      <h1 className="text-3xl">Reviews:</h1>
      {reviews.map((review) => {
        return (
          <div
            key={review.id}
            className="bg-blue-300 border-b-2 border-slate-800 p-4 mt-4 rounded-md"
          >
            <div className="flex justify-between border-b-2 border-slate-800 mb-4">
              <h1 className="font-bold text-lg">{review.createdBy}</h1>
              <h1>{review.rating}/10</h1>
            </div>
            <p className="text-sm">{review.comment}</p>
          </div>
        );
      })}
    </div>
  );
};

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
      <div className="bg-blue-200">
        <Link className="m-8 p-2 bg-slate-200 hover:bg-slate-400" to="/">
          Back to Home
        </Link>
      </div>
      <div className="flex justify-center items-baseline gap-3 bg-blue-200 border-b-2 border-b-slate-900 pt-6">
        <h1 className="text-4xl">{movie.titlu}</h1>
        <p>{movie.an}</p>
      </div>
      <h3>Director: {movie.director}</h3>
      <ReviewList reviews={movie.reviews} />
    </div>
  );
};

export default Movie;
