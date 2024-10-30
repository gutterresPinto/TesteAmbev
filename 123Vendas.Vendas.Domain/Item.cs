using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public Guid UID { get; set; }
        public Guid UIDVenda { get; set; }
        public Guid UIDProduto { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorItem { get; set; }
    }
}
