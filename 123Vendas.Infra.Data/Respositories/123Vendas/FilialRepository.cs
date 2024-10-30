using _123Vendas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Infra.Data.Respositories._123Vendas;

public  class FilialRepository
{
    private AppVendasContext _dbContext;

    public FilialRepository(AppVendasContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Filial>> GetFilial()
    {
        return await _dbContext.Filial.ToListAsync();
    }

    public async Task<Filial> CreateFilial(Filial filial)
    {
        filial.UID = Guid.NewGuid();

        _dbContext.Filial.Add(filial);
        await _dbContext.SaveChangesAsync();

        return filial;
    }
}
