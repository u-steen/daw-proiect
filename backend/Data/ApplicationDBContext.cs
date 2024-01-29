using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend.Data;

public class ApplicationDBContext : IdentityDbContext<AppUser>
{

    public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions) { }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Categorie> Caterogie { get; set; }

}
