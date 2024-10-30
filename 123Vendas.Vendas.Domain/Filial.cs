using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _123Vendas.Domain;

[Table("Filial")]
public class Filial
{
    [Key] public Guid UID { get; set; }
    [Required] public required string Nome { get; set; }
}
