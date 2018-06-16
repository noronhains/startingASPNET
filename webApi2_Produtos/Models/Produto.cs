using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi2_Produtos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
    }
}