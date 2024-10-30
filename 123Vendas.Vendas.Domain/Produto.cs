using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace _123Vendas.Domain;

[Table("Produto")]
public class Produto
{
    [Key] public Guid UID { get; set; }
    [Required] public int CodigoProduto { get; set; }
    [Required] public required string Nome { get; set; }
    [Required] public decimal Valor { get; set; }        
}
