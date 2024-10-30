using _123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _123Vendas.Application.DTO.FilialDTO;
using _123Vendas.Domain;
using _123Vendas.Application.DTO.ProdutoDTO;

namespace _123Vendas.Application;

public class ProdutoApplication
{
    private readonly AppVendasContext _context;

    private ProdutoRepository _produtoRepository;

    public ProdutoApplication(AppVendasContext context, ProdutoRepository produtoRepository)
    {
        _context = context;
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<ProdutoResponse>> GetProduto()
    {
        IEnumerable<Produto> listaVendas = await _produtoRepository.GetProduto();

        return listaVendas.Select(x => (ProdutoResponse)x);
    }

    public async Task<ProdutoResponse> InsertProduto(ProdutoRequest produto)
    {
        Produto produtoInsert = new Produto()
        {
            CodigoProduto = produto.CodigoProduto,
            Nome = produto.Nome,
            Valor = produto.Valor            
        };

        await _produtoRepository.CreateProduto(produtoInsert);

        return produtoInsert;
    }
}
