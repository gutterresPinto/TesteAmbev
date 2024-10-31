using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _123Vendas.Domain;

[Table("Filial")]
public class Filial
{
    [Key] public Guid UID { get; set; }
    [Required] public required string Nome { get; set; }

    public class Configuration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {

        }
    }
}
