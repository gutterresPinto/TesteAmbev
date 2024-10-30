using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.Vendas
{
    public class ItemResponse
    {
        public required string Produto { get; set; }
        public required string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorItem { get; set; }

        public static implicit operator ItemResponse(Item parametro)
        {
            if (parametro is null)
                return null;

            ItemResponse retorno = new ItemResponse()
            {
                Produto = parametro.UIDProduto.ToString(),
                DescricaoProduto = parametro.Produto != null ? parametro.Produto.Nome : "",
                Quantidade = parametro.Quantidade,
                Desconto = parametro.Desconto,
                ValorItem = parametro.ValorItem
            };

            return retorno;
        }
    }
}
