using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessObject;
using DAL;


namespace BLL.EntradaBusiness
{
    public class Charts:Conexao
    {
        public DataSet Chart1()
        {
            string str = string.Format(@"SELECT Serial,Sintomas FROM EntradaReparo");
            using (cmd = new SqlCommand(str, conn))
            {
                using (Dpter = new SqlDataAdapter(cmd))
                {
                    using (DataSet ds = new DataSet())
                    {
                        Dpter.Fill(ds);
                        return ds;
                    }
                }
            }

        }
    }
}
