using BLL.EntradaBusiness;
using BLL.EntradaBusiness.CQP;
using DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.RegisterBoard
{
    public partial class RegisterBoard : System.Web.UI.Page
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
            var listar = new PesquisasReparos();
            GridView1.DataSource = listar.ListaParaAmarracao();
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
                string area = "HHP-OQC";
                ddlTec.DataSource = dropList.GetTecnico(area);
                ddlTec.DataTextField = "UserName";
                ddlTec.DataValueField = "Id";
                ddlTec.DataBind();
                ListItem item = new ListItem("SELECIONAR O TÈCNICO", "VALUES", true); item.Selected = true;
                ddlTec.Items.Add(item);

                //ddlTec.DataSource = dropList.GetTecnico();
                //ddlTec.DataTextField = "UserName";
                //ddlTec.DataValueField = "Id";
                //ddlTec.DataBind();
                //ListItem item2 = new ListItem("SELECIONAR O TÈCNICO", "VALUES", true); item.Selected = true;
                //ddlTec.Items.Add(item2);
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
                   
                    string EntradaId =((Label)row.FindControl("lblCodigo")).Text;

                    Entrada mod = new Entrada();
                    mod.EntradaId = Convert.ToInt32(EntradaId);
                    mod.Usuario = ddlTec.SelectedValue;

                    RegistrosEntrada add = new RegistrosEntrada();
                    add.RegistrarTecnicoComBoard(mod);
                    add.UpdateStatus(mod);
                    var count = new Class_Count_Day();
                    count.CountDayTecnico();
                    count.CountDayRepair();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Relacionamento feito com sucesso');", true);
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
                var listar = new PesquisasReparos();
                GridView1.DataSource = listar.ListaParaAmarracao(cn);
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
                GridView1.DataSource = listar.ListaParaAmarracao();
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
            if(txtSeach.Text !="")
            {
                string cn = txtSeach.Text;
                var listar = new PesquisasReparos();
                GridView1.DataSource = listar.ListaParaAmarracao(cn);
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
                GridView1.DataSource = listar.ListaParaAmarracao();
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