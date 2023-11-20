
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Data;
using Ws_prectoex.Models;

namespace Ws_prectoex.Controllers
{
    public class ReprocesoController : ControllerBase
    {
        IReproceso ireprocesos = new IReproceso();

        private readonly ILogger<ReprocesoController> _logger;

        public ReprocesoController(ILogger<ReprocesoController> logger)
        {
            _logger = logger;
        }


        [Route("reprocesos/showReprocesos")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Reproceso>> showAllReprocesos( )
        {
            List<Reproceso> lstReproceso = new List<Reproceso>();
            try
            {
                lstReproceso = ireprocesos.ConsultarGrupoPartida();
                return lstReproceso;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            
            }
        }


        /*Lista de Motivo de Reprocesos  motivoReproceso*/
        [Route("reprocesos/motivosReprocesos/{Cod_Ordtra}/{Cod_Tela}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<MotivoReproceso>> MotivosReprocesos(string Cod_Ordtra, string Cod_Tela)
        {
            List<MotivoReproceso> lstMotivoReproceso = new List<MotivoReproceso>();
            try
            {
                lstMotivoReproceso = ireprocesos.motivoReproceso(Cod_Ordtra,Cod_Tela);
                return lstMotivoReproceso;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }



        [Route("reprocesos/showReprocesosObserva")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Reproceso>> showAllReprocesosObserva()
        {
            List<Reproceso> lstReproceso = new List<Reproceso>();
            try
            {
                lstReproceso = ireprocesos.visualizarReproceso();
                return lstReproceso;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);

            }
        }



        /*
         grabar Reproceso
         */

        [Route("reprocesos/ti_GrabarPartidasRollosReprocesos")]
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]        
        public async Task<RptaPx> ti_GrabarPartidasRollosReprocesos([FromBody] List<Reproceso> lstPartidaReprocesos, string observacion, string motivo, string Cod_Proceso, string Flg_Orden)
        {
            var bresultado = new RptaPx();            
            try
            {
                bresultado = ireprocesos.guardarReproceso(lstPartidaReprocesos, observacion, motivo, Cod_Proceso, Flg_Orden);

                return bresultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }



        [Route("reprocesos/validaReprocesos")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<int> validaReproceso(int IdProceso, string Cod_Tela, string Cod_Ordtra, string Cod_Proceso_Tinto, int Secuencia)
        {
            int valor = 0;
           // List<Reproceso> lstReproceso = new List<Reproceso>();
            try
            {
                valor = ireprocesos.validarReproceso(IdProceso, Cod_Tela, Cod_Ordtra, Cod_Proceso_Tinto, Secuencia);
                return valor;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);

            }
        }


        [Route("reprocesos/showMotivoImproductivo/{Cod_Maquina_Tinto}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<MotivoTiempoImproductivo>> showMotivoImproductivo(string Cod_Maquina_Tinto)
        {
            List<MotivoTiempoImproductivo> lstMotivoImproductivo = new List<MotivoTiempoImproductivo>();
            try
            {
                lstMotivoImproductivo = ireprocesos.showMotivosImproductivos(Cod_Maquina_Tinto);
                return lstMotivoImproductivo;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);

            }
        }
           

        [Route("reprocesos/movil")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Respuesta>> movil()
        {
            List<Respuesta> lstMotivoImproductivo = new List<Respuesta>();
            try
            {
                lstMotivoImproductivo = ireprocesos.movil();
                return lstMotivoImproductivo;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);

            }
        }

    }
}
