using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using System.Data.SqlClient;
using DAL;

namespace BLL.EntradaBusiness.SMD
{
    public class Class_ListToRepair : Conexao
    {
        /// <summary>
        /// SMD
        /// Aqui lista os dados para analise dos Tecnicos, seja ela,amarrada ou tecnico ou não.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListaPlacaParaReparo(string user)
        {
            try
            {
                OpenConnection();
                string strObj = string.Format(@"SELECT  B.EntradaId,D.DateRepair,D.HoraRepair,A.Model,A.Sintomas,A.CN,D.StatusFinal,D.TimeTecnico,D.TimeRepair FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                WHERE (B.UserName  =@user AND D.StatusRepair ='' AND D.StatusRepair <> 'TRANSFERT TO REPAIR' AND StatusFinal ='' AND D.Area='SMD') OR (StatusFinal ='RETURN TO REPAIR' AND D.Area ='SMD' OR B.UserName is null)
                                                OR (StatusFinal ='WAITING' OR StatusFinal ='RETURN TO REPAIR' AND D.Area ='SMD')");
                using (cmd = new SqlCommand(strObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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

                throw new Exception("Erro ao listar as placas para reparo: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// LISTA NPC
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListaPlacaParaReparoNPC(string user)
        {
            try
            {
                OpenConnection();
               
                string strObj = string.Format(@"SELECT  B.EntradaId,D.DateRepair,D.HoraRepair,A.Model,A.Sintomas,A.CN,D.StatusFinal,D.TimeTecnico,D.TimeRepair FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                WHERE (B.UserName  =@user AND D.StatusRepair ='' AND D.StatusRepair <> 'TRANSFERT TO REPAIR' AND StatusFinal ='' AND D.Area='NPC') OR (StatusFinal ='RETURN TO REPAIR' AND D.Area ='NPC' OR B.UserName is null)
                                                OR (StatusFinal ='WAITING' OR StatusFinal ='RETURN TO REPAIR' AND D.Area ='NPC')");
                using (cmd = new SqlCommand(strObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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

                throw new Exception("Erro ao listar as placas para reparo: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// Lista para mostrar os dados de SMD
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListaPlacaParaRepairMan(string user)
        {
            try
            {
                OpenConnection();
                string strObj = string.Format(@"SELECT E.RepairMainId,B.EntradaId,B.Data,A.Model,A.Sintomas,A.CN FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                INNER JOIN AnalysisRepairMan E ON E.EntradaId = A.CodReparoMain
                                                WHERE (E.UserName  =@user AND E.ActionRepair ='WAITING' AND D.Area ='SMD') OR (E.UserName is NULL and D.Area ='SMD' AND E.ActionRepair ='WAITING')");
                using (cmd = new SqlCommand(strObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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

                throw new Exception("Erro ao listar as placas por Repair: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// LISTA PARA ANALISE REPAIR SMD
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListaParaAnaliseRepairSMD(string user)
        {
            try
            {
                OpenConnection();
                string strObj = string.Format(@"SELECT E.RepairMainId,B.EntradaId,B.Data,A.Model,A.Sintomas,A.CN FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                INNER JOIN AnalysisRepairMan E ON E.EntradaId = A.CodReparoMain
                                                WHERE (E.UserName  =@user AND E.ActionRepair ='WAITING' AND D.Area ='SMD') OR (E.UserName is NULL and D.Area ='SMD' AND E.ActionRepair ='WAITING')");
                using (cmd = new SqlCommand(strObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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

                throw new Exception("Erro ao listar as placas por Repair: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        public DataTable ListaPlacaParaRepairNPC(string user)
        {
            try
            {
                OpenConnection();
               
                string strObj = string.Format(@"SELECT E.RepairMainId,B.EntradaId,B.Data,A.Model,A.Sintomas,A.CN FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                INNER JOIN AnalysisRepairMan E ON E.EntradaId = A.CodReparoMain
                                                WHERE (E.UserName  =@user AND E.ActionRepair ='WAITING' AND Area ='NPC') OR (E.UserName is NULL and Area ='NPC')");
                using (cmd = new SqlCommand(strObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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

                throw new Exception("Erro ao listar as placas por Repair: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        public DataTable ListaProcessoTerminateSMD()
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.UN,A.CN,B.StatusRepair FROM EntradaRepairMain A
                                                   INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                   WHERE (StatusRepair = 'SCRAP' AND B.Area ='SMD') OR ( StatusRepair = 'FEEDBACK' AND B.Area ='SMD')");
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

        #region Updates SMD
        public void UpdateUserName(ProcessRepair objModel)
        {
            OpenConnection();
            string strUpdate = string.Format(@"UPDATE TecnicoMaisPlaca SET UserName = @user WHERE EntradaId =@cod");
            using (cmd = new SqlCommand(strUpdate, conn))
            {
                cmd.Parameters.AddWithValue("@cod", objModel.EntradaId);
                cmd.Parameters.AddWithValue("@user", objModel.RepairMan);
                try
                {
                    cmd.ExecuteNonQuery();
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
        }
        #endregion


        public void UpdateReturnRepair(SeacherRepair objModel)
        {

            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET StatusRepair =@status,StatusFinal =@statusFinal WHERE EntradaId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objModel.EntradaId);
                    cmd.Parameters.AddWithValue("@status", objModel.StatusRepair);
                    cmd.Parameters.AddWithValue("@statusFinal", objModel.StatusFinal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update the process terminate " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void InsertAnalisysRepairMan(ProcessRepair Objmod)
        {
            try
            {
                OpenConnection();
                string StrInsert = string.Format(@"INSERT INTO dbo.AnalysisRepairMan VALUES(@data,@hora,@user,@id,@action,@location,@partnumber)");
                using (cmd = new SqlCommand(StrInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@user", Objmod.RepairMan);
                    cmd.Parameters.AddWithValue("@id", Objmod.EntradaId);
                    cmd.Parameters.AddWithValue("@action", Objmod.ActionRepainMan);
                    cmd.Parameters.AddWithValue("@location", Objmod.LocationSmd);
                    cmd.Parameters.AddWithValue("@partnumber", Objmod.PartNumber);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register the RepairMan " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objModel"></param>
        public void UpdateTerminateNULL(SeacherRepair objModel)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE TecnicoMaisPlaca SET UserName =@user WHERE EntradaId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objModel.EntradaId);
                    cmd.Parameters.AddWithValue("@user", objModel.UserName);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update the process terminate " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }


    }
}
