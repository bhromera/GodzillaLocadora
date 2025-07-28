using GodzillaLocadora.WebAPI.Models;

namespace GodzillaLocadora.WebAPI.Auth
{
    public interface IAuthService
    {
        public string GerarToken(Usuario usuario);
    }
}
