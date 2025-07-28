using GodzillaLocadora.WebAPI.Auth;
using GodzillaLocadora.WebAPI.DTO.Requests;
using GodzillaLocadora.WebAPI.DTO.Responses;
using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Repositories.Interface;
using GodzillaLocadora.WebAPI.Services.Interface;

namespace GodzillaLocadora.WebAPI.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IAuthService _auth;

        public UsuarioService(IUsuarioRepository repo, IAuthService auth)
        {
            _repo = repo;
            _auth = auth;
        }

        public async Task<(UsuarioResponse usuario, string token)> CriarUsuarioAsync(LoginRequest request)
        {
            var usuario = new Usuario
            {
                Email = request.Email,
                Senha = request.Senha,
                Nome = request.Email.Split('@')[0]
            };

            var criado = await _repo.CriarAsync(usuario);

            return (new UsuarioResponse
            {
                Id = criado.Id,
                Email = criado.Email,
                Nome = criado.Nome
            }, _auth.GerarToken(criado));
        }
    }
}
