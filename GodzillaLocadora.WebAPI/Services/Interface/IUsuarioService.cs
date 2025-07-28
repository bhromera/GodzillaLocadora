using GodzillaLocadora.WebAPI.DTO.Requests;
using GodzillaLocadora.WebAPI.DTO.Responses;

namespace GodzillaLocadora.WebAPI.Services.Interface
{
    public interface IUsuarioService
    {
        Task<(UsuarioResponse usuario, string token)> CriarUsuarioAsync(LoginRequest request);
    }
}
