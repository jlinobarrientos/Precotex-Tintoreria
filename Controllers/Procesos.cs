using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Data;

namespace Ws_prectoex.Controllers
{
    [ApiController]

    [AllowAnonymous]
    public class Procesos : ControllerBase
    {

        Iprocesos iprocesos = new Iprocesos();

        public string carpetaToberas = "Imagenes";

        private readonly ILogger<Procesos> _logger;

        public static IWebHostEnvironment _environment;

        public Procesos(ILogger<Procesos> logger, IWebHostEnvironment environment)
        {
            _logger = logger;            
            _environment = environment;
        }


        /* ======= CALIDAD ROLLOS 4 PUNTOS ============ */

        [Route("calidadtj/showAuditor/{Cod_Auditor}/{Nom_Auditor}/{FLat_Inspecion}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Auditor>> showAuditor(string Cod_Auditor, string Nom_Auditor, string FLat_Inspecion)
        {

            List<Auditor> lstAuditor = new List<Auditor>();
            try
            {
                lstAuditor = iprocesos.ConsultarAuditor(Cod_Auditor, Nom_Auditor, FLat_Inspecion);
                return lstAuditor;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("calidadtj/showrestric")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Restric>> showrestric()
        {

            List<Restric> lstrestric = new List<Restric>();
            try
            {
                lstrestric = iprocesos.ConsultarRestric();
                return lstrestric;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("calidadtj/showOt/{Opcion}/{COD_ORDTRA}/{RolloTeje}/{RolloTeje1}/{RolloTeje2}/{SER_ORDCOMP}/{COD_ORDCOMP}/{FlagReporte}/{Estado}")]
        [AllowAnonymous]
        [HttpGet]

        public async Task<List<OrdRollos>> showOt(string Opcion, string COD_ORDTRA, string RolloTeje, string RolloTeje1, string RolloTeje2, string SER_ORDCOMP, string COD_ORDCOMP, string FlagReporte, string Estado)
        {

            List<OrdRollos> lstot = new List<OrdRollos>();
            try
            {
                lstot = iprocesos.ConsultarOt(Opcion, COD_ORDTRA, RolloTeje, RolloTeje1, RolloTeje2, SER_ORDCOMP, COD_ORDCOMP, FlagReporte, Estado);
                return lstot;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("calidadtj/showDefectos/{Opcion}/{Defecto}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<CC_Confec_Motivos>> showDefectos(string Opcion, string Defecto)
        {

            List<CC_Confec_Motivos> lstDefectos = new List<CC_Confec_Motivos>();
            try
            {
                lstDefectos = iprocesos.ConsultarDefecto(Opcion, Defecto);
                return lstDefectos;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("calidadtj/showDetalleDefectos/{Ot}/{CodRollo}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Detalle_Defectos_4_Puntos>> showDetalleDefectos(int Ot, string CodRollo)
        {

            List<Detalle_Defectos_4_Puntos> lstDetalleDefectos = new List<Detalle_Defectos_4_Puntos>();
            try
            {
                lstDetalleDefectos = iprocesos.ConsultarDetalleDefecto(Ot, CodRollo);
                return lstDetalleDefectos;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }



        [Route("calidadtj/tj_GrabarDetalleDefecto/{Accion}/{Cod_Ordtra}/{Codigo_Rollo}/{Prefijo_Maquina}/{Inspector}/{Digitador}/{Restriccion}" +
            "/{Turno}/{Cod_Motivo}/{MTRS}/{Ptos}/{seg_usuario}/{size}/{Calidad}/{Tip_Trabajador}/{Cod_Trabajador}/{Observaciones}/{MetrosCuad}/{Secuencia_n}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<RptaPx> tj_GrabarDetalleDefecto(string Accion, string Cod_Ordtra, string Codigo_Rollo, string Prefijo_Maquina,
            string Inspector, string Digitador, string Restriccion, string Turno, string Cod_Motivo, decimal MTRS, int Ptos, string seg_usuario,
            decimal size, int Calidad, string Tip_Trabajador, string Cod_Trabajador, string Observaciones, decimal MetrosCuad, string Secuencia_n)
        {
            var bresultado = new RptaPx();

            List<Detalle_Defectos_4_Puntos> lstGrabarDetalle4Puntos0 = new List<Detalle_Defectos_4_Puntos>();            

            bresultado = iprocesos.salvarDetalleDefectos4Puntos(Accion, Cod_Ordtra, Codigo_Rollo, Prefijo_Maquina, Inspector, Digitador,
                Restriccion, Turno, Cod_Motivo, MTRS, Ptos, seg_usuario, size, Calidad, Tip_Trabajador, Cod_Trabajador, Observaciones, MetrosCuad, Secuencia_n);
            return bresultado;
        }


        [Route("calidadtj/tj_EliminarDetalleDefecto/{Accion}/{Cod_Ordtra}/{Codigo_Rollo}/{Prefijo_Maquina}/{Inspector}/{Digitador}/{Restriccion}" +
            "/{Turno}/{Cod_Motivo}/{MTRS}/{Ptos}/{seg_usuario}/{size}/{Calidad}/{Tip_Trabajador}/{Cod_Trabajador}/{Observaciones}/{MetrosCuad}/{Secuencia_n}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<RptaPx> tj_EliminarDetalleDefecto(string Accion, string Cod_Ordtra, string Codigo_Rollo, string Prefijo_Maquina,
            string Inspector, string Digitador, string Restriccion, string Turno, string Cod_Motivo, decimal MTRS, int Ptos, string seg_usuario,
            decimal size, int Calidad, string Tip_Trabajador, string Cod_Trabajador, string Observaciones, decimal MetrosCuad, string Secuencia_n)
        {
            var bresultado = new RptaPx();


            bresultado = iprocesos.EliminarDetalleDefectos4Puntos(Accion, Cod_Ordtra, Codigo_Rollo, Prefijo_Maquina, Inspector, Digitador,
                Restriccion, Turno, Cod_Motivo, MTRS, Ptos, seg_usuario, size, Calidad, Tip_Trabajador, Cod_Trabajador, Observaciones, MetrosCuad, Secuencia_n);
            return bresultado;

        }


        [Route("calidadtj/showSumaPtos/{Cod_Ordtra}/{Codigo_Rollo}/{Prefijo_Maquina}/{MetrosCuad}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<SumaPtos>> showSumaPtos(string Cod_Ordtra, string Codigo_Rollo, string Prefijo_Maquina, decimal MetrosCuad)
        {
            List<SumaPtos> lstsuma = new List<SumaPtos>();
            try
            {
                lstsuma = iprocesos.SumaPtos(Cod_Ordtra, Codigo_Rollo, Prefijo_Maquina, MetrosCuad);
                return lstsuma;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        /* ======= LABORATORIO  - LECTURA DE RECETAS  ============   */

        [Route("laboratorio/showLecturaReceta/{Accion}/{Tip_Trabajador}/{Cod_Trabajador}/{Cod_Cliente_Tex}/{Tip_Partida}/{Clave}/{Des_Colcli}/{Cod_Colorante}/{Fec_Programa}/{Num_Corre}/{Cod_Usuario}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Lb_Programa_Receta_Agrupado>> showLecturaReceta(string Accion, string Tip_Trabajador, string Cod_Trabajador, string Cod_Cliente_Tex, string Tip_Partida,
            string Clave, string Des_Colcli, string Cod_Colorante, DateTime Fec_Programa, string Num_Corre, string Cod_Usuario)
        {

            List<Lb_Programa_Receta_Agrupado> lsProgramaReceta = new List<Lb_Programa_Receta_Agrupado>();
            try
            {
                lsProgramaReceta = iprocesos.showLecturaReceta(Accion, Tip_Trabajador, Cod_Trabajador, Cod_Cliente_Tex, Tip_Partida,
             Clave, Des_Colcli, Cod_Colorante, Fec_Programa, Num_Corre, Cod_Usuario);
                return lsProgramaReceta;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("laboratorio/grabarlecturareceta/{Accion}/{Tip_Trabajador}/{Cod_Trabajador}/{Cod_Cliente_Tex}/{Tip_Partida}/{Clave}/{Des_Colcli}/{Cod_Colorante}/{Fec_Programa}/{Num_Corre}/{Cod_Usuario}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<RptaPx> grabarlecturareceta(string Accion, string Tip_Trabajador, string Cod_Trabajador, string Cod_Cliente_Tex, string Tip_Partida,
            string Clave, string Des_Colcli, string Cod_Colorante, DateTime Fec_Programa, string Num_Corre, string Cod_Usuario)
        {
            var bresultado = new RptaPx();

            List<Lb_Programa_Receta_Agrupado> lsProgramaReceta = new List<Lb_Programa_Receta_Agrupado>();

            bresultado = iprocesos.grabarlecturareceta(Accion, Tip_Trabajador, Cod_Trabajador, Cod_Cliente_Tex, Tip_Partida,
             Clave, Des_Colcli, Cod_Colorante, Fec_Programa, Num_Corre, Cod_Usuario);
            return bresultado;

        }

        /* ======= LABORATORIO  - LECTURA DE RECETAS  ============   */

        /* ======= SEGUIMIENTO TOBERAS  ============   */

        [Route("seguimientotobera/showLectura/{Accion}/{IdSeg}/{FechaRegistro}/{CodReceta}/{NumTobera}/{Maquina}/{Partida}/{RutaFoto}/{FlgStatus}/{Cod_usuario}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Lectura_Tobera_net>> showLectura(string Accion, int IdSeg, string FechaRegistro, string CodReceta, int NumTobera, string Maquina, string Partida,
                                                                string RutaFoto, string FlgStatus, string Cod_usuario)
        {
            List<Lectura_Tobera_net> lsLecturaTobera = new List<Lectura_Tobera_net>();

            try
            {
                lsLecturaTobera = iprocesos.showLectura(Accion, IdSeg, FechaRegistro, CodReceta, NumTobera, Maquina, Partida,
                                                        RutaFoto, FlgStatus, Cod_usuario);
                lsLecturaTobera[0].Imagenes= iprocesos.showLecturaDetalleImagen(CodReceta);
                return lsLecturaTobera;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("seguimientotobera/grabarlecturatobera/{Accion}/{IdSeg}/{FechaRegistro}/{CodReceta}/{NumTobera}/{Maquina}/{Partida}/{RutaFoto}/{FlgStatus}/{Cod_usuario}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<RptaPx> grabarlecturatobera(string Accion, int IdSeg, string FechaRegistro, string CodReceta, int NumTobera, string Maquina, string Partida,
                                                      string RutaFoto, string FlgStatus, string Cod_usuario)
        {
            var bresultado = new RptaPx();

            List<Lectura_Tobera_net> lsProgramaReceta = new List<Lectura_Tobera_net>();

            bresultado = iprocesos.grabarlecturatobera(Accion, IdSeg, FechaRegistro, CodReceta, NumTobera, Maquina, Partida,
                                                        RutaFoto, FlgStatus, Cod_usuario);
            return bresultado;

        }

        public class FileUpload
        {
            public IFormFile files { get; set; }
            public IFormFile files2 { get; set; }
            public IFormFile files3 { get; set; }
            public IFormFile files4 { get; set; }
            public IFormFile files5 { get; set; }
            public string partida { get; set; }

            public string codreceta { get; set; }

        }


        public string CodReceta;

        [Route("seguimientotobera/CargarImagen/{codreceta}")]
        [AllowAnonymous]
        [HttpPost]
        //public async Task<RptaPx> CargarImagen([FromForm] FileUpload objFile, string codreceta)
        public async Task<RptaPx> CargarImagen([FromForm] FileUpload objFile, string codreceta)
        {

            string Foto1 = "";
            string Foto2 = "";

            try
            {
                if (objFile.files != null)
                {
                    await subirImagen(objFile.files, objFile.partida, codreceta, 1);
                }
                if (objFile.files2 != null)
                {
                    await subirImagen(objFile.files2, objFile.partida, codreceta, 2);
                }
                if (objFile.files3 != null)
                {
                    await subirImagen(objFile.files3, objFile.partida, codreceta, 3);
                }
                if (objFile.files4 != null)
                {
                    await subirImagen(objFile.files4, objFile.partida, codreceta, 4);
                }
                if (objFile.files5 != null)
                {
                    await subirImagen(objFile.files5, objFile.partida, codreceta, 5);
                }


                var rptx2 = new RptaPx();
                rptx2.Mensaje = "OKOK";
                return rptx2;
            }

            catch (Exception)
            {

                throw;
            }
        }



        public int conteo = 1;

        //private async Task<string> subirImagen(IFormFile objFile, string codreceta, int Secuencia)
        private async Task<string> subirImagen(IFormFile objFile, string partida, string codreceta, int Secuencia)

        {
            try
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                }

                //if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\" + codreceta + "_" + Secuencia + ".jpg"))
                //{
                //    System.IO.File.Delete(_environment.WebRootPath + "\\uploads\\" + codreceta + "_" + Secuencia + ".jpg");
                //}

                if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\" + partida + "-" + codreceta + "-"  + Secuencia + ".jpg"))
                {
                    System.IO.File.Delete(_environment.WebRootPath + "\\uploads\\" + partida + "-" + codreceta + "-" + Secuencia + ".jpg");
                }

                //using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + codreceta + "_" + Secuencia + ".jpg"))
                using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + partida + "-" + codreceta + "-" + Secuencia + ".jpg"))
                {
                    await objFile.CopyToAsync(fileStream);
                    fileStream.Flush();

                }

                var rptx2 = new RptaPx();
                var NombreImagen = partida + "-" + codreceta + "-" + Secuencia;
                var bresultado = new RptaPx();
                //bresultado = iprocesos.grabarlecturatoberaImagenDetalle(codreceta, NombreImagen, Secuencia);
                bresultado = iprocesos.grabarlecturatoberaImagenDetalle(codreceta, NombreImagen, Secuencia);

                conteo += 1;                
                return codreceta;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        


        [Route("seguimientotobera/showLecturaDetalleImagen/{CodReceta}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Lectura_Tobera_Detalle>> showLecturaDetalleImagen(string CodReceta)
        {

            List<Lectura_Tobera_Detalle> lsLecturaToberaDetalle = new List<Lectura_Tobera_Detalle>();
            try
            {
                lsLecturaToberaDetalle = iprocesos.showLecturaDetalleImagen(CodReceta);
                return lsLecturaToberaDetalle;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("seguimientotobera/GuardarImagen")]
        [AllowAnonymous]
        [HttpPost]
        
        public async Task<RptaPx> Post([FromForm] FileUpload objFile)
        {
            if (objFile.files.Length > 0)            
            {            
                    try
                    {
                        if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                        {
                            Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                        }

                        if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\" + objFile.partida + objFile.codreceta + ".jpg"))
                        {
                            System.IO.File.Delete(_environment.WebRootPath + "\\uploads\\" + objFile.partida + objFile.codreceta + ".jpg");
                        }

                        var rptx2 = new RptaPx();
                        var bresultado = new RptaPx();
                        bresultado = iprocesos.grabarlecturatoberaImagen(objFile.codreceta);

                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + objFile.partida + objFile.codreceta + ".jpg"))
                        {
                            await objFile.files.CopyToAsync(fileStream);
                            fileStream.Flush();
                        }
                        rptx2.Mensaje = "OK";
                        return rptx2;

                    }
                    catch (Exception ex)
                    {
                        var rptx2 = new RptaPx();
                        rptx2.Mensaje = ex.Message;
                        return rptx2;
                    }
                }
                    else
               {
                var rptx2 = new RptaPx();
                rptx2.Mensaje = "Vacio";
                return rptx2;
               }
        }
        
        /* ======= SEGUIMIENTO TOBERAS  ============   */


        [Route("procesos/showAll/{Maquina}/{Usuario}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Proceso>> showAll( string Maquina, string Usuario)
        {
            List<Proceso> lstProceso = new List<Proceso>();
            try
            {
                lstProceso = iprocesos.Consultar(Maquina, Usuario);
                return lstProceso;
            } catch (Exception e){
                throw new Exception("Error " + e.Message);
            }
        }

        [Route("procesos/ti_sm_muestra_telas_partida_resumen/{cod_ordtra}/{cod_tela}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<partida_resumen>> ti_sm_muestra_telas_partida_resumen(string cod_ordtra, string cod_tela)
        {
            List<partida_resumen> lstPartResumen = new List<partida_resumen>();
            try
            {
                lstPartResumen = iprocesos.TelasPartidaResumen(cod_ordtra, cod_tela);
                return lstPartResumen;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/TI_MUESTRA_PROCESO/{cod_ordtra}/{cod_tela}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<tela_proceso>> TI_MUESTRA_PROCESO(string cod_ordtra, string cod_tela)
        {
            List<tela_proceso> lstProceso = new List<tela_proceso>();
            try
            {
                lstProceso = iprocesos.TelaProceso(cod_ordtra, cod_tela);
                return lstProceso;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        //[Route("procesos/TI_MUESTRA_PROCESO_CAMBIO_RUTA/{cod_ordtra}/{cod_tela}/{cod_motivo_repro}")]
        [Route("procesos/TI_MUESTRA_PROCESO_CAMBIO_RUTA")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<tela_proceso>> TI_MUESTRA_PROCESO_CAMBIO_RUTA(string cod_ordtra, string cod_tela, string cod_motivo)
        {
            List<tela_proceso> lstProceso = new List<tela_proceso>();
            try
            {
                lstProceso = iprocesos.TelaProcesoCambioRuta(cod_ordtra, cod_tela, cod_motivo);
                return lstProceso;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/TI_MUESTRA_TI_ORDTRA_TINTORERIA_PROCESOS/{cod_ordtra}/{id_proceso}/{flg_orden}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<tintoreria_procesos>> TI_MUESTRA_TI_ORDTRA_TINTORERIA_PROCESOS(string cod_ordtra,int id_proceso,string flg_orden)
        {
            List<tintoreria_procesos> lstPartProcesos = new List<tintoreria_procesos>();
            try
            {
                lstPartProcesos = iprocesos.PartidaProcesos(cod_ordtra,id_proceso,flg_orden);
                lstPartProcesos.OrderBy(i => i.Fecha_Inicio);
                return lstPartProcesos;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/ac_Maquina_Proceso/{codMaquina}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<maquinaProceso>> ac_Maquina_Proceso(string codMaquina)
        {
            List<maquinaProceso> lstProcess = new List<maquinaProceso>();
            try
            {
                lstProcess = iprocesos.maquinaProceso(codMaquina);
                return lstProcess;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/ac_Procesos_Acabados/{Partida}/{CodTela}/{Cod_Maquina}/{Cod_Usuario}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<maquinaProceso>> ac_Procesos_Acabados(string Partida, string CodTela, string Cod_Maquina, string Cod_Usuario)
        {
            List<maquinaProceso> lstProcess = new List<maquinaProceso>();
            try
            {
                lstProcess = iprocesos.ProcesoAcabados(Partida, CodTela,  Cod_Maquina,  Cod_Usuario);
                return lstProcess;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/ac_Procesos_AcabadosCerrados/{Partida}/{CodTela}/{Cod_Maquina}/{Cod_Usuario}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<maquinaProceso>> ac_Procesos_AcabadosCerrados(string Partida, string CodTela, string Cod_Maquina, string Cod_Usuario)
        {
            List<maquinaProceso> lstProcess = new List<maquinaProceso>();
            try
            {
                lstProcess = iprocesos.ProcesoAcabadosCerrados(Partida, CodTela, Cod_Maquina, Cod_Usuario);
                return lstProcess;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        [Route("procesos/ti_sm_muestra_telas_partida_proceso_SECUENCIA/{cod_ordtra}/{cod_tela}/{cod_proc}/{secuencia}/{id_proceso}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<telas_partida_proceso>> ti_sm_muestra_telas_partida_proceso_SECUENCIA(string cod_ordtra, string cod_tela, string cod_proc, int secuencia, int id_proceso)
        {
            List<telas_partida_proceso> lstTelaPartidas = new List<telas_partida_proceso>();
            try
            {
                lstTelaPartidas = iprocesos.telas_partida(cod_ordtra, cod_tela,cod_proc, secuencia, id_proceso);
                return lstTelaPartidas;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

         //Grabar los Rollos

        [Route("procesos/ti_GrabarPartidasRollos")]        
        [AllowAnonymous]
        [HttpPost]       

        public async Task<RptaPx> ti_GrabarPartidasRollos([FromBody] List<telas_partida_proceso> lstRollosPartida, string proceso, string maquina, int secuencia, string accion, string fechaFinal, int IdProceso,  string fechainicial, string usuario, string motivo, string observaciones, string codtela, string partida, string Flg_Orden)
        {
            var bresultado = new RptaPx();

            List<telas_partida_proceso> lstTelaPartidaProceso = new List<telas_partida_proceso>();
            lstTelaPartidaProceso = lstRollosPartida;
            try
            {
                bresultado = iprocesos.salvarDatosRollos(lstRollosPartida, proceso, maquina, secuencia, accion, fechaFinal, IdProceso,  fechainicial,  usuario, motivo, observaciones, codtela, partida, Flg_Orden);

                return bresultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);                
            }
        }

        //Grabar Cambio Ruta

        [Route("procesos/ti_GrabarCambioRuta")]
        [AllowAnonymous]
        [HttpPost]

        public async Task<RptaPx> ti_GrabarCambioRuta([FromBody] List<tela_proceso> lstProcesos, string partida, string codtela, string codmotivo,string codigomotivos, string usuario)
        {
            var bresultado = new RptaPx();

            List<tela_proceso> lstCambioRuta = new List<tela_proceso>();
            lstCambioRuta = lstProcesos;
            try
            {
                bresultado = iprocesos.grabaCambioRuta(lstProcesos, partida, codtela, codmotivo,codigomotivos, usuario);

                return bresultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/ti_GrabartiemposImproductivos")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]        
        public async Task<bool> ti_GrabartiemposImproductivos(string accion, string maquina, string motivo, string observaciones,string partida,string usuario)
        {
            bool bresultado = false;
            try
            {                
                bresultado = iprocesos.salvarTiemposImproductivos(accion, maquina,  motivo,  observaciones,partida,usuario);

                return bresultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

// partida con su estado y color
        [Route("procesos/ParticaColorEstado")]       
        [AllowAnonymous]
        [HttpGet]
        public async Task<partidaStatus> ti_PartidaColorEstatus( string cod_ordtra, string Cod_Tela)
        {
            partidaStatus partidaStatus = new partidaStatus();
            try
            {
                partidaStatus = iprocesos.partidaStatusColor(cod_ordtra,Cod_Tela);

                return partidaStatus;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        [Route("procesos/MuestraPartidasPendientesRef}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<PartidaPendientesEstRef>> MuestraPartidasPendientesRef()
        {
            List<PartidaPendientesEstRef> lspartidas = new List<PartidaPendientesEstRef>();
            try
            {
                lspartidas= iprocesos.MuestraPartidasPendientesRef();
                return lspartidas;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }


        [Route("procesos/MuestraParamReceta/{NroReferencia}/{Cod_usuario}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<RecetaAcabado>> MuestraParamReceta(string NroReferencia, string Cod_usuario)
        {
            List<RecetaAcabado> lsParamReceta = new List<RecetaAcabado>();
            try
            {
                lsParamReceta = iprocesos.MuestraParamReceta(NroReferencia, Cod_usuario);                
                return lsParamReceta;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

        [Route("paramreceta/SaveParamReceta/{scod_usuario}")]
        [AllowAnonymous]
        [HttpPost]        
        public async Task<RptaPx> SaveParamReceta([FromForm] FileUploadTinto objFile, string scod_usuario)
        {

            string Foto1 = "";
            string Foto2 = "";

            try
            {
                //if (objFile.sMuDurezaTenido != null)
                //{
                //    await subirParamReceta(objFile.sMuDurezaTenido, objFile.Nro_Referencia);
                //}
                //if (objFile.files2 != null)
                //{
                //    await subirImagen(objFile.files2, objFile.partida, codreceta, 2);
                //}

                await subirParamReceta(objFile.Nro_Referencia
                                       , objFile.nDgHoraCarga
                                       , objFile.nDgCuerdas
                                       , objFile.nCrAncho
                                       , objFile.nCrDensidad                                       
                                       , objFile.nPrTobera 
                                       , objFile.nPrNivBanoMaq
                                       , objFile.nPrPhPilling1
                                       , objFile.nPrPhPilling2
                                       , objFile.nTrTobera
                                       , objFile.nTrVolumen
                                       , objFile.nTrNivBanoMaq1
                                       , objFile.nTrNivBanoMaq2 
                                       , objFile.nTrPhInicio1CSal
                                       , objFile.nTrPhInicio2CSal
                                       , objFile.nTrPhInicio1SSal
                                       , objFile.nTrPhInicio2SSal                                       
                                       , objFile.nTrDensidadSal1
                                       , objFile.nTrDensidadSal2
                                       , objFile.nTrTemperatura1
                                       , objFile.nTrTemperatura2
                                       , objFile.nTrLtDosifColor
                                       , objFile.nTrLtDosifSal
                                       , objFile.nTrLtDosif1Alca
                                       , objFile.nTrPh1Alcali1
                                       , objFile.nTrPh1Alcali2
                                       , objFile.nTrPh2Alcali1
                                       , objFile.nTrPh2Alcali2
                                       , objFile.nTrLtDosif2Alca                               
                                       , objFile.nTrAgotamiento1
                                       , objFile.nTrAgotamiento2
                                       , objFile.nTrTiempoAgota
                                       , objFile.nJaPh1
                                       , objFile.nJaPh2
                                       , objFile.nFiPh1
                                       , objFile.nFiPh2
                                       , objFile.nAcPh1
                                       , objFile.nAcPh2
                                       , objFile.nTdTobera
                                       , objFile.nTdPhTenido1
                                       , objFile.nTdPhTenido2
                                       , objFile.nTdPhDescargaDisp1
                                       , objFile.nTdPhDescargaDisp2
                                       , objFile.sMuDurezaTenido
                                       , objFile.sMuPeroxiResidu
                                       , objFile.sCambioTurno                                       
                                       , objFile.sObs
                                       , scod_usuario);

                var rptx2 = new RptaPx();
                rptx2.Mensaje = "Ok";
                return rptx2;
            }

            catch (Exception)
            {

                throw;
            }
        }

        private async Task<string> subirParamReceta(string NroReferencia
                                                     , string nDg_Hora_Carga
                                                     , string Dg_Cuerdas
                                                     , string Cr_Ancho
                                                     , string Cr_Densidad                                                     
                                                     , string Pr_Tobera
                                                     , string Pr_Niv_Bano_Maq
                                                     , string Pr_Ph_Pilling_1
                                                     , string Pr_Ph_Pilling_2
                                                     , string Tr_Tobera
                                                     , string Tr_Volumen
                                                     , string Tr_Niv_Bano_Maq1
                                                     , string Tr_Niv_Bano_Maq2
                                                     , string Tr_Ph_Inicio1_CSal
                                                     , string Tr_Ph_Inicio2_CSal
                                                     , string Tr_Ph_Inicio1_SSal
                                                     , string Tr_Ph_Inicio2_SSal
                                                     , string Tr_Densidad_Sal_1
                                                     , string Tr_Densidad_Sal_2
                                                     , string Tr_Temperatura_1
                                                     , string Tr_Temperatura_2
                                                     , string Tr_Lt_Dosif_Color
                                                     , string Tr_Lt_Dosif_Sal
                                                     , string Tr_Lt_Dosif1_Alca
                                                     , string Tr_Ph_1_Alcali_1
                                                     , string Tr_Ph_1_Alcali_2
                                                     , string Tr_Ph_2_Alcali_1
                                                     , string Tr_Ph_2_Alcali_2
                                                     , string Tr_Lt_Dosif2_Alca                                                     
                                                     , string Tr_Agotamiento_1
                                                     , string Tr_Agotamiento_2
                                                     , string Tr_Tiempo_Agota
                                                     , string Ja_Ph_1
                                                     , string Ja_Ph_2
                                                     , string Fi_Ph_1
                                                     , string Fi_Ph_2                
                                                     , string Ac_Ph_1
                                                     , string Ac_Ph_2
                                                     , string Td_Tobera
                                                     , string Td_Ph_Tenido_1
                                                     , string Td_Ph_Tenido_2
                                                     , string Td_Ph_Descarga_Disp_1
                                                     , string Td_Ph_Descarga_Disp_2
                                                     , IFormFile sMuDurezaTenido
                                                     , IFormFile sMuPeroxiResidu
                                                     , string Cambio_Turno                                                     
                                                     , string Observaciones
                                                     , string scod_usuario)

        {
            try
            {
                string Mu_Dureza_Tenido = "";
                string Mu_Peroxi_Residu = "";

                if (!Directory.Exists(_environment.WebRootPath + "\\uploadsparamtinto\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\uploadsparamtinto\\");
                }

                if (sMuDurezaTenido != null)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUDUTE-" + NroReferencia + ".jpg"))
                    {
                        System.IO.File.Delete(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUDUTE-" + NroReferencia + ".jpg");
                    }

                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUDUTE-" + NroReferencia + ".jpg"))
                    {
                        await sMuDurezaTenido.CopyToAsync(fileStream);
                        fileStream.Flush();
                        Mu_Dureza_Tenido = "MUDUTE-" + NroReferencia;
                    }
                }

                if (sMuPeroxiResidu != null)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUPERE-" + NroReferencia + ".jpg"))
                    {
                        System.IO.File.Delete(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUPERE-" + NroReferencia + ".jpg");
                    }

                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploadsparamtinto\\" + "MUPERE-" + NroReferencia + ".jpg"))
                    {
                        await sMuPeroxiResidu.CopyToAsync(fileStream);
                        fileStream.Flush();
                        Mu_Peroxi_Residu = "MUPERE-" + NroReferencia;
                    }
                }

                var rptx2 = new RptaPx();

                var bresultado = new RptaPx();

                bresultado = iprocesos.grabarParamReceta(NroReferencia
                                                         , nDg_Hora_Carga
                                                         , Dg_Cuerdas
                                                         , Cr_Ancho
                                                         , Cr_Densidad
                                                         , Pr_Tobera
                                                         , Pr_Niv_Bano_Maq
                                                         , Pr_Ph_Pilling_1
                                                         , Pr_Ph_Pilling_2
                                                         , Tr_Tobera
                                                         , Tr_Volumen
                                                         , Tr_Niv_Bano_Maq1
                                                         , Tr_Niv_Bano_Maq2
                                                         , Tr_Ph_Inicio1_CSal
                                                         , Tr_Ph_Inicio2_CSal
                                                         , Tr_Ph_Inicio1_SSal
                                                         , Tr_Ph_Inicio2_SSal
                                                         , Tr_Densidad_Sal_1
                                                         , Tr_Densidad_Sal_2
                                                         , Tr_Temperatura_1
                                                         , Tr_Temperatura_2
                                                         , Tr_Lt_Dosif_Color
                                                         , Tr_Lt_Dosif_Sal
                                                         , Tr_Lt_Dosif1_Alca
                                                         , Tr_Ph_1_Alcali_1
                                                         , Tr_Ph_1_Alcali_2
                                                         , Tr_Ph_2_Alcali_1
                                                         , Tr_Ph_2_Alcali_2
                                                         , Tr_Lt_Dosif2_Alca
                                                         , Tr_Agotamiento_1
                                                         , Tr_Agotamiento_2
                                                         , Tr_Tiempo_Agota
                                                         , Ja_Ph_1
                                                         , Ja_Ph_2
                                                         , Fi_Ph_1
                                                         , Fi_Ph_2
                                                         , Ac_Ph_1
                                                         , Ac_Ph_2
                                                         , Td_Tobera
                                                         , Td_Ph_Tenido_1
                                                         , Td_Ph_Tenido_2
                                                         , Td_Ph_Descarga_Disp_1
                                                         , Td_Ph_Descarga_Disp_2
                                                         , Mu_Dureza_Tenido
                                                         , Mu_Peroxi_Residu
                                                         , Cambio_Turno                                                         
                                                         , Observaciones
                                                         , scod_usuario);

                
                return bresultado.Mensaje;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public class FileUploadTinto
        {
            public string Nro_Referencia { get; set; }
            public string nDgHoraCarga { get; set; }
            public string nDgCuerdas { get; set; }
            public string nCrAncho { get; set; }
            public string nCrDensidad { get; set; }            
            public string nPrTobera { get; set; }            
            public string nPrNivBanoMaq { get; set; }
            public string nPrPhPilling1 { get; set; }
            public string nPrPhPilling2 { get; set; }
            public string nTrTobera { get; set; }            
            public string nTrVolumen { get; set; }
            public string nTrNivBanoMaq1 { get; set; }
            public string nTrNivBanoMaq2 { get; set; }
            public string nTrPhInicio1CSal { get; set; }
            public string nTrPhInicio2CSal { get; set; }
            public string nTrPhInicio1SSal { get; set; }
            public string nTrPhInicio2SSal { get; set; }
            public string nTrDensidadSal1 { get; set; }
            public string nTrDensidadSal2 { get; set; }
            public string nTrTemperatura1 { get; set; }
            public string nTrTemperatura2 { get; set; }
            public string nTrLtDosifColor { get; set; }
            public string nTrLtDosifSal { get; set; }
            public string nTrLtDosif1Alca { get; set; }
            public string nTrPh1Alcali1 { get; set; }
            public string nTrPh1Alcali2 { get; set; }
            public string nTrPh2Alcali1 { get; set; }
            public string nTrPh2Alcali2 { get; set; }
            public string nTrLtDosif2Alca { get; set; }            
            public string nTrAgotamiento1 { get; set; }
            public string nTrAgotamiento2 { get; set; }
            public string nTrTiempoAgota { get; set; }
            public string nJaPh1 { get; set; }
            public string nJaPh2 { get; set; }
            public string nFiPh1 { get; set; }
            public string nFiPh2 { get; set; }
            public string nAcPh1 { get; set; }
            public string nAcPh2 { get; set; }            
            public string nTdTobera { get; set; }            
            public string nTdPhTenido1 { get; set; }
            public string nTdPhTenido2 { get; set; }
            public string nTdPhDescargaDisp1 { get; set; }
            public string nTdPhDescargaDisp2 { get; set; }
            public IFormFile sMuDurezaTenido { get; set; }
            public IFormFile sMuPeroxiResidu { get; set; }
            public string sCambioTurno { get; set; }            
            public string sObs { get; set; }
        }
    }
}

