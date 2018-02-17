using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace DataAccessObject
{
    public class DataFirebird
    {
        protected FbConnection conn;
        protected FbCommand cmd;
        protected FbDataAdapter Da;
        protected FbDataReader Dr;

        public void AbreConexaoFirebird()
        {
            try
            {
                conn = new FbConnection(@"User=SYSDBA;Password=masterkey;Database=c:\main\base\oqc.gbd;DataSource=105.103.13.107;Port=3050;Dialect=3");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao conectar ao banco " + ex.Message);
            }
        }
        public void FechaConexaoFirebird()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao fechar a conexao " + ex.Message); ;
            }
        }
    }
}
