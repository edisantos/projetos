using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.EntradaBusiness;

namespace RefaccoSystem.Refacco.RegisterBoard
{
    public partial class TecnicoBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListaAll();
            }
            
        }
        public void ListaAll()
        {
            var listar = new PesquisasReparos();
            GridView1.DataSource = listar.ListarDadosParaTecnico();
            GridView1.DataBind();
            if (GridView1.Rows.Count < 1)
            {
              Console.Write("Nenhuma placa para reparo");
            }




        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl = (Label)row.FindControl("lblCodigo");
            lblCod.Text = lbl.Text;
        }

        protected void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    // CheckBox chk = (CheckBox)row.Cells[1].FindControl("ckBox");
            //    CheckBox chk = (CheckBox)row.FindControl("ckBox");
            //    if (chk != null)
            //    {
            //        //GridViewRow rw = (GridViewRow)chk.Parent.Parent;
            //        //codigo += Convert.ToInt32(GridView1.DataKeys[rw.RowIndex].Value);
            //        lblCodigoEnvio.Text = row.Cells[1].Text;
            //    }
            //}
        }

        protected void btnTEste_Click(object sender, EventArgs e)
        {
            string codigochamado = "";
            foreach (GridViewRow row in GridView1.Rows)
            {
                //CheckBox chk = (CheckBox)row.Cells[0].FindControl("ckBox");
                 CheckBox chk = (CheckBox)row.FindControl("ckBox");
                if (chk != null && chk.Checked)
                {

                    //GridViewRow rw = (GridViewRow)chk.Parent.Parent;
                    Label lbl = (Label)row.FindControl("lblCodigo");

                    //codigochamado += Convert.ToInt32(GridView1.DataKeys[rw.RowIndex].Value);
                    lblCodigoEnvio.Text = lbl.Text;

                }
            }


        }
    }
}