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
    public class FichaController : ControllerBase
    {
        IFichas ifichas = new IFichas();
        private readonly ILogger<FichaController> _logger;



        public FichaController(ILogger<FichaController> logger)
        {
            _logger = logger;
        }


        [Route("ficha/showFicha/{IdGrupo}/{Cod_Tela}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Ficha>> showFicha(int IdGrupo, string Cod_Tela)
        {
            List<Ficha> lstFicha = new List<Ficha>();
            lstFicha = ifichas.Consultar(IdGrupo, Cod_Tela);
            return lstFicha;
        }


       // string , string , string 
       [Route("ficha/addFicha/{IdGrupo}/{Cod_Tela}/{Cod_Proceso_Tinto}/{Cod_Usuario}/{Cod_Maquina}")]
        // [Authorize]
        [AllowAnonymous]
        [HttpPost]
        public async Task<bool> addFicha(int IdGrupo, string Cod_Tela, string Cod_Proceso_Tinto, string Cod_Usuario, string Cod_Maquina)
        {
          //  List<Ficha> lstFicha = new List<Ficha>();
            bool bInsertar = false;
            bInsertar = ifichas.InsertarFichas(IdGrupo, Cod_Tela, Cod_Proceso_Tinto, Cod_Usuario, Cod_Maquina);
            return bInsertar;
        }


        // Fichas
        [Route("ficha/traerPartidas/{IdGrupo}")]
        // [Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<Respuesta> traerPartidas(int IdGrupo)
        {
            Respuesta respueta = new Respuesta();
            //bool bInsertar = false;
            if (IdGrupo >= 10) { 
            respueta = ifichas.traerPartidas(IdGrupo);
        }else{
                respueta.Resultado = "";
            }
            return respueta;
        }



    }
}

