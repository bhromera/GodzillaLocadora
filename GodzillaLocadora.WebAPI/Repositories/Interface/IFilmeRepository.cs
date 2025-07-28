using GodzillaLocadora.WebAPI.Models;

namespace GodzillaLocadora.WebAPI.Repositories.Interface
{
    public interface IFilmeRepository
    {
        Task<Filme> ObterPorIdAsync(int id);
        Task<List<Filme>> BuscarPorTituloAsync(string titulo);
        Task<bool> AtualizarAsync(Filme filme);
    }
}
