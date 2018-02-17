using BLL.EntradaBusiness;
using BLL.EntradaBusiness.CQP;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.AnaliseReparadora
{
    public partial class AnalysisRepairMan : System.Web.UI.Page
    {
        public object Logado { get; private set; }
        public object ErrorMessage { get; private set; }
        Cls_Filtros_CQP objFiltros = new Cls_Filtros_CQP(); //Deixando o metodo da class Universal
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListaPlacaParaReparo();
                getTec();
                var count = new Class_Count_Day();
                count.CountDayTecnico();
                count.CountDayRepair();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void getTec()
        {
            try
            {
                string area = "HHP-OQC";
                DropboxGenericos dropList = new DropboxGenericos();
                ddlSendRepair.DataSource = dropList.GetTecnico(area);
                ddlSendRepair.DataTextField = "UserName";
                ddlSendRepair.DataValueField = "Id";
                ddlSendRepair.DataBind();
                ListItem item = new ListItem("SELECIONE O TECNICO", "VALUES", true); item.Selected = true;
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
                GridView1.DataSource = objFiltros.ListarRepairMain(UserLagado);
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
        /// <summary>
        /// ESTE METODO PEGA O ID DO GRIDVIEW E MOSTRA NO MODAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// ESTE ABAIXO MOSTRA A INFORMAÇAÕ NO FORMULARIO DE REPARO FEITO PELO TECNICO.
        /// ESTACIA DA CLASS LISTADEPLACAPARAREPAROOQC - METODO: MOSTRARDADOSPARAREPAIR
        /// </summary>
        //public void MostrarDadosParaReparo()
        //{
        //    try
        //    {
        //        string objCod = lblCodigo.Text;
        //        var objLista = new ListaDePlacaParaReparoOQC();
        //        Pesquisas objModel = objLista.MostrarDadosRepaiMan(objCod);
        //        if(objModel!=null)
        //        {
        //            lblUn.Text = objModel.UN;
        //            lblCN.Text = objModel.CN;
        //            lblCausa.Text = objModel.Causa;
        //            lblPartNumber.Text = objModel.Causa;
        //            lblLote.Text = objModel.Lote;
        //            lblLocation.Text = objModel.Location;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorMessageRepairMan.Text = "Erro ao listar : " + ex.Message;
        //    }
        //}
        protected void btnSalvar_Click(object sender, EventArgs e)
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso!');", true);
            ListaPlacaParaReparo();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                string UserLogado = HttpContext.Current.User.Identity.GetUserId();
                GridView1.DataSource = objFiltros.Listar(UserLogado,cn);
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

                string UserLogado = HttpContext.Current.User.Identity.GetUserId();
                GridView1.DataSource = objFiltros.Listar(UserLogado);
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

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                string UserLogado = HttpContext.Current.User.Identity.GetUserId();
                GridView1.DataSource = objFiltros.Listar(UserLogado,cn);
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

                string UserLogado = HttpContext.Current.User.Identity.GetUserId();
                GridView1.DataSource = objFiltros.Listar(UserLogado);
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