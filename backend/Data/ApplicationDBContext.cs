using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backend.Data;

public class ApplicationDBContext : IdentityDbContext<AppUser>
{

    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Categorie> Caterogie { get; set; }
    public DbSet<MovieCategorie> MovieCategorii { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Many to many
        builder.Entity<MovieCategorie>(x => x.HasKey(p => new { p.MovieId, p.CategorieId }));

        builder.Entity<MovieCategorie>()
            .HasOne(u => u.Movie)
            .WithMany(u => u.MovieCategorii)
            .HasForeignKey(u=>u.MovieId);

        builder.Entity<MovieCategorie>()
            .HasOne(u => u.Categorie)
            .WithMany(u => u.MovieCategorii)
            .HasForeignKey(u=>u.CategorieId);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }

}
