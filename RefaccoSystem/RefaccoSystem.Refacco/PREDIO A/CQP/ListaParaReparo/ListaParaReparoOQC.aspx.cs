using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;
using Microsoft.AspNet.Identity;
using DAL;

namespace RefaccoSystem.Refacco.ListaParaReparo
{
    public partial class ListaParaReparoOQC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaPlacaParaReparo();
                GetDefectCause();
                GetActions();
                GetLocation();
                GetRepairMan();
                ddlLocation.AutoPostBack = true;
                ddlSendRepair.Enabled = false;
               
                /*COLEÇÃO PARA PREENCHIMENTO DO DROPDOWNLIST STATUS*/
                //ListItemCollection item = new ListItemCollection
                //{
                    
                //    new ListItem("SELECT STATUS","0"),
                //    new ListItem("PASS","1"),
                //    new ListItem("SCRAP","2"),
                //    new ListItem("FEEDBACK","3"),
                //    new ListItem("TRANSFER TO REPAIR","4"),
                //};

                //ddlStatus.DataSource = item;
                //ddlStatus.DataBind();

                //if(Convert.ToString(item) =="4")
                //{
                //    ddlSendRepair.Enabled = true;
                //}

            }
        }
        public void ListaPlacaParaReparo()
        {
            try
            {
                string UserLogado = HttpContext.Current.User.Identity.GetUserId();//AQUI RECUPERA O ID USUARIO LOGADO PARA REGISTRAR NO BANCO
                string UserLogadoName = HttpContext.Current.User.Identity.GetUserName();
                var lista = new ListaDePlacaParaReparoOQC();
                GridView1.DataSource = lista.ListaPlacaParaReparo(UserLogado);
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    Logado.InnerText = "Ola, " + UserLogadoName + " segue abaixo sua lista de placas para reparo!";
                    Panel7.Visible = true;
                }
                else
                {
                    Logado.InnerText = "Ola, " + UserLogadoName + " não há nenhuma placa registrada para você!";
                    Panel7.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Erro ao listar os dados: " + ex.Message;

            }
        }

        public void GetDefectCause()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlDefectCause.DataSource = get.GetDefectCause();
                ddlDefectCause.DataTextField = "Causa";
                ddlDefectCause.DataValueField = "CausaId";
                ddlDefectCause.DataBind();
                ListItem item = new ListItem("SELECIONE A CAUSA", "VALUES", true); item.Selected = true;
                ddlDefectCause.Items.Add(item);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Erro ao listar as causas de defeitos" + ex.Message;
            }
        }

        protected void ddlLocation_TextChanged(object sender, EventArgs e)
        {
            if (ddlLocation.SelectedValue != "0")
            {

                string part = ddlLocation.SelectedItem.Text;
                var list = new ListaDePlacaParaReparoOQC();
                Pesquisas mod = list.ListaBom(part);
                if (mod != null)
                {
                    txtPartNumber.Text = mod.PartNumber;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Nenhum Part-Number encontrado');", true);
                }
            }

        }
        public void GetLocation()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlLocation.DataSource = get.GetLocationSMD();
                ddlLocation.DataTextField = "DesigLoc";
                ddlLocation.DataBind();
                ListItem item = new ListItem("SELECIONE O LOCATION", "VALUES", true); item.Selected = true;
                ddlLocation.Items.Add(item);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Erro ao listar o Location" + ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void GetActions()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlAction.DataSource = get.GetAction();
                ddlAction.DataTextField = "Action";
                ddlAction.DataValueField = "ActionId";
                ddlAction.DataBind();
                ListItem item = new ListItem("SELECIONE A AÇÂO", "VALUES", true); item.Selected = true;
                ddlAction.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void GetRepairMan()
        {
            try
            {
                string area = "HHP-OQC";
                var get = new DropboxGenericos();
                ddlSendRepair.DataSource = get.GetRepairMan(area);
                ddlSendRepair.DataTextField = "UserName";
                ddlSendRepair.DataValueField = "Id";
                ddlSendRepair.DataBind();
                ListItem item = new ListItem("SELECIONE A REPARADORA", "VALUES", true); item.Selected = true;
                ddlSendRepair.Items.Add(item);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the list RepairMan " + ex.Message;
            }
        }
        /// <summary>
        /// AQUI FAZ O UPDATE NA TABELA PRINCIPAL
        /// </summary>
        public void UpdateReparo()
        {
            try
            {
                string user = HttpContext.Current.User.Identity.GetUserName();
                DAL.ProcessRepair mod = new DAL.ProcessRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.UN = txtUn.Text;
                mod.DefectCauseId = Convert.ToInt32(ddlDefectCause.SelectedValue);
                mod.LocationSmd = ddlLocation.SelectedItem.Text;
                mod.lote = txtLote.Text;
                mod.ActionId = Convert.ToInt32(ddlAction.SelectedValue);
                mod.TecnicoResponsavel = user;
                mod.statusRepair = ddlStatus.SelectedItem.Text;
                var add = new ListaDePlacaParaReparoOQC();
                add.UptadeRepair(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error ao atualizar o repapro! " + ex.Message;
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void InsertAnalysisRepairMan()
        {
            try
            {
                string IdAction = "WAITING";
                DAL.ProcessRepair mod = new DAL.ProcessRepair();
                mod.RepairMan = ddlSendRepair.SelectedValue;
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.ActionRepainMan = Convert.ToString(IdAction);
                mod.LocationSmd = ddlLocation.SelectedItem.Text;
                mod.PartNumber = txtPartNumber.Text;
                var reg = new ListaDePlacaParaReparoOQC();
                reg.InsertAnalisysRepairMan(mod);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the Insert Analysis RepairMan: " + ex.Message;
            }
        }
        /// <summary>
        /// BOTÃO PARA O EVENDO DOS METODOS UPDATE REPARO, INSERT ANALYSIS REPAIMAN E LISTA PLACAS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (lblStatusFinally.Text == "")
            {
                if (txtLote.Text == "" && txtUn.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Campos UN e Lote não pode ser vazio! Caso não exista preencha com N/A');", true);
                }
                else
                {
                    UpdateReparo();
                }


            }



            if (ddlSendRepair.SelectedItem.Text != "SELECIONE A REPARADORA" && lblStatusFinally.Text == "")
            {
                InsertAnalysisRepairMan();
            }
            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "PASS")
            {
                var mod = new SeacherRepair();
                string statusFinal = "TERMINATE";
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Reparo Finalizado com sucesso.');", true);
                ListaPlacaParaReparo();
            }
            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "SCRAP")
            {
                string statusFinal = "SCRAP";
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Item enviado para Scrap.');", true);
                ListaPlacaParaReparo();
            }

            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "FEEDBACK")
            {
                string statusFinal = "FEEDBACK";
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Item enviado para Feedack.');", true);
                ListaPlacaParaReparo();
            }
            if(ddlStatus.SelectedValue =="4" && lblStatusFinally.Text =="WAITING")
            {
                string statusFinal = "";
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateReturnRepair(mod);
                InsertAnalysisRepairMan();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Reparo retornado com sucesso!');", true);
                ListaPlacaParaReparo();
            }
            ListaPlacaParaReparo();

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl = (Label)row.FindControl("lblId");
            Label StatusFinal = (Label)row.FindControl("lblStatusFinal");
            lblCodigo.Text = lbl.Text;
            lblStatusFinally.Text = StatusFinal.Text;
            /*O CODIGO ABAIXO DESABILITA ALGUNS CAMPO DO FORMULARIO CASO O STATUS FINAL ESTEJA APENAS AGUARDANDO 
             O TECNICO FINALIZAR O REPARO
             */
            if (StatusFinal.Text == "WAITING")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
                Panel3.Visible = true;
                Panel4.Visible = true;
                Panel5.Visible = true;
                Panel6.Visible = true;
                
            }

           
            /* O CODIGO ABAIXO EXECUTA O FORMULARIO MODAL EM SEGUNDO PLANO, OU SEJA SOMENTE DEPOIS DE RECUPERAR O ID 
             DA LINHA CLICADA NO GRIDVIEW */
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Pop", "openModal();", true);

        }

        protected void ddlStatus_TextChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue == "4")
            {
                ddlSendRepair.Enabled = true;
               
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Field transfer enabled.');", true);
               
            }
            else
            {
                ddlSendRepair.Enabled = false;
                
            }
            /*ENABLE AND DISABLE LOCATION FIELD*/
            if (ddlStatus.SelectedValue == "4" && lblStatusFinally.Text == "WAITING")
            {
                Panel4.Visible = true;
                Panel5.Visible = true;
            }
            //else
            //{
            //    Panel4.Visible = false;
            //    Panel5.Visible = false;
            //}

        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();
                var listar = new PesquisasReparos();
                GridView1.DataSource = listar.ListarRegisterByTecnico(cn, UserLagado);
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
                string User = HttpContext.Current.User.Identity.GetUserId();
                var listar = new PesquisasReparos();
                GridView1.DataSource = listar.ListarRegisterByTecnico(User);
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
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();
                var listar = new PesquisasReparos();
                GridView1.DataSource = listar.ListarRegisterByTecnico(cn, UserLagado);
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
                string UserLogado = HttpContext.Current.User.Identity.GetUserId();
                GridView1.DataSource = listar.ListarRegisterByTecnico(UserLogado);
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