using _123Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Application.DTO.FilialDTO
{
    public class FilialReponse
    {
        public required string FilialId { get; set; }
        public required string Nome { get; set; }

        public static implicit operator FilialReponse(Filial parametro)
        {
            if (parametro is null)
                return null;

            FilialReponse retorno = new FilialReponse()
            {
                FilialId = parametro.UID.ToString(),                
                Nome = parametro.Nome
            };

            return retorno;
        }
    }
}
