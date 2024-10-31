using _123Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.Vendas;

public class VendasResquest
{
    public string? VendaId{ get; set; }
    public int NumeroVenda { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.Now;
    public required string Cliente { get; set; }        
    public decimal ValorTotal { get; set; }
    public required string Filial { get; set; }        
    public ItemRequest[] Itens { get; set; } = Array.Empty<ItemRequest>();
    public int Status { get; set; }
}
