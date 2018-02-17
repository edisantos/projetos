using BLL.EntradaBusiness;
using BLL.EntradaBusiness.NPC;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Drawing;

namespace RefaccoSystem.Refacco.PREDIO_B.MAINNPC
{
    public partial class MainNPCRegister : System.Web.UI.Page
    {
        string PnGlobal;
        string DataGlobal;
        string HoraGlobal;
        string CNGlobal;
        string CodFireGlobal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProducts();
                GetUnit();
                GetInspProcess();
                GetDefectCause();
                GetSintomas();
                GetStatus();
                GetActions();
                GetLocation();
                GetDefectInput();
                GetLinhas();
                titleLista.Visible = false;
                ddlUnitId.AutoPostBack = true;
                Panel1.Visible = false;
                ddlProduto.Enabled = false;
                ddlProduto.SelectedIndex = 4;

            }
        }

        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            try
            {

                string cn = txtCn.Text;
                string cod = txtCn.Text;
                PnGlobal = txtCn.Text;
                //var listar = new GetDataEntradaRepair();
                var listar = new Class_Get_Dropdown_NPC();
                Model_NPC mod = listar.GetDataToInput(cod, cn);
                if (mod != null)
                {
                    txtModels.Text = mod.Model;
                    txtPartNumber.Text = mod.PartNumbe;

                }
                else
                {
                    lblMsgError.Text = "Nenhum item encontrado para este codigo: ";
                }

                /*AQUI CHAMO O METODO PARA REGISTRAR OS DADOS QUE VEM DE MAIN LINE NO BANCO SQL LOGO APOS A PESQUISA DOS MESMO*/
                InsertInputRepairOfMainlin();
                /*FIM */


                var RetunCod = new GetDataEntradaRepair();
                SeacherRepair modCod = RetunCod.GetCodRegisterNPC(cod, cn);
                if (modCod != null)
                {
                    lblCodEntrada.Text = Convert.ToString(modCod.EntradaId);
                }
            }
            catch (Exception ex)
            {
                Panel1.Visible = true;
                lblMsgError.Text = "Error to the search: " + ex.Message;
            }





            try
            {
                titleLista.Visible = true;
                string pn = txtCn.Text;
                var listaGrid = new GetDataEntradaRepair();
                GrdLista.DataSource = listaGrid.GetAllDataPerPartnumber(PnGlobal);
                GrdLista.DataBind();
                if (GrdLista.Rows.Count < 1)
                {
                    Panel1.Visible = true;
                    lblMsgError.Text = "Nenhum item encontrado, pois não há entrada registrada. ";
                }


                Entrada mod = listaGrid.CountRegisterEntrada(PnGlobal);//AQUI FAZ CONTAGEM DOS REGISTROS
                if (mod != null)
                {
                    lblCount.InnerText = "Total de Reparos: " + mod.Serial;
                }
                else
                {
                    lblCount.InnerText = "Nenhum item encontrado: " + mod.Serial;
                }
            }
            catch (Exception ex)
            {
                Panel1.Visible = true;
                lblMsgError.Text = "Nenhuma entrada encontrada: " + ex.Message;
            }
        }

        #region Registro de Entrada de Reparo de Mainline
        /// <summary>
        /// ESTE METODO FAZ O REGISTRO DOS APARELHOS DE REPARO QUE VEM DA MAINLINE DO BANCO
        /// FIREBIRD DO SISTEMA DO TEROSSI. 
        /// </summary>
        public void InsertInputRepairOfMainlin()
        {
            try
            {

                if(DdlSimtomas.SelectedItem.Text!= "SELECIONE O SINTOMA" && ddlBlocks.SelectedItem.Text!= "SELECIONE A LINHA")
                {
                    string user = HttpContext.Current.User.Identity.GetUserId();
                    SeacherRepair objMod = new SeacherRepair();
                    //objMod.data = Convert.ToDateTime(DataGlobal);
                    //objMod.hora = HoraGlobal;
                    //objMod.CodFirebird = CodFireGlobal;
                    objMod.Modelo = txtModels.Text;
                    objMod.Simtomas = DdlSimtomas.SelectedItem.Text;
                    objMod.Block = ddlBlocks.SelectedItem.Text;
                    objMod.UN = txtUn.Text;
                    objMod.CN = PnGlobal;
                    objMod.UserName = user;
                    var ObjInsert = new RegistrosEntrada();
                    ObjInsert.InsertInputRepairOfNPC(objMod);
                    txtCn.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Linha ou Sintomas não foram selecionado! Selecione e tente novamente');", true);
                }
                

            }
            catch (Exception ex)
            {
                Panel1.Visible = true;
                lblMsgError.Text = "Erro ao registrar os dados de reparo: " + ex.Message;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void GetProducts()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlProduto.DataSource = get.GetProducts();
                ddlProduto.DataTextField = "Produtos";
                ddlProduto.DataValueField = "ProductId";
                ddlProduto.DataBind();
                ListItem item = new ListItem("SELECIONE O PRODUTO", "VALUES", true); item.Selected = true;
                ddlProduto.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetUnit()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlUnitId.DataSource = get.GetUnitID();
                ddlUnitId.DataTextField = "Unit";
                ddlUnitId.DataValueField = "UnitId";
                ddlUnitId.DataBind();
                ListItem item = new ListItem("SELECIONE UNIT ID", "VALUES", true); item.Selected = true;
                ddlUnitId.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetInspProcess()
        {
            try
            {
                var get = new Class_Get_Dropdown_NPC();
                ddlInpsProcess.DataSource = get.GetInspProcess();
                ddlInpsProcess.DataTextField = "InspProcess";
                ddlInpsProcess.DataValueField = "ProcessID";
                ddlInpsProcess.DataBind();
                ListItem item = new ListItem("SELECIONE INSP.PROCESSO", "VALUES", true); item.Selected = true;
                ddlInpsProcess.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetDefectCause()
        {
            try
            {
                var get = new Class_Get_Dropdown_NPC();
                ddlDefectCause.DataSource = get.GetDefectCause();
                ddlDefectCause.DataTextField = "Causa";
                ddlDefectCause.DataValueField = "CausaId";
                ddlDefectCause.DataBind();
                ListItem item = new ListItem("SELECIONE A CAUSA", "VALUES", true); item.Selected = true;
                ddlDefectCause.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetSintomas()
        {
            try
            {
                var get = new Class_Get_Dropdown_NPC();
                DdlSimtomas.DataSource = get.GetSymtomns();
                DdlSimtomas.DataTextField = "CodSintomas";
                DdlSimtomas.DataValueField = "SintomasId";
                DdlSimtomas.DataBind();
                ListItem item = new ListItem("SELECIONE O SINTOMA", "VALUES", true); item.Selected = true;
                DdlSimtomas.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsgError.Text = "Erro ao listar os sintomas: " + ex.Message;
            }
        }
        public void GetLocation()
        {
            try
            {
                var get = new Class_Get_Dropdown_NPC();
                ddlLocation.DataSource = get.GetLocation();
                ddlLocation.DataTextField = "Location";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
                ListItem item = new ListItem("SELECT O LOCATION", "VALUES", true); item.Selected = true;
                ddlLocation.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void GetLinhas()
        {
            try
            {
                var get = new Class_Get_Dropdown_NPC();
                ddlBlocks.DataSource = get.GetLinha();
                ddlBlocks.DataTextField = "Linhas";
                ddlBlocks.DataValueField = "LinhaId";
                ddlBlocks.DataBind();
                ListItem item = new ListItem("SELECIONE A LINHA", "VALUES", true); item.Selected = true;
                ddlBlocks.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void GetDefectInput()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlDefectImput.DataSource = get.GetDefectImput();
                ddlDefectImput.DataTextField = "Defeito";
                ddlDefectImput.DataValueField = "defectId";
                ddlDefectImput.DataBind();
                ListItem item = new ListItem("SELECIONE O DEFEITO", "VALUES", true); item.Selected = true;
                ddlDefectImput.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

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
        public void GetStatus()
        {
            try
            {
                var get = new DropboxGenericos();
                ddlStatus.DataSource = get.GetStatus();
                ddlStatus.DataTextField = "StatusAction";
                ddlStatus.DataValueField = "StatusID";
                ddlStatus.DataBind();
                ListItem item = new ListItem("SELECIONE O STATUS", "VALUES", true); item.Selected = true;
                ddlStatus.Items.Add(item);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void ddlUnitId_TextChanged(object sender, EventArgs e)
        {
            if (ddlUnitId.SelectedItem.Text == "MAIN B/D")
            {
                txtUn.Enabled = false;
                ddlDefectCause.Enabled = false;
                ddlLocation.Enabled = false;
                ddlDefectImput.Enabled = false;
                txtLote.Enabled = false;
                txtPartNumber.Enabled = false;
                ddlAction.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Nesta opção alguns campos serão bloqueados!');", true);
            }
            else if (ddlUnitId.SelectedItem.Text == "SUB ASSY")
            {
                txtUn.Enabled = true;
                ddlDefectCause.Enabled = true;
                ddlLocation.Enabled = true;
                ddlDefectImput.Enabled = true;
                txtLote.Enabled = true;
                txtPartNumber.Enabled = true;
                ddlAction.Enabled = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Campos liberados! Nesta opção você deve preencher todos os campos');", true);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitId.SelectedItem.Text == "SUB ASSY")//verifica a opção  do Unit Id. Nesta opção sera logado todos os campos
                {

                    if (User != null)//Verifica se existe usuario logago
                    {
                        string codLocation = "N/A";
                        string user = HttpContext.Current.User.Identity.GetUserId();
                        DAL.ProcessRepair modelo = new DAL.ProcessRepair();
                        modelo.EntradaId = Convert.ToInt32(lblCodEntrada.Text);
                        modelo.ProductId = Convert.ToInt32(ddlProduto.SelectedValue);
                        modelo.Unitid = Convert.ToInt32(ddlUnitId.SelectedValue);
                        modelo.UN = txtUn.Text.ToString().ToUpper(); ;
                        modelo.InsProcessID = Convert.ToInt32(ddlInpsProcess.SelectedValue);
                        modelo.DefectCauseId = Convert.ToInt32(ddlDefectCause.SelectedValue);
                        modelo.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);
                        modelo.LocationSmd = codLocation;
                        modelo.DefectImputId = Convert.ToInt32(ddlDefectImput.SelectedValue);
                        modelo.lote = txtLote.Text.ToString().ToUpper(); ;
                        modelo.PartNumber = txtPartNumber.Text.ToString().ToUpper();
                        modelo.ActionId = Convert.ToInt32(ddlAction.SelectedValue);
                        modelo.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
                        modelo.RepairMan = user;
                        modelo.Comment = txtComment.Text.ToString().ToUpper();
                        modelo.EntradaSMDId = 0;
                        var salve = new RegistroPrincipalReparoMain();
                        salve.RegitrarReparoMainNPC(modelo);
                        txtCn.Text = string.Empty;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);

                        Panel1.Visible = false;
                        lblMsgError.Text = string.Empty;

                    }
                    else
                    {
                        lblMsgError.Text = "Nenhum usuário logado! Por favor você precisa estar logado no sistema para esta função";
                        lblMsgError.ForeColor = Color.Red;
                    }
                    if (ckbMassa.Checked != true) //Caso o Checkbox for true registro sera em massa
                    {
                        //GetProducts();
                        GetUnit();
                        GetInspProcess();
                        //GetArea();
                        GetDefectCause();
                        GetStatus();
                        GetActions();
                        GetLocation();
                        GetDefectInput();
                        txtCn.Focus();
                        txtUn.Text = string.Empty;
                        txtModels.Text = string.Empty;
                        //txtSimtomas.Text = string.Empty;
                        //txtBlocks.Text = string.Empty;
                        txtLote.Text = string.Empty;
                        txtPartNumber.Text = string.Empty;
                        txtComment.Text = string.Empty;

                    }
                    else if (ckbMassa.Checked == true)
                    {
                        txtCn.Focus();
                    }
                }
                else if (ddlUnitId.SelectedItem.Text == "MAIN B/D")
                {
                    if (User != null)
                    {
                        string user = HttpContext.Current.User.Identity.GetUserId();
                        DAL.ProcessRepair modelo = new DAL.ProcessRepair();
                        modelo.EntradaId = Convert.ToInt32(lblCodEntrada.Text);
                        modelo.ProductId = Convert.ToInt32(ddlProduto.SelectedValue);
                        modelo.Unitid = Convert.ToInt32(ddlUnitId.SelectedValue);
                        modelo.InsProcessID = Convert.ToInt32(ddlInpsProcess.SelectedValue);
                        modelo.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
                        modelo.PartNumber = txtPartNumber.Text;
                        modelo.RepairMan = user;
                        modelo.Comment = txtComment.Text.ToString().ToUpper();
                        modelo.EntradaSMDId = 0;
                        var salve = new RegistroPrincipalReparoMain();
                        salve.RegitrarReparoMainNUllNPC(modelo);
                        txtCn.Text = string.Empty;
                        Panel1.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);

                        lblMsgError.Text = string.Empty;
                    }
                    else
                    {
                        lblMsgError.Text = "Nenhum usuário logado! Por favor você precisa estar logado no sistema para esta função";
                        lblMsgError.ForeColor = Color.Red;
                    }
                    if (ckbMassa.Checked != true)
                    {
                        //GetProducts();
                        GetUnit();
                        GetInspProcess();
                        //GetArea();
                        GetDefectCause();
                        GetStatus();
                        GetActions();
                        GetLocation();
                        GetDefectInput();
                        txtCn.Focus();
                        txtUn.Text = string.Empty;
                        txtModels.Text = string.Empty;
                        GetSintomas();
                        //txtBlocks.Text = string.Empty;
                        txtLote.Text = string.Empty;
                        txtPartNumber.Text = string.Empty;
                        txtComment.Text = string.Empty;

                    }
                    else if (ckbMassa.Checked == true)
                    {
                        txtCn.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Panel1.Visible = true;
                lblMsgError.Text = "Erro ao registrar: " + ex.Message;
                lblMsgError.ForeColor = Color.Red;
            }
        }
    }
}