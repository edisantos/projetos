using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataAccessObject;
using System.Data;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class RegistroPrincipalReparoMain : Conexao
    {
        public void RegitrarReparoMain(ProcessRepair objAdd)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.PrincipalProcessRepair VALUES(@data,@hora,@entradaId,@ProductId,
                                           @unitId,@un,@inspProcessId,@defectCauseId,@locationId,@LocationSmd,@DefectImputId,
                                           @lote,@partnumber,@actionId,@statusId,@repair,@comentario,'TERMINATE','','','','CQP','0','0')");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@entradaId", objAdd.EntradaId);
                    cmd.Parameters.AddWithValue("@ProductId", objAdd.ProductId);
                    cmd.Parameters.AddWithValue("@unitId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@un", objAdd.UN);
                    cmd.Parameters.AddWithValue("@inspProcessId", objAdd.InsProcessID);
                    cmd.Parameters.AddWithValue("@defectCauseId", objAdd.DefectCauseId);
                    cmd.Parameters.AddWithValue("@locationId", objAdd.LocationId);
                    cmd.Parameters.AddWithValue("@LocationSmd", objAdd.LocationSmd);
                    cmd.Parameters.AddWithValue("@DefectImputId", objAdd.DefectImputId);
                    cmd.Parameters.AddWithValue("@lote", objAdd.lote);
                    cmd.Parameters.AddWithValue("@partnumber", objAdd.PartNumber);
                    cmd.Parameters.AddWithValue("@actionId", objAdd.ActionId);
                    cmd.Parameters.AddWithValue("@statusId", objAdd.StatusId);
                    cmd.Parameters.AddWithValue("@repair", objAdd.RepairMan);
                    cmd.Parameters.AddWithValue("@comentario", objAdd.Comment);
                   
                    //if (string.IsNullOrEmpty(Convert.ToString(objAdd.EntradaSMDId)))
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", objAdd.EntradaSMDId);
                    //}
                   
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void RegitrarReparoMainNPC(ProcessRepair objAdd)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.PrincipalProcessRepair VALUES(@data,@hora,@entradaId,@ProductId,
                                           @unitId,@un,@inspProcessId,@defectCauseId,@locationId,@LocationSmd,@DefectImputId,
                                           @lote,@partnumber,@actionId,@statusId,@repair,@comentario,'TERMINATE','','','','NPC','0','0')");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@entradaId", objAdd.EntradaId);
                    cmd.Parameters.AddWithValue("@ProductId", objAdd.ProductId);
                    cmd.Parameters.AddWithValue("@unitId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@un", objAdd.UN);
                    cmd.Parameters.AddWithValue("@inspProcessId", objAdd.InsProcessID);
                    cmd.Parameters.AddWithValue("@defectCauseId", objAdd.DefectCauseId);
                    cmd.Parameters.AddWithValue("@locationId", objAdd.LocationId);
                    cmd.Parameters.AddWithValue("@LocationSmd", objAdd.LocationSmd);
                    cmd.Parameters.AddWithValue("@DefectImputId", objAdd.DefectImputId);
                    cmd.Parameters.AddWithValue("@lote", objAdd.lote);
                    cmd.Parameters.AddWithValue("@partnumber", objAdd.PartNumber);
                    cmd.Parameters.AddWithValue("@actionId", objAdd.ActionId);
                    cmd.Parameters.AddWithValue("@statusId", objAdd.StatusId);
                    cmd.Parameters.AddWithValue("@repair", objAdd.RepairMan);
                    cmd.Parameters.AddWithValue("@comentario", objAdd.Comment);

                    //if (string.IsNullOrEmpty(Convert.ToString(objAdd.EntradaSMDId)))
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", objAdd.EntradaSMDId);
                    //}

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        public void RegitrarReparoMainNUll(ProcessRepair objAdd)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.PrincipalProcessRepair VALUES(@data,@hora,@entradaId,@ProductId,
                                           @unitId,'',@inspProcessId,'70','26','N/A','9',
                                           '','','14',@statusId,@repair,@comentario,'WAITING','','','','CQP','0','0')");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@entradaId", objAdd.EntradaId);
                    cmd.Parameters.AddWithValue("@ProductId", objAdd.ProductId);
                    cmd.Parameters.AddWithValue("@unitId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@inspProcessId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@statusId", objAdd.StatusId);
                    cmd.Parameters.AddWithValue("@repair", objAdd.RepairMan);
                    cmd.Parameters.AddWithValue("@comentario", objAdd.Comment);
                  
                    
                    //if (string.IsNullOrEmpty(Convert.ToString(objAdd.EntradaSMDId)))
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", objAdd.EntradaSMDId);
                    //}
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void RegitrarReparoMainNUllNPC(ProcessRepair objAdd)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.PrincipalProcessRepair VALUES(@data,@hora,@entradaId,@ProductId,
                                           @unitId,'',@inspProcessId,'70','26','N/A','9',
                                           '',@partNumber,'14',@statusId,@repair,@comentario,'WAITING','','','','NPC','0','0')");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@entradaId", objAdd.EntradaId);
                    cmd.Parameters.AddWithValue("@ProductId", objAdd.ProductId);
                    cmd.Parameters.AddWithValue("@unitId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@inspProcessId", objAdd.Unitid);
                    cmd.Parameters.AddWithValue("@statusId", objAdd.StatusId);
                    cmd.Parameters.AddWithValue("@partNumber", objAdd.PartNumber);
                    cmd.Parameters.AddWithValue("@repair", objAdd.RepairMan);
                    cmd.Parameters.AddWithValue("@comentario", objAdd.Comment);


                    //if (string.IsNullOrEmpty(Convert.ToString(objAdd.EntradaSMDId)))
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@entradaSMDid", objAdd.EntradaSMDId);
                    //}
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the register: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
    }
}
