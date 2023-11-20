using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws_prectoex.Data
{
    public class ITelas:Conexion
    {
        public Tela Consultar(string Codigo) {
            Conectar();
            Tela tela = new Tela();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_tx_tela_web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Tela", Codigo);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    tela.Cod_Tela = read["Cod_Tela"].ToString();
                    tela.Des_Tela = read["Des_Tela"].ToString();
                    
                }
                
            }

            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return tela;
        }


        //public string ConsultarTelaPrincipal(int idGrupo)
        public Tela ConsultarTelaPrincipal(string cod_ordtra)
        {
            Conectar();
             Tela tela = new Tela();
           // string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Ti_Partida_Agrupado_TelaPrincipal_ws", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Ordtra", cod_ordtra);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    
                    tela.Cod_Tela = read["Cod_Tela"].ToString();
                    tela.Des_Tela = read["Des_Tela"].ToString();
                    

                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return tela;
        }

    }
    
}
