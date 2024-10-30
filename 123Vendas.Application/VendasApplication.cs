using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using _123Vendas.Infra.Data.Respositories._123Vendas;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Application;

public class VendasApplication
{
    private readonly AppVendasContext _context;
    private VendasRepository _vendasRepository;
    private ItemRepository _itemRepository;

    public VendasApplication(AppVendasContext context, VendasRepository vendasRepository, ItemRepository itemRepository)
    {
        _context = context;
        _vendasRepository = vendasRepository;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<VendasResponse>> GetVenda()
    {
        IEnumerable<Venda> listaVendas = await _vendasRepository.GetVenda();

        return listaVendas.Select(x => (VendasResponse)x);
    }

    public async Task<VendasResponse> GetVenda(int numeroVenda)
    {
        var venda = await _vendasRepository.GetVenda(numeroVenda);

        return venda;
    }
    
    public async Task<VendasResponse> InsertVenda(VendasResquest venda)
    {
        Venda vendainsert = new Venda() 
        { 
            DataVenda = DateTime.Now,
            Status = 1,
            UIDCliente = new Guid(venda.Cliente),
            UIDFilial = new Guid(venda.Filial),
            ValorTotal = venda.Itens.Sum(i => i.ValorItem)                     
        };

        await _vendasRepository.CreateVenda(vendainsert);

        foreach (ItemRequest item in venda.Itens)
        {
            Item intemInser = new Item() 
            { 
                UIDVenda = vendainsert.UID,
                UIDProduto = new Guid(item.Produto),
                Quantidade = item.Quantidade,
                Desconto = item.Desconto,
                ValorItem = item.ValorItem                    
            };

            await _itemRepository.CreateItem(intemInser);

            vendainsert.Itens.Add(intemInser);
        }

        return vendainsert;
    }

    public async Task<VendasResponse> UpdateVenda(int numeroVenda, Venda venda)
    {
        if (numeroVenda != venda.NumeroVenda)
        {
            throw new ArgumentException("Dados inconsistentes");
        }

        return await _vendasRepository.UpdateVenda(venda);
    }

    public async Task DeleteVenda(int numerovenda)
    {
        await _vendasRepository.DeleteVenda(numerovenda);
    }
}
