function Movie({titlu, director, an}) {
    return (
        <>
            <h1>{titlu}</h1>
            <h2>by {director}</h2>
            <p>Release Year: {an}</p>
            <br></br>
        </>
    )
}

export default Movie