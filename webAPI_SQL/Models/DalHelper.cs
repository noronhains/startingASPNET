using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace webAPI_SQL.Models
{
    public class DalHelper
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }

        public static List<Produto> GetProdutos()
        {
            List<Produto> _produtos = new List<Produto>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM TabProdutos", con))
                {
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr != null)
                        {
                            while (dr.Read())
                            {
                                var produto = new Produto();
                                produto.ID = Convert.ToInt32(dr["Prod_ID"]);
                                produto.Nome = dr["Prod_Nome"].ToString();
                                produto.Descricao = dr["Prod_Descricao"].ToString();
                                produto.Preco = Convert.ToDouble(dr["Prod_Preco"]);
                                produto.Estoque = Convert.ToInt32(dr["Prod_Estoque"]);
                                _produtos.Add(produto);
                            }
                        }
                        return _produtos;
                    }
                }
            }
        }

        public static Produto GetProduto(int Id)
        {
            Produto produto = null;

            using(SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM TabProdutos WHERE Prod_Id = " + Id, con))
                {
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr != null)
                        {
                            while (dr.Read())
                            {
                                produto = new Produto();
                                produto.ID = Convert.ToInt32(dr["Prod_ID"]);
                                produto.Nome = dr["Prod_Nome"].ToString();
                                produto.Descricao = dr["Prod_Descricao"].ToString();
                                produto.Preco = Convert.ToDouble(dr["Prod_Preco"]);
                                produto.Estoque = Convert.ToInt32(dr["Prod_Estoque"]);
                            }
                        }
                        return produto;
                    }
                }
            }
        }

        public static int InsertProduto(Produto produto)
        {
            int reg = 0;
            using(SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO TabProdutos(Prod_ID, Prod_Nome, Prod_Descricao, Prod_Preco, Prod_Estoque) VALUES ((SELECT COALESCE(MAX(Prod_ID), 0) + 1 AS ID FROM TabProdutos), @nome, @descricao, @preco, @estoque)";
                using(SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateProduto(Produto produto)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE TabProdutos SET Prod_Nome = @nome, Prod_Descricao = @descricao, Prod_Preco = @preco, Prod_Estoque = @estoque WHERE Prod_Id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", produto.ID);
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteProduto(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE TabProdutos WHERE Prod_Id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
    }
}