using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness.NPC
{
    public class Class_NPC_Neg:Conexao
    {
        public DataTable ListarRegisterByRepair()
        {
            try
            {


                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.CN,A.UN,A.Line FROM EntradaRepairMain A
                                                INNER JOIN PrincipalProcessRepair B
                                                ON A.CodReparoMain = B.EntradaId
                                                WHERE B.Status ='WAITING' AND B.Area ='NPC' ");
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

        public DataTable ListarRegisterByRepair(string cn)
        {
            try
            {
                OpenConnection();

                string srtObj = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.CN,A.UN,A.Line FROM EntradaRepairMain A
                                                INNER JOIN PrincipalProcessRepair B
                                                ON A.CodReparoMain = B.EntradaId
                                                WHERE B.Status ='WAITING' AND B.Area ='NPC' AND A.CN =@cn");
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
                ClosedConnection();
            }
        }
    }
}
