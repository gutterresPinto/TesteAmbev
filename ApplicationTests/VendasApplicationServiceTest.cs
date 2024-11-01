using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using _123Vendas.Infra.Data.Interfaces;
using _123Vendas.Infra.Data.Respositories._123Vendas;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace ApplicationTests
{
    public class VendasApplicationServiceTest
    {
        private Mock<AppVendasContext> _contextMock = new();
        private Mock<IItemRepository> _itemRepositoryMock = new();// new Mock<IItemRepository>(new Mock<AppVendasContext>().Object);
        private Mock<IVendasRepository> _vendasRepositoryMock = new(); //new Mock<IVendasRepository>(new Mock<AppVendasContext>().Object);
        

        private VendasApplication GetSystemUnderTest()
        {
            return new VendasApplication(_contextMock.Object, _vendasRepositoryMock.Object, _itemRepositoryMock.Object);
        }

        private void ClearDependencies()
        {
            _itemRepositoryMock.Reset();
            _vendasRepositoryMock.Reset();
            _contextMock.Reset();
        }


        [Fact]
        public void GenerateTestGetVendas()
        {
            ClearDependencies();

            Guid guidvenda = new Guid();

            _vendasRepositoryMock
                .Setup(x => x.GetVendas())
                .ReturnsAsync([new Venda() { UID = guidvenda, NumeroVenda = 123876, DataVenda = DateTime.Now, UIDCliente = new Guid(), UIDFilial = new Guid(), Status = 1, Itens = [ new Item() { UID = new Guid() } ] }]);

            var application = GetSystemUnderTest();

            var task = application.GetVenda();
            task.Wait();
            var resultado = task.Result;


            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
            Assert.StartsWith(guidvenda.ToString(), resultado.FirstOrDefault().VendaId);
        }

        [Fact]
        public void GenerateTestGetVendasPorNUmero()
        {
            ClearDependencies();

            Guid guidvenda = new Guid();
            int numero = 123876;

            _vendasRepositoryMock
                .Setup(x => x.GetVendaPorNumero(numero))
                .ReturnsAsync(new Venda() { UID = guidvenda, NumeroVenda = numero, DataVenda = DateTime.Now, UIDCliente = new Guid(), UIDFilial = new Guid(), Status = 1, Itens = [new Item() { UID = new Guid() }] });

            var application = GetSystemUnderTest();

            var task = application.GetVenda(numero);
            task.Wait();
            var resultado = task.Result;


            Assert.NotNull(resultado);
            Assert.StartsWith(guidvenda.ToString(), resultado.VendaId);
        }

        [Fact]
        public void GenerateTestGetVendasPorId()
        {
            ClearDependencies();

            Guid guidvenda = new Guid();

            _vendasRepositoryMock
                .Setup(x => x.GetVendaPorId(guidvenda.ToString()))
                .ReturnsAsync(new Venda() { UID = guidvenda, NumeroVenda = 123876, DataVenda = DateTime.Now, UIDCliente = new Guid(), UIDFilial = new Guid(), Status = 1, Itens = [new Item() { UID = new Guid() }] });

            var application = GetSystemUnderTest();

            var task = application.GetVenda(guidvenda.ToString());
            task.Wait();
            var resultado = task.Result;


            Assert.NotNull(resultado);
            Assert.StartsWith(guidvenda.ToString(), resultado.VendaId);
        }
    }
}