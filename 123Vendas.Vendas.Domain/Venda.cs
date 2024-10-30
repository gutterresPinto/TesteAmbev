using System;

namespace _123Vendas.Domain;

public class Venda
{
    public int Id { get; set; }
    public Guid UID { get; set; }
    public int NumeroVenda { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.Now;
    public Guid UIDCliente { get; set; }
    public Cliente? Cliente { get; set; } 
    public decimal ValorTotal { get; set; }
    public Guid UIDFilial { get; set; }
    public Filial? Filial { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();
    public int Status { get; set; }
}









