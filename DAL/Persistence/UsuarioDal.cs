using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using System.Data.SqlClient;

namespace DAL.Persistence
{
    public class UsuarioDal: Conexao
    {
        public void Insert(Usuario u)
        {
            try
            {
                string query = "INSERT INTO Usuario(Nome, Email, Login, Senha, DataCadastro) "
                                    + "VALUES(@v1, @v2, @v3, @v4, @v5)";
                OpenConnection();

                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", u.Nome);
                Cmd.Parameters.AddWithValue("@v2", u.Email);
                Cmd.Parameters.AddWithValue("@v3", u.Login);
                Cmd.Parameters.AddWithValue("@v4", u.Senha);
                Cmd.Parameters.AddWithValue("@v5", u.DataCadastro);
                Cmd.ExecuteNonQuery();

            }
            catch
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }

        }

        public Usuario Find(string Login, string Senha)
        {
            try
            {
                string query = "SELECT Nome, Email, Login FROM Usuario " +
                                "WHERE Login = @v1 AND Senha = @v2";

                OpenConnection();
                Cmd = new SqlCommand(query, Con);
                Cmd.Parameters.AddWithValue("@v1", Login);
                Cmd.Parameters.AddWithValue("@v2", Senha);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    Usuario u = new Usuario();
                    u.Nome = Dr["Nome"] as string;
                    u.Nome = Dr["Email"] as string;
                    u.Nome = Dr["Login"] as string;

                    return u;
                }
                return null;
            }
            catch
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
