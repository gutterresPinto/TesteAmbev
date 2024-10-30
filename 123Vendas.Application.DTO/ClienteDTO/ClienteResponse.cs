using _123Vendas.Application.DTO.Vendas;
using _123Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.ClienteDTO
{
    public  class ClienteResponse
    {
        public required string ClienteID { get; set; }
        public int NumeroCliente { get; set; }
        public required string Documento { get; set; }
        public required string Nome { get; set; }


        public static implicit operator ClienteResponse(Cliente parametro)
        {
            if (parametro is null)
                return null;

            ClienteResponse retorno = new ClienteResponse()
            {
                ClienteID = parametro.UID.ToString(),
                NumeroCliente  = parametro.NumeroCliente,
                Documento= parametro.Documento,
                Nome = parametro.Nome
            };

            return retorno;
        }
    }
}
