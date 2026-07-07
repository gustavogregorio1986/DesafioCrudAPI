using Xunit;
using Moq;
using DesafioCrudAPI.Entidade.Contato;
using DesafioCrudAPI.Entidade.Enum;
using DesafioCrudAPI.Service.Service;
using DesafioCrudAPI.Repository.Repository.Interface;

namespace DesafioCrudAPI.Test.Testes
{
    public class ContatoServiceTests
    {
        [Fact]
        public async Task AdicionarContato_DeveLancarExcecao_SeIdadeZero()
        {
            var repoMock = new Mock<IContatoRepository>();
            var service = new ContatoService(repoMock.Object);

            var contato = new Contato
            {
                NomeContato = "Teste",
                Email = "teste@email.com",
                DataNascimento = DateTime.Today, // idade = 0
                Sexo = EnumSexo.Masculino
            };

            var ex = await Assert.ThrowsAsync<Exception>(() => service.AdicionarContatoAsync(contato));
            Assert.Equal("Idade não pode ser igual a 0.", ex.Message);
        }

        [Fact]
        public async Task AdicionarContato_DeveLancarExcecao_SeMenorDe18()
        {
            var repoMock = new Mock<IContatoRepository>();
            var service = new ContatoService(repoMock.Object);

            var contato = new Contato
            {
                NomeContato = "Menor",
                Email = "menor@email.com",
                DataNascimento = DateTime.Today.AddYears(-15), // 15 anos
                Sexo = EnumSexo.Feminino
            };

            var ex = await Assert.ThrowsAsync<Exception>(() => service.AdicionarContatoAsync(contato));
            Assert.Equal("Contato deve ser maior de idade (mínimo 18 anos).", ex.Message);
        }

        [Fact]
        public async Task AdicionarContato_DeveSalvar_SeMaiorDe18()
        {
            var repoMock = new Mock<IContatoRepository>();
            repoMock.Setup(r => r.AdicionarAsync(It.IsAny<Contato>()))
                    .Returns(Task.CompletedTask);

            var service = new ContatoService(repoMock.Object);

            var contato = new Contato
            {
                NomeContato = "Adulto",
                Email = "adulto@email.com",
                DataNascimento = DateTime.Today.AddYears(-40), // 40 anos
                Sexo = EnumSexo.Masculino
            };

            await service.AdicionarContatoAsync(contato);

            repoMock.Verify(r => r.AdicionarAsync(It.IsAny<Contato>()), Times.Once);
        }
    }
}
