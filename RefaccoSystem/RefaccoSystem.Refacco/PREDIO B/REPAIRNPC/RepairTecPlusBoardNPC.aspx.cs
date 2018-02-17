using BLL.EntradaBusiness;
using BLL.EntradaBusiness.SMD;
using BLL.EntradaBusiness.NPC;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.PREDIO_B.REPAIRNPC
{
    public partial class RepairTecPlusBoardNPC : System.Web.UI.Page
    {
        DropboxGenericos dropList = new DropboxGenericos();
        Class_NPC_Neg objNeg = new Class_NPC_Neg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaAll();
                getTec();

            }
        }

        public void ListaAll()
        {

            GridView1.DataSource = objNeg.ListarRegisterByRepair();
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

        public void getTec()
        {
            try
            {
                //ddlTec.DataSource = dropList.GetTecnico();
                //ddlTec.DataTextField = "UserName";
                //ddlTec.DataValueField = "Id";
                //ddlTec.DataBind();
                //ListItem item = new ListItem("SELECT TECHNICIAN", "VALUES", true); item.Selected = true;
                //ddlTec.Items.Add(item);

                string area = "NPC-REPAIR";
                ddlTec.DataSource = dropList.GetTecnico(area);
                ddlTec.DataTextField = "UserName";
                ddlTec.DataValueField = "Id";
                ddlTec.DataBind();
                ListItem item2 = new ListItem("ALL", "VALUES", true); item2.Selected = true;
                ddlTec.Items.Add(item2);
            }
            catch (Exception)
            {

                ErrorMessage.Text = "Erro ao listar os Tecnico";
            }
        }
        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;

                GridView1.DataSource = objNeg.ListarRegisterByRepair(cn);
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


                GridView1.DataSource = objNeg.ListarRegisterByRepair();
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

                GridView1.DataSource = objNeg.ListarRegisterByRepair(cn);
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


                GridView1.DataSource = objNeg.ListarRegisterByRepair();
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

        protected void ckeckBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                ((CheckBox)row.FindControl("ckeckBoxInsert")).Checked = ((CheckBox)sender).Checked;
            }
        }

        protected void ckeckBoxInsert_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)GridView1.HeaderRow.FindControl("ckeckBoxHeader");
            if (headerCheckBox.Checked)
            {
                headerCheckBox.Checked = ((CheckBox)sender).Checked;
            }
            else
            {
                bool allCheckBoxesChecked = true;
                foreach (GridViewRow gridviewRow in GridView1.Rows)
                {
                    if (!((CheckBox)gridviewRow.FindControl("ckeckBoxInsert")).Checked)
                    {
                        allCheckBoxesChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = allCheckBoxesChecked;
            }
        }

        protected void btnSalve_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("ckeckBoxInsert")).Checked)
                {

                    string EntradaId = ((Label)row.FindControl("lblCodigo")).Text;


                    Model_EntradaSMD objModel = new Model_EntradaSMD();
                    objModel.EntradaId = Convert.ToInt32(EntradaId);
                    objModel.UserName = ddlTec.SelectedValue;

                    Class_SMD_Board_Plus_Tecnico add = new Class_SMD_Board_Plus_Tecnico();
                    if(ddlTec.SelectedItem.Text!="ALL")
                    {
                        add.RegistrarTecnicoComBoard(objModel);
                        add.UpdateStatus(objModel);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Relacionamento feito com sucesso');", true);
                    }
                    else
                    {
                        add.RegistrarTecnicoComBoardNUll(objModel);
                        add.UpdateStatusNull(objModel);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Placas relacionadas a todos os tecnicos');", true);
                    }
                    
                    ListaAll();
                    getTec();
                }
            }
        }
    }
}