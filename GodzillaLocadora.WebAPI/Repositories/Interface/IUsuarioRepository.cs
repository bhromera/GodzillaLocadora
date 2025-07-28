using GodzillaLocadora.WebAPI.Models;

namespace GodzillaLocadora.WebAPI.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<Usuario> CriarAsync(Usuario usuario);
    }
}
