using DAL;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace BLL.EntradaBusiness
{
    public class PesquisasReparos : Conexao
    {
        public List<Pesquisas> PesquisarPorCn(string cn)
        {
            try
            {
                OpenConnection();
                List<Pesquisas> lista = new List<Pesquisas>();
                string str = string.Format(@"SELECT B.CN,A.DataEntrada,A.HoraEntrada,C.Modelo,D.Produtos,E.Unit,F.InspProcess,B.Turno,G.Causa,H.Location,I.Defeito,B.Lote,B.PartNumber,J.Action,B.RepairMan,B.Comment,B.DateRepair,B.HoraRepair FROM dbo.EntradaReparo A
                                             INNER JOIN
                                             dbo.PrincipalProcessRepair B
                                             ON A.Serial = B.CN
                                             INNER JOIN 
                                             dbo.Modelos C
                                             ON A.ModeloId = C.ModeloId
                                             INNER JOIN
                                             dbo.Products D
                                             ON B.ProcessId = D.ProductId
                                             INNER JOIN 
                                             dbo.UnitId E
                                             ON B.UnitId = E.UnitId
                                             INNER JOIN 
                                             dbo.InspProcess F
                                             ON B.InspProcessID = F.ProcessID
                                             INNER JOIN
                                             dbo.DefectCause G
                                             ON B.DefectCauseId = G.CausaId
                                             INNER JOIN
                                             dbo.Locations H
                                             ON B.LocationId = H.LocationId
                                             INNER JOIN 
                                             dbo.DefectImput I
                                             ON B.DefectImputId = I.defectId
                                             INNER JOIN
                                             dbo.Actions J
                                             ON B.ActionId = J.ActionId
                                             WHERE B.CN = @cn
                                             ORDER BY B.ProcessId DESC ");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", cn);
                    using (Dr = cmd.ExecuteReader())
                    {
                        Pesquisas model = null;
                        while (Dr.Read())
                        {
                            model = new Pesquisas();
                            model.CN = Convert.ToString(Dr["CN"]);
                            model.DataEntrada = Convert.ToDateTime(Dr["DataEntrada"]);
                            model.HoraEntrada = Convert.ToDateTime(Dr["HoraEntrada"]);
                            model.Modelo = Convert.ToString(Dr["Modelo"]);
                            model.Produtos = Convert.ToString(Dr["Produtos"]);
                            model.Unit = Convert.ToString(Dr["Unit"]);
                            model.InspProcess = Convert.ToString(Dr["InspProcess"]);
                            model.Turno = Convert.ToString(Dr["Turno"]);
                            model.Causa = Convert.ToString(Dr["Causa"]);
                            model.Location = Convert.ToString(Dr["Location"]);
                            model.Defeito = Convert.ToString(Dr["Defeito"]);
                            model.Lote = Convert.ToString(Dr["Lote"]);
                            model.PartNumber = Convert.ToString(Dr["PartNumber"]);
                            model.Action = Convert.ToString(Dr["Action"]);
                            model.RepairMan = Convert.ToString(Dr["RepairMan"]);
                            model.Comment = Convert.ToString(Dr["Comment"]);
                            model.DataRepair = Convert.ToDateTime(Dr["DataRepair"]);
                            model.HoraRepair = Convert.ToDateTime(Dr["HoraRepair"]);
                            lista.Add(model);
                        }
                        return lista;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the search: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public DataTable ListaPorCn(string cn)
        {
            try
            {
                OpenConnection();

                string str = string.Format(@"SELECT B.CN,A.DataEntrada,A.HoraEntrada,C.Modelo,D.Produtos,E.Unit,F.InspProcess,B.Turno,G.Causa,H.Location,I.Defeito,B.Lote,B.PartNumber,J.Action,B.RepairMan,B.Comment,B.DateRepair,B.HoraRepair FROM dbo.EntradaReparo A
                                             INNER JOIN
                                             dbo.PrincipalProcessRepair B
                                             ON A.Serial = B.CN
                                             INNER JOIN 
                                             dbo.Modelos C
                                             ON A.ModeloId = C.ModeloId
                                             INNER JOIN
                                             dbo.Products D
                                             ON B.ProcessId = D.ProductId
                                             INNER JOIN 
                                             dbo.UnitId E
                                             ON B.UnitId = E.UnitId
                                             INNER JOIN 
                                             dbo.InspProcess F
                                             ON B.InspProcessID = F.ProcessID
                                             INNER JOIN
                                             dbo.DefectCause G
                                             ON B.DefectCauseId = G.CausaId
                                             INNER JOIN
                                             dbo.Locations H
                                             ON B.LocationId = H.LocationId
                                             INNER JOIN 
                                             dbo.DefectImput I
                                             ON B.DefectImputId = I.defectId
                                             INNER JOIN
                                             dbo.Actions J
                                             ON B.ActionId = J.ActionId
                                             WHERE B.CN = @cn
                                             ORDER BY B.ProcessId DESC ");
                using (cmd = new SqlCommand(str, conn))
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

                throw new Exception("Error to the search: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public DataTable ListarRegisterByTecnico(string usuario)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,D.DateRepair,D.HoraRepair,A.Model,A.Sintomas,A.CN,D.StatusFinal,D.TimeTecnico,D.TimeRepair FROM EntradaRepairMain A
                                                INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                WHERE B.UserName  =@user AND D.StatusRepair ='' AND StatusFinal ='' 
                                                OR (StatusFinal ='WAITING') ");
                using (cmd = new SqlCommand(srtObj, conn))
                {
                    cmd.Parameters.AddWithValue("@user", usuario);

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

                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #region Filtros da Pagina RegisterBoard Para amarração do tecnico com a placa
        /// <summary>
        /// ESTE METODO LISTA TODAS AS PLACAS QUE ESTÃO PARA SER AMARRADA COM O TECNICO
        /// OI REGISTERBOARD SCREEN
        /// </summary>
        /// <returns>CN</returns>
        public DataTable ListaParaAmarracao()
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT A.EntradaId,A.DateRepair,A.HoraRepair,B.Model,B.Sintomas,B.CN,B.UN,CodFirebird,B.Line FROM PrincipalProcessRepair A
                                                 INNER JOIN EntradaRepairMain B ON A.EntradaId = B.CodReparoMain
                                                 WHERE A.Status = 'WAITING' AND A.Area ='CQP'");
                using (cmd = new SqlCommand(srtObj, conn))
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

                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// ESTE METODO LISTA TODAS AS PLACAS QUE ESTÃO PARA SER AMARRADA COM O TECNICO FINTRANDO POR CN
        /// OI REGISTERBOARD SCREEN
        /// </summary>
        /// <returns>CN</returns>
        public DataTable ListaParaAmarracao(string cn)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT A.EntradaId,A.DateRepair,A.HoraRepair,B.Model,B.Sintomas,B.CN,B.UN,CodFirebird,B.Line FROM PrincipalProcessRepair A
                                                 INNER JOIN EntradaRepairMain B ON A.EntradaId = B.CodReparoMain
                                                 WHERE A.Status = 'WAITING' AND A.Area ='CQP' AND CN IN(@cn)");
                using (cmd = new SqlCommand(srtObj, conn))
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

                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                if(conn!=null)
                {
                    ClosedConnection();
                }
                if(cmd!=null)
                {
                    cmd.Dispose();
                }
                
                
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable ListarRegisterByTecnico(string cn, string user)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,D.DateRepair,D.HoraRepair,A.Model,A.Sintomas,A.CN,D.StatusFinal,D.TimeTecnico,D.TimeRepair FROM EntradaRepairMain A
                                                 INNER JOIN TecnicoMaisPlaca B ON A.CodReparoMain = B.EntradaId
                                                 INNER JOIN AspNetUsers C ON B.UserName = C.Id
                                                 INNER JOIN PrincipalProcessRepair D ON D.EntradaId = A.CodReparoMain
                                                 WHERE (B.UserName  =@user AND D.StatusRepair ='' AND StatusFinal ='' AND CN =@cn) 
                                                 OR (StatusFinal ='WAITING' AND CN =@cn)");
                using (cmd = new SqlCommand(srtObj, conn))
                {

                    cmd.Parameters.AddWithValue("@cn", cn);
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

                throw new Exception("Error: " + ex.Message);
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
        public List<SeacherRepair> ListarDadosParaTecnico()
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT A.EntradaId,A.DateRepair,A.HoraRepair,B.Model,B.Sintomas,B.CN,B.UN,CodFirebird,B.Line FROM PrincipalProcessRepair A
                                                 INNER JOIN EntradaRepairMain B ON A.EntradaId = B.CodReparoMain
                                                 WHERE A.Status = 'WAINTING'");

                using (cmd = new SqlCommand(srtObj, conn))
                {
                    List<SeacherRepair> list = new List<SeacherRepair>();
                    using (Dr = cmd.ExecuteReader())
                    {
                        SeacherRepair mod = null;
                        while (Dr.Read())
                        {
                            mod = new SeacherRepair();
                            mod.EntradaId = Convert.ToInt32(Dr[0]);
                            mod.DateRepair = Convert.ToDateTime(Dr[1]);
                            mod.Model = Convert.ToString(Dr[2]);
                            mod.Sintomas = Convert.ToString(Dr[3]);
                            mod.CN = Convert.ToString(Dr[4]);
                            mod.UN = Convert.ToString(Dr[5]);
                            mod.CodFirebird = Convert.ToString(Dr[6]);
                            mod.Line = Convert.ToString(Dr[7]);
                            list.Add(mod);
                        }
                        return list;
                    }
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
