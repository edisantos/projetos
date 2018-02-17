using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;

namespace RefaccoSystem.Refacco.PREDIO_A.MAIN.SEARCH
{
    public partial class SearchMain : System.Web.UI.Page
    {
        PesquisaMain lista = new PesquisaMain();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListAll();
            }
        }
        public void ListAll()
        {
            try
            {
                GridView1.DataSource = lista.SearchMain();
                GridView1.DataBind();
                if(GridView1.Rows.Count < 1)
                {
                    lblMsg.Text = "Nenhum item encontrado!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro na pesquisa: " + ex.Message;
            }
        }
        /// <summary>
        /// SEARCH BY DATE
        /// </summary>
        public void ListBydate()
        {
            try
            {
                string data1 = txtdate1.Text;
                 string data2 = txtdate2.Text;
                GridView1.DataSource = lista.SearchMain(data1,data2);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    lblMsg.Text = "Nenhum item encontrado!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro na pesquisa: " + ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ListCN()
        {
            try
            {
                string cn = txtCN.Text;              
                GridView1.DataSource = lista.SearchMain(cn);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    lblMsg.Text = "Nenhum item encontrado!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro na pesquisa: " + ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ListUN()
        {
            try
            {
                string un = txtCodigo.Text;
                GridView1.DataSource = lista.SearchUn(un);
                GridView1.DataBind();
                if (GridView1.Rows.Count < 1)
                {
                    lblMsg.Text = "Nenhum item encontrado!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro na pesquisa: " + ex.Message;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtdate1.Text !="" && txtdate2.Text!="" && txtCN.Text =="" && txtCodigo.Text =="")
            {
                ListBydate();
            }
            if (txtdate1.Text == "" && txtdate2.Text == "" && txtCN.Text == "" && txtCodigo.Text == "")
            {
                ListAll();
            }
            if (txtdate1.Text == "" && txtdate2.Text == "" && txtCN.Text != "" && txtCodigo.Text == "")
            {
                ListCN();
            }
            if (txtdate1.Text == "" && txtdate2.Text == "" && txtCN.Text == "" && txtCodigo.Text != "")
            {
                ListUN();
            }
        }
    }
}