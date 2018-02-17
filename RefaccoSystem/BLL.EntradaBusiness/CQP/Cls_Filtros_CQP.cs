using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class Cls_Filtros_CQP:Conexao
    {

        public DataTable ListarRepairMain(string user)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT D.RepairMainId,B.EntradaId,B.DateRepair,B.HoraRepair,A.Model,A.Sintomas,A.CN,B.TimeRepair FROM EntradaRepairMain A 
                                                INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.RepairMan = C.Id
                                                INNER JOIN AnalysisRepairMan D ON B.EntradaId = D.EntradaId
                                                WHERE D.ActionRepair = 'WAITING' AND D.UserName =@user");
                using (cmd = new SqlCommand(srtObj, conn))
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

                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public DataTable ListarRepairMain(string user, string cn)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT D.RepairMainId,B.DateRepair,B.HoraRepair,A.Model,A.Sintomas,A.CN,B.TimeRepair FROM EntradaRepairMain A 
                                                INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.RepairMan = C.Id
                                                INNER JOIN AnalysisRepairMan D ON B.EntradaId = D.EntradaId
                                                WHERE D.ActionRepair = 'WAITING' AND D.UserName =@user AND A.CN =@cn");
                using (cmd = new SqlCommand(srtObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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
                ClosedConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable Listar(string user)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,B.DateRepair,B.HoraRepair,A.Model,A.Sintomas,A.CN,B.TimeRepair FROM EntradaRepairMain A 
                                                INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.RepairMan = C.Id
                                                INNER JOIN AnalysisRepairMan D ON B.EntradaId = D.EntradaId
                                                WHERE D.ActionRepair = 'WAITING' AND D.UserName =@user");
                using (cmd = new SqlCommand(srtObj, conn))
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
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable Listar(string user,string cn)
        {
            try
            {
                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,B.DateRepair,B.HoraRepair,A.Model,A.Sintomas,A.CN,B.TimeRepair FROM EntradaRepairMain A 
                                                INNER JOIN PrincipalProcessRepair B ON A.CodReparoMain = B.EntradaId
                                                INNER JOIN AspNetUsers C ON B.RepairMan = C.Id
                                                INNER JOIN AnalysisRepairMan D ON B.EntradaId = D.EntradaId
                                                WHERE D.ActionRepair = 'WAITING' AND D.UserName =@user AND A.CN =@cn");
                using (cmd = new SqlCommand(srtObj, conn))
                {

                    cmd.Parameters.AddWithValue("@user", user);
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
                ClosedConnection();
            }
        }
    }
}
