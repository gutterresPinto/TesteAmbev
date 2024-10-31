
namespace _123Vendas.Application.DTO.Vendas;

public class ItemRequest
{
    public string? ItemId { get; set; }
    public required string Produto { get; set; }        
    public int Quantidade { get; set; }
    public decimal Desconto { get; set; }
    public decimal ValorItem { get; set; }
}
