using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DataAccessObject;

namespace BLL.EntradaBusiness
{
    public class Anotacoes : Conexao
    {
        public void RegistrarAnotacoes(Comentario comentario)
        {
            try
            {
                OpenConnection();
                string str = string.Format(@"INSERT INTO dbo.Anotacoes VALUES(@data,@processo,@anotacoes,@status)");
                using (cmd = new SqlCommand(str, conn))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@processo", comentario.Processo);
                    cmd.Parameters.AddWithValue("@anotacoes", comentario.Comentarios);
                    cmd.Parameters.AddWithValue("@status", comentario.status);
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro ao registrar os dados: " + ex.Message);
            }
            finally
            {
                ClosedConnection();
            }
            
        }



    }
}
