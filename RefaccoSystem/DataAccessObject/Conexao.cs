using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessObject
{
    public class Conexao
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader Dr;
        protected SqlDataAdapter Dpter;

        /// <summary>
        /// METHOD TO OPEN CONNECTION
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnection()
        {
            try
            {
                //string conexao = string.Format(@"Data Source=105.103.12.156\DBREFACCOSYSTEM;Initial Catalog=DbRefaccoSystem;Integrated Security=True");
                string conexao = string.Format(@"Data Source=105.103.12.156\DBREFACCOSYSTEM;Initial Catalog=DbRefaccoSystem;User ID=sa;Password=Edi318730");
                conn = new SqlConnection(conexao);
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return conn;
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error open connection" + ex.Message);
            }
        }
        /// <summary>
        /// METHOD TO CLOSED CONNECTION
        /// </summary>
        /// <returns></returns>
        public SqlConnection ClosedConnection()
        {
            try
            {
                
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return conn;

            }
            catch (Exception ex)
            {

                throw new Exception("Error Closed connection" + ex.Message);
            }
        }
    }
}
