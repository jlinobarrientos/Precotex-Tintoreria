using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Models;

namespace Ws_prectoex.Data
{
    public class IReproceso : Conexion
    {
        public List<Reproceso> ConsultarGrupoPartida()
        {
            Conectar();
            List<Reproceso> lstReproceso = new List<Reproceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("AC_Partida_Agrupado_Reproceso", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Reproceso reproceso = new Reproceso()
                    {
                        Fecha_Registro = DateTime.Parse(read["Fecha_Registro"].ToString()),
                        IdGrupo = int.Parse(read["IdGrupo"].ToString()),
                        Cod_Ordtra = read["Cod_Ordtra"].ToString(),
                        Num_Secuencia = int.Parse(read["Num_Secuencia"].ToString()),
                        Cod_Tela = read["Cod_Tela"].ToString(),
                        Cod_Comb = read["Cod_Comb"].ToString(),
                        Kgs_Crudo = double.Parse(read["Kgs_Crudo"].ToString()),
                        Flg_Principal = read["Flg_Principal"].ToString()
                    };
                    lstReproceso.Add(reproceso);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstReproceso;
        }
        /**
         * Grabar Reproceso
         * **/

        public List<MotivoTiempoImproductivo> showMotivosImproductivos(string Cod_Maquina_Tinto)
        {
            Conectar();
            List<MotivoTiempoImproductivo> lstMotivoImproductivo = new List<MotivoTiempoImproductivo>();
            try
            {
                SqlCommand cmd = new SqlCommand("TI_TIEMPOS_IMPRODUCTIVOS_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Maquina_Tinto", Cod_Maquina_Tinto);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    MotivoTiempoImproductivo mImproductivo = new MotivoTiempoImproductivo()
                    {
                        Cod_Motivo_Impr = read["Cod_Motivo_Impr"].ToString(),
                        Descripcion = read["Descripcion"].ToString(),
                        Flg_Estado = read["Flg_Estado"].ToString(),
                        Cod_Motivo_Imp_Orgatex = read["Cod_Motivo_Imp_Orgatex"].ToString()
                    };
                    lstMotivoImproductivo.Add(mImproductivo);
                }
            }
            catch (Exception e)
            {     
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstMotivoImproductivo;
        }

        public List<Reproceso> visualizarReproceso()
        {
            Conectar();
            List<Reproceso> lstReproceso = new List<Reproceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_view_Ti_Partida_Agrupado_Reproceso", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Reproceso reproceso = new Reproceso()
                    {


                        Fecha_Registro = DateTime.Parse(read["Fecha_Registro"].ToString()),
                        IdGrupo = int.Parse(read["IdGrupo"].ToString()),
                        Cod_Ordtra = read["Cod_Ordtra"].ToString(),
                        Num_Secuencia = int.Parse(read["Num_Secuencia"].ToString()),
                        Cod_Tela = read["Cod_Tela"].ToString(),
                        Cod_Comb = read["Cod_Comb"].ToString(),
                        Kgs_Crudo = double.Parse(read["Kgs_Crudo"].ToString()),
                        Flg_Principal = read["Flg_Principal"].ToString(),
                        observacion = read["observacion"].ToString()
                    };
                    lstReproceso.Add(reproceso);
                }
            }
            catch (Exception e)
            {                
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstReproceso;
        }

        public List<MotivoReproceso> motivoReproceso(string Cod_Ordtra, string Cod_Tela)
        {
            Conectar();
            List<MotivoReproceso> lstMotivoRepro = new List<MotivoReproceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("TI_MUESTRA_MOTIVOS_REPROCESO_PARA_REGISTRO_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@COD_ORDTRA", Cod_Ordtra);
                cmd.Parameters.AddWithValue("@COD_TELA", Cod_Tela);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    MotivoReproceso motivo = new MotivoReproceso()
                    {
                        Cod_Motivo_Reproceso = read["Cod_Motivo_Reproceso"].ToString(),
                        Descripcion  = read["Descripcion"].ToString(),
                        Flg_Reproceso    = read["Flg_Reproceso"].ToString(),
                        Flg_Reproceso_Neto   = read["Flg_Reproceso_Neto"].ToString(),
                        Estado = bool.Parse(read["Estado"].ToString())
                    };
                    lstMotivoRepro.Add(motivo);
                }
            }
            catch (Exception e)
            {    
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstMotivoRepro;
        }

