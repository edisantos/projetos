using DAL;
using DataAccessObject;
using System;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class RegistrosEntrada : Conexao
    {
        /// <summary>
        /// METHOD TO INSERT NEW MODEL
        /// </summary>
        /// <param name="model"></param>
        public void InsertModel(Modelos model)
        {

            try
            {
                OpenConnection();
                string cadastrar = string.Format(@"INSERT INTO Modelos VALUES(@modelo)");
                using (cmd = new SqlCommand(cadastrar, conn))
                {
                    cmd.Parameters.AddWithValue("@modelo", model.Modelo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error to the Insert a new model" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }


        }
        /// <summary>
        /// THIS METHOD TO DO THE INSERT THE SYMPTOMS
        /// </summary>
        /// <param name="model"></param>
        public void InsertSintoms(Sintomas model)
        {

            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO Sintomas VALUES(@Codsintomas,@Sintomas)");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@Codsintomas", model.CodSintomas);
                    cmd.Parameters.AddWithValue("@Sintomas", model.Sintoma);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error to the Insert a new symptoms" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }


        }

        /// <summary>
        /// THIS METHOD TO DO THE INSERT THE SYMPTOMS
        /// </summary>
        /// <param name="model"></param>
        public void InsertBlocks(Blocks model)
        {

            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO Blocks VALUES(@block)");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@block", model.Block);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error to the Insert a new block" + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }


        }

        public void RegisterInput(Entrada model)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.EntradaReparo VALUES(@data,@hora,@serial,@model,@Cod,@sintomas,@block,@user)");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@serial", model.Serial);
                    cmd.Parameters.AddWithValue("@model", model.ModeloId);
                    cmd.Parameters.AddWithValue("@Cod", model.SintomasId);
                    cmd.Parameters.AddWithValue("@sintomas", model.Sintomas);
                    cmd.Parameters.AddWithValue("@block", model.BlockId);
                    cmd.Parameters.AddWithValue("@user", model.Usuario);
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

        /// <summary>
        /// AQUI FAÇO O REGISTRO DOS DADOS QUE BUSCO NO BANCO FIREBIRD DE MAINLINE.
        /// </summary>
        /// <param name="objMod"></param>
        public void InsertInputRepairOfMainLine(SeacherRepair objMod)
        {
            try
            {
                OpenConnection();
                string strInsert = string.Format(@"INSERT INTO dbo.EntradaRepairMain VALUES(@data,@hora,@codigoFirebird,@model,@sintomas,@line,@un,@cn,@user,NULL,'MAIN')");
                using (cmd = new SqlCommand(strInsert, conn))
                {

                    cmd.Parameters.AddWithValue("@data", objMod.data);
                    cmd.Parameters.AddWithValue("@hora", objMod.hora);
                    cmd.Parameters.AddWithValue("@codigoFirebird", objMod.CodFirebird);
                    cmd.Parameters.AddWithValue("@model", objMod.Modelo);
                    cmd.Parameters.AddWithValue("@sintomas", objMod.Simtomas);
                    cmd.Parameters.AddWithValue("@line", objMod.Block);
                    cmd.Parameters.AddWithValue("@un", objMod.UN);
                    cmd.Parameters.AddWithValue("@cn", objMod.CN);
                    cmd.Parameters.AddWithValue("@user", objMod.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the Insert the Material of Mainline: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public void InsertInputRepairOfNPC(SeacherRepair objMod)
        {
            try
            {
                OpenConnection();
                string strInsert = string.Format(@"INSERT INTO dbo.EntradaRepairMain VALUES(@data,@hora,NULL,@model,@sintomas,@line,@un,@cn,@user,NULL,'NPC')");
                using (cmd = new SqlCommand(strInsert, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("HH:mm;ss");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@model", objMod.Modelo);
                    cmd.Parameters.AddWithValue("@sintomas", objMod.Simtomas);
                    cmd.Parameters.AddWithValue("@line", objMod.Block);
                    cmd.Parameters.AddWithValue("@un", objMod.UN);
                    cmd.Parameters.AddWithValue("@cn", objMod.CN);
                    cmd.Parameters.AddWithValue("@user", objMod.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the Insert the Material of NPC: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /*AQUI FAZEMOS O REGISTRO DO TECNICO QUE ESTARA RELACIONADO A PLACA*/
        public void RegistrarTecnicoComBoard(Entrada mod)
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
                    cmd.Parameters.AddWithValue("@user", mod.Usuario);
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
        /// <summary>
        /// ESTE METODO FAZ ATUALIZAÇÂO DO STATUS PADA DONE AO 
        /// AMARRAR O TECNICO COM A PLACA, ALTERADO O STATUS DE WAINTING PARA DONE
        /// </summary>
        public void UpdateStatus(Entrada mod)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"UPDATE PrincipalProcessRepair SET Status='TRANSFER TO REPAIR' WHERE EntradaId = @cod");
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


    }
}
