using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI_SQL.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
    }
}