using BLL.EntradaBusiness;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.ProcessoFinalizado
{
    public partial class ProcessoTerminate : System.Web.UI.Page
    {
        /* ABAIXO ESTAO AS REFERENCIAS DOS METODOS DAS CLASS MODEL E NEGOCIO*/
        BLL.EntradaBusiness.ProcessoTerminate objProcess = new BLL.EntradaBusiness.ProcessoTerminate();
        SeacherRepair objModel = new SeacherRepair();
        string user = HttpContext.Current.User.Identity.GetUserId();
        /*################### --fim-- ####################################*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListaTerminateALL();
                PanelMsg.Visible = false;
            }
        }
        protected void ListaTerminateALL()
        {
            try
            {
                
                GridView1.DataSource = objProcess.ListaProcessoTerminateAll();
                GridView1.DataBind();
                if(GridView1.Rows.Count < 1)
                {
                    PanelMsg.Visible = true;
                    lblMsgError.Text = "Nunhuma placa para finalização de SCRAP ou FEEDBACK encontrada no momento!";
                    Panel3.Visible = false;
                }
                else
                {
                    Panel3.Visible = true;
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the list the process terminate! " + ex.Message;
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if(lblStatusFinal.Text == "SCRAP")
            {
                objModel.UserName = user;
                objModel.StatusTerminate = ddlStatusScrap.SelectedItem.Text;
                objModel.Descricao = txtDescription.Text;
                objModel.EntradaId = Convert.ToInt32(lblCod.Text);
                objProcess.RegistrarProcessoTerminate(objModel);

                /*update na tabela Principal SCRAP*/

                string statusRepair = "SCRAP / " + ddlStatusScrap.SelectedItem.Text;
                objModel.StatusRepair = ddlStatusScrap.SelectedItem.Text;
                objModel.StatusFinal = statusRepair;
                objProcess.UpdateProcessTerminate(objModel);
                ListaTerminateALL();
            }
            if(lblStatusFinal.Text == "FEEDBACK")
            {
                objModel.UserName = user;
                objModel.StatusTerminate = ddlStatusScrap.SelectedItem.Text;
                objModel.Descricao = txtDescription.Text;
                objModel.EntradaId = Convert.ToInt32(lblCod.Text);
                objProcess.RegistrarProcessoTerminate(objModel);

                /*update na tabela Principal FEEDBACK*/

                string statusRepair = "FEEDBACK / " + ddlStatusFeedback.SelectedItem.Text;
                objModel.StatusRepair = ddlStatusFeedback.SelectedItem.Text;
                objModel.StatusFinal = statusRepair;
                
                objProcess.UpdateProcessTerminate(objModel);
                ListaTerminateALL();
            }
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl = (Label)row.FindControl("lblId");
            Label status = (Label)row.FindControl("lblStatusFinal");
            lblCod.Text = lbl.Text;
            lblStatusFinal.Text = status.Text;
            if(lblStatusFinal.Text == "SCRAP")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            if(lblStatusFinal.Text == "FEEDBACK")
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
            }
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                
                string cn = txtSeach.Text;
                GridView1.DataSource = objProcess.ListaProcessoTerminate(cn);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    ErrorMessage.Text = "Nenhuma placa para reparo";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }
            }
            else
            {


                GridView1.DataSource = objProcess.ListaProcessoTerminateAll();
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    ErrorMessage.Text = "Nenhuma placa para reparo";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                GridView1.DataSource = objProcess.ListaProcessoTerminate(cn);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    ErrorMessage.Text = "Nenhuma placa para reparo";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }
            }
            else
            {


                GridView1.DataSource = objProcess.ListaProcessoTerminateAll();
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    ErrorMessage.Text = "Nenhuma placa para reparo";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }
            }

        }
    }
}