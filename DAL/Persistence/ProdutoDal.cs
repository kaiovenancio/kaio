using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Entity;

namespace DAL.Persistence
{
    public class ProdutoDal : Conexao
    {
        public void Insert(Produtoo p)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("insert into Produto(Nome, Preco, Quantidade, DataCompra) values(@v1, @v2, @v3, @v4)", Con);
                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Preco);
                Cmd.Parameters.AddWithValue("@v3", p.Quantidade);
                Cmd.Parameters.AddWithValue("@v4", p.DataCompra);
                Cmd.ExecuteNonQuery();
            }
            catch
            {

                throw new Exception("Erro ao cadastrar");
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Produtoo> FindAll()
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("Select * From Produto", Con);
                Dr = Cmd.ExecuteReader();

                List<Produtoo> lista = new List<Produtoo>();

                while (Dr.Read())
                {
                    Produtoo p = new Produtoo();

                    p.IdProduto     = Dr.GetInt32(0);
                    p.Nome          = Dr.GetString(1);
                    p.Preco         = Dr.GetDouble(2);
                    p.Quantidade    = Dr.GetInt32(3);
                    p.DataCompra    = Dr.GetDateTime(4);

                    lista.Add(p);
                }

                return lista;
            }
            catch
            {

                throw new Exception("Erro ao consultar");
            }
            finally
            {
                CloseConnection();
            }
        }

        public Produtoo FindById(int IdProduto)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("select * from Produto where IdProduto = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", IdProduto);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Produtoo p = new Produtoo();

                    p.IdProduto = Dr.GetInt32(0);
                    p.Nome = Dr.GetString(1);
                    p.Preco = Dr.GetDouble(2);
                    p.Quantidade = Dr.GetInt32(3);
                    p.DataCompra = Dr.GetDateTime(4);

                    return p;
                }
                return null;
            }
            catch 
            {

                throw new Exception("Erro ao Consultar Produto");
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int IdProduto)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("delete from Produto where IdProduto = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", IdProduto);
                Cmd.ExecuteNonQuery();

            }
            catch
            {

                throw new Exception("Erro ao excluir Produto");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
