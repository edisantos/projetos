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
    public class GetDataEntradaRepair : Conexao
    {
        public SeacherRepair GetDataEntradaReparo(string cn)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"SELECT A.EntradaId,A.Serial,B.Modelo,C.Sintomas,Block FROM dbo.EntradaReparo A INNER JOIN dbo.Modelos B ON A.ModeloId = B.ModeloId
                                              INNER JOIN dbo.Sintomas C ON A.SintomasId = C.SintomasId INNER JOIN dbo.Blocks D ON A.BlockId = D.BlockId
                                              WHERE A.Serial = @cn");
                using (cmd = new SqlCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", cn);

                    using (Dr = cmd.ExecuteReader())
                    {
                        SeacherRepair model = null;
                        while (Dr.Read())
                        {
                            model = new SeacherRepair();
                            model.Modelo = Convert.ToString(Dr["Modelo"]);
                            model.Simtomas = Convert.ToString(Dr["Sintomas"]);
                            model.Block = Convert.ToString(Dr["Block"]);
                            model.EntradaId = Convert.ToInt32(Dr["EntradaId"]);

                        }
                        return model;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error to search the data of incoming repair: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public DataTable GetAllDataPerPartnumber(string pn)
        {
            try
            {
                OpenConnection();
                
                string strList = string.Format(@"SELECT Data,Hora,CodFirebird,Model,Sintomas,Line,UN,CN,B.UserName FROM dbo.EntradaRepairMain A
                                                 INNER JOIN AspNetUsers B ON A.UserName = B.Id
                                                 WHERE CN= @pn");
                using (cmd = new SqlCommand(strList, conn))
                {

                    cmd.Parameters.AddWithValue("@pn", pn);

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

                throw new Exception("Error to the retur List: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }

        public Entrada CountRegisterEntrada(string mod)
        {
            try
            {
                OpenConnection();
                //string str = string.Format(@"SELECT COUNT(Serial) As Total From EntradaReparo WHERE Serial =@cn");
                string strCount = string.Format(@"SELECT COUNT(CN)AS TOTAL FROM dbo.EntradaRepairMain
                                                 WHERE CN = @cn");
                using (cmd = new SqlCommand(strCount, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", mod);
                    Entrada m = null;
                    using (Dr = cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            m = new Entrada();
                            m.Serial = Convert.ToString(Dr["Total"]);
                        }
                        return m;
                    }

                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error Count register: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #region Pegar o Codigo Registrado por Codigo e PN
        /// <summary>
        /// ESTE METODO PEGA O CODIGO QUE FOI REGISTRADO PARA REGISTRO INSERT NA 
        /// TABELA PRINCIPAL COMO CHAVE ESTRANGEIRA
        /// </summary>
        /// <returns></returns>
        public SeacherRepair GetCodRegister(string Cod, string CN)
        {
            try
            {
                OpenConnection();
                string strGet = string.Format(@"SELECT TOP(1) CodReparoMain FROM dbo.EntradaRepairMain
                                               WHERE (CodFirebird = @cod) OR (CN = @cn) ORDER BY CodReparoMain DESC");
                using (cmd = new SqlCommand(strGet, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", Cod);
                    cmd.Parameters.AddWithValue("@cn", CN);

                    using (Dr = cmd.ExecuteReader())
                    {
                        SeacherRepair objMod = null;
                        while(Dr.Read())
                        {
                            objMod = new SeacherRepair();
                            objMod.EntradaId = Convert.ToInt32(Dr["CodReparoMain"]);
                        }
                        return objMod;
                    }
                }

            }

            catch (SqlException ex)
            {

                throw new Exception("Erro ao retornar o codigo: "+ ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        /// <summary>
        /// NPC
        /// </summary>
        /// <param name="Cod"></param>
        /// <param name="CN"></param>
        /// <returns></returns>
        public SeacherRepair GetCodRegisterNPC(string Cod, string CN)
        {
            try
            {
                OpenConnection();
                string strGet = string.Format(@"SELECT TOP(1) CodReparoMain FROM dbo.EntradaRepairMain
                                               WHERE CN = @cn ORDER BY CodReparoMain DESC");
                using (cmd = new SqlCommand(strGet, conn))
                {
                    cmd.Parameters.AddWithValue("@cn", CN);

                    using (Dr = cmd.ExecuteReader())
                    {
                        SeacherRepair objMod = null;
                        while (Dr.Read())
                        {
                            objMod = new SeacherRepair();
                            objMod.EntradaId = Convert.ToInt32(Dr["CodReparoMain"]);
                        }
                        return objMod;
                    }
                }

            }

            catch (SqlException ex)
            {

                throw new Exception("Erro ao retornar o codigo: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
        }
        #endregion
    }
}
