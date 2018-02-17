using BLL.EntradaBusiness;
using BLL.EntradaBusiness.SMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using DAL;

namespace RefaccoSystem.Refacco.PREDIO_A.SMD.AnalysisRepair
{
    public partial class AnalysisRepair : System.Web.UI.Page
    {
        public object Logado { get; private set; }
        public object ErrorMessage { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaPlacaParaReparo();
                getTec();
            }
        }

        public void getTec()
        {
            try
            {
                string area = "HHP-SMD";
                DropboxGenericos dropList = new DropboxGenericos();
                ddlSendRepair.DataSource = dropList.GetTecnico(area);
                ddlSendRepair.DataTextField = "UserName";
                ddlSendRepair.DataValueField = "Id";
                ddlSendRepair.DataBind();
                ListItem item = new ListItem("ALL", "VALUES", true); item.Selected = true;
                ddlSendRepair.Items.Add(item);

            }
            catch (Exception)
            {

                ErrorMessageRepairMan.Text = "Erro ao listar os Tecnico";
            }
        }

        /// <summary>
        /// ESTE METODO LISTA TODOS OS DADOS COM PLACA PARA REPARO QUE ESTEJA NO NOME DO REPADOR LOGADO
        /// </summary>
        public void ListaPlacaParaReparo()
        {
            try
            {
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();//AQUI RECUPERA O ID USUARIO LOGADO PARA REGISTRAR NO BANCO
                string UserLagadoName = HttpContext.Current.User.Identity.GetUserName();
                var lista = new Class_ListToRepair();
                GridView1.DataSource = lista.ListaPlacaParaRepairMan(UserLagado);
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    LogadoRepairMan.InnerText = "Ola, " + UserLagadoName + " segue abaixo sua lista de placas para reparo!";
                    Panel2.Visible = true;
                }
                else
                {
                    LogadoRepairMan.InnerText = "Ola, " + UserLagadoName + " não há nenhuma placa registrada para você!";
                    Panel2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageRepairMan.Text = "Erro ao listar os dados: " + ex.Message;

            }
        }


        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if(ddlSendRepair.SelectedItem.Text!="ALL")
            {
                var objModel = new SeacherRepair();
                objModel.EntradaId = Convert.ToInt32(lblEntrada.Text);
                objModel.RepairMainId = Convert.ToInt32(lblCodigo.Text);
                objModel.ActionRepair = Convert.ToString(ddlAction.SelectedItem.Text);
                objModel.UserName = Convert.ToString(ddlSendRepair.SelectedValue);
                var updateAction = new ListaDePlacaParaReparoOQC();
                updateAction.UpdateRepairManAction(objModel);
                updateAction.UpdateTecnicoAfterActionRepairMan(objModel);
                updateAction.UpdateStatusFinalAfterActionRepairMan(objModel);
                /*******/
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();
                var objMod = new SeacherRepair();
                objMod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                objMod.UserName = UserLagado;
                updateAction.UpdateRepairMan(objMod);
                /*FIM*/
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso!');", true);
                ListaPlacaParaReparo();
            }
            else if(ddlSendRepair.SelectedItem.Text =="ALL")
            {
                var objModel = new SeacherRepair();
                objModel.EntradaId = Convert.ToInt32(lblEntrada.Text);
                objModel.RepairMainId = Convert.ToInt32(lblCodigo.Text);
                objModel.ActionRepair = Convert.ToString(ddlAction.SelectedItem.Text);
                objModel.UserName = Convert.ToString(ddlSendRepair.SelectedValue);
                var updateAction = new ListaDePlacaParaReparoOQC();
                updateAction.UpdateRepairManAction(objModel);
                updateAction.UpdateTecnicoAfterActionRepairManNULL(objModel);
                updateAction.UpdateStatusFinalAfterActionRepairMan(objModel);
                /*******/
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();
                var objMod = new SeacherRepair();
                objMod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                objMod.UserName = UserLagado;
                updateAction.UpdateRepairMan(objMod);
                /*FIM*/
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso!');", true);
                ListaPlacaParaReparo();
            }
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl = (Label)row.FindControl("lblId");
            Label lblEntradaId = (Label)row.FindControl("lblEntradaId");
            lblCodigo.Text = lbl.Text;
            lblEntrada.Text = lblEntradaId.Text;
            /* O CODIGO ABAIXO EXECUTA O FORMULARIO MODAL EM SEGUNDO PLANO, OU SEJA SOMENTE DEPOIS DE RECUPERAR O ID 
             DA LINHA CLICADA NO GRIDVIEW */
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                var listar = new PesquisasReparos();
                //GridView1.DataSource = listar.ListarRegisterByRepair(cn);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    ErrorMessage = "Nenhuma placa para reparo";
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
                    ErrorMessage = "Nenhuma placa para reparo";
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
                    ErrorMessage = "Nenhuma placa para reparo";
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
                    ErrorMessage = "Nenhuma placa para reparo";
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