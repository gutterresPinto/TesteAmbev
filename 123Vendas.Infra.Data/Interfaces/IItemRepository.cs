using _123Vendas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Infra.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> CreateItem(Item item);

        Task<Item> UpdateItem(Item item);

        Task DeleteItem(string id);
        
    }
}
