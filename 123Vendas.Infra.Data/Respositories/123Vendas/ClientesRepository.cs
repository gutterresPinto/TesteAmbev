using _123Vendas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Infra.Data.Respositories._123Vendas
{
    public  class ClientesRepository
    {
        private AppVendasContext _dbContext;

        public ClientesRepository(AppVendasContext context)
        {
            _dbContext = context;
        }

        public async Task<Cliente> GetCliente(string documento)
        {
            var cliente = await _dbContext.Cliente.FirstOrDefaultAsync(c => c.Documento == documento);

            return cliente;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            cliente.UID = Guid.NewGuid();

            _dbContext.Cliente.Add(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }
    }
}
