using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using _123Vendas.Infra.Data;
using _123Vendas.Infra.Data.Interfaces;
using _123Vendas.Infra.Data.Respositories._123Vendas;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace _123Vendas.Application;

public class VendasApplication
{
    private readonly AppVendasContext _context;
    private IVendasRepository _vendasRepository;
    private IItemRepository _itemRepository;

    public VendasApplication(AppVendasContext context, IVendasRepository vendasRepository, IItemRepository itemRepository)
    {
        _context = context;
        _vendasRepository = vendasRepository;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<VendasResponse>> GetVenda()
    {
        IEnumerable<Venda> listaVendas = await _vendasRepository.GetVendas();

        return listaVendas.Select(x => (VendasResponse)x);
    }

    public async Task<VendasResponse> GetVenda(int numeroVenda)
    {
        var venda = await _vendasRepository.GetVendaPorNumero(numeroVenda);

        return venda;
    }

    public async Task<VendasResponse> GetVenda(string id)
    {
        var venda = await _vendasRepository.GetVendaPorId(id);

        return venda;
    }

    public async Task<VendasResponse> InsertVenda(VendasResquest venda)
    {
        Log.Information("Inserindo Venda");

        Log.Debug("Dados", venda);


        Log.Information($"Data da  Venda {DateTime.Now}");
        Log.Information($"Cliente {venda.Cliente}");
        Log.Information($"Filial {venda.Filial}");

        Venda vendainsert = new Venda() 
        { 
            NumeroVenda = (int)DateTime.Now.Ticks,
            DataVenda = DateTime.Now,
            Status = 1,
            UIDCliente = new Guid(venda.Cliente),
            UIDFilial = new Guid(venda.Filial),
            ValorTotal = venda.Itens.Sum(i => i.ValorItem)                     
        };

        try
        {
            await _vendasRepository.CreateVenda(vendainsert);
        }
        catch (Exception ex)
        {
            Log.Error($"Erro ao gravar venda. {ex.Message}");
            throw;
        }


        try
        {
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
        }
        catch (Exception ex)
        {
            Log.Error($"Erro ao gravar item de venda. {ex.Message}");
            throw;
        }        

        return vendainsert;
    }

    public async Task<VendasResponse> UpdateVenda(string id, VendasResquest venda)
    {
        if (id != venda.VendaId)
        {
            Log.Error($"Dados inconsistentes");
            throw new ArgumentException("Dados inconsistentes");
        }

        Log.Information("Atualizandi Venda");

        Log.Debug("Dados", venda);

        Log.Information($"Data da  Venda {venda.DataVenda}");
        Log.Information($"Cliente {venda.Cliente}");
        Log.Information($"Filial {venda.Filial}");

        Venda vendaAtualizar = new Venda()
        {
            UID = new Guid(venda.VendaId),
            NumeroVenda = venda.NumeroVenda,
            DataVenda = venda.DataVenda,
            UIDCliente = new Guid(venda.Cliente),
            UIDFilial = new Guid(venda.Filial),
            Status = venda.Status,
            ValorTotal = venda.Itens.Sum(i => i.ValorItem)
        };

        Venda vendaOriginal = await _vendasRepository.GetVendaPorId(venda.VendaId);

        try
        {
            foreach (ItemRequest item in venda.Itens)
            {
                Item intemInser = new Item()
                {
                    UIDVenda = vendaAtualizar.UID,
                    UIDProduto = new Guid(item.Produto),
                    Quantidade = item.Quantidade,
                    Desconto = item.Desconto,
                    ValorItem = item.ValorItem
                };

                if (string.IsNullOrEmpty(item.ItemId))
                {
                    await _itemRepository.CreateItem(intemInser);
                }
                else
                {
                    intemInser.UID = new Guid(item.ItemId);

                    await _itemRepository.UpdateItem(intemInser);
                }

                vendaAtualizar.Itens.Add(intemInser);
            }

            foreach (Item iteOriginal in vendaOriginal.Itens)
            {
                if (venda.Itens.Any(i => i.ItemId == iteOriginal.UID.ToString()))
                {
                    await _itemRepository.DeleteItem(iteOriginal.UID.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Erro ao gravar item de venda. {ex.Message}");
            throw;
        }


        try
        {
            return await _vendasRepository.UpdateVenda(vendaAtualizar);
        }
        catch (Exception ex)
        {
            Log.Error($"Erro ao gravar  venda. {ex.Message}");
            throw;
        }
        
    }

    public async Task DeleteVenda(string id)
    {
        await _vendasRepository.DeleteVenda(id);
    }
}
