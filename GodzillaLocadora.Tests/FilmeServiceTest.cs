using GodzillaLocadora.WebAPI.Models;
using GodzillaLocadora.WebAPI.Repositories.Interface;
using GodzillaLocadora.WebAPI.Services.Implementation;
using Moq;

namespace GodzillaLocadora.Tests
{
    public class FilmeServiceTests
    {
        [Fact]
        public async Task AlugarFilme_QuandoFilmeTemEstoque_DeveRetornarTrue()
        {
            // Arrange
            var filmeRepoMock = new Mock<IFilmeRepository>();

            var filme = new Filme
            {
                FilmeId = 1,
                Titulo = "Godzilla",
                Estoque = 3
            };

            filmeRepoMock.Setup(r => r.ObterPorIdAsync(filme.FilmeId))
                .ReturnsAsync(filme);

            filmeRepoMock.Setup(r => r.AtualizarAsync(It.IsAny<Filme>()))
                .ReturnsAsync(true);

            var service = new FilmeService(filmeRepoMock.Object);

            // Act
            var resultado = await service.AlugarFilmeAsync(1);

            // Assert
            Assert.True(resultado);
            filmeRepoMock.Verify(r => r.AtualizarAsync(It.Is<Filme>(f => f.Estoque == 2)), Times.Once);
        }

        [Fact]
        public async Task AlugarFilme_QuandoSemEstoque_DeveRetornarFalse()
        {
            var repoMock = new Mock<IFilmeRepository>();
            repoMock.Setup(r => r.ObterPorIdAsync(1))
                .ReturnsAsync(new Filme { FilmeId = 1, Estoque = 0 });

            var service = new FilmeService(repoMock.Object);
            var resultado = await service.AlugarFilmeAsync(1);

            Assert.False(resultado);
        }
    }
}
