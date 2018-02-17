using BLL.EntradaBusiness;
using System;
using System.Web.UI.WebControls;
using DAL;
using System.Web.UI;
using System.Drawing;
using System.Web;
using Microsoft.AspNet.Identity;

namespace RefaccoSystem.Refacco.PREDIO_A.SMD.EntradaSMD
{
    public partial class EntradaSMD : System.Web.UI.Page
    {
        Class_SMD_GetDropboxGenerico getNeg = new Class_SMD_GetDropboxGenerico();
        Class_SMD_Registros list = new Class_SMD_Registros();
        Model_EntradaSMD objModel = new Model_EntradaSMD();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowLine();
                ShowFailure();
                ShowModel();
                ShowRevisadora();
                txtCN.Enabled = false;
            }
        }
        #region DropDownList
        public void ShowLine()
        {
            try
            {
                ddlBlock.DataSource = getNeg.ShowLine();
                ddlBlock.DataTextField = "Line";
                ddlBlock.DataValueField = "IdLine";
                ddlBlock.DataBind();
                ListItem item = new ListItem("SELECIONE A LINHA", "VALUES", true); item.Selected = true;
                ddlBlock.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error to the show Line: " + ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowModel()
        {
            try
            {
                ddlModelo.DataSource = getNeg.ShowModel();
                ddlModelo.DataTextField = "Modelo";
                ddlModelo.DataValueField = "ModeloId";
                ddlModelo.DataBind();
                ListItem item = new ListItem("SELECIONE O MODELO", "VALUES", true); item.Selected = true;
                ddlModelo.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error to the show Line: " + ex.Message;
            }
        }

        public void ShowFailure()
        {
            try
            {
                ddlFalhas.DataSource = getNeg.ShowFailure();
                ddlFalhas.DataTextField = "Falhas";
                ddlFalhas.DataValueField = "IdFalhas";
                ddlFalhas.DataBind();
                ListItem item = new ListItem("SELECIONE A FAILHA", "VALUES", true); item.Selected = true;
                ddlFalhas.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error to the show failure: " + ex.Message;
            }
        }

        public void ShowRevisadora()
        {
            try
            {
                ddlRevisadora.DataSource = getNeg.ShowRevisadora();
                ddlRevisadora.DataTextField = "Revisadora";
                ddlRevisadora.DataValueField = "IdRevisadora";
                ddlRevisadora.DataBind();
                ListItem item = new ListItem("SELECIONE A REVISADORA", "VALUES", true); item.Selected = true;
                ddlRevisadora.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error to the show revisadora: " + ex.Message;
            }
        }
        #endregion
        #region Registros
        public void RegistroEntrada()
        {
            try
            {
                string user = HttpContext.Current.User.Identity.GetUserId();
                objModel.Model = ddlModelo.SelectedItem.Text;
                objModel.Falhas = ddlFalhas.SelectedItem.Text;
                objModel.Line = ddlBlock.SelectedItem.Text;
                objModel.UserName = user;
                objModel.CN = txtCN.Text;
                objModel.TecnicoSMD = ddlRevisadora.SelectedValue;
                Class_SMD_Registros reg = new Class_SMD_Registros();
                reg.RegistroRepairSMD(objModel);
                getCodPai();
                RegisterPrincipal();
                txtCN.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
                if(ckbMassa.Checked)
                {
                    txtCN.Enabled = true;
                }
                else
                {
                    txtCN.Enabled = false;
                }
               
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error Register: " + ex.Message;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void getCodPai()
        {
            try
            {
              
                objModel = list.GetCodPai();
                if(objModel!=null)
                {
                    lblCodPai.Text = Convert.ToString(objModel.EntradaId);
                }
                else
                {
                    lblMsg.Text = "Nunhum codigo retornado!";
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error ao recuperar o Codigo: " + ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RegisterPrincipal()
        {
            try
            {
                string user = HttpContext.Current.User.Identity.GetUserId();
                objModel.UserName = user;
                objModel.EntradaId = Convert.ToInt32(lblCodPai.Text);
                list.RegistroRepairSMDPrincipal(objModel);

            }
            catch (Exception ex)
            {

                lblMsg.Text = "Error ao registrar o codigo Pai: " + ex.Message;
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtCN_TextChanged(object sender, EventArgs e)
        {
            if(ckbMassa.Checked)
            {
                if (txtCN.Text != "" && ddlBlock.SelectedItem.Text!= "SELECT LINE" && ddlFalhas.SelectedItem.Text != "SELECT FAIL" && ddlModelo.SelectedItem.Text != "SELECT MODEL" && ddlRevisadora.SelectedItem.Text != "SELECT REVISADORA")
                {
                    RegistroEntrada();
                   
                }
                else
                {
                    lblMsg.Text = "Algum campo não foi selecionado!";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                if (txtCN.Text != "" && ddlBlock.SelectedItem.Text != "SELECT LINE" && ddlFalhas.SelectedItem.Text != "SELECT FAIL" && ddlModelo.SelectedItem.Text != "SELECT MODEL" && ddlRevisadora.SelectedItem.Text != "SELECT REVISADORA")
                {
                    RegistroEntrada();
                    ShowLine();
                    ShowFailure();
                    ShowModel();
                    ShowRevisadora();
                }
                else
                {
                    lblMsg.Text = "Algum campo não foi selecionado!";
                    lblMsg.ForeColor = Color.Red;
                }
            }
           
        }

        protected void ddlFalhas_TextChanged(object sender, EventArgs e)
        {
            txtCN.Enabled = true;
        }
    }
}