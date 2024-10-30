﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vendas.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public Guid UID { get; set; }
        public int CodigoProduto { get; set; }
        public required string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
