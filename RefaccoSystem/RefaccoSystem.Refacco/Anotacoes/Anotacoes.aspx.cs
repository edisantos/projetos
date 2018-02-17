using DAL;
using System;
using System.Web.UI;
using BLL.EntradaBusiness;

namespace RefaccoSystem.Refacco.Anotacoes
{
    public partial class Anotacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var mod = new Comentario();
                mod.Processo = txtProcesso.Text;
                mod.Comentarios = txtComentario.Text;
                mod.status = ddlStatus.SelectedItem.Text;
                Anotacoes registar = new Anotacoes();
               
                

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);

                txtProcesso.Text = string.Empty;
                txtComentario.Text = string.Empty;
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao registrar: " + ex.Message;
            }
           
            
           
           
        }
    }
}