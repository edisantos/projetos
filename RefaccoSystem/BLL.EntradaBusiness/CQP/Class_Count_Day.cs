using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using DAL;

namespace BLL.EntradaBusiness.CQP
{
    public class Class_Count_Day:Conexao
    {
        public void CountDayTecnico()
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET TimeTecnico = DATEDIFF(DD,DateRepair,@data) WHERE (Status ='TRANSFER TEC' AND StatusRepair ='') OR (StatusFinal='WAITING')");
                using (cmd = new SqlCommand(strUpdate,conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void CountDayRepair()
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET TimeRepair = DATEDIFF(DD,DateRepair,@data) WHERE Status ='TRANSFER TO REPAIR' AND StatusFinal =''");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
