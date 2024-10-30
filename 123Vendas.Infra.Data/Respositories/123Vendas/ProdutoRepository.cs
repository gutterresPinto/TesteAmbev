using _123Vendas.Domain;


namespace _123Vendas.Infra.Data.Respositories._123Vendas;

public  class ProdutoRepository
{
    private AppVendasContext _dbContext;

    public ProdutoRepository(AppVendasContext context)
    {
        _dbContext = context;
    }

    public async Task<Produto> CreateProduto(Produto produto)
    {
        produto.UID = Guid.NewGuid();

        _dbContext.Produto.Add(produto);
        await _dbContext.SaveChangesAsync();

        return produto;
    }
}
