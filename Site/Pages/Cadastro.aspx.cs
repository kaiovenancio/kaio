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
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            
            try
            {
                Produtoo p = new Produtoo();
                p.Nome = txtNome.Text;
                p.Preco = Convert.ToDouble(txtPreco.Text);
                p.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                p.DataCompra = Convert.ToDateTime(txtDataCompra.Text);

                ProdutoDal d = new ProdutoDal();
                d.Insert(p);

                lblMensagem.Text = "Produto " + p.Nome + ", cadastrado com sucesso";

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}