using _123Vendas.Application;
using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Application.DTO.FilialDTO;
using _123Vendas.Application.DTO.ProdutoDTO;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace TesteAmbev.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly AppVendasContext _context;
    private readonly VendasApplication _applicationVendas;
    private readonly ClientesApplication _applicationCliente;
    private readonly ProdutoApplication _applicationProduto;
    private readonly FilialApplication _applicationFilial;

    public VendasController(AppVendasContext context, VendasApplication applicationVendas, ClientesApplication applicationCliente, ProdutoApplication Applicationproduto, FilialApplication applicationFilial)
    {
        _context = context;
        _applicationVendas = applicationVendas;
        _applicationCliente = applicationCliente;
        _applicationProduto = Applicationproduto;
        _applicationFilial = applicationFilial;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendasResponse>>> GetVendas()
    {
        Log.Information("Buscando Lista de Vendas");

        var vendas = await _applicationVendas.GetVenda();

        return !vendas.Any() ? NoContent() : Ok(vendas);
    }

    [HttpGet("GetVendaPorNumero/{numero}")]
    public async Task<ActionResult<Venda>> GetVenda(int numero)
    {
        var venda = await _applicationVendas.GetVenda(numero);

        if (venda == null)
        {
            return NotFound();
        }

        return Ok(venda);
    }

    [HttpGet("GetVendaPorId/{id}")]
    public async Task<ActionResult<Venda>> GetVenda(string id)
    {
        var venda = await _applicationVendas.GetVenda(id);

        if (venda == null)
        {
            return NotFound();
        }

        return Ok(venda);
    }

    [HttpPost]
    public async Task<ActionResult<VendasResponse>> PostVenda(VendasResquest venda)
    {
        Log.Information("Inserindo Venda");

        var vendaCriada = await _applicationVendas.InsertVenda(venda);

        return CreatedAtAction("GetVenda", new { id = vendaCriada.VendaId }, vendaCriada);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenda(string id, VendasResquest venda)
    {
        if (id != venda.VendaId)
        {
            return BadRequest();
        }

        var vendaAtualizada = await _applicationVendas.UpdateVenda(id, venda);

        return CreatedAtAction("GetVenda", new { id = vendaAtualizada.VendaId }, vendaAtualizada);
    }


    // DELETE: api/VendasTeste/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenda(string id)
    {
        await _applicationVendas.DeleteVenda(id);

        return NoContent();
    }


    [HttpGet("PrepararBase")]
    public async Task<ActionResult<VendasResponse>> PrepararBase()
    {
        try
        {
            ProdutoRequest produto1 = new ProdutoRequest() { CodigoProduto = 123, Nome = "Produto 1", Valor = 22M };
            ProdutoRequest produto2 = new ProdutoRequest() { CodigoProduto = 124, Nome = "Produto 2", Valor = 12M };
            ProdutoRequest produto3 = new ProdutoRequest() { CodigoProduto = 125, Nome = "Produto 3", Valor = 54M };
            ProdutoRequest produto4 = new ProdutoRequest() { CodigoProduto = 126, Nome = "Produto 4", Valor = 19M };

            ProdutoResponse p1 = await _applicationProduto.InsertProduto(produto1);
            ProdutoResponse p2 = await _applicationProduto.InsertProduto(produto2);
            ProdutoResponse p3 = await _applicationProduto.InsertProduto(produto3);
            ProdutoResponse p4 = await _applicationProduto.InsertProduto(produto4);

            FilialRequest filial = new FilialRequest() { Nome = "Filial 1" };

            FilialReponse f1 = await _applicationFilial.InsertFilial(filial);

            ClienteRequest cliente = new ClienteRequest() { Documento = "00585745045", Nome = "Renato Gutterres" };

            ClienteResponse c1 = await _applicationCliente.InsertCliente(cliente);

            ItemRequest it1 = new ItemRequest() { Produto = p1.ProdutoID, Quantidade = 2, ValorItem = 44M };
            

            VendasResquest vend = new VendasResquest() { DataVenda = DateTime.Now, Cliente = c1.ClienteID, Filial = f1.FilialId, Status = 1 };
            vend.Itens = [it1];

            var vendaCriada = await _applicationVendas.InsertVenda(vend);

            return CreatedAtAction("GetVenda", new { id = vendaCriada.VendaId }, vendaCriada);
        }
        catch (Exception)
        {

            return BadRequest();

        }        
    }

}
