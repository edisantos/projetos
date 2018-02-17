using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessObject;
using DAL;

namespace BLL.EntradaBusiness
{
    public class Class_SMD_Registros:Conexao
    {
        public void RegistroRepairSMD(Model_EntradaSMD objEntrada)
        {
            try
            {
                OpenConnection();
                string strInsert = string.Format(@"INSERT INTO dbo.EntradaRepairMain VALUES(@data,@hora,NULL,@model,@falhas,@line,NULL,@cn,@user,@tec,'SMD')");
                using (cmd = new SqlCommand(strInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");

                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@model", objEntrada.Model);
                    cmd.Parameters.AddWithValue("@falhas", objEntrada.Falhas);
                    cmd.Parameters.AddWithValue("@line", objEntrada.Line);
                    cmd.Parameters.AddWithValue("@cn", objEntrada.CN);
                    cmd.Parameters.AddWithValue("@user", objEntrada.UserName);
                    cmd.Parameters.AddWithValue("@tec", objEntrada.TecnicoSMD);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error to Insert: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objEntrada"></param>
        public void RegistroRepairSMDPrincipal(Model_EntradaSMD objEntrada)
        {
            try
            {
                OpenConnection();
                string strInsert = string.Format(@"INSERT INTO dbo.PrincipalProcessRepair 
                                                 VALUES(@data,@hora,@cod,NULL,
                                                 NULL,'',NULL,NULL,
                                                 NULL,'N/A',NULL,
                                                 '','',NULL,NULL,@user,'','WAITING','','','','SMD','0','0')");
                using (cmd = new SqlCommand(strInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");

                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@cod", objEntrada.EntradaId);
                    cmd.Parameters.AddWithValue("@user", objEntrada.UserName);
                   
                  
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public Model_EntradaSMD GetCodPai()
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT TOP(1)CodReparoMain FROM EntradaRepairMain  ORDER BY CodReparoMain DESC");
                using (cmd = new SqlCommand(strSelect, conn))
                {
                    using (Dr = cmd.ExecuteReader())
                    {
                        Model_EntradaSMD objModel = null;
                        while(Dr.Read())
                        {
                            objModel = new Model_EntradaSMD();
                            objModel.EntradaId = Convert.ToInt32(Dr[0]);
                        }
                        return objModel;
                    }
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
