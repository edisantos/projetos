using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;
using DAL;
using System.Drawing;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Net;

namespace RefaccoSystem.Refacco.ReparoEntrada
{
    public partial class EntradaReparo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FilterModels();
                FilterCodSintomas();
                FilterBlocks();
                //FilterPlants();
                txtCN.Enabled = false;
            }

        }
        public void FilterModels()
        {
            try
            {
                var drp = new DropboxGenericos();
                ddlModelo.DataSource = drp.FiltertModels();
                ddlModelo.DataTextField = "Modelo";
                ddlModelo.DataValueField = "ModeloId";
                ddlModelo.DataBind();
                ListItem item = new ListItem("SELECIONE O MODELO", "VALUES", true); item.Selected = true;
                ddlModelo.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao listar os modelos" + ex.Message;
            }
        }

        public void FilterCodSintomas()
        {
            try
            {
                var drp = new DropboxGenericos();
                ddlCodFalhas.DataSource = drp.FilterCodSintomas();
                ddlCodFalhas.DataTextField = "CodSintomas";
                ddlCodFalhas.DataValueField = "SintomasId";
                ddlCodFalhas.DataBind();
                ListItem item = new ListItem("SELECIONE O SINTOMA", "VALUES", true); item.Selected = true;
                ddlCodFalhas.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao listar os sintomas" + ex.Message;
            }
        }

        public void FilterBlocks()
        {
            try
            {
                var drp = new DropboxGenericos();
                ddlBlock.DataSource = drp.FilterBlock();
                ddlBlock.DataTextField = "Block";
                ddlBlock.DataValueField = "BlockId";
                ddlBlock.DataBind();
                ListItem item = new ListItem("SELECIONE A LINHA", "VALUES", true); item.Selected = true;
                ddlBlock.Items.Add(item);
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao listar as blocks" + ex.Message;
            }
        }

        //public void FilterPlants()
        //{
        //    try
        //    {
        //        var drp = new DropboxGenericos();
        //        ddlPlanta.DataSource = drp.FilterPlant();
        //        ddlPlanta.DataTextField = "Planta";
        //        ddlPlanta.DataValueField = "PlantaId";
        //        ddlPlanta.DataBind();
        //        ListItem item = new ListItem("SELECT PLANT", "VALUES", true); item.Selected = true;
        //        ddlPlanta.Items.Add(item);
        //    }
        //    catch (Exception ex)
        //    {

        //        lblMsg.Text = "Erro ao listar a planta" + ex.Message;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCodFalhas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var cod = ddlCodFalhas.SelectedItem.Text;
                DropboxGenericos drl = new DropboxGenericos();
                Sintomas model = drl.GetSymptoms(cod);
                if(model != null)
                {
                    txtSintomas.Text = model.Sintoma;
                    lblMsg.Text = string.Empty;
                    txtCN.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "Nenhum sintomas encontrado";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao mostrar o Sintomas " + ex.Message;
             }
        }

        protected void txtCN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlModelo.SelectedValue) != 0 && Convert.ToInt32(ddlCodFalhas.SelectedValue) != 0 && Convert.ToInt32(ddlBlock.SelectedValue) != 0)
                {
                    //string UserLagado = Session["Id"].ToString();
                    string UserLagado = HttpContext.Current.User.Identity.GetUserId();//AQUI RECUPERA O ID USUARIO LOGADO PARA REGISTRAR NO BANCO
                    if (UserLagado != null)
                    {
                       
                        var model = new Entrada();
                        model.Serial = txtCN.Text;
                        model.ModeloId = Convert.ToInt32(ddlModelo.SelectedValue);
                        model.SintomasId = Convert.ToInt32(ddlCodFalhas.SelectedValue);
                        model.Sintomas = txtSintomas.Text;
                        model.BlockId = Convert.ToInt32(ddlBlock.SelectedValue);
                        model.Usuario = UserLagado;
                        var add = new RegistrosEntrada();
                        add.RegisterInput(model);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
                        txtCN.Text = string.Empty;

                        if (ckbMassa.Checked != true)
                        {
                            FilterModels();
                            FilterCodSintomas();
                            FilterBlocks();
                            txtCN.Enabled = false;
                            txtSintomas.Text = string.Empty;
                        }
                        else if (ckbMassa.Checked == true)
                        {

                        }
                    }
                    else
                    {
                        lblMsg.Text = "Nenhum usuário logado no momento! Por faovor entre com seu usuário e senha no sistema";
                        lblMsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sorry! Algum dos campos não foram selecionado');", true);
                }
            }
            
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao registrar " + ex.Message;
            }
        }

      
    }
}