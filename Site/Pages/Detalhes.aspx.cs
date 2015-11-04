using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistence;
using DAL.Entity;

namespace Site.Pages
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                ProdutoDal d = new ProdutoDal();
                Produtoo p = d.FindById(id);

                lblCodigo.Text = p.IdProduto.ToString();
                lblNome.Text = p.Nome;
                lblPreco.Text = p.Preco.ToString();
                lblQuantidade.Text = p.Quantidade.ToString();
                lblDataCompra.Text = p.DataCompra.ToString("dd/MM/yyyy");

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnExclusao_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblCodigo.Text);

                ProdutoDal d = new ProdutoDal();
                d.Delete(id);

                lblMensagem.Text = "Produto excluido com sucesso.";
                painel.Visible = false;
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}