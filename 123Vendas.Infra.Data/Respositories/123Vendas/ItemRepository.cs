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

    private async Task<bool> ItemExists(string id)
    {
        return await _dbContext.Item.AnyAsync(e => e.UID.ToString() == id);
    }

    public async Task<Item> CreateItem(Item item)
    {
        item.UID = Guid.NewGuid();

        _dbContext.Item.Add(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<Item> UpdateItem(Item item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ItemExists(item.UID.ToString()))
            {
                throw new InvalidOperationException("Item Inexistente");
            }
            else
            {
                throw;
            }
        }

        return item;
    }

    public async Task DeleteItem(string id)
    {
        var item = await _dbContext.Item.FindAsync(id);

        if (item != null)
        {
            _dbContext.Item.Remove(item);
        }

        await _dbContext.SaveChangesAsync();
    }
}
