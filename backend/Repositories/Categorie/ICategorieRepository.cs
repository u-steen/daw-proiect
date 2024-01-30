using backend.DTO.Categorie;

namespace backend.Repositories.Categorie
{
    public interface ICategorieRepository
    {
        public Task<List<Models.Categorie>> GetAllAsync();
        public Task<Models.Categorie?> GetByIdAsync(int id);
        public Task<Models.Categorie> CreateCategorieAsync(CreateCategorieDto categorie);
        public Task<Models.Categorie?> UpdateCategorieAsync(int id, CategorieDto CategorieDto);
        public Task<Models.Categorie?> DeleteCategorieAsync(int id);
    }
}
