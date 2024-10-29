using _123Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.Vendas
{
    public class VendasResponse
    {
        public Guid UID { get; set; }
        public int NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
        public Guid UIDCliente { get; set; }
        //public Cliente Cliente { get; set; } = new Cliente();
        public decimal ValorTotal { get; set; }
        public Guid UIDFilial { get; set; }
        //public Filial Filial { get; set; } = new Filial();
        //public List<Item> Itens { get; set; } = new List<Item>();
        public int Status { get; set; }


        public static implicit operator VendasResponse(Venda parametro)
        {
            if (parametro is null)
                return null;

            VendasResponse retorno = new VendasResponse()
            {
                UID = parametro.UID,
                NumeroVenda = parametro.NumeroVenda,
                DataVenda = parametro.DataVenda,
                ValorTotal = parametro.ValorTotal,
                Status = parametro.Status
            };

            return retorno;
        }

    }
}
