using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Application.DTO.FilialDTO;
using _123Vendas.Domain;

namespace _123Vendas.Application.DTO.Vendas
{
    public class VendasResponse
    {
        public required string VendaId { get; set; }
        public int NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;        
        public ClienteResponse? Cliente { get; set; }
        public FilialReponse? Filial { get; set; }
        public decimal ValorTotal { get; set; }
        //public Filial Filial { get; set; } = new Filial();
        public ItemResponse[] Itens { get; set; } = Array.Empty<ItemResponse>();
        public int Status { get; set; }


        public static implicit operator VendasResponse(Venda parametro)
        {
            if (parametro is null)
                return null;

            VendasResponse retorno = new VendasResponse()
            {
                VendaId = parametro.UID.ToString(),
                NumeroVenda = parametro.NumeroVenda,
                DataVenda = parametro.DataVenda,
                Cliente = parametro.Cliente != null ? parametro.Cliente : null,
                Filial = parametro.Filial != null ? parametro.Filial : null,
                ValorTotal = parametro.ValorTotal,
                Status = parametro.Status,
                Itens = parametro.Itens.Select(x => (ItemResponse)x).ToArray()
            };

            return retorno;
        }

    }
}
