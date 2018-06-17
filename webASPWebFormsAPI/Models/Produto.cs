using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webASPWebFormsAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
    }
}