import './App.css';
import './Components/Movie'
import {useEffect, useState} from "react";
import Movie from "./Components/Movie";

function App() {
    const [movies, setMovies] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch("/api/movie");
            const data = await response.json();
            console.log(data);
            setMovies(data);
        }
        fetchData();
    }, []);

  return (
      <>
          {movies.map(movie => (
              <div key={movie.id}>
                  <Movie
                  titlu={movie.titlu}
                  director = {movie.director}
                  an = {movie.an}>
                  </Movie>
              </div>
          ))}
      </>
  );
}

export default App;
