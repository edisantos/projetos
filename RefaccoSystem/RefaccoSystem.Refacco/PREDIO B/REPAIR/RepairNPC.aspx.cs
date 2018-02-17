using BLL.EntradaBusiness;
using BLL.EntradaBusiness.CQP;
using BLL.EntradaBusiness.SMD;
using DAL;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;


namespace RefaccoSystem.Refacco.PREDIO_B.REPAIR
{
    public partial class RepairNPC : System.Web.UI.Page
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

                var count = new Class_Count_Day();
                count.CountDayTecnico();
                count.CountDayRepair();
            }
        }

        public void ListaPlacaParaReparo()
        {
            try
            {
                string UserLagado = HttpContext.Current.User.Identity.GetUserId();//AQUI RECUPERA O ID USUARIO LOGADO PARA REGISTRAR NO BANCO
                string UserLagadoName = HttpContext.Current.User.Identity.GetUserName();
                var lista = new Class_ListToRepair();
                GridView1.DataSource = lista.ListaPlacaParaReparoNPC(UserLagado);
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    Logado.InnerText = "Ola, " + UserLagadoName + " segue abaixo sua lista de placas para reparo!";
                    Panel7.Visible = true;
                }
                else
                {
                    Logado.InnerText = "Ola, " + UserLagadoName + " não há nenhuma placa registrada para você!";
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
                string area = "NPC-REPAIR";
                var get = new DropboxGenericos();
                ddlSendRepair.DataSource = get.GetRepairMan(area);
                ddlSendRepair.DataTextField = "UserName";
                ddlSendRepair.DataValueField = "Id";
                ddlSendRepair.DataBind();
                ListItem item = new ListItem("ALL", "VALUES", true); item.Selected = true;
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

        public void InsertAnalysisRepairALL()
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
                reg.InsertAnalisysRepairAll(mod);

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the Insert Analysis RepairMan: " + ex.Message;
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
               // GridView1.DataSource = listar.ListarRegisterByRepair();
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblStatusFinally.Text == "")
            {
                UpdateReparo();
            }

            if (ddlSendRepair.SelectedItem.Text != "ALL" && lblStatusFinally.Text == "" && ddlStatus.SelectedValue == "4")
            {
                InsertAnalysisRepairMan();
            }

            if (ddlSendRepair.SelectedItem.Text != "ALL" && ddlStatus.SelectedValue == "4" && lblStatusFinally.Text == "WAITING")
            {
                var mod = new SeacherRepair();
                string statusFinal = "";
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                var obj = new Class_ListToRepair();
                obj.UpdateReturnRepair(mod);
                InsertAnalysisRepairMan();
                ListaPlacaParaReparo();
            }
            if (ddlSendRepair.SelectedItem.Text =="ALL" && lblStatusFinally.Text =="")
            {

                string user = HttpContext.Current.User.Identity.GetUserId();
                DAL.ProcessRepair mod = new DAL.ProcessRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.RepairMan = user;
                
                var obj = new Class_ListToRepair();

                obj.UpdateUserName(mod);
                InsertAnalysisRepairALL();
            }
            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "PASS/TERMINATE")
            {
                string user = HttpContext.Current.User.Identity.GetUserId();
                var mod = new SeacherRepair();
                string statusFinal = "PASS/TERMINATE";
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                mod.UserName = user;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                add.UpdateTerminateNULL(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Reparo Finalizado com sucesso.');", true);
                ListaPlacaParaReparo();
            }
            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "SCRAP/TERMINATE")
            {
                string user = HttpContext.Current.User.Identity.GetUserId();
                string statusFinal = "SCRAP/TERMINATE";
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                mod.UserName = user;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                add.UpdateTerminateNULL(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Item enviado para Scrap.');", true);
                ListaPlacaParaReparo();
            }

            if (lblStatusFinally.Text == "WAITING" && ddlStatus.SelectedItem.Text == "FEEDBACK")
            {
                string user = HttpContext.Current.User.Identity.GetUserId();
                string statusFinal = "FEEDBACK/TERMINATE";
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                mod.UserName = user;
                var add = new ListaDePlacaParaReparoOQC();
                add.UpdateTerminate(mod);
                add.UpdateTerminateNULL(mod);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Item enviado para Feedack.');", true);
                ListaPlacaParaReparo();
            }

            if (ddlStatus.SelectedValue == "4" && lblStatusFinally.Text == "WAITING" && ddlSendRepair.SelectedItem.Text == "ALL")
            {
                string statusFinal = "";
                string user = HttpContext.Current.User.Identity.GetUserId();
                var mod = new SeacherRepair();
                mod.EntradaId = Convert.ToInt32(lblCodigo.Text);
                mod.StatusRepair = ddlStatus.SelectedItem.Text;
                mod.StatusFinal = statusFinal;
                mod.UserName = user;
                var add = new Class_ListToRepair();
                //Atualizar o dados de returno ao reparo
                add.UpdateReturnRepair(mod);
                //Atualiza o usuario para a tabela tecnicoMaisPlaca
                add.UpdateTerminateNULL(mod);
                //Insiere um novo registro na tabela AnalysisRepairMan
                InsertAnalysisRepairAll();

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
            /*O CODOGO ABAIXO DESABILITA ALGUNS CAMPO DO FORMULARIO CASO O STATUS FINAL ESTEJA APENAS AGUARDANDO 
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
        public void InsertAnalysisRepairAll()
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
                reg.InsertAnalisysRepairAll(mod);
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the Insert Analysis RepairMan: " + ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
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
    }
}