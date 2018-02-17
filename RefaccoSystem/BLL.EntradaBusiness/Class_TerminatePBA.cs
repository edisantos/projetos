using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessObject;
using DAL;
namespace BLL.EntradaBusiness
{
    public class Class_TerminatePBA : Conexao
    {
        #region Lista dados

        public DataTable ShowDataTeminatePBA()
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.EntradaId,
                                                          B.DateRepair,
                                                          B.PartNumber,
                                                          A.Model,A.Sintomas,
                                                          A.CN,B.UN,C.Causa,
                                                          D.Location,
                                                          E.Defeito,
                                                          F.Action FROM EntradaRepairMain A
                                                          INNER JOIN PrincipalProcessRepair B
                                                          ON A.CodReparoMain = B.EntradaId
                                                          INNER JOIN DefectCause C
                                                          ON B.DefectCauseId = C.CausaId
                                                          INNER JOIN Locations D
                                                          ON B.LocationId = D.LocationId
                                                          INNER JOIN DefectImput E
                                                          ON B.DefectImputId = E.defectId
                                                          INNER JOIN Actions F
                                                          ON B.ActionId = F.ActionId
                                                          WHERE StatusRepair = 'PASS' AND B.Area ='CQP'");
                using (cmd = new SqlCommand(strSelect, conn))
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

                throw new Exception("Error to the list: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
                Dpter.Dispose();
                cmd.Dispose();
            }
        }

        public DataTable ShowDataTeminatePBA(string cn)
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.EntradaId,
                                                          B.DateRepair,
                                                          B.PartNumber,
                                                          A.Model,A.Sintomas,
                                                          A.CN,B.UN,C.Causa,
                                                          D.Location,
                                                          E.Defeito,
                                                          F.Action FROM EntradaRepairMain A
                                                          INNER JOIN PrincipalProcessRepair B
                                                          ON A.CodReparoMain = B.EntradaId
                                                          INNER JOIN DefectCause C
                                                          ON B.DefectCauseId = C.CausaId
                                                          INNER JOIN Locations D
                                                          ON B.LocationId = D.LocationId
                                                          INNER JOIN DefectImput E
                                                          ON B.DefectImputId = E.defectId
                                                          INNER JOIN Actions F
                                                          ON B.ActionId = F.ActionId
                                                          WHERE StatusRepair = 'PASS' AND B.Area='CQP' AND A.CN =@cn");
                using (cmd = new SqlCommand(strSelect, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", cn);
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

                throw new Exception("Error to the list: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
                Dpter.Dispose();
                cmd.Dispose();
            }
        }
        #endregion

        #region Registro e Update do processo terminate
        public void TerminateProcessRegister(SeacherRepair objModel)
        {
             OpenConnection();
                string strInsert = string.Format(@"INSERT INTO TerminatePBA VALUES(@data,@hora,@user,@status,@descr,@entradaId)");
                using (cmd = new SqlCommand(strInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@user", objModel.UserName);
                    cmd.Parameters.AddWithValue("@status", objModel.StatusFinal);
                    cmd.Parameters.AddWithValue("@descr", objModel.Descricao);
                    cmd.Parameters.AddWithValue("@entradaId", objModel.EntradaId);
                    cmd.ExecuteNonQuery();
                }
           
            
                ClosedConnection();
           
        }

        public void UpdateProcessTerminate(SeacherRepair objModel)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET StatusRepair =@statusrepair,StatusFinal=@statusfinal  WHERE EntradaId =@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objModel.EntradaId);
                    cmd.Parameters.AddWithValue("@statusrepair", objModel.StatusRepair);
                    cmd.Parameters.AddWithValue("@statusfinal", objModel.StatusRepair);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #endregion
    }
}
