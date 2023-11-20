using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Models;

namespace Ws_prectoex.Data
{
    public class IMaquinas:Conexion
    {
        public List<Maquina> Consultar(string Usuario, string Cod_Proceso)
        {
            Conectar();
            List<Maquina> lstMaquina = new List<Maquina>();
            try
            {
                SqlCommand cmd = new SqlCommand("ac_Maquina_usuario_web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Cod_Proceso", Cod_Proceso);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Maquina maquina = new Maquina()
                    {
                        Cod_Maquina = read["Cod_Maquina"].ToString(),
                        Des_Maquina = read["Des_Maquina"].ToString()
                    };
                    lstMaquina.Add(maquina);
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
            return lstMaquina ;
        }


        public List<Maquina> ListadoMaquina(string Cod_Maquina_Tinto)
        {
            Conectar();
            List<Maquina> lstMaquina = new List<Maquina>();
            try
            {
                SqlCommand cmd = new SqlCommand("ac_Maquina_Listado_web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Maquina_Tinto", Cod_Maquina_Tinto);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Maquina maquina = new Maquina()
                    {
                        Cod_Maquina = read["Cod_Maquina"].ToString(),
                        Des_Maquina = read["Des_Maquina"].ToString()
                    };
                    lstMaquina.Add(maquina);
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
            return lstMaquina;
        }

        public List<Respuesta> ExisteTiempo(string Cod_Maquina_Tinto,string Cod_Motivo_Impr)
        {
            Conectar();
            List<Respuesta> lstRespuesta = new List<Respuesta>();
            try
            {
                SqlCommand cmd = new SqlCommand("ti_existe_tiempo_impr", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Maquina_Tinto", Cod_Maquina_Tinto);
                cmd.Parameters.AddWithValue("@Cod_Motivo_Impr", Cod_Motivo_Impr);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Respuesta rpta = new Respuesta()
                    {
                        Resultado = read["Resultado"].ToString(),
                        ObservaUsuario = read["ObservaUsuario"].ToString(),
                    };
                    lstRespuesta.Add(rpta);
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
            return lstRespuesta;
        }
    }
}
