using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Repositories.Interface;
using GodzillaLocadora.WebAPI.Services.Interface;

namespace GodzillaLocadora.WebAPI.Services.Implementation
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _repo;
        public FilmeService(IFilmeRepository repo) => _repo = repo;

        public async Task<bool> AlugarFilmeAsync(int filmeId)
        {
            var filme = await _repo.ObterPorIdAsync(filmeId);
            if (filme == null || filme.Estoque <= 0) return false;

            filme.Estoque--;
            return await _repo.AtualizarAsync(filme);
        }

        public Task<List<Filme>> BuscarFilmesAsync(string titulo)
        {
            return _repo.BuscarPorTituloAsync(titulo);
        }
    }
}
