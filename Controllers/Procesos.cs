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

        [Route("procesos/MuestraParamReceta/{CodReceta}/{Cod_usuario}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<RecetaAcabado>> MuestraParamReceta(string CodReceta,string Cod_usuario)
        {
            List<RecetaAcabado> lsParamReceta = new List<RecetaAcabado>();
            try
            {
                lsParamReceta = iprocesos.MuestraParamReceta(CodReceta, Cod_usuario);                
                return lsParamReceta;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

    }
}
