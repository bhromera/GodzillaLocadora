using GodzillaLocadora.WebAPI.Auth;
using GodzillaLocadora.WebAPI.Data;
using GodzillaLocadora.WebAPI.DTO.Requests;
using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaLocadora.WebAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> CriarUsuario(LoginRequest request)
        {
            var (usuario, token) = await _usuarioService.CriarUsuarioAsync(request);

            return Ok(new
            {
                auth = true,
                usuario,
                token
            });
        }
    }
}
