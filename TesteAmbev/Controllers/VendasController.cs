using _123Vendas.Application;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TesteAmbev.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly AppVendasContext _context;
    private readonly VendasApplication _applicationVendas;

    public VendasController(AppVendasContext context, VendasApplication applicationVendas)
    {
        _context = context;
        _applicationVendas = applicationVendas;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendasResponse>>> GetVenda()
    {
        var vendas = await _applicationVendas.GetVenda();

        return !vendas.Any() ? NoContent() : Ok(vendas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Venda>> GetVenda(int id)
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
        var vendaCriada = await _applicationVendas.InsertVenda(venda);

        return CreatedAtAction("GetVenda", new { id = vendaCriada.VendaId }, vendaCriada);
    }
}
