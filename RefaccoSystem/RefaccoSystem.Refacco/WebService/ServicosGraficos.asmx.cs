using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccessObject;

namespace RefaccoSystem.Refacco.WebService
{
    /// <summary>
    /// Descrição resumida de ServicosGraficos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicosGraficos : System.Web.Services.WebService
    {
        Conexao con = new Conexao();
        [WebMethod]
        public List<object> getLineChartData(string mobileId_one, string mobileId_two, string year)
        {
            List<object> iData = new List<object>();
            List<string> labels = new List<string>();
            //First get distinct Month Name for select Year.
            //string query1 = "Select distinct( DateName( month , DateAdd( month , DATEPART(MONTH,orders_date) , -1 ) )) as month_name, ";
            //query1 += " DATEPART(MONTH,orders_date) as month_number from mobile_sales  where DATEPART(YEAR,orders_date)='" + year + "'  ";
            //query1 += " order by month_number;";
            string query1 = string.Format(@"SELECT DATENAME(MONTH,DataEntrada),Sintomas,Count(Sintomas)	As Total FROM EntradaReparo
                                          GROUP BY Sintomas,DataEntrada");

            DataTable dtLabels = commonFuntionGetData(query1);
            foreach (DataRow drow in dtLabels.Rows)
            {
                labels.Add(drow["Sintomas"].ToString());
            }
            iData.Add(labels);

            string query_DataSet_1 = " select DATENAME(MONTH,DATEADD(MONTH,month(orders_date),-1 )) as month_name, month(orders_date) as month_number ,sum ";
            query_DataSet_1 += " (orders_quantity) as total_quantity  from mobile_sales  ";
            query_DataSet_1 += " where YEAR(orders_date)='" + year + "' and  mobile_id='" + mobileId_one + "'  ";
            query_DataSet_1 += " group by   month(orders_date) ";
            query_DataSet_1 += " order by  month_number  ";

            //DataTable dtDataItemsSets_1 = commonFuntionGetData(query_DataSet_1);
            List<int> lst_dataItem_1 = new List<int>();
            //foreach (DataRow dr in dtDataItemsSets_1.Rows)
            {
                //lst_dataItem_1.Add(Convert.ToInt32(dr["total_quantity"].ToString()));
            }
            iData.Add(lst_dataItem_1);

            string query_DataSet_2 = " select DATENAME(MONTH,DATEADD(MONTH,month(orders_date),-1 )) as month_name, month(orders_date) as month_number ,sum ";
            query_DataSet_2 += " (orders_quantity) as total_quantity  from mobile_sales  ";
            query_DataSet_2 += " where YEAR(orders_date)='" + year + "' and  mobile_id='" + mobileId_two + "'  ";
            query_DataSet_2 += " group by   month(orders_date) ";
            query_DataSet_2 += " order by  month_number  ";

            DataTable dtDataItemsSets_2 = commonFuntionGetData(query_DataSet_2);
            List<int> lst_dataItem_2 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_2.Rows)
            {
                lst_dataItem_2.Add(Convert.ToInt32(dr["total_quantity"].ToString()));
            }
            iData.Add(lst_dataItem_2);
            return iData;
        }
        public DataTable commonFuntionGetData(string strQuery)
        {
            //SqlDataAdapter dap = new SqlDataAdapter(strQuery, con);
            DataSet ds = new DataSet();
           // dap.Fill(ds);
            return ds.Tables[0];
        }
    }
}