        public RptaPx guardarReproceso(List<Reproceso> lstRollospartida, string observacion, string motivo, string Cod_Proceso, string Flg_Orden)
        {
            var bRespuesta = new RptaPx();
            string datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            foreach (var reproceso in lstRollospartida)
            {
                Conectar2();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Ti_Partida_Agrupado_Reproceso", cnn2);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@ACCION", "I");
                    cmd.Parameters.AddWithValue("@Fecha_Registro", reproceso.Fecha_Registro);
                    cmd.Parameters.AddWithValue("@IdGrupo", reproceso.IdGrupo);
                    cmd.Parameters.AddWithValue("@Cod_Ordtra", reproceso.Cod_Ordtra);
                    cmd.Parameters.AddWithValue("@Num_Secuencia", reproceso.Num_Secuencia); //DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    cmd.Parameters.AddWithValue("@Cod_Tela", reproceso.Cod_Tela); //DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    cmd.Parameters.AddWithValue("@Cod_Comb", reproceso.Cod_Comb);
                    cmd.Parameters.AddWithValue("@Kgs_Crudo", reproceso.Kgs_Crudo);
                    cmd.Parameters.AddWithValue("@Flg_Principal", reproceso.Flg_Principal);
                    cmd.Parameters.AddWithValue("@observacion", observacion);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@Cod_Proceso", Cod_Proceso);
                    cmd.Parameters.AddWithValue("@Flg_Orden", Flg_Orden);
                    cmd.ExecuteNonQuery();
                    bRespuesta.Mensaje = "Ok";
                    bRespuesta.Status = "1";
                }
                catch (Exception e)
                {
                    Desconectar2();
                    //throw new Exception("Error " + e.Message);
                    bRespuesta.Mensaje = e.Message;
                    bRespuesta.Status = "0";
                    return bRespuesta;
                }
                finally
                {
                    Desconectar2();
                }
            }
            return bRespuesta;
        }

        public int  validarReproceso(int IdProceso, string Cod_Tela, string Cod_Ordtra, string Cod_Proceso_Tinto, int Secuencia)
        {
            Conectar();
            int valor = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ti_ordtra_tintoreria_procesos_ExisteReproceso", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Proceso", IdProceso);
                cmd.Parameters.AddWithValue("@Cod_Tela", Cod_Tela);
                cmd.Parameters.AddWithValue("@Cod_Ordtra", Cod_Ordtra);
                cmd.Parameters.AddWithValue("@Cod_Proceso_Tinto", Cod_Proceso_Tinto);
                cmd.Parameters.AddWithValue("@Secuencia", Secuencia);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    valor = int.Parse(read["Valor"].ToString()); 
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return valor;
        }

        public List<Respuesta> movil()
        {
            Conectar4();
            List<Respuesta> lstMotivoRepro = new List<Respuesta>();
            try
            {
                SqlCommand cmd = new SqlCommand("Sg_Muestra_Historial_Control_Vehiculo", cnn4);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_Planta", 1);
                cmd.Parameters.AddWithValue("@Cod_Barras", "");
                cmd.Parameters.AddWithValue("@Dni_Conductor", "");
                cmd.Parameters.AddWithValue("@Fec_Registro","01/01/1900");
                
                
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Respuesta motivo = new Respuesta()
                    {
                        Resultado = read["Observacion"].ToString()
                    };
                    lstMotivoRepro.Add(motivo);
                }
            }
            catch (Exception e)
            {         
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar4();
            }
            return lstMotivoRepro;
        }

    }
}
