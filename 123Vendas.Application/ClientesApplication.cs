using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using _123Vendas.Infra.Data.Respositories._123Vendas;

namespace _123Vendas.Application;

public  class ClientesApplication
{
    private readonly AppVendasContext _context;

    private ClientesRepository _clientesRepository;    

    public ClientesApplication(AppVendasContext context, ClientesRepository clientesRepository)
    {
        _context = context;
        _clientesRepository = clientesRepository;        
    }

    public async Task<ClienteResponse> GetCliente(string documento)
    {
        var cliente = await _clientesRepository.GetCliente(documento);

        return cliente;
    }

    public async Task<ClienteResponse> InsertCliente(ClienteRequest cliente)
    {
        Cliente clienteInsert = new Cliente()
        {
            Documento = cliente.Documento,
            Nome = cliente.Nome            
        };

        await _clientesRepository.CreateCliente(clienteInsert);

        return clienteInsert;
    }
}
