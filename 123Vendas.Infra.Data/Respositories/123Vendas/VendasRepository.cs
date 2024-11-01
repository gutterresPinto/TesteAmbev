using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using _123Vendas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace __123Vendas.Infra.Data.Respositories._123Vendas
{
    public class VendasRepository : IVendasRepository
    {
        private AppVendasContext _dbContext;

        public VendasRepository(AppVendasContext context)
        { 
            _dbContext = context;
        }

        private async Task<bool> VendaExists(string id)
        {
            return await _dbContext.Venda.AnyAsync(e => e.UID.ToString() == id);
        }

        public async Task<IEnumerable<Venda>> GetVendas()
        {
            var query = (_dbContext.Venda).AsNoTracking();

            query = query.Include(v => v.Itens).ThenInclude(i => i.Produto);            
            query = query.Include(v => v.Cliente);
            query = query.Include(v => v.Filial);

            return await query.ToListAsync();
        }

        public async Task<Venda> GetVendaPorNumero(int numeroVenda)
        {
            var query = (_dbContext.Venda).AsNoTracking();

            query = query.Include(v => v.Itens).ThenInclude(i => i.Produto);
            query = query.Include(v => v.Cliente);
            query = query.Include(v => v.Filial);

            return await query.Where(v => v.NumeroVenda == numeroVenda).FirstAsync();            
        }

        public async Task<Venda> GetVendaPorId(string id)
        {
            var query = (_dbContext.Venda).AsNoTracking();

            query = query.Include(v => v.Itens).ThenInclude(i => i.Produto);
            query = query.Include(v => v.Cliente);
            query = query.Include(v => v.Filial);

            return await query.Where(v => v.UID.ToString() == id).FirstAsync();
        }

        public async Task<Venda> CreateVenda(Venda venda)
        {
            venda.UID = Guid.NewGuid();
            
            _dbContext.Venda.Add(venda);
            await _dbContext.SaveChangesAsync();

            return venda;
        }

        public async Task<Venda> UpdateVenda(Venda venda)
        {
            _dbContext.Entry(venda).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VendaExists(venda.UID.ToString()))
                {
                    throw new InvalidOperationException("Venda Inexistente");
                }
                else
                {
                    throw;
                }
            }

            return venda;
        }

        public async Task DeleteVenda(string id)
        {
            var venda = await _dbContext.Venda.FirstOrDefaultAsync(v => v.UID.ToString() == id);

            if (venda != null)
            {
                _dbContext.Venda.Remove(venda);
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}
