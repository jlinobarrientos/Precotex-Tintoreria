using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Models;

namespace Ws_prectoex.Data
{
    public class IFichas:Conexion
    {
        public List<Ficha> Consultar(int IdGrupo, string Cod_Tela)
        {
            Conectar();
            List<Ficha> lstFicha = new List<Ficha>();
            try
            {
                SqlCommand cmd = new SqlCommand("ti_Agrupado_dETALLE_Web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupo", IdGrupo);
                cmd.Parameters.AddWithValue("@Cod_Tela", Cod_Tela);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read["Respuesta"].ToString() == "OK")
                    {
                        Ficha ficha = new Ficha()
                        {
                            Cod_Ordtra = read["Cod_Ordtra"].ToString(),
                            Cod_Tela = read["Cod_Tela"].ToString(),
                            Kgs_Crudo = double.Parse(read["Kgs_Crudo"].ToString()),
                            Respuesta = read["Respuesta"].ToString(),
                        };
                        lstFicha.Add(ficha);

                    }
                    else
                    {
                        Ficha ficha = new Ficha()
                        {
                            Cod_Ordtra = "",
                            Cod_Tela = "",
                            Kgs_Crudo = 0,
                            Respuesta = read["Respuesta"].ToString(),
                        };
                        lstFicha.Add(ficha);
                    }
                 


                    
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.StackTrace);
                //HttpMethods.Msg(e.Message.ToString());

                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstFicha;
        }

        /********************************/
        public bool InsertarFichas(int IdGrupo, string Cod_Tela, string Cod_Proceso_Tinto, string Cod_Usuario, string Cod_Maquina)
        {
            bool bConsulta = false;
            Conectar();
            List<Ficha> lstFicha = new List<Ficha>();
            try
            {
                SqlCommand cmd = new SqlCommand("ti_Agrup_telas_partida_proceso_SECUENCIA", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupo", IdGrupo);
                cmd.Parameters.AddWithValue("@Cod_Tela", Cod_Tela);
                cmd.Parameters.AddWithValue("@Cod_Proceso_Tinto", Cod_Proceso_Tinto);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Cod_Usuario);
                cmd.Parameters.AddWithValue("@Cod_Maquina", Cod_Maquina);
                cmd.ExecuteNonQuery();
                bConsulta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //Log(e.ToString());
            }
            finally
            {
                Desconectar();
            }
            return bConsulta;
        }




        //* partidas**////

        public Respuesta traerPartidas(int IdGrupo)
        {
            Conectar();
            //List<Ficha> lstFicha = new List<Ficha>();
            Respuesta respuesta = new Respuesta();
            try
            {
                SqlCommand cmd = new SqlCommand("ti_Agrupado_Partidas_Web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupo", IdGrupo);
                //cmd.Parameters.AddWithValue("@Cod_Tela", Cod_Tela);
                SqlDataReader read = cmd.ExecuteReader();
                var resp = "";
                while (read.Read())
                {
                    respuesta.Resultado = read["Cod_Ordtra"].ToString()+"-"+respuesta.Resultado;
                }
                respuesta.Resultado =respuesta.Resultado.Substring(0, respuesta.Resultado.Length-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return respuesta;
        }







    }
}
