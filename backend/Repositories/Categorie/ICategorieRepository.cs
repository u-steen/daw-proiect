namespace backend.Repositories.Categorie
{
    interface ICategorieRepository
    {
        Task<List<Models.Categorie>> GetAllAsync();
        Task<Models.Categorie?> GetByIdAsync(int id);
        Task<Models.Categorie> CreateMovieAsync(Models.Categorie movie);
        // Task<Models.Categorie?> UpdateMovieAsync(int id, UpdateCategorieDto movieDto);
        Task<Models.Categorie?> DeleteMovieAsync(int id);
    }
}
