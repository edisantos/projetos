using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class PesquisaMain:Conexao
    {
        public DataTable SearchMain()
        {
            try
            {
                OpenConnection();
                //string strSelect = string.Format(@"SELECT TOP(10) B.DateRepair,B.HoraRepair,A.CodFirebird,A.CN,A.UN,A.Model,A.Sintomas,B.PartNumber,C.UserName FROM EntradaRepairMain A
                //                                 INNER JOIN PrincipalProcessRepair B
                //                                 ON A.CodReparoMain = B.EntradaId
                //                                 INNER JOIN AspNetUsers C
                //                                 ON A.UserName = C.Id AND Areas ='MAIN' ORDER BY CodReparoMain DESC");

                string strSelect = string.Format(@"SELECT TOP(10)Data,Hora,CodFirebird,CN,UN,Model,Sintomas,B.UserName FROM EntradaRepairMain A
                                                   INNER JOIN AspNetUsers B ON B.Id = A.UserName
                                                   WHERE Areas = 'MAIN'");
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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// BY DATE
        /// </summary>
        /// <returns></returns>
        public DataTable SearchMain(string date1, string date2)
        {
            try
            {
                OpenConnection();
                //string strSelect = string.Format(@"SELECT B.DateRepair,B.HoraRepair,A.CodFirebird,A.CN,A.UN,A.Model,A.Sintomas,B.PartNumber,C.UserName FROM EntradaRepairMain A
                //                                 INNER JOIN PrincipalProcessRepair B
                //                                 ON A.CodReparoMain = B.EntradaId
                //                                 INNER JOIN AspNetUsers C
                //                                 ON A.UserName = C.Id 
                //                                 WHERE B.DateRepair BETWEEN @date1 AND @date2 AND Areas ='MAIN'
                //                                 ORDER BY CodReparoMain DESC
                //                                 ");
                string strSelect = string.Format(@"SELECT Data,Hora,CodFirebird,CN,UN,Model,Sintomas,B.UserName FROM EntradaRepairMain A
                                                   INNER JOIN AspNetUsers B ON B.Id = A.UserName
                                                   WHERE Data BETWEEN @date1 AND @date2 AND Areas = 'MAIN'");
                using (cmd = new SqlCommand(strSelect, conn))
                {
                    cmd.Parameters.AddWithValue("@date1", date1);
                    cmd.Parameters.AddWithValue("@date2", date2);
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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /// <summary>
        /// BY DATE
        /// </summary>
        /// <returns></returns>
        public DataTable SearchMain(string cn)
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT B.DateRepair,B.HoraRepair,A.CodFirebird,A.CN,A.UN,A.Model,A.Sintomas,B.PartNumber,C.UserName FROM EntradaRepairMain A
                                                 INNER JOIN PrincipalProcessRepair B
                                                 ON A.CodReparoMain = B.EntradaId
                                                 INNER JOIN AspNetUsers C
                                                 ON A.UserName = C.Id 
                                                 WHERE CN = @cn AND Areas ='MAIN'
                                                 ORDER BY CodReparoMain DESC
                                                 ");
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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }


        /// <summary>
        /// BY DATE
        /// </summary>
        /// <returns></returns>
        public DataTable SearchUn(string cod)
        {
            try
            {
                OpenConnection();
                string strSelect = string.Format(@"SELECT A.Data,A.Hora,A.CodFirebird,A.CN,A.UN,A.Model,A.Sintomas,B.PartNumber,C.UserName FROM EntradaRepairMain A
                                                 INNER JOIN PrincipalProcessRepair B
                                                 ON A.CodReparoMain = B.EntradaId
                                                 INNER JOIN AspNetUsers C
                                                 ON A.UserName = C.Id 
                                                 WHERE CodFirebird = @cod AND Areas ='MAIN'
                                                 ORDER BY CodReparoMain DESC
                                                 ");
                using (cmd = new SqlCommand(strSelect, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", cod);

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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
