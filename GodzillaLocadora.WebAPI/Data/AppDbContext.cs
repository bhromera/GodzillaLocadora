using GodzillaLocadora.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GodzillaLocadora.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
