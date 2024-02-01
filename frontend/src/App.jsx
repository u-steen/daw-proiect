const moviesJSON = [
    {
        id: 1,
        title: "Ceva",
        director: "Cineva",
        year: 2025
    },
    {
        id: 2,
        title: "Altceva",
        director: "Tot Cineva",
        year: 2013
    }
]
const Movie = ({title, director, year}) => (
    <div className={"p-6 bg-blue-300 rounded-xl"}>
        <h1 className={"text-3xl"}>{title}</h1>
        <h2 className={"text-xl"}>made by {director} and released in {year}</h2>
    </div>
)

const MovieList = ({movies}) => {

    return (
        <div className={"w-3/4 mx-auto my-0"}>
            {movies.map((movie) => {
                return (
                    <Movie
                        key={movie.id}
                        title={movie.title}
                        director={movie.director}
                        year={movie.year}
                    />
                )
            })}
        </div>
    )
}

function App() {
    return (
        <>
            <MovieList
                movies={moviesJSON}
            />
        </>
    )
}

export default App
