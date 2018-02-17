using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;
using DAL;
using Microsoft.AspNet.Identity;

namespace RefaccoSystem.Refacco.TerminatePBA
{
    public partial class TerminatePBA : System.Web.UI.Page
    {
        Class_TerminatePBA objTerminate = new Class_TerminatePBA();
        SeacherRepair objModel = new SeacherRepair();
        string user = HttpContext.Current.User.Identity.GetUserId();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowListTerminatePBA();
                PanelMsg.Visible = false;
                if (user == null)
                {
                    Response.Redirect("~/");
                }
            }
        }
        protected void ShowListTerminatePBA()
        {
            try
            {
                GridView1.DataSource = objTerminate.ShowDataTeminatePBA();
                GridView1.DataBind();
                if(GridView1.Rows.Count < 1)
                {
                    PanelMsg.Visible = true;
                    lblMsgError.Text = "Nenhum item encontrado!";
                    Panel1.Visible = false;
                }
                else
                {
                    Panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Error to the list: " + ex.Message;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("CkbInsert")).Checked)
                {


                    string EntradaId = ((Label)row.FindControl("lblCodigo")).Text;

                    string status = "TERMINATE";
                    string statusFinal = "PASS/" + ddlStatusFeedback.SelectedItem.Text;
                    objModel.UserName = user;
                    objModel.StatusRepair = status;
                    objModel.StatusFinal = statusFinal;
                    objModel.Descricao = txtDescription.Text;
                    objModel.EntradaId = Convert.ToInt32(EntradaId);

                    objTerminate.TerminateProcessRegister(objModel);
                    objTerminate.UpdateProcessTerminate(objModel);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Terminate feito com sucesso');", true);

                    ShowListTerminatePBA();

                }
            }
        }

        protected void CkbInsert_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)GridView1.HeaderRow.FindControl("CkbHeader");
            if (headerCheckBox.Checked)
            {
                headerCheckBox.Checked = ((CheckBox)sender).Checked;
            }
            else
            {
                bool allCheckBoxesChecked = true;
                foreach (GridViewRow gridviewRow in GridView1.Rows)
                {
                    if (!((CheckBox)gridviewRow.FindControl("CkbInsert")).Checked)
                    {
                        allCheckBoxesChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = allCheckBoxesChecked;
            }
        }

        protected void CkbHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                ((CheckBox)row.FindControl("CkbInsert")).Checked = ((CheckBox)sender).Checked;
            }
        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                var listar = new Class_TerminatePBA();
                string cn = txtSeach.Text;
                GridView1.DataSource = listar.ShowDataTeminatePBA(cn);
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

                var listar = new Class_TerminatePBA();
                GridView1.DataSource = listar.ShowDataTeminatePBA();
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
                var listar = new Class_TerminatePBA();
                string cn = txtSeach.Text;
                GridView1.DataSource = listar.ShowDataTeminatePBA(cn);
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

                var listar = new Class_TerminatePBA();
                GridView1.DataSource = listar.ShowDataTeminatePBA();
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