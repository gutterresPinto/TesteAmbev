using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.ClienteDTO
{
    public  class ClienteRequest
    {
        public int NumeroCliente { get; set; }
        public required string Documento { get; set; }
        public required string Nome { get; set; }
    }
}
