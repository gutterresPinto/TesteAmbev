using _123Vendas.Application.DTO.ClienteDTO;
using _123Vendas.Domain;
using _123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _123Vendas.Application.DTO.FilialDTO;
using __123Vendas.Infra.Data.Respositories._123Vendas;
using _123Vendas.Application.DTO.Vendas;

namespace _123Vendas.Application
{
    public class FilialApplication
    {
        private readonly AppVendasContext _context;

        private FilialRepository _filialRepository;

        public FilialApplication(AppVendasContext context, FilialRepository filialRepository)
        {
            _context = context;
            _filialRepository = filialRepository;
        }

        public async Task<IEnumerable<FilialReponse>> GetFilial()
        {
            IEnumerable<Filial> listaVendas = await _filialRepository.GetFilial();

            return listaVendas.Select(x => (FilialReponse)x);
        }

        public async Task<FilialReponse> InsertFilial(FilialRequest filial)
        {
            Filial filialInsert = new Filial()
            {
                Nome = filial.Nome
            };

            await _filialRepository.CreateFilial(filialInsert);

            return filialInsert;
        }
    }
}
