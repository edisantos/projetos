using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class Class_SMD_GetDropboxGenerico:Conexao
    {
        /// <summary>
        /// PEGA O MODELES PARA PREENCHER DROPDOWLINST MODELO DA PAGINA ENTRADA DE REPARO
        /// </summary>
        /// <returns></returns>
        public DataTable ShowLine()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT IdLine, Line FROM dbo.LineSMD");
                using (cmd = new SqlCommand(str, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        using (Dpter = new SqlDataAdapter(cmd))
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error return the line" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ShowModel()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ModeloId, Modelo FROM dbo.Modelos");
                using (cmd = new SqlCommand(str, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        using (Dpter = new SqlDataAdapter(cmd))
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error return the model" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ShowFailure()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT IdFalhas, Falhas FROM dbo.FalhasSMD");
                using (cmd = new SqlCommand(str, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        using (Dpter = new SqlDataAdapter(cmd))
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error return the failure" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ShowRevisadora()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT IdRevisadora,Revisadora FROM dbo.RevisadoraSMD");
                using (cmd = new SqlCommand(str, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        using (Dpter = new SqlDataAdapter(cmd))
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error return the failure" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
