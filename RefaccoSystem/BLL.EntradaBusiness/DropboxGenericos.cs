using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using DataAccessObject;

namespace BLL.EntradaBusiness
{
    public class DropboxGenericos:Conexao
    {
        /// <summary>
        /// PEGA O MODELES PARA PREENCHER DROPDOWLINST MODELO DA PAGINA ENTRADA DE REPARO
        /// </summary>
        /// <returns></returns>
        public DataTable FiltertModels()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ModeloId, Modelo FROM dbo.Modelos");
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

                throw new Exception("Error return the model" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /// <summary>
        /// PEGA O MODELES PARA PREENCHER DROPDOWLINST MODELO DA PAGINA ENTRADA DE REPARO
        /// </summary>
        /// <returns></returns>
        public DataTable FilterCodSintomas()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT SintomasId,CodSintomas, Sintomas FROM dbo.Sintomas");
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

                throw new Exception("Error return the Symptoms" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public DataTable FilterBlock()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT BlockId, Block FROM dbo.Blocks");
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

                throw new Exception("Error return the block" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public DataTable FilterPlant()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT PlantaId, Planta FROM dbo.Plantas");
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

                throw new Exception("Error return the Plant" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public Sintomas GetSymptoms(string sintomas)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT Sintomas FROM dbo.Sintomas WHERE CodSintomas = @sintomas");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@sintomas", sintomas);
                    using (Dr = cmd.ExecuteReader())
                    {
                        Sintomas model = null;
                        while(Dr.Read())
                        {
                            model = new Sintomas();
                            model.Sintoma = Convert.ToString(Dr[0]);
                        }
                        return model;
                    }
                        
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error the get the Symptoms " + ex.Message);
            }
            finally
            {
                ClosedConnection();
                
            }
        }


        /// <summary>
        /// GET PRODUCT TO FILL DROPDOWNLIST PRODUCT
        /// </summary>
        /// <param name="sintomas"></param>
        /// <returns></returns>
        public DataTable GetProducts()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ProductId,Produtos FROM dbo.Products");
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

                throw new Exception("Error the get the Products " + ex.Message);
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
        public DataTable GetUnitID()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT UnitId,Unit FROM dbo.UnitId");
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

                throw new Exception("Error the get the Unit " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetInspProcess()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ProcessID,InspProcess FROM dbo.InspProcess WHERE AreaId <> 7");
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

        public DataTable GetArea()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT AreaId,Area FROM dbo.Areas");
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

                throw new Exception("Error the get the area " + ex.Message);
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
                string str = string.Format(@"SELECT CausaId,Causa FROM dbo.DefectCause WHERE Area ='CQP'");
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

        public DataTable GetLocation()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT LocationId,Location FROM dbo.Locations WHERE Area ='CQP'");
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
        public DataTable GetLocationSMD()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT PartsCode,DesigLoc,PartsDescription FROM dbo.BOM");
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
        public DataTable GetDefectImput()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT DefectId,Defeito FROM dbo.DefectImput");
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

                throw new Exception("Error the get the Defect " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetAction()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT ActionId,Action FROM dbo.Actions");
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

                throw new Exception("Error the get the Action " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetStatus()
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT StatusID,StatusAction FROM dbo.StatusActionFinal");
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

                throw new Exception("Error the get the Status " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }

        public DataTable GetTecnico(string area)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT Id,UserName FROM dbo.AspNetUsers WHERE Funcao = 'TECNICO' AND Area =@area ORDER BY UserName DESC");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@area", area);

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

                throw new Exception("Error the get the Status " + ex.Message);
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
        public DataTable GetRepairMan(string area)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT Id,UserName FROM dbo.AspNetUsers WHERE Funcao = 'REPARADOR' AND Area =@area ORDER BY UserName ASC");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@area", area);
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

                throw new Exception("Error the get the Status " + ex.Message);
            }
            finally
            {
                ClosedConnection();

            }
        }
    }
}
