using DAL;
using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BLL.EntradaBusiness
{
    public class ListaDePlacaParaReparoOQC : Conexao
    {
        public DataTable ListaPlacaParaReparo(string user)
        {
            try
            {
                OpenConnection();
                string strObj = string.Format(@"SELECT B.EntradaId,D.DateRepair,D.HoraRepair,A.Model,A.Sintomas,A.CN,D.StatusFinal,D.TimeTecnico,D.TimeRepair FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                WHERE B.UserName  =@user AND D.StatusRepair ='' AND StatusFinal ='' OR StatusFinal ='RETURN TO REPAIR' AND D.Area='CQP'
                                                OR (StatusFinal ='WAITING' AND D.Area ='CQP')");
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
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListaPlacaParaRepairMan(string user)
        {
            try
            {
                OpenConnection();
                string strObj = string.Format(@"SELECT B.EntradaId,B.Data,A.Model,A.Sintomas,A.CN FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                INNER JOIN AnalysisRepairMan E ON E.EntradaId = A.CodReparoMain
                                                WHERE E.UserName  =@user AND E.ActionRepair ='WAITING'");



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
        /// 
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public Pesquisas ListaBom(string loc)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT PartsCode FROM dbo.BOM WHERE DesigLoc = @loc");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@loc", loc);
                    using (Dr = cmd.ExecuteReader())
                    {
                        Pesquisas model = null;
                        while (Dr.Read())
                        {
                            model = new Pesquisas();
                            model.PartNumber = Convert.ToString(Dr["PartsCode"]);
                        }
                        return model;
                    }


                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the list Location: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mod"></param>
        public void UptadeRepair(ProcessRepair mod)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"UPDATE PrincipalProcessRepair SET UN =@un,DefectCauseId=@defectCause,LocationSMD=@location,Lote=@lote,ActionId=@action,TecnicoResponsavel=@tec,StatusRepair=@statusRepair WHERE EntradaId =@cod");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", mod.EntradaId);
                    cmd.Parameters.AddWithValue("@un", mod.UN);
                    cmd.Parameters.AddWithValue("@defectCause", mod.DefectCauseId);
                    cmd.Parameters.AddWithValue("@location", mod.LocationSmd);
                    cmd.Parameters.AddWithValue("@lote", mod.lote);
                    cmd.Parameters.AddWithValue("@action", mod.ActionId);
                    cmd.Parameters.AddWithValue("@tec", mod.TecnicoResponsavel);
                    cmd.Parameters.AddWithValue("@statusRepair", mod.statusRepair);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the Update : " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// ATUALIZA AS AÇÕES DE REPARO
        /// </summary>
        /// <param name="objCod"></param>
        public void UpdateRepairManAction(SeacherRepair objCod)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE AnalysisRepairMan SET ActionRepair =@action WHERE RepairMainId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objCod.RepairMainId);
                    cmd.Parameters.AddWithValue("@action", objCod.ActionRepair);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update Action RepairMan : " +ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// ATUALIZA O TECNICO DEPOIS DAS AÇOES DO REPARADOR
        /// </summary>
        /// <param name="objCod"></param>
        public void UpdateTecnicoAfterActionRepairMan(SeacherRepair objCod)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE TecnicoMaisPlaca SET UserName =@user WHERE EntradaId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objCod.EntradaId);
                    cmd.Parameters.AddWithValue("@user", objCod.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update Action RepairMan : " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCod"></param>
        public void UpdateTecnicoAfterActionRepairManNULL(SeacherRepair objCod)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE TecnicoMaisPlaca SET UserName =NULL WHERE EntradaId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objCod.EntradaId);
                   // cmd.Parameters.AddWithValue("@user", objCod.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update Action RepairMan : " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// ESTE METODO FAZ O REGISTRO NA TABELA ANALYSISREPAIRMAN
        /// PARA RELACIONAR COM TABELA PRINCIPAL
        /// </summary>
        /// <param name="Objmod"></param>
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

        public void InsertAnalisysRepairAll(ProcessRepair Objmod)
        {
            try
            {
                OpenConnection();
                string StrInsert = string.Format(@"INSERT INTO dbo.AnalysisRepairMan VALUES(@data,@hora,NULL,@id,@action,@location,@partnumber)");
                using (cmd = new SqlCommand(StrInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@id", Objmod.EntradaId);
                    cmd.Parameters.AddWithValue("@action", Objmod.ActionRepainMan);
                    cmd.Parameters.AddWithValue("@location", Objmod.LocationSmd);
                    cmd.Parameters.AddWithValue("@partnumber", Objmod.PartNumber);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register the All RepairMan " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCod"></param>
        public void UpdateStatusFinalAfterActionRepairMan(SeacherRepair objCod)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE PrincipalProcessRepair SET StatusFinal ='WAITING' WHERE EntradaId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objCod.EntradaId);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update the Status Final : " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCod"></param>
        public void UpdateRepairMan(SeacherRepair objCod)
        {
            try
            {
                OpenConnection();
                string strUpdate = string.Format(@"UPDATE AnalysisRepairMan SET UserName =@user WHERE RepairMainId=@cod");
                using (cmd = new SqlCommand(strUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", objCod.EntradaId);
                    cmd.Parameters.AddWithValue("@user", objCod.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the update the Status Final : " + ex.Message);
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
        public void UpdateTerminate(SeacherRepair objModel)
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
        /// <summary>
        /// 
        /// </summary>
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

        #region Metodo onde lista os dados UN,CN,Causa, PartNumber e Lote para o formulario de Ação do Reparador.
        /// <summary>
        /// ESTE MOTODO LISTA OS DADOS PARA MOSTRAR NO FORMULARIO DE REGISTRO DE AÇÃO DO REPARADOR
        /// </summary>
        /// <param name="objCod"></param>
        /// <returns></returns>
        //public Pesquisas MostrarDadosRepaiMan(string objCod)
        //{
        //    try
        //    {
        //        OpenConnection();
        //        string strSelect = string.Format(@"SELECT B.UN,A.CN,C.Causa,B.PartNumber,B.Lote,D.Location FROM EntradaRepairMain A
        //                                           INNER JOIN PrincipalProcessRepair B
        //                                           ON A.CodReparoMain = B.EntradaId
        //                                           INNER JOIN DefectCause C ON C.CausaId = B.DefectCauseId
        //                                           INNER JOIN Locations D ON D.LocationId = B.LocationId
        //                                           WHERE B.EntradaId = @cod");
        //        using (cmd = new SqlCommand(strSelect, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@cod", objCod);

        //            using (Dr = cmd.ExecuteReader())
        //            {
        //                Pesquisas mod = null;
        //                while(Dr.Read())
        //                {
        //                    mod.UN = Convert.ToString(Dr["UN"]);
        //                    mod.CN = Convert.ToString(Dr["CN"]);
        //                    mod.Causa = Convert.ToString(Dr["Causa"]);
        //                    mod.PartNumber = Convert.ToString("PartNumber");
        //                    mod.Lote = Convert.ToString("Lote");
        //                    mod.Location = Convert.ToString("Location");

        //                }
        //                return mod;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new Exception("Error to the show data RepairMan: " + ex.Message);
        //    }
        //    finally
        //    {
        //        ClosedConnection();
        //    }
        //}
        #endregion
    }

}
