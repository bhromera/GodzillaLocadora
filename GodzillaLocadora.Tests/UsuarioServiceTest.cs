using GodzillaLocadora.WebAPI.Auth;
using GodzillaLocadora.WebAPI.DTO.Requests;
using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Repositories.Interface;
using GodzillaLocadora.WebAPI.Services.Implementation;
using Moq;

namespace GodzillaLocadora.Tests
{
    public class UsuarioServiceTest
    {
        [Fact]
        public async Task CriarUsuario_DeveRetornarUsuarioResponseComToken()
        {
            // Arrange
            var usuarioRepoMock = new Mock<IUsuarioRepository>();
            var authMock = new Mock<IAuthService>();

            var fakeUsuario = new Usuario
            {
                Id = 1,
                Email = "teste@email.com",
                Nome = "teste",
                Senha = "1234"
            };

            usuarioRepoMock.Setup(r => r.CriarAsync(It.IsAny<Usuario>()))
                .ReturnsAsync(fakeUsuario);

            authMock.Setup(a => a.GerarToken(It.IsAny<Usuario>()))
                .Returns("token.fake.jwt");

            var usuarioService = new UsuarioService(usuarioRepoMock.Object, authMock.Object);

            var request = new LoginRequest
            {
                Email = "teste@email.com",
                Senha = "1234"
            };

            // Act
            var (usuario, token) = await usuarioService.CriarUsuarioAsync(request);

            // Assert
            Assert.Equal(fakeUsuario.Id, usuario.Id);
            Assert.Equal(fakeUsuario.Email, usuario.Email);
            Assert.Equal(fakeUsuario.Nome, usuario.Nome);
            Assert.Equal("token.fake.jwt", token);
        }
    }
}
