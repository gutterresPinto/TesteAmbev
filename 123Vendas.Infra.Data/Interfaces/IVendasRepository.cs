using _123Vendas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Infra.Data.Interfaces
{
    public interface IVendasRepository
    {
        Task<IEnumerable<Venda>> GetVendas();


        Task<Venda> GetVendaPorNumero(int numeroVenda);


        Task<Venda> GetVendaPorId(string id);
        

        Task<Venda> CreateVenda(Venda venda);


        Task<Venda> UpdateVenda(Venda venda);


        Task DeleteVenda(string id);
        
    }
}
