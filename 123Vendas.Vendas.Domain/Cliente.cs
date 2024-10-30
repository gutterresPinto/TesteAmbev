using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public Guid UID { get; set; }
        public int NumeroCliente { get; set; }
        public required string Documento { get; set; } = "";
        public required string Nome { get; set; } = "";
    }
}
