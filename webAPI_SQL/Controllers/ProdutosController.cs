using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI_SQL.Models;

namespace webAPI_SQL.Controllers
{
    public class ProdutosController : ApiController
    {
        static  IProdutoRepositorio repositorio;

        public ProdutosController()
        {
             repositorio = new ProdutoRepositorio();
        }


        //GET: api/Produtos
        [HttpGet]
        public IEnumerable<Produto> List()
        {
            return repositorio.All;
        }

        //GET: api/Produtos/5
        public Produto GetProduto(int id)
        {
            var produto = repositorio.Find(id);

            if (produto == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return produto;
        }

        //POST: api/Produtos
        [HttpPost]
        public void Post([FromBody]Produto produto)
        {
            repositorio.Insert(produto);
        }

        //PUT: api/Produtos/5
        [HttpPut()]
        public void Put(int id, [FromBody]Produto produto)
        {
            produto.ID = id;
            repositorio.Update(produto);
        }

        //DELETE: api/Produtos/5
        [HttpDelete()]
        public void Delete(int id)
        {
            repositorio.Delete(id);
        }
    }
}
