﻿using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ws_precotex.Models;

namespace Ws_prectoex.Data
{
    public class Iprocesos : Conexion
    {                
        public List<Proceso> Consultar(string Maquina, string Usuario)
        {
            Conectar();
            List<Proceso> lstProceso = new List<Proceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("AC_Proceso_Acabados_Web", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Nom_Usuario", Usuario);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Proceso proceso = new Proceso()
                    {
                        Cod_Proceso_Tinto = read["Cod_Proceso_Tinto"].ToString(),
                        Descripcion = read["Descripcion"].ToString()
                    };
                    lstProceso.Add(proceso);
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
            return lstProceso;
        }

        public List<Auditor> ConsultarAuditor(string Cod_Auditor, string Nom_Auditor, string FLat_Inspecion)
        {
            Conectar();
            List<Auditor> lstAuditor = new List<Auditor>();

            Cod_Auditor = "";
            Nom_Auditor = "";
            try
            {
                SqlCommand cmd = new SqlCommand("ti_muestra_Auditor_InspeccionCalidad_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Auditor", Cod_Auditor);
                cmd.Parameters.AddWithValue("@Nom_Auditor", Nom_Auditor);
                cmd.Parameters.AddWithValue("@FLat_Inspecion", FLat_Inspecion);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {                    
                    Auditor ficha = new Auditor()
                    {
                        Tip_Auditor = read["Tip_Auditor"].ToString(),
                        sCod_Auditor = read["sCod_Auditor"].ToString(),
                        Codigo = read["Codigo"].ToString(),
                        Nom_Auditor = read["Descripcion"].ToString()

                    };
                    lstAuditor.Add(ficha);
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
            return lstAuditor;
        }

        public List<Restric> ConsultarRestric()
        {
            Conectar();
            List<Restric> lstrestric = new List<Restric>();           

            try
            {
                SqlCommand cmd = new SqlCommand("ti_muestra_restriccion_ws", cnn);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Conectar2();
                    Restric ficha = new Restric()
                    {
                        Codigo = read["Codigo"].ToString(),
                        Descripcion = read["Descripcion"].ToString()

                    };
                    lstrestric.Add(ficha);
                }
            }
            catch (Exception e)
            {
                Desconectar2();
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstrestric;
        }

        public List<OrdRollos> ConsultarOt(string Opcion, string COD_ORDTRA, string RolloTeje, string RolloTeje1, string RolloTeje2, string SER_ORDCOMP, string COD_ORDCOMP, string FlagReporte, string Estado)
        {
            Conectar();
            List<OrdRollos> lstot = new List<OrdRollos>();            
            try
            {
                SqlCommand cmd = new SqlCommand("TI_MUESTRA_DETALLE_POR_ROLLO_POR_OT_DETALLE_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", Opcion);
                cmd.Parameters.AddWithValue("@COD_ORDTRA", COD_ORDTRA);
                cmd.Parameters.AddWithValue("@RolloTeje", RolloTeje);
                cmd.Parameters.AddWithValue("@RolloTeje1", RolloTeje1);
                cmd.Parameters.AddWithValue("@RolloTeje2", RolloTeje2);
                cmd.Parameters.AddWithValue("@SER_ORDCOMP", SER_ORDCOMP);
                cmd.Parameters.AddWithValue("@COD_ORDCOMP", COD_ORDCOMP);
                cmd.Parameters.AddWithValue("@FlagReporte", FlagReporte);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {                    
                    OrdRollos ficha = new OrdRollos()
                    {
                        ID = read["ID"].ToString(),
                        ROLLO = read["ROLLO"].ToString(),
                        TALLA = read["TALLA"].ToString(),
                        OT = read["OT"].ToString(),
                        Lote = read["Lote"].ToString(),
                        Partida = read["Partida"].ToString(),
                        OC = read["OC"].ToString(),
                        PROVEEDOR = read["PROVEEDOR"].ToString(),
                        Prefijo_Maquina = read["Prefijo_Maquina"].ToString(),
                        Codigo_Rollo = read["Codigo_Rollo"].ToString(),

                        TELA_COMB = read["TELA_COMB"].ToString(),
                        NOMBRE_TELA = read["NOMBRE_TELA"].ToString(),
                        Cod_Maquina_Tejeduria = read["Cod_Maquina_Tejeduria"].ToString(),
                        MAQUINA = read["MAQUINA"].ToString(),
                        Sec_Maquina = read["Sec_Maquina"].ToString(),
                        Tip_Trabajador_Tejedor = read["Tip_Trabajador_Tejedor"].ToString(),
                        Cod_Trabajador_Tejedor = read["Cod_Trabajador_Tejedor"].ToString(),
                        TEJEDOR = read["TEJEDOR"].ToString(),
                        KGS_PRODUCIDOS = read["KGS_PRODUCIDOS"].ToString(),
                        STATUS_ROLLO = read["STATUS_ROLLO"].ToString(),
                        CALIDAD = read["CALIDAD"].ToString(),
                        Calf_Auto = read["Calf_Auto"].ToString(),
                        Def_Tej = read["Def_Tej"].ToString(),
                        INSPECTOR = read["INSPECTOR"].ToString(),
                        Observaciones_Inspeccion = read["Observaciones_Inspeccion"].ToString(),
                        FECHA_CALIFICACION = read["FECHA_CALIFICACION"].ToString(),
                        DIGITADOR = read["DIGITADOR"].ToString(),
                        TURNO = read["TURNO"].ToString(),
                        FECHA_PRODUCCION = read["FECHA_PRODUCCION"].ToString(),
                        FECHA_ALMACEN = read["FECHA_ALMACEN"].ToString(),
                        FECHA_DESPACHO_CRUDO = read["FECHA_DESPACHO_CRUDO"].ToString(),
                        flg_status = read["flg_status"].ToString(),
                        RESTRICCION = read["RESTRICCION"].ToString(),
                        OBSERVACION = read["OBSERVACION"].ToString(),
                        AUTORIZA_TERCERO = read["AUTORIZA_TERCERO"].ToString(),
                        PEDIDO = read["PEDIDO"].ToString(),

                        Cod_Auditor = read["Cod_Auditor"].ToString(),
                        Cod_Digitador = read["Cod_Digitador"].ToString(),
                        Cod_Restriccion = read["Cod_Restriccion"].ToString(),
                        Cod_Turno= read["Cod_Turno"].ToString(),
                        MetrosCuad = read["MetrosCuad"].ToString()

                    };
                    lstot.Add(ficha);
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
            return lstot;
        }

        public List<CC_Confec_Motivos> ConsultarDefecto(string Opcion, string Defecto)
        {
            Conectar();
            List<CC_Confec_Motivos> lstdefecto = new List<CC_Confec_Motivos>();
            try
            {
                SqlCommand cmd = new SqlCommand("TJ_MUESTRA_DEFECTOS4PUNTOS_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", Opcion);
                cmd.Parameters.AddWithValue("@DEFECTO", Defecto);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    CC_Confec_Motivos ficha = new CC_Confec_Motivos()
                    {
                        Cod_Motivo = read["Cod_Motivo"].ToString(),
                        Descripcion = read["Descripcion"].ToString(),
                    };
                    lstdefecto.Add(ficha);
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
            return lstdefecto;
        }

        public List<Detalle_Defectos_4_Puntos> ConsultarDetalleDefecto(int Ot, string CodRollo)
        {
            Conectar();
            List<Detalle_Defectos_4_Puntos> lstdetalledefecto = new List<Detalle_Defectos_4_Puntos>();

            try
            {
                SqlCommand cmd = new SqlCommand("TJ_MUESTRA_DETALLE_DEFECTOS_4PUNTOS_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ot", Ot);
                cmd.Parameters.AddWithValue("@CodRollo", CodRollo);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    Detalle_Defectos_4_Puntos ficha = new Detalle_Defectos_4_Puntos()
                    {
                        MTRS = read["MTRS"].ToString(),
                        Cod_Motivo = read["Cod_Motivo"].ToString(),
                        Descripcion_Def = read["Descripcion"].ToString(),
                        size = read["size"].ToString(),
                        Ptos = read["Ptos"].ToString(),

                        Ot= read["Cod_Ordtra"].ToString(),
                        Rollo = read["Codigo_Rollo"].ToString(),
                        Prefijo_Maquina= read["Prefijo_Maquina"].ToString(),
                        Num_secuencia = read["Num_secuencia"].ToString()
                    };
                    lstdetalledefecto.Add(ficha);
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
            return lstdetalledefecto;
            ;
        }

        public RptaPx salvarDetalleDefectos4Puntos(
          string Accion,
          string Cod_Ordtra,
          string Codigo_Rollo,
          string Prefijo_Maquina,
          string Inspector, 
          string Digitador, 
          string Restriccion, 
          string Turno,
          string Cod_Motivo,
          decimal MTRS,
          int Ptos,
          string seg_usuario,
          decimal size,
          int Calidad,
          string Tip_Trabajador,
          string Cod_Trabajador,
          string Observaciones,
          decimal MetrosCuad,
          string Secuencia_n
          )
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd2 = new SqlCommand("tj_detalle_calidad_rollo_4_puntos", cnn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Accion", Accion);
                cmd2.Parameters.AddWithValue("@Cod_Ordtra", Cod_Ordtra);
                cmd2.Parameters.AddWithValue("@Codigo_Rollo", Codigo_Rollo);
                cmd2.Parameters.AddWithValue("@Prefijo_Maquina", Prefijo_Maquina);
                cmd2.Parameters.AddWithValue("@Cod_Auditor", Inspector);
                cmd2.Parameters.AddWithValue("@Cod_Digitador", Digitador);
                cmd2.Parameters.AddWithValue("@Cod_Restriccion", Restriccion);
                cmd2.Parameters.AddWithValue("@Cod_Turno", Turno);
                cmd2.Parameters.AddWithValue("@Cod_Motivo", Cod_Motivo);
                cmd2.Parameters.AddWithValue("@MTRS", MTRS);
                cmd2.Parameters.AddWithValue("@Ptos", Ptos);
                cmd2.Parameters.AddWithValue("@Usuario", seg_usuario);
                cmd2.Parameters.AddWithValue("@size", size);
                cmd2.Parameters.AddWithValue("@Calidad", Calidad);
                cmd2.Parameters.AddWithValue("@Tip_Trabajador", Tip_Trabajador);
                cmd2.Parameters.AddWithValue("@Cod_Trabajador", Cod_Trabajador);
                cmd2.Parameters.AddWithValue("@Observaciones", Observaciones);
                cmd2.Parameters.AddWithValue("@MetrosCuad", MetrosCuad);
                cmd2.Parameters.AddWithValue("@Secuencia_n", Secuencia_n);
                cmd2.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";

            }
            catch (Exception e)
            {                            
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }

            return bRespuesta;
        }

        public RptaPx EliminarDetalleDefectos4Puntos(
           string Accion,
          string Cod_Ordtra,
          string Codigo_Rollo,
          string Prefijo_Maquina,
          string Auditor,
          string Digitador,
          string Restriccion,
          string Turno,
          string Cod_Motivo,
          decimal MTRS,
          int Ptos,
          string seg_usuario,
          decimal size,
          int Calidad, 
          string Tip_Trabajador,
          string Cod_Trabajador,
          string Observaciones,
          decimal MetrosCuad,
          string Secuencia_n

          )
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd2 = new SqlCommand("tj_detalle_calidad_rollo_4_puntos", cnn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Accion", Accion);
                cmd2.Parameters.AddWithValue("@Cod_Ordtra", Cod_Ordtra);
                cmd2.Parameters.AddWithValue("@Codigo_Rollo", Codigo_Rollo);
                cmd2.Parameters.AddWithValue("@Cod_Auditor", "");
                cmd2.Parameters.AddWithValue("@Cod_Digitador", "");
                cmd2.Parameters.AddWithValue("@Cod_Restriccion", "");
                cmd2.Parameters.AddWithValue("@Cod_Turno", "");
                cmd2.Parameters.AddWithValue("@Prefijo_Maquina", "");
                cmd2.Parameters.AddWithValue("@Cod_Motivo", "");
                cmd2.Parameters.AddWithValue("@MTRS", 0);
                cmd2.Parameters.AddWithValue("@Ptos", 0);
                cmd2.Parameters.AddWithValue("@Usuario", seg_usuario);
                cmd2.Parameters.AddWithValue("@size", 0);
                cmd2.Parameters.AddWithValue("@Calidad", Calidad);
                cmd2.Parameters.AddWithValue("@Tip_Trabajador", Tip_Trabajador);
                cmd2.Parameters.AddWithValue("@Cod_Trabajador", Cod_Trabajador);
                cmd2.Parameters.AddWithValue("@Observaciones", Observaciones);
                cmd2.Parameters.AddWithValue("@MetrosCuad", MetrosCuad);
                cmd2.Parameters.AddWithValue("@Secuencia_n", Secuencia_n);
                cmd2.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }
            return bRespuesta;
        }

        public List<SumaPtos> SumaPtos(string Cod_Ordtra, string Codigo_Rollo, string Prefijo_Maquina, decimal MetrosCuad)
        {
            Conectar();
            List<SumaPtos> lstsuma = new List<SumaPtos>();
            var bRespuesta = new SumaPtos();
            try
            {
                SqlCommand cmd = new SqlCommand("TJ_MUESTRA_DETALLE_DEFECTOS_4PUNTOS_SUMA_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ot", Cod_Ordtra);
                cmd.Parameters.AddWithValue("@CodRollo", Codigo_Rollo);
                cmd.Parameters.AddWithValue("@Prefijo_Maquina", Prefijo_Maquina);
                cmd.Parameters.AddWithValue("@MetrosCuad", MetrosCuad);
                SqlDataReader read = cmd.ExecuteReader();
             

                while (read.Read())
                {
                    SumaPtos ficha = new SumaPtos()
                    {
                     SumaPt = read["SumaPtos"].ToString(),
                     Mensaje = "Ok",
                     Status = "1"
                };
                    lstsuma.Add(ficha);
                }
            }
            catch (Exception e)
            {                
                    SumaPtos ficha2 = new SumaPtos()
                    {
                        SumaPt = "0.00",
                        Mensaje = e.Message,
                        Status = "0"
                    };
                    lstsuma.Add(ficha2);                
            }

            finally
            {
                Desconectar();
            }
            return lstsuma;
        }

        /* ======= LABORATORIO  - LECTURA DE RECETAS  ============   */
        public List<Lb_Programa_Receta_Agrupado> showLecturaReceta(string Accion, string Tip_Trabajador, string Cod_Trabajador, string Cod_Cliente_Tex, string Tip_Partida,
            string Clave, string Des_Colcli, string Cod_Colorante, DateTime Fec_Programa, string Num_Corre, string Cod_Usuario)
        {
            Conectar();
            List<Lb_Programa_Receta_Agrupado> lsProgramaReceta = new List<Lb_Programa_Receta_Agrupado>();

            try
            {
                SqlCommand cmd = new SqlCommand("Lb_Man_Programa_Receta_Agrupado", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", Accion);
                cmd.Parameters.AddWithValue("@Tip_Trabajador", Tip_Trabajador);
                cmd.Parameters.AddWithValue("@Cod_Trabajador", Cod_Trabajador);
                cmd.Parameters.AddWithValue("@Cod_Cliente_Tex", Cod_Cliente_Tex);
                cmd.Parameters.AddWithValue("@Tip_Partida", Tip_Partida);
                cmd.Parameters.AddWithValue("@Clave", Clave);
                cmd.Parameters.AddWithValue("@Des_Colcli", Des_Colcli);
                cmd.Parameters.AddWithValue("@Cod_Colorante", Cod_Colorante);
                cmd.Parameters.AddWithValue("@Fec_Programa", Fec_Programa);
                cmd.Parameters.AddWithValue("@Num_Corre", Num_Corre);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Cod_Usuario);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    Lb_Programa_Receta_Agrupado ficha = new Lb_Programa_Receta_Agrupado()
                    {
                        Num_Corre = read["Num_Corre"].ToString(),
                        Nom_Analista = read["Nom_Analista"].ToString(),
                        Nom_Cliente = read["Nom_Cliente"].ToString(),
                        Clave = read["Clave"].ToString(),
                        Des_Colcli = read["Des_Colcli"].ToString(),
                        Des_Colorante = read["Des_Colorante"].ToString(),
                        Fec_Programa = read["Fec_Programa"].ToString(),
                        Fec_Termino = read["Fec_Termino"].ToString(),
                        Partidas = read["Partidas"].ToString(),
                        Color = read["Color"].ToString()

                    };
                    lsProgramaReceta.Add(ficha);
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
            return lsProgramaReceta;
        }

        public RptaPx grabarlecturareceta(
        string Accion, string Tip_Trabajador, string Cod_Trabajador, string Cod_Cliente_Tex, string Tip_Partida,
            string Clave, string Des_Colcli, string Cod_Colorante, DateTime Fec_Programa, string Num_Corre, string Cod_Usuario
         )
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("Lb_Man_Programa_Receta_Agrupado", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", Accion);
                cmd.Parameters.AddWithValue("@Tip_Trabajador", Tip_Trabajador);
                cmd.Parameters.AddWithValue("@Cod_Trabajador", Cod_Trabajador);
                cmd.Parameters.AddWithValue("@Cod_Cliente_Tex", Cod_Cliente_Tex);
                cmd.Parameters.AddWithValue("@Tip_Partida", Tip_Partida);
                cmd.Parameters.AddWithValue("@Clave", Clave);
                cmd.Parameters.AddWithValue("@Des_Colcli", Des_Colcli);
                cmd.Parameters.AddWithValue("@Cod_Colorante", Cod_Colorante);
                cmd.Parameters.AddWithValue("@Fec_Programa", Fec_Programa);
                cmd.Parameters.AddWithValue("@Num_Corre", Num_Corre);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Cod_Usuario);
                cmd.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }

            return bRespuesta;
        }

        /* ======= LABORATORIO  - LECTURA DE RECETAS  ============   */

        /* ======= SEGUIMIENTO TOBERAS ============   */
        public List<Lectura_Tobera_net> showLectura(string Accion, int IdSeg, string FechaRegistro, string CodReceta, int NumTobera, string Maquina, string Partida,
                                                    string RutaFoto, string FlgStatus, string Cod_usuario)
        {
            Conectar();
            List<Lectura_Tobera_net> lsLecturaTobera = new List<Lectura_Tobera_net>();

            try
            {
                SqlCommand cmd = new SqlCommand("TI_MAN_SEGUIMIENTO_TOBERA", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", Accion);
                cmd.Parameters.AddWithValue("@IdSeg", IdSeg);
                cmd.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
                cmd.Parameters.AddWithValue("@CodReceta", CodReceta);
                cmd.Parameters.AddWithValue("@NumTobera", NumTobera);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Partida", Partida);
                cmd.Parameters.AddWithValue("@RutaFoto", RutaFoto);
                cmd.Parameters.AddWithValue("@FlgStatus", FlgStatus);
                cmd.Parameters.AddWithValue("@Cod_usuario", Cod_usuario);
                
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Lectura_Tobera_net ficha = new Lectura_Tobera_net()
                    {
                        IdSeg =   read["IdSeg"].ToString(),
                        Tobera = read["Tobera"].ToString(),
                        Toberasel =  read["Toberasel"].ToString(),
                        Maquina = read["Maquina"].ToString(),
                        Partida = read["Partida"].ToString(),
                        RutaFoto = read["RutaFoto"].ToString(),
                        CodReceta= read["CodReceta"].ToString()
                    };
                    lsLecturaTobera.Add(ficha);
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
            return lsLecturaTobera;
        }

        public RptaPx grabarlecturatobera(string Accion, int IdSeg, string FechaRegistro, string CodReceta, int NumTobera, string Maquina, string Partida,
                                                    string RutaFoto, string FlgStatus, string Cod_usuario)
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("TI_MAN_SEGUIMIENTO_TOBERA", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", Accion);
                cmd.Parameters.AddWithValue("@IdSeg", IdSeg);
                cmd.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
                cmd.Parameters.AddWithValue("@CodReceta", CodReceta);
                cmd.Parameters.AddWithValue("@NumTobera", NumTobera);
                cmd.Parameters.AddWithValue("@Maquina", Maquina);
                cmd.Parameters.AddWithValue("@Partida", Partida);
                cmd.Parameters.AddWithValue("@RutaFoto", RutaFoto);
                cmd.Parameters.AddWithValue("@FlgStatus", FlgStatus);
                cmd.Parameters.AddWithValue("@Cod_usuario", Cod_usuario);
                cmd.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }
            return bRespuesta;
        }


        public RptaPx grabarlecturatoberaImagen(string CodReceta)
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("TI_MAN_SEGUIMIENTO_TOBERA_GUARDA_IMAGEN", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodReceta", CodReceta);                
                cmd.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }

            return bRespuesta;
        }

        public RptaPx grabarlecturatoberaImagenDetalle(string CodReceta, string RutaFoto, int Secuencia)
        {
            var bRespuesta = new RptaPx();            

            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("TI_MAN_SEGUIMIENTO_TOBERA_GUARDA_IMAGEN_DETALLE", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodReceta", CodReceta);
                cmd.Parameters.AddWithValue("@RutaFoto", RutaFoto);
                cmd.Parameters.AddWithValue("@Secuencia", Secuencia);
                cmd.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {
                Desconectar();
            }

            return bRespuesta;
        }

        public List<Lectura_Tobera_Detalle> showLecturaDetalleImagen(string CodReceta)
        {
            Conectar();
            List<Lectura_Tobera_Detalle> lsLecturaToberaDetalle = new List<Lectura_Tobera_Detalle>();

            try
            {
                SqlCommand cmd = new SqlCommand("TI_TRAER_SEGUIMIENTO_TOBERA_GUARDA_IMAGEN_DETALLE", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodReceta", CodReceta);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Lectura_Tobera_Detalle ficha = new Lectura_Tobera_Detalle()
                    {
                        RutaFoto = read["RutaFoto"].ToString(),
                        Secuencia = read["Secuencia"].ToString()
                    };
                    lsLecturaToberaDetalle.Add(ficha);
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
            return lsLecturaToberaDetalle;
        }


        public List<partida_resumen> TelasPartidaResumen(string cod_ordtra, string Cod_tela)
        {
            Conectar();
                       
            List<partida_resumen> lstPartResumen = new List<partida_resumen>();            
            try
            {            
                        SqlCommand cmd = new SqlCommand("ti_sm_muestra_telas_partida_resumen_ws", cnn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@COD_ORDTRA", cod_ordtra);
                        cmd.Parameters.AddWithValue("@COD_TELA", Cod_tela);
                        SqlDataReader read = cmd.ExecuteReader();

                        while (read.Read())
                        {          
                                partida_resumen ficha = new partida_resumen()
                                {
                                    Cod_OrdTra = cod_ordtra,
                                    Check = int.Parse(read["Check"].ToString()),
                                    Cod_tela = read["cod_tela"].ToString(),
                                    Des_Tela = read["Tela"].ToString(),
                                    Crudo = decimal.Parse(read["Crudo"].ToString()),
                                    Rollos_Asignados = read["Rollos_Asignados"].ToString(),
                                    Respuesta = read["Respuesta"].ToString()
                                };

                    lstPartResumen.Add(ficha);
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
            return lstPartResumen;
        }

        public List<tela_proceso> TelaProceso(string cod_ordtra, string Cod_tela)
        {
            Conectar();

            List<tela_proceso> lstTelaProceso = new List<tela_proceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("TI_MUESTRA_PROCESO_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COD_ORDTRA", cod_ordtra);
                cmd.Parameters.AddWithValue("@COD_TELA", Cod_tela);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    tela_proceso lista = new tela_proceso()
                    {
                        Partida = read["PARTIDA"].ToString(),
                        Tela = read["TELA"].ToString(),
                        Proceso = read["PROCESO"].ToString(),
                        Descripcion = read["DESCRIPCION"].ToString(),
                        Cod_Receta = read["COD_RECETA"].ToString(),
                        Des_Receta = read["DES_RECETA"].ToString(),
                        Termino = read["TERMINO"].ToString(),
                        Estado = bool.Parse(read["ESTADO"].ToString()),
                        Ruta_Madre = bool.Parse(read["RUTA_MADRE"].ToString()),                                                      
                        Cod_Motivo = read["COD_MOTIVO"].ToString(),
                        Id_Proceso = int.Parse(read["ID_PROCESO"].ToString()),
                        Flg_Reproceso = read["FLG_REPROCESO"].ToString()
                    };

                    lstTelaProceso.Add(lista);
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
            return lstTelaProceso;
        }

        public List<tela_proceso> TelaProcesoCambioRuta(string cod_ordtra, string Cod_tela, string cod_motivo_repro)
        {
            Conectar();

            List<tela_proceso> lstTelaProcesoCambioRuta = new List<tela_proceso>();
            try
            {
                SqlCommand cmd = new SqlCommand("TI_MUESTRA_PROCESOS_CAMBIO_RUTA", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COD_ORDTRA", cod_ordtra);
                cmd.Parameters.AddWithValue("@COD_TELA", Cod_tela);
                cmd.Parameters.AddWithValue("@COD_MOTIVO", cod_motivo_repro);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    tela_proceso lista = new tela_proceso()
                    {                        
                        Proceso = read["PROCESO"].ToString(),
                        Descripcion = read["DESCRIPCION"].ToString(),                        
                    };

                    lstTelaProcesoCambioRuta.Add(lista);
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
            return lstTelaProcesoCambioRuta ;
        }

        /** Grabar los Rollos **/
        public RptaPx salvarDatosRollos(
            List<telas_partida_proceso> lstRollospartida, //Lista de rollos 
            string proceso,
            string maquina,
            int secuencia,
            string accion,
            string fechaFinal,
            int IdProceso,
            string fechainicial,
            string usuario,
            string motivo,
            string observaciones,
            string codtela,
            string partida,
            string Flg_Orden)
        {
            var bRespuesta = new RptaPx();            
            List<telas_partida_proceso> 
            lstkilosRollos = new List<telas_partida_proceso>(); //NUEVA LISTA DE ROLLOS

            lstRollospartida.OrderBy(s => s.Cod_OrdTra).ThenBy(s => s.Rollo); //SE ORDENA LA LISTA POR COD_ORDTRA Y ROLLO
            lstkilosRollos = lstRollospartida; // SE ESTABLECE EN LSTKILOSROLLOS LA LISTA
                                               // lstkilosRollos.OrderBy(i => i.Rollo);
            var total = lstRollospartida.Sum(s => s.kgs_crudo); // SE SUMA LA CANTIDAD TOTAL DE KILOS ESTADO
            string datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //ESTABLECE FECHA Y HORA ACTUAL            
            var NuevoOT = "";
            var KilosOTNuevo = "";
            var KilosOTNuevoDetallado = "";
            Decimal kilosPartida = 0;
            //foreach (var rollo in lstRollospartida)
            foreach (var rollo in lstRollospartida.OrderBy(s => s.Cod_OrdTra).ThenBy(s => s.Rollo)) //RECORRE LA LISTA Y SE ASIGAN EN ROLLO
            {
                if (rollo.Cod_OrdTra != NuevoOT) //COMPARA SI LA PARTIDA ESTA VACIA O LLENA
                {
                    NuevoOT = rollo.Cod_OrdTra; // ASIGNA EL NRO DE PARTIDA
                    KilosOTNuevo = "";
                    Conectar2();
                    try
                    {
                        kilosPartida = 0; //SETEADO EN 0
                        foreach (var Rolloskilos in lstkilosRollos.OrderBy(i => i.Rollo))
                        {
                            if (Rolloskilos.Rollo != KilosOTNuevo)
                            {
                                kilosPartida = kilosPartida + Rolloskilos.kgs_crudo;
                                KilosOTNuevo = Rolloskilos.Rollo;
                            }
                        }

                        try
                        {
                            //Cabecera 
                            Conectar();
                            SqlCommand cmd = new SqlCommand("TI_UP_MAN_TI_ORDTRA_TINTORERIA_PROCESOS_WS", cnn);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ACCION", accion);                            
                            cmd.Parameters.AddWithValue("@COD_ORDTRA", partida);
                            cmd.Parameters.AddWithValue("@COD_PROCESO_TINTO", proceso);
                            cmd.Parameters.AddWithValue("@SECUENCIA", secuencia);                           

                            cmd.Parameters.AddWithValue("FECHA_INICIO", datetime); //
                            cmd.Parameters.AddWithValue("FECHA_FIN", datetime);

                            //cmd.Parameters.AddWithValue("@COD_MAQUINA_TINTO", "PTX-48");
                            cmd.Parameters.AddWithValue("@COD_MAQUINA_TINTO", maquina);
                            cmd.Parameters.AddWithValue("@OBSERVACIONES", observaciones);
                            cmd.Parameters.AddWithValue("@cod_motivo_reproceso", motivo);
                            cmd.Parameters.AddWithValue("@kilos", kilosPartida);  //rollo.kgs_crudo
                            cmd.Parameters.AddWithValue("@Flg_Reproceso", "N");                            
                            cmd.Parameters.AddWithValue("@Tiempo_Estandar", 0);
                            cmd.Parameters.AddWithValue("@SubSecuencia", 0);
                            cmd.Parameters.AddWithValue("@num_secuencia", rollo.Num_Secuencia);
                            cmd.Parameters.AddWithValue("@Cod_Usuario", usuario);
                            cmd.Parameters.AddWithValue("@sFechaFinal", fechaFinal);
                            cmd.Parameters.AddWithValue("@Id_Proceso", IdProceso);

                            cmd.Parameters.AddWithValue("@COD_TELA", codtela);
                            cmd.Parameters.AddWithValue("@Flg_Orden", Flg_Orden);
                            cmd.ExecuteNonQuery();
                            bRespuesta.Mensaje = "Ok";
                            bRespuesta.Status = "1";

                        }
                        catch (Exception e)
                        {
                            Desconectar();                            
                            bRespuesta.Mensaje = e.Message;
                            bRespuesta.Status = "0";
                            return bRespuesta;      
                        }
                        finally
                        {
                            Desconectar();                            
                        }

                        /****** Eliminar Detalle  ******/ 
                        try
                        {
                            Conectar();
                            SqlCommand cmd2 = new SqlCommand("TI_DELETE_TI_ORDTRA_TINTORERIA_TELAS_PROCESOS_WS", cnn);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@COD_ORDTRA", rollo.Cod_OrdTra);
                            cmd2.Parameters.AddWithValue("@COD_PROCESO_TINTO", proceso);
                            cmd2.Parameters.AddWithValue("@SECUENCIA", secuencia);
                            cmd2.Parameters.AddWithValue("@Id_Proceso", IdProceso);
                            cmd2.ExecuteNonQuery();
                            bRespuesta.Mensaje = "Ok";
                            bRespuesta.Status = "1";

                        }
                        catch (Exception e)
                        {
                            Desconectar();
                                                        
                            bRespuesta.Mensaje = e.Message;
                            bRespuesta.Status = "0";                            
                        }
                        finally
                        {
                            Desconectar();
                        }


                        /****** Inserta los Detalles00  ******/
                        try
                        {
                            KilosOTNuevoDetallado = rollo.Rollo;
                            Conectar();
                            SqlCommand cmd2 = new SqlCommand("TI_UP_MAN_TI_ORDTRA_TINTORERIA_TELAS_PROCESOS_WS", cnn);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@ACCION", accion);
                            cmd2.Parameters.AddWithValue("@COD_ORDTRA", rollo.Cod_OrdTra);
                            cmd2.Parameters.AddWithValue("@COD_PROCESO_TINTO", proceso);
                            cmd2.Parameters.AddWithValue("@SECUENCIA", secuencia);
                            cmd2.Parameters.AddWithValue("@num_secuencia", rollo.Num_Secuencia);
                            cmd2.Parameters.AddWithValue("@kilos", rollo.kgs_crudo);
                            cmd2.Parameters.AddWithValue("@Rollo", rollo.Rollo);
                            cmd2.Parameters.AddWithValue("@Id_Proceso", IdProceso);
                            cmd2.Parameters.AddWithValue("@COD_USUARIO", usuario);
                            cmd2.ExecuteNonQuery();
                            bRespuesta.Mensaje = "Ok";
                            bRespuesta.Status = "1";
                        }
                        catch (Exception e)
                        {
                            Desconectar();                           
                            bRespuesta.Mensaje = e.Message;
                            bRespuesta.Status = "0";                            
                        }
                        finally
                        {
                           Desconectar();
                        }
                    }
                    catch (Exception e)
                    {                        
                        Desconectar2();                     
                        bRespuesta.Mensaje = e.Message;
                        bRespuesta.Status = "0";
                    }
                    finally
                    {
                        Desconectar2();
                    }
                }
                //Solo para rollos
                else
                {
                    
                    if (rollo.Rollo != KilosOTNuevoDetallado)
                    {

                        KilosOTNuevoDetallado = rollo.Rollo;
                        try
                        {
                            Conectar();
                            SqlCommand cmd2 = new SqlCommand("TI_UP_MAN_TI_ORDTRA_TINTORERIA_TELAS_PROCESOS_WS", cnn);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@ACCION", accion);
                            cmd2.Parameters.AddWithValue("@COD_ORDTRA", rollo.Cod_OrdTra);
                            cmd2.Parameters.AddWithValue("@COD_PROCESO_TINTO", proceso);
                            cmd2.Parameters.AddWithValue("@SECUENCIA", secuencia);
                            cmd2.Parameters.AddWithValue("@num_secuencia", rollo.Num_Secuencia);
                            cmd2.Parameters.AddWithValue("@kilos", rollo.kgs_crudo);
                            cmd2.Parameters.AddWithValue("@Rollo", rollo.Rollo);
                            cmd2.Parameters.AddWithValue("@Id_Proceso", IdProceso);
                            cmd2.Parameters.AddWithValue("@COD_USUARIO", usuario);
                            cmd2.ExecuteNonQuery();
                            bRespuesta.Mensaje = "Ok";
                            bRespuesta.Status = "1";
                        }
                        catch (Exception e)
                        {
                            Desconectar();                            
                            bRespuesta.Mensaje = e.Message;
                            bRespuesta.Status = "0";                            
                        }
                        finally
                        {
                            Desconectar();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return bRespuesta;
        }

        public RptaPx grabaCambioRuta(
            List<tela_proceso> lstProcesos, 
            string partida,
            string codtela,
            string codmotivo,
            string codigomotivos,
            string usuario            
            )
        {
            var bRespuesta = new RptaPx();
            var NuevoProceso = "";
            var accion = "";
            int secuencia = 0;

            /****** Eliminar Ruta Anterior  ******/
            try
            {
                accion = "D";
                Conectar();
                SqlCommand cmd = new SqlCommand("TI_UP_MAN_CAMBIO_RUTA_WS", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACCION", accion);
                cmd.Parameters.AddWithValue("@COD_PROCESO_TEX", "");
                cmd.Parameters.AddWithValue("@COD_ORDTRA", partida);
                cmd.Parameters.AddWithValue("@COD_TELA", codtela);
                cmd.Parameters.AddWithValue("@SECUENCIA", secuencia);
                cmd.Parameters.AddWithValue("@COD_MOTIVO", codmotivo);
                cmd.Parameters.AddWithValue("@CODIGO_MOTIVOS", codigomotivos);
                cmd.Parameters.AddWithValue("@RUTA_MADRE", "");
                cmd.Parameters.AddWithValue("@FLG_REPROCESO", "");
                cmd.Parameters.AddWithValue("@ID_PROCESO", 0);
                cmd.Parameters.AddWithValue("@COD_USUARIO", usuario);                
                cmd.ExecuteNonQuery();
                bRespuesta.Mensaje = "Ok";
                bRespuesta.Status = "1";
            }
            catch (Exception e)
            {
                Desconectar();

                bRespuesta.Mensaje = e.Message;
                bRespuesta.Status = "0";
            }
            finally
            {

                Desconectar();
            }

            /****** Inserta Nueva Ruta ******/

            foreach (var proceso in lstProcesos)
            {
                secuencia += 1;
                accion = "I";
                NuevoProceso = proceso.Proceso; 

                 try
                 {                         
                     Conectar();
                     SqlCommand cmd = new SqlCommand("TI_UP_MAN_CAMBIO_RUTA_WS", cnn);
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@ACCION", accion);
                     cmd.Parameters.AddWithValue("@COD_PROCESO_TEX", NuevoProceso);
                     cmd.Parameters.AddWithValue("@COD_ORDTRA", partida);
                     cmd.Parameters.AddWithValue("@COD_TELA", codtela);
                     cmd.Parameters.AddWithValue("@SECUENCIA", secuencia);
                     cmd.Parameters.AddWithValue("@COD_MOTIVO", codmotivo);
                     cmd.Parameters.AddWithValue("@CODIGO_MOTIVOS", codigomotivos);
                     cmd.Parameters.AddWithValue("@RUTA_MADRE", proceso.Ruta_Madre);
                     cmd.Parameters.AddWithValue("@FLG_REPROCESO", proceso.Flg_Reproceso);
                     cmd.Parameters.AddWithValue("@ID_PROCESO", proceso.Id_Proceso);
                     cmd.Parameters.AddWithValue("@COD_USUARIO", usuario);
                     cmd.ExecuteNonQuery();
                     bRespuesta.Mensaje = "Ok";
                     bRespuesta.Status = "1";
                 }
                 catch (Exception e)
                 {
                     Desconectar();
                     bRespuesta.Mensaje = e.Message;
                     bRespuesta.Status = "0";
                     return bRespuesta;
                 
                 }
                 finally
                 {
                     Desconectar();
                 }                
            }

            return bRespuesta;
        }

        public List<tintoreria_procesos> PartidaProcesos(string cod_ordtra,int id_proceso,string flg_orden)
        {
            Conectar();
            List<tintoreria_procesos> lstProcesos = new List<tintoreria_procesos>();            
            try
            {
                    //Telas x Partidas
                    SqlCommand Cmd = new SqlCommand("TI_MUESTRA_TI_ORDTRA_TINTORERIA_PROCESOS_WS", cnn);
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@COD_ORDTRA", cod_ordtra);
                    Cmd.Parameters.AddWithValue("@ID_PROCESO", id_proceso);
                    Cmd.Parameters.AddWithValue("@FLG_ORDEN", flg_orden);
                    SqlDataReader read = Cmd.ExecuteReader();
                    while (read.Read())
                    {

                        DateTime vfecha = DateTime.Parse("01/01/1901");

                        if (read["Fecha_Fin"] is not DBNull)
                        {
                            vfecha = DateTime.Parse(read["Fecha_Fin"].ToString());
                        }
                        else
                        {
                            vfecha = vfecha;
                        }

                        tintoreria_procesos ficha = new tintoreria_procesos()
                        {
                            Cod_OrdTra = cod_ordtra,
                            Proceso = read["Proceso"].ToString(),
                            Descripcion = read["Descripcion"].ToString(),
                            Secuencia = int.Parse(read["Secuencia"].ToString()),
                            Fecha_Inicio = DateTime.Parse(read["Fecha_Inicio"].ToString()),
                            //                            Fecha_Fin = DateTime.Paac_Procesos_Acabadosrse(read2["Fecha_Fin"].ToString()),
                            Fecha_Fin = vfecha,
                            Maquina = read["Maquina"].ToString(),
                            Observaciones = read["Observaciones"].ToString(),
                                
                            fechaini = read["fechaini"].ToString(),
                            fechafin = read["fechafin"].ToString(),
                            reproceso= read["reproceso"].ToString(),
                            motivo = read["Motivo"].ToString(),
                            codigomotivo = read["Cod_Motivo_Reproceso"].ToString(),
                            id_proceso = int.Parse(read["Id_Proceso"].ToString())

                        };

                        lstProcesos.Add(ficha);
                        lstProcesos.OrderBy(s=>s.Fecha_Inicio);
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
            return lstProcesos;
        }

        public List<telas_partida_proceso> telas_partida(string cod_ordtra,string cod_tela, string cod_proc, int secuencia,int id_proceso)
        {
            Conectar();
            List<telas_partida_proceso> lstTelas_partida = new List<telas_partida_proceso>();
           
            try
            {           

                    //Telas x Partidas
                SqlCommand Cmd = new SqlCommand("ti_sm_muestra_telas_partida_proceso_SECUENCIA_WS", cnn);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@COD_ORDTRA", cod_ordtra);
                Cmd.Parameters.AddWithValue("@SELECCION", cod_tela);
                Cmd.Parameters.AddWithValue("@cod_proceso_tinto", cod_proc);
                Cmd.Parameters.AddWithValue("@secuencia", secuencia);
                Cmd.Parameters.AddWithValue("@ID_PROCESO", id_proceso);
                SqlDataReader read = Cmd.ExecuteReader();
                    while (read.Read())
                    {
                        telas_partida_proceso ficha = new telas_partida_proceso()
                        {
                            Cod_OrdTra = cod_ordtra,
                            Num_Secuencia = int.Parse(read["Num_Secuencia"].ToString()),
                            Cod_Tela = read["Tela"].ToString(),
                            Des_Tela = read["Nombre"].ToString(),
                            Cod_Comb = read["Cod_Comb"].ToString(),
                            Comb = read["Comb"].ToString(),
                            Cod_Talla = read["Cod_Talla"].ToString(),
                            Sel = int.Parse(read["Sel"].ToString()),
                            kgs_crudo = decimal.Parse(read["kgs_crudo"].ToString()),
                            kgs_crudo_Editable = decimal.Parse(read["kgs_crudo_Editable"].ToString()),
                            Rollo = read["Rollo"].ToString()
                        };

                        lstTelas_partida.Add(ficha);

                    }            
            }
            catch (Exception e)
            {
                //HttpMethods.Msg(e.Message.ToString());
                throw new Exception("Error " + e.Message);
            }
            finally
            {
                Desconectar();
            }
            return lstTelas_partida;
        }

        public List<maquinaProceso> maquinaProceso(string cod_Maquina)
        {
            Conectar();
            List<maquinaProceso> lstMaqProcesos = new List<maquinaProceso>();
            //   partida_resumen ficha = new partida_resumen()
            try
            {
                SqlCommand cmd = new SqlCommand("ac_Maquina_Proceso", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cod_Maquina", cod_Maquina);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    maquinaProceso process = new maquinaProceso()
                    {
                        Cod_Proceso_Tinto = read["Cod_Proceso_Tinto"].ToString(),
                        Descripcion = read["Descripcion"].ToString(),
                    };

                    lstMaqProcesos.Add(process);
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
            return lstMaqProcesos;
        }

        public List<maquinaProceso> ProcesoAcabados(string cod_Ordtra, string CodTela, string Cod_Maquina, string Cod_Usuario)
        {
            Conectar();
            List<maquinaProceso> lstMaqProcesos = new List<maquinaProceso>();            
            try
            {
                SqlCommand cmd = new SqlCommand("ac_Proceso_Acabados", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Ordtra", cod_Ordtra);
                cmd.Parameters.AddWithValue("@Cod_Tela", CodTela);
                cmd.Parameters.AddWithValue("@Cod_Maquina", Cod_Maquina);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Cod_Usuario);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    maquinaProceso process = new maquinaProceso()
                    {
                        Cod_Proceso_Tinto = read["Cod_Proceso_Tinto"].ToString(),
                        Descripcion = read["Descripcion"].ToString(),
                        Cod_Motivo_Repro = read["Cod_Motivo_Repro"].ToString(),
                        Descrip_Repro = read["Descrip_Repro"].ToString(),
                        Obser_Repro = read["Obser_Repro"].ToString(),
                        Flg_Reproceso = read["Flg_Reproceso"].ToString(),
                        Flg_Orden = read["Orden"].ToString(),
                        Id_Proceso = int.Parse(read["Id_Proceso"].ToString())
                    };

                    lstMaqProcesos.Add(process);
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
            return lstMaqProcesos;
        }



        public List<maquinaProceso> ProcesoAcabadosCerrados(string cod_Ordtra, string CodTela, string Cod_Maquina, string Cod_Usuario)
        {
            Conectar();
            List<maquinaProceso> lstMaqProcesos = new List<maquinaProceso>();            
            try
            {
                SqlCommand cmd = new SqlCommand("ac_Proceso_AcabadosCerrados", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_Ordtra", cod_Ordtra);
                cmd.Parameters.AddWithValue("@Cod_Tela", CodTela);
                cmd.Parameters.AddWithValue("@Cod_Maquina", Cod_Maquina);
                cmd.Parameters.AddWithValue("@Cod_Usuario", Cod_Usuario);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    maquinaProceso process = new maquinaProceso()
                    {
                        Cod_Proceso_Tinto = read["Cod_Proceso_Tinto"].ToString(),
                        Descripcion = read["Descripcion"].ToString(),
                        Flg_Orden = read["Flg_Orden"].ToString(),
                    };

                    lstMaqProcesos.Add(process);
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
            return lstMaqProcesos;
        }


        /*Grabar los Tiempos Improductivos*/        
        public bool salvarTiemposImproductivos(string accion, string maquina, string motivo, string observaciones, string partida,string usuario)
        {
            bool bRespuesta = false;      
                      
                Conectar2();
                try
                {                    
                    SqlCommand cmd = new SqlCommand("ti_up_man_TI_Improductivos_por_Maquina_Propio_ws", cnn2);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", accion);                    
                    cmd.Parameters.AddWithValue("@cod_maquina_tinto", maquina);                    
                    cmd.Parameters.AddWithValue("@cod_motivo_impr", motivo);                    
                    cmd.Parameters.AddWithValue("@observacionesUsuario", observaciones);
                    cmd.Parameters.AddWithValue("@Cod_OrdTra", partida);
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
                    cmd.ExecuteNonQuery();
                    bRespuesta = true;

                }
                catch (Exception e)
                {                    
                    throw new Exception("Error " + e.Message);
                }
                finally
                {
                    Desconectar2();
                }

            return bRespuesta;
        }

        public partidaStatus partidaStatusColor(string cod_ordtra, string Cod_Tela)
        {
            Conectar();
            
            partidaStatus partidastatusColor = new partidaStatus();            
            try
            {
                SqlCommand cmd = new SqlCommand("ti_Partida_statusColor", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_ordtra", cod_ordtra);
                cmd.Parameters.AddWithValue("@Cod_Tela", Cod_Tela);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    partidastatusColor.Cliente = read["Cliente"].ToString();
                    partidastatusColor.Color = read["Color"].ToString();
                    partidastatusColor.Clase = read["Clase"].ToString();
                    partidastatusColor.status = read["status"].ToString();
                    partidastatusColor.StatusCal = read["StatusCal"].ToString();
                    //partidastatusColor.FechaCal = DateTime.Parse(read["FechaCal"].ToString());
                    DateTime vfecha = DateTime.Parse("01/01/1901");

                    if (read["FechaCal"] is DBNull)
                    {
                        partidastatusColor.FechaCal = DateTime.Parse(read["FechaCal"].ToString());
                    }
                    else
                    {
                        partidastatusColor.FechaCal = vfecha;
                    }
                    partidastatusColor.IngrTinto = int.Parse(read["IngrTinto"].ToString());
                    partidastatusColor.Habilitado = bool.Parse(read["Habilitado"].ToString());
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
            return partidastatusColor;
        }

    }
}
