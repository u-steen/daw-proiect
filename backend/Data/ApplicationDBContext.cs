using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class ApplicationDBContext : DbContext
{

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Categorie> Caterogie { get; set; }

    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
}
