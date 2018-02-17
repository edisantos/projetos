using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;
using DAL;
using System.Drawing;

namespace RefaccoSystem.Refacco.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// METHOD TO INSERT NEW MODEL
        /// </summary>
        protected void RegistrarModelo()
        {
            try
            {
                if (txtModelo.Text != "")
                {
                    var Model = new Modelos();
                    Model.Modelo = txtModelo.Text;
                    var registrar = new RegistrosEntrada();
                    registrar.InsertModel(Model);
                    txtModelo.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
                    //lblMsg.Text = "Registro realizado com sucesso!";
                    //lblMsg.ForeColor = Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops!Campo Modelo não pode ser vazio');", true);
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Erro ao registrar um novo modelo');", true);
                lblMsg.Text = "Erro ao Registrar o Modelo" + ex.Message;
                lblMsg.ForeColor = Color.Red;
            }
        }
        /// <summary>
        /// EVENT BUTTON TO INSERT NEW MODEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrarModelo_Click(object sender, EventArgs e)
        {
            RegistrarModelo();
        }
          
        protected void btnRegistroSintomas_Click(object sender, EventArgs e)
        {
            /*THIS EVENT OF CLASS METHOD TO INSERT THE SYMPTOMS*/
            try
            {
                if (txtSintomas.Text != "" && txtCodSintomas.Text != "")
                {
                    var symptoms = new Sintomas();
                    symptoms.CodSintomas = txtCodSintomas.Text;
                    symptoms.Sintoma = txtSintomas.Text;
                    var registrar = new RegistrosEntrada();
                    registrar.InsertSintoms(symptoms);
                    txtCodSintomas.Text = string.Empty;
                    txtSintomas.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
                    //lblMsg.Text = "Registro realizado com sucesso!";
                    //lblMsg.ForeColor = Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops!Campo Sintomas não pode ser vazio');", true);
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao registrar um novo sintomas" + ex.Message;
            }
        }

        protected void btnRegistrarBlock_Click(object sender, EventArgs e)
        {
            /*THIS EVENT OF CLASS METHOD TO INSERT THE SYMPTOMS*/
            try
            {
                if (txtBlock.Text != "")
                {
                    var model = new Blocks();
                    model.Block = txtBlock.Text;
                    
                    var registrar = new RegistrosEntrada();
                    registrar.InsertBlocks(model);
                    txtBlock.Text = string.Empty;
                   
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro feito com sucesso');", true);
                    //lblMsg.Text = "Registro realizado com sucesso!";
                    //lblMsg.ForeColor = Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ops!Campo BLock não pode ser vazio');", true);
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = "Erro ao registrar uma nova block" + ex.Message;
            }
        }
    }
}