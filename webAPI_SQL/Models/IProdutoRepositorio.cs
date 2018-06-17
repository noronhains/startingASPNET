using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPI_SQL.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> All { get; }
        Produto Find(int id);
        void Insert(Produto item);
        void Update(Produto item);
        void Delete(int id);
    }
}
