using FizzWare.NBuilder;
using LojaDropS.Dominio;
using LojaDropS.Infra.Interfaces;
using LojaDropS.Servicos.Vendas.Controllers;
using LojaDropS.Servicos.Vendas.Results;
using LojaDropS.Servicos.Vendas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LojaDropS.Servicos.Vendas.Tests.Controllers
{
    public class ProdutosControllerTests
    {
        private readonly ProdutosController _controller;
        private readonly Mock<IProdutoStore> _mockIProdutoStore;

        public ProdutosControllerTests()
        {
            _mockIProdutoStore = new Mock<IProdutoStore>();

            _controller = new ProdutosController(_mockIProdutoStore.Object);
        }

        [Fact]
        public async Task Get_SemParameteros_DeveRetornarLista()
        {
            // Arrange
            var listaProdutos = Builder<Produto>
                .CreateListOfSize(10)
                .Build()
                .AsQueryable();

            _mockIProdutoStore.SetupGet(p => p.Produtos)
                .Returns(() => listaProdutos);

            // Act
            var result = await _controller.Get(string.Empty);
            var okResult = result as OkObjectResult;
            var lista = okResult?.Value as IEnumerable<DisplayProdutoViewModel>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => okResult.ShouldNotBeNull(),
                () => okResult.StatusCode.ShouldBe(200),
                () => lista.ShouldNotBeNull(),
                () => lista.ShouldNotBeEmpty());
        }

        [Fact]
        public async Task Get_ComParametro_DeveRetornarLista()
        {
            // Arrange
            const string Query = "marcax";
            const int Display = 5;
            var listaProdutos = Builder<Produto>
                .CreateListOfSize(10)
                .Build();
            var produtoPesquisa = new Produto
            {
                Nome = "TV 42\" MarcaX",
                Descricao = "SmartTV 42 polegadas 4K ",
                Valor = 2099,
                FornecedorId = Guid.NewGuid(),
                CategoriaId = Guid.NewGuid(),
            };
            listaProdutos.Add(produtoPesquisa);
            _mockIProdutoStore.SetupGet(p => p.Produtos)
                .Returns(() => listaProdutos.AsQueryable());

            // Act
            var result = await _controller.Get(Query, display: Display);
            var okResult = result as OkObjectResult;
            var lista = okResult?.Value as IEnumerable<DisplayProdutoViewModel>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => okResult.ShouldNotBeNull(),
                () => okResult.StatusCode.ShouldBe(200),
                () => lista.ShouldNotBeNull(),
                () => lista.ShouldNotBeEmpty(),
                () => lista.Any(p => p.Descricao == produtoPesquisa.Descricao).ShouldBeTrue());
        }

        [Fact]
        public async Task Get_ComPaginacao_DeveRetornarLista()
        {
            // Arrange
            const int Pagina = 2;
            const int Display = 15;
            var listaProdutos = Builder<Produto>
                .CreateListOfSize(70)
                .Build()
                .AsQueryable();

            _mockIProdutoStore.SetupGet(p => p.Produtos)
                .Returns(() =>
                {
                    return listaProdutos;
                });

            // Act
            var result = await _controller.Get(string.Empty, Pagina, Display);
            var okResult = result as OkObjectResult;
            var lista = okResult?.Value as IEnumerable<DisplayProdutoViewModel>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => okResult.ShouldNotBeNull(),
                () => okResult.StatusCode.ShouldBe(200),
                () => lista.ShouldNotBeNull(),
                () => lista.ShouldNotBeEmpty(),
                () => lista.Count().ShouldBe(Display));
        }

        [Fact]
        public async Task Post_Sucesso_DeveRetornarObjeto()
        {
            // Arrange
            _mockIProdutoStore.Setup(p => p.AddAsync(It.IsAny<Produto>()))
                .Returns<Produto>((produtoToAdd) => 
                {
                    return Task.FromResult(produtoToAdd);
                });

            var produto = new CadastroProdutoViewModel
            {
                CategoriaId = Guid.NewGuid().ToString(),
                FornecedorId = Guid.NewGuid().ToString(),
                Caracteristicas = new Dictionary<string, string>()
            };

            // Act
            var result = await _controller.Post(produto);
            var okResult = result as OkObjectResult;
            var produtoResult = okResult?.Value as DisplayProdutoViewModel;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => okResult.ShouldNotBeNull(),
                () => produtoResult.ShouldNotBeNull(),
                () => produtoResult.CategoriaId.ShouldBe(produto.CategoriaId),
                () => produtoResult.FornecedorId.ShouldBe(produto.FornecedorId));
        }

        [Fact]
        public async Task Post_ModelStateInvalido_DeveRetornarBadRequest()
        {
            // Arrange
            const string DummyMessage = "Dummy Error Message";
            const string Key = "DummyKey";
            var cadastro = new CadastroProdutoViewModel();
            _controller.ModelState.AddModelError(Key, DummyMessage);

            // Act
            var result = await _controller.Post(cadastro);
            var badRequestResult = result as BadRequestObjectResult;
            var statusCode = badRequestResult?.StatusCode;
            var modelState = badRequestResult?.Value as IDictionary<string, object>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => modelState.ShouldNotBeNull(),
                () => statusCode.ShouldBe(400),
                () => modelState.ContainsKey(Key).ShouldBeTrue());
        }

        [Fact]
        public async Task Post_Excecao_DeveRetornarServerError()
        {
            // Arrange
            const string DummyException = "Dummy exception message";
            _mockIProdutoStore.Setup(p => p.AddAsync(It.IsAny<Produto>()))
                .ThrowsAsync(new Exception(DummyException));
            var produto = new CadastroProdutoViewModel
            {
                CategoriaId = Guid.NewGuid().ToString(),
                FornecedorId = Guid.NewGuid().ToString(),
                Caracteristicas = new Dictionary<string, string>()
            };

            // Act
            var result = await _controller.Post(produto);
            var errorResult = result as ServerErrorObjectResult;
            var error = errorResult?.Value as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => errorResult.ShouldNotBeNull(),
                () => errorResult.StatusCode.ShouldBe(500),
                () => error.ShouldNotBeNullOrEmpty(),
                () => error.ShouldBe(DummyException));
        }

    }
}
