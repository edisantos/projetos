using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;

namespace RefaccoSystem.Refacco.MainPesquisasReparos
{
    public partial class pesquisaReparoMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = new PesquisasReparos();
                string cn = txtcn.Text;
                GridView1.DataSource = lista.ListaPorCn(cn);
                GridView1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}