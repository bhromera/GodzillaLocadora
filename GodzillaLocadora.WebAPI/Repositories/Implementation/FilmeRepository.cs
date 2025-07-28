using GodzillaLocadora.WebAPI.Data;
using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GodzillaLocadora.WebAPI.Repositories.Implementation
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;
        public FilmeRepository(AppDbContext context) => _context = context;

        public async Task<Filme> ObterPorIdAsync(int id) =>
            await _context.Filmes.FindAsync(id);

        public async Task<List<Filme>> BuscarPorTituloAsync(string titulo) =>
            await _context.Filmes
                .Where(f => f.Titulo.Contains(titulo))
                .ToListAsync();

        public async Task<bool> AtualizarAsync(Filme filme)
        {
            _context.Filmes.Update(filme);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
