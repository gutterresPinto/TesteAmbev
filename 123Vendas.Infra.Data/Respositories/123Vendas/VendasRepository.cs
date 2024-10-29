using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace __123Vendas.Infra.Data.Respositories._123Vendas
{
    public class VendasRepository
    {
        private AppVendasContext _dbContext;

        public VendasRepository(AppVendasContext context)
        { 
            _dbContext = context;
        }

        public async Task<IEnumerable<Venda>> GetVenda()
        {
            return await _dbContext.Venda.ToListAsync();
        }

        public async Task<Venda> GetVenda(int numeroVenda)
        {
            var venda = await _dbContext.Venda.FindAsync(numeroVenda);

            return venda;
        }

        public async Task<Venda> CreateVenda(Venda venda)
        {
            venda.UID = Guid.NewGuid();
            
            _dbContext.Venda.Add(venda);
            await _dbContext.SaveChangesAsync();

            return venda;
        }

        public async Task DeleteVenda(int numeroVenda)
        {
            var venda = await _dbContext.Venda.FindAsync(numeroVenda);

            if (venda != null)
            {
                _dbContext.Venda.Remove(venda);
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}
