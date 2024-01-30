using backend.DTO.Categorie;
using backend.Repositories.Categorie;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/categorie")]
[ApiController]
public class CategorieController : ControllerBase
{
    private readonly ICategorieRepository _categorieRepo;
    public CategorieController(ICategorieRepository categorieRepo)
    {
        _categorieRepo = categorieRepo;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var categorii = await _categorieRepo.GetAllAsync();
        return Ok(categorii);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var categorie = await _categorieRepo.GetByIdAsync(id);
        if (categorie == null)
            return BadRequest("Categoria nu exista");
        return Ok(categorie);

    }
    [HttpPost]
    public async Task<IActionResult> CreateCategorie([FromBody] CreateCategorieDto categorie)
    {
        var categorieCreata = await _categorieRepo.CreateCategorieAsync(categorie);
        return Ok(categorieCreata);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategorie([FromRoute] int id, [FromBody] CategorieDto updatedCategorie)
    {
        var categorie = await _categorieRepo.UpdateCategorieAsync(id, updatedCategorie);
        if(categorie == null)
            return BadRequest("Categoria nu exista");
        return Ok(categorie);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategorie([FromRoute] int id)
    {
        var categorie = await _categorieRepo.DeleteCategorieAsync(id);
        return Ok(categorie);
    }

}
