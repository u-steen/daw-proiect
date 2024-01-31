using AutoMapper;
using backend.Data;
using backend.DTO.Categorie;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Categorie;
public class CategorieRepository : ICategorieRepository
{
    public readonly ApplicationDBContext _context;
    public readonly IMapper _mapper;

    public CategorieRepository(ApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Models.Categorie> CreateCategorieAsync(CreateCategorieDto createdCategorie)
    {
        var categorie = _mapper.Map<Models.Categorie>(createdCategorie);
        await _context.Categorii.AddAsync(categorie);
        await _context.SaveChangesAsync();
        return categorie;
    }

    public async Task<Models.Categorie?> DeleteCategorieAsync(int id)
    {
        var categorie = await _context.Categorii.FirstOrDefaultAsync(x => x.Id == id);
        if(categorie == null)
            return null;
        _context.Categorii.Remove(categorie);
        await _context.SaveChangesAsync();
        return categorie;
    }


    public async Task<List<Models.Categorie>> GetAllAsync()
    {
        var categorii = await _context.Categorii.ToListAsync();
        return categorii;
    }

    public async Task<Models.Categorie?> GetByIdAsync(int id)
    {
        var categorie = await _context.Categorii.FirstOrDefaultAsync(x => x.Id == id);
        return categorie;

    }

    public async Task<Models.Categorie?> UpdateCategorieAsync(int id, CategorieDto updatedCategorie)
    {
        var categorie = await _context.Categorii.FirstOrDefaultAsync(x => x.Id == id);
        if(categorie == null)
            return null;

        categorie.Nume = updatedCategorie.Nume;
        categorie.Descriere = updatedCategorie.Descriere;
        await _context.SaveChangesAsync();
        return categorie;
    }
}
