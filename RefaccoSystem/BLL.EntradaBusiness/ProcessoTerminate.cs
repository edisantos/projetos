using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using DAL;

namespace BLL.EntradaBusiness
{
    public class ProcessoTerminate : Conexao
    {
        public DataTable ListaProcessoTerminateAll()
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.UN,A.CN,B.StatusRepair FROM EntradaRepairMain A
                                                   INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                   WHERE (StatusRepair = 'SCRAP' AND B.Area ='CQP') OR ( StatusRepair = 'FEEDBACK' AND B.Area ='CQP')");
                using (cmd = new SqlCommand(strSelect, conn))
                {

                    using (Dpter = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao listar o processo terminate: " + ex.Message);
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
        public DataTable ListaProcessoTerminate(string cn)
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.UN,A.CN,B.StatusRepair FROM EntradaRepairMain A
                                                   INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                   WHERE (StatusRepair = 'SCRAP' AND B.Area ='CQP' AND A.CN=@cn) OR ( StatusRepair = 'FEEDBACK' AND B.Area ='CQP' AND A.CN=@cn)");
                using (cmd = new SqlCommand(strSelect, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", cn);

                    using (Dpter = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            Dpter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao listar o processo terminate: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #region Area de Registros e Updates
        public void RegistrarProcessoTerminate(SeacherRepair objModel)
        {
            try
            {
                OpenConnection();
                string strInsert = string.Format(@"INSERT INTO dbo.ProcessoTerminate VALUES(@date,@hora,@user,@status,@descr,@EntradaId)");
                using (cmd = new SqlCommand(strInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@date", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@user", objModel.UserName);
                    cmd.Parameters.AddWithValue("@status", objModel.StatusTerminate);
                    cmd.Parameters.AddWithValue("@descr", objModel.Descricao);
                    cmd.Parameters.AddWithValue("@EntradaId", objModel.EntradaId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the Insert the process terminate: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void UpdateProcessTerminate(SeacherRepair objModel)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET StatusRepair =@statusRepair,StatusFinal =@statusfinal WHERE EntradaId = @cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objModel.EntradaId);
                    cmd.Parameters.AddWithValue("@statusRepair", objModel.StatusRepair);
                    cmd.Parameters.AddWithValue("@statusfinal", objModel.StatusFinal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro to the update process terminate: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #endregion
    }
}
