using _123Vendas.Application.DTO.FilialDTO;
using _123Vendas.Application.DTO.ProdutoDTO;
using _123Vendas.Application;
using _123Vendas.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Domain;

namespace TesteAmbev.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly AppVendasContext _context;
    private readonly ClientesApplication _applicationCliente;

    public ClienteController(AppVendasContext context, ClientesApplication applicationCliente)
    {
        _context = context;
        _applicationCliente = applicationCliente;
        
    }

    [HttpGet("{documento}")]
    public async Task<ActionResult<ClienteResponse>> Get(string documento)
    {
        var cliente = await _applicationCliente.GetCliente(documento);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpGet("PrepararBase")]
    public async Task<ActionResult> PrepararBase()
    {
        try
        {
            ClienteRequest cliente = new ClienteRequest() { Documento = "00585745045", Nome = "Renato Gutterres" };            

            await _applicationCliente.InsertCliente(cliente);
            
        }
        catch (Exception)
        {

            return BadRequest();

        }

        return Ok();
    }

}
