using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness.SMD;
using BLL.EntradaBusiness;

namespace RefaccoSystem.Refacco.PREDIO_A.SMD.Terminate
{
    public partial class TerminateSMD : System.Web.UI.Page
    {
        /* ABAIXO ESTAO AS REFERENCIAS DOS METODOS DAS CLASS MODEL E NEGOCIO*/
        BLL.EntradaBusiness.ProcessoTerminate objProcess = new BLL.EntradaBusiness.ProcessoTerminate();
        Class_ListToRepair objSmd = new Class_ListToRepair();
        SeacherRepair objModel = new SeacherRepair();
        string user = HttpContext.Current.User.Identity.GetUserId();
        /*################### --fim-- ####################################*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaProcessTerminate();
                PanelMsg.Visible = false;
            }
        }
        protected void ListaProcessTerminate()
        {
            try
            {

                GridView1.DataSource = objSmd.ListaProcessoTerminateSMD();
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
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
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl = (Label)row.FindControl("lblId");
            Label status = (Label)row.FindControl("lblStatusFinal");
            lblCod.Text = lbl.Text;
            lblStatusFinal.Text = status.Text;
            if (lblStatusFinal.Text == "SCRAP")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            if (lblStatusFinal.Text == "FEEDBACK")
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblStatusFinal.Text == "SCRAP")
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
                ListaProcessTerminate();
            }
            if (lblStatusFinal.Text == "FEEDBACK")
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
                ListaProcessTerminate();
            }
        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                var listar = new PesquisasReparos();
               // GridView1.DataSource = listar.ListarRegisterByRepair(cn);
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

                var listar = new PesquisasReparos();
                //GridView1.DataSource = listar.ListarRegisterByRepair();
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
                var listar = new PesquisasReparos();
              //  GridView1.DataSource = listar.ListarRegisterByRepair(cn);
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

                var listar = new PesquisasReparos();
                //GridView1.DataSource = listar.ListarRegisterByRepair();
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