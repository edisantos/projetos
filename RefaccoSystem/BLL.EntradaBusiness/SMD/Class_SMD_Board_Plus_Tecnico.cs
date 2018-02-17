using DataAccessObject;
using System;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL.EntradaBusiness.SMD
{
    public class Class_SMD_Board_Plus_Tecnico : Conexao
    {
        public DataTable ListarRegisterByRepair()
        {
            try
            {


                OpenConnection();
                string srtObj = string.Format(@"SELECT B.EntradaId,B.DateRepair,A.Model,A.Sintomas,A.CN,A.UN,A.Line FROM EntradaRepairMain A
                                                INNER JOIN PrincipalProcessRepair B
                                                ON A.CodReparoMain = B.EntradaId
                                                WHERE B.Status ='WAITING' AND B.Area ='SMD' ");
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
                                                WHERE B.Status ='WAITING' AND B.Area ='SMD' AND A.CN =@cn");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mod"></param>
        public void UpdateStatus(Model_EntradaSMD mod)
        {
            
            try
            {
                OpenConnection();
                string str = string.Format(@"UPDATE PrincipalProcessRepair SET Status='TRANSFER TEC' WHERE EntradaId = @cod");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", mod.EntradaId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao atualizar os Status: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        public void UpdateStatusNull(Model_EntradaSMD mod)
        {

            try
            {
                OpenConnection();
                //string str = string.Format(@"UPDATE PrincipalProcessRepair SET Status='TRANSFER TEC',RepairMan= NULL WHERE EntradaId = @cod");
                string str = string.Format(@"UPDATE PrincipalProcessRepair SET Status='TRANSFER TEC' WHERE EntradaId = @cod");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", mod.EntradaId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao atualizar os Status: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        /*AQUI FAZEMOS O REGISTRO DO TECNICO QUE ESTARA RELACIONADO A PLACA*/
        public void RegistrarTecnicoComBoard(Model_EntradaSMD mod)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO TecnicoMaisPlaca VALUES(@data,@cod,@user,@alocado)");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    bool alocada = true;
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@cod", mod.EntradaId);
                    cmd.Parameters.AddWithValue("@user", mod.UserName);
                    cmd.Parameters.AddWithValue("@alocado", alocada);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao registrar o tecnico + placa" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void RegistrarTecnicoComBoardNUll(Model_EntradaSMD mod)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO TecnicoMaisPlaca VALUES(@data,@cod,NULL,@alocado)");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    bool alocada = true;
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@cod", mod.EntradaId);
                    cmd.Parameters.AddWithValue("@alocado", alocada);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao registrar o tecnico + placa" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }

}
