using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webASPWebFormsAPI.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Guaraná Antartica", Descricao = "Refrigerantes", Preco = 4.59D, Estoque = 1});
            Add(new Produto { Nome = "Suco de Laranja Prats", Descricao = "Sucos", Preco = 5.75D, Estoque = 1 });
            Add(new Produto { Nome = "Mostarda Hammer", Descricao = "Condimentos", Preco = 3.90D, Estoque = 1 });
            Add(new Produto { Nome = "Molho de Tomate Cepera", Descricao = "Condimentos", Preco = 2.99D, Estoque = 1});
            Add(new Produto { Nome = "Suco de Uva Aurora", Descricao = "Sucos", Preco = 6.50D, Estoque = 1 });
            Add(new Produto { Nome = "Pepsi-Cola", Descricao = "Refrigerantes", Preco = 4.25D, Estoque = 1 });
        }

        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = produtos.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}