using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;

using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Application
{
    public class VendasApplication
    {
        private readonly AppVendasContext _context;
        private VendasRepository _vendasRepository;

        public VendasApplication(AppVendasContext context, VendasRepository vendasRepository)
        {
            _context = context;
            _vendasRepository = vendasRepository;
        }

        public async Task<IEnumerable<VendasResponse>> GetVenda()
        {
            IEnumerable<Venda> listaVendas = await _vendasRepository.GetVenda();

            return listaVendas.Select(x => (VendasResponse)x);
        }

        public async Task<Venda> GetVenda(int numeroVenda)
        {
            var venda = await _vendasRepository.GetVenda(numeroVenda);

            return venda;
        }
        
        public async Task<Venda> InsertVenda(Venda venda)
        {
            
            venda.DataVenda = DateTime.Now;
            venda.Status = 1;

            return await _vendasRepository.CreateVenda(venda);
        }

        public async Task DeleteVenda(int numerovenda)
        {
            await _vendasRepository.DeleteVenda(numerovenda);
        }
    }
}
