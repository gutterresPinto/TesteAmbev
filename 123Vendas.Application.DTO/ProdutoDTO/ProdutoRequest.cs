using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.ProdutoDTO
{
    public class ProdutoRequest
    {
        public int CodigoProduto { get; set; }
        public required string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
