using DAL;
using DataAccessObject;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data.SqlClient;

namespace BLL.EntradaBusiness
{
    public class GetDataInput : DataFirebird
    {
        public SeacherRepair GetDataToInput(string cod,string cn)
        {
            try
            {
                AbreConexaoFirebird();
                string str = string.Format(@"SELECT B.COD004,A.DTA005,A.HRA005,B.FER004,C.DES028,D.NUM045,NPN004 FROM MAI005 A
                                             INNER JOIN MAI004C B ON A.COD005 = B.COD004
                                             INNER JOIN OQC028 C ON B.DEF004 = C.COD028
                                             INNER JOIN OQC045 D ON B.LIN004 = D.COD045
                                             WHERE COD004 = @cod OR NPN004= @cn");

                using (cmd = new FbCommand(str, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", cod);
                    cmd.Parameters.AddWithValue("@cn", cn);
                    using (Dr = cmd.ExecuteReader())
                    {

                        SeacherRepair mod = null;
                        while (Dr.Read())
                        {
                            mod = new SeacherRepair();
                            mod.CodFirebird = Convert.ToString(Dr["COD004"]);
                            mod.data = Convert.ToDateTime(Dr["DTA005"]);
                            mod.hora = Convert.ToString(Dr["HRA005"]);
                            mod.Modelo = Convert.ToString(Dr["FER004"]);
                            mod.Simtomas = Convert.ToString(Dr["DES028"]);
                            mod.Block = Convert.ToString(Dr["NUM045"]);
                            mod.CN = Convert.ToString(Dr["NPN004"]);
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
                FechaConexaoFirebird();
            }
        }


    }
}
