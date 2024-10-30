using _123Vendas.Application;
using _123Vendas.Application.DTO.FilialDTO;
using _123Vendas.Application.DTO.ProdutoDTO;
using _123Vendas.Infra.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteAmbev.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstoqueController : ControllerBase
{
    private readonly AppVendasContext _context;
    private readonly ProdutoApplication _applicationProduto;
    private readonly FilialApplication _applicationFilial;

    public EstoqueController(AppVendasContext context, ProdutoApplication Applicationproduto, FilialApplication applicationFilial)
    {
        _context = context;
        _applicationProduto = Applicationproduto;
        _applicationFilial = applicationFilial;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoResponse>>> Get()
    {
        var produtos = await _applicationProduto.GetProduto();

        return !produtos.Any() ? NoContent() : Ok(produtos);
    }

    [HttpGet("GetFilial")]
    public async Task<ActionResult<IEnumerable<FilialReponse>>> GetFilial()
    {
        var filiais = await _applicationFilial.GetFilial();

        return !filiais.Any() ? NoContent() : Ok(filiais);
    }

    [HttpGet("PrepararBase")]
    public async Task<ActionResult> PrepararBase()
    {
        try
        {
            ProdutoRequest produto1 = new ProdutoRequest() { CodigoProduto = 123, Nome = "Produto 1", Valor = 22M };
            ProdutoRequest produto2 = new ProdutoRequest() { CodigoProduto = 124, Nome = "Produto 2", Valor = 12M };
            ProdutoRequest produto3 = new ProdutoRequest() { CodigoProduto = 125, Nome = "Produto 3", Valor = 54M };
            ProdutoRequest produto4 = new ProdutoRequest() { CodigoProduto = 126, Nome = "Produto 4", Valor = 19M };

            await _applicationProduto.InsertProduto(produto1);
            await _applicationProduto.InsertProduto(produto2);
            await _applicationProduto.InsertProduto(produto3);
            await _applicationProduto.InsertProduto(produto4);

            FilialRequest filial = new FilialRequest() { Nome = "Filial 1" };

            await _applicationFilial.InsertFilial(filial);
        }
        catch (Exception)
        {

            return BadRequest();

        }

        return Ok();
    }

    
    
}
