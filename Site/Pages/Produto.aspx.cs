using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DAL.Entity;
using DAL.Persistence;

namespace Site.Pages
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = HttpContext.Current.User.Identity.Name;
        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {

        }

        protected void btnAcesso_Click1(object sender, EventArgs e)
        {
            string opcao = ddlMenu.SelectedValue;
            switch (opcao)
            {
                case "1":
                    Response.Redirect("/Pages/Cadastro.aspx");
                    break;
                case "2":
                    Response.Redirect("/Pages/Consultar.aspx");
                    break;

            }
        }        
    }
}