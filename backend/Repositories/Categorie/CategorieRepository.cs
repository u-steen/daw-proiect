namespace backend.Repositories.Categorie{
    class CategorieRepository : ICategorieRepository
    {
        Task<Models.Categorie> ICategorieRepository.CreateMovieAsync(Models.Categorie movie)
        {
            throw new NotImplementedException();
        }

        Task<Models.Categorie?> ICategorieRepository.DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Models.Categorie>> ICategorieRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Models.Categorie?> ICategorieRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Task<Models.Categorie?> ICategorieRepository.UpdateMovieAsync(int id, UpdateCategorieDto movieDto)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
