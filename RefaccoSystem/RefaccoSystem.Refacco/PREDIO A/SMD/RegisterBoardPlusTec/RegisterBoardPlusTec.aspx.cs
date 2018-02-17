using BLL.EntradaBusiness.SMD;
using BLL.EntradaBusiness;
using DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.PREDIO_A.SMD.RegisterBoardPlusTec
{
    public partial class RegisterBoardPlusTec : System.Web.UI.Page
    {
        DropboxGenericos dropList = new DropboxGenericos();
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
            var listar = new Class_SMD_Board_Plus_Tecnico();
            GridView1.DataSource = listar.ListarRegisterByRepair();
            GridView1.DataBind();
            if (GridView1.Rows.Count < 1)
            {
                ErrorMessage.Text = "Nenhuma placa para reparo";
                Panel2.Visible = false;
                //bntFormulario.Visible = false;
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
                //ListItem item = new ListItem("ALL", "VALUES", true); item.Selected = true;
                //ddlTec.Items.Add(item);

                string area = "HHP-SMD";
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

                    if (ddlTec.SelectedItem.Text != "ALL")
                    {
                        add.RegistrarTecnicoComBoard(objModel);
                        add.UpdateStatus(objModel);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Relacionamento feito com sucesso');", true);
                    }
                    else
                    {
                        add.RegistrarTecnicoComBoardNUll(objModel);
                        add.UpdateStatusNull(objModel);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Relacionamento feito com sucesso');", true);
                    }

                    ListaAll();
                    getTec();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                var listar = new Class_SMD_Board_Plus_Tecnico();
                GridView1.DataSource = listar.ListarRegisterByRepair(cn);
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

                var listar = new Class_SMD_Board_Plus_Tecnico();
                GridView1.DataSource = listar.ListarRegisterByRepair();
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

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            if (txtSeach.Text != "")
            {
                string cn = txtSeach.Text;
                var listar = new Class_SMD_Board_Plus_Tecnico();
                GridView1.DataSource = listar.ListarRegisterByRepair(cn);
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

                var listar = new Class_SMD_Board_Plus_Tecnico();
                GridView1.DataSource = listar.ListarRegisterByRepair();
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