using DAL;
using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness.NPC
{
    public class Class_Get_Dropdown_NPC:Conexao
    {
        public DataTable GetInspProcess()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ProcessID,InspProcess FROM dbo.InspProcess WHERE AreaId =7");
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

                throw new Exception("Error the get the Insp.Process " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetLocation()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT LocationId,Location FROM dbo.Locations WHERE Area ='NPC'");
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

                throw new Exception("Error the get the location " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetDefectCause()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT CausaId,Causa FROM dbo.DefectCause WHERE Area ='NPC'");
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

                throw new Exception("Error the get the Causa " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetSymtomns()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT SintomasId,CodSintomas FROM dbo.Sintomas WHERE Area ='NPC'");
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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetLinha()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT LinhaId,Linhas FROM dbo.Linhas WHERE Area ='NPC'");
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

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public Model_NPC GetDataToInput(string cod, string cn)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT Cod,PartNumber,Model FROM dbo.BomNPC WHERE Cod= LEFT(@cod,4)");

                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", cod);
                    using (Dr = cmd.ExecuteReader())
                    {

                        Model_NPC mod = null;
                        while (Dr.Read())
                        {
                            mod = new Model_NPC();
                            mod.PartNumbe = Convert.ToString(Dr["PartNumber"]);
                            mod.Model = Convert.ToString(Dr["Model"]);
                            
                        }
                        return mod;


                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the list datas: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
