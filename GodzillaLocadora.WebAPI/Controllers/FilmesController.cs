using GodzillaLocadora.WebAPI.Data;
using GodzillaLocadora.WebAPI.DTO.Requests;
using GodzillaLocadora.WebAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaLocadora.WebAPI.Controllers
{
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [Authorize]
        [HttpPost("godzilla")]
        public async Task<IActionResult> Alugar([FromBody] AluguelRequest req)
        {
            var sucesso = await _filmeService.AlugarFilmeAsync(req.FilmeId);
            return sucesso ? Ok("Aluguel confirmado") : Forbid();
        }

        [Authorize]
        [HttpGet("locadora/godzilla")]        
        public async Task<IActionResult> BuscarPorTitulo([FromQuery] string titulo)
        {
            var filmes = await _filmeService.BuscarFilmesAsync(titulo);

            return Ok(filmes);
        }
    }
}
