using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Entity;
using DAL.Persistence;
using Util;
using System.Web.Security;

namespace Site.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {

                string login = txtLogin.Text;
                string senha = txtSenha.Text;

                UsuarioDal d = new UsuarioDal();
                Usuario u = d.Find(login, Criptografia.Encriptar(senha));

                if (u!= null)
                {
                    FormsAuthentication.SetAuthCookie(login, false);

                    Response.Redirect("/Pages/Produto.aspx");
                }
                    
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                string senha1 = txtSenhaAcesso.Text;
                string senha2 = txtSenhaConfirm.Text;
               
                if (senha1.Equals(senha2))
                {
                    Usuario u = new Usuario();

                    u.Nome = txtNome.Text;
                    u.Email = txtEmail.Text;
                    u.Login = txtLoginAcesso.Text;
                    u.Senha = Criptografia.Encriptar(senha1);
                    u.DataCadastro = DateTime.Now;

                    UsuarioDal d = new UsuarioDal();
                    d.Insert(u);

                    lblMensagem.Text = "O usuario " + u.Nome + ", cadastrado com sucesso.";

                    txtNome.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtLoginAcesso.Text = string.Empty;
                }
                else
                {
                    lblMensagem.Text = "ERRO. Confirme sua senha corretamente";
                }

            }
            catch (Exception ex)
            {

                lblMensagem.Text="Erro ao cadastrar usuario " + ex.Message;
            }
        }
    }
}