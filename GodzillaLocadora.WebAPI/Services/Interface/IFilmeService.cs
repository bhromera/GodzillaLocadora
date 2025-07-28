using GodzillaLocadora.WebAPI.Models;

namespace GodzillaLocadora.WebAPI.Services.Interface
{
    public interface IFilmeService
    {
        Task<bool> AlugarFilmeAsync(int filmeId);
        Task<List<Filme>> BuscarFilmesAsync(string titulo);
    }
}
