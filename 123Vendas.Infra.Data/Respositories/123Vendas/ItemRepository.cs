using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Infra.Data.Respositories._123Vendas;

public class ItemRepository
{
    private AppVendasContext _dbContext;

    public ItemRepository(AppVendasContext context)
    {
        _dbContext = context;
    }

    public async Task<Item> CreateItem(Item item)
    {
        item.UID = Guid.NewGuid();

        _dbContext.Item.Add(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }
}
