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
    public class MaquinaController : ControllerBase
    {
        IMaquinas imaquinas = new IMaquinas();
        private readonly ILogger<MaquinaController> _logger;

            public MaquinaController(ILogger<MaquinaController> logger)
            {
                _logger = logger;
            }

            [Route("maquina/showMaquina/{Usuario}/{Cod_Proceso}")]
     //    [Authorize]
            [AllowAnonymous]
            [HttpGet]
            public async Task<List<Maquina>> showMaquina(string Usuario, string Cod_Proceso)
            {
                List<Maquina> lstMaquina = new List<Maquina>();
            lstMaquina = imaquinas.Consultar( Usuario, Cod_Proceso);
                return lstMaquina;
            }


            [Route("maquina/showMaquinasListado/{Cod_Maquina_Tinto}")]
            //[Authorize]
            [AllowAnonymous]
            [HttpGet]
            public async Task<List<Maquina>> showMaquinasListado(string Cod_Maquina_Tinto)
            {
                List<Maquina> lstMaquina = new List<Maquina>();
                try
                {
                lstMaquina = imaquinas.ListadoMaquina(Cod_Maquina_Tinto);
                    return lstMaquina;
                }
                catch (Exception e)
                {
                    throw new Exception("Error " + e.Message);

                }
            }

            [Route("maquina/ti_existe_tiempoimproductivo/{Cod_Maquina_Tinto}/{Cod_Motivo_Impr}")]
            //[Authorize]
            [AllowAnonymous]
            [HttpGet]
            public async Task<List<Respuesta>> ti_existe_tiempoimproductivo(string Cod_Maquina_Tinto,string Cod_Motivo_Impr)
            {
                List<Respuesta> lstMaquina = new List<Respuesta>();
                try
                {
                    lstMaquina = imaquinas.ExisteTiempo(Cod_Maquina_Tinto, Cod_Motivo_Impr);
                    return lstMaquina;
                }
                catch (Exception e)
                {
                    throw new Exception("Error " + e.Message);

                }
            }

    }
}
