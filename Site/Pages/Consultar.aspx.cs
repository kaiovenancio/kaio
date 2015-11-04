using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistence;

namespace Site.Pages
{
    public partial class Consultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProdutoDal d = new ProdutoDal();

                gridProduto.DataSource = d.FindAll();
                gridProduto.DataBind();
            }
            catch (Exception ex)
            {

                lblMensagem.Text= ex.Message;
            }
        }
    }
}