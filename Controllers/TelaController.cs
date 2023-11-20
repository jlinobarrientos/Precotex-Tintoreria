using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_prectoex.Data;

namespace Ws_prectoex.Controllers
{
    [ApiController]

    [AllowAnonymous]
    public class TelaController : ControllerBase
    {
       
            ITelas itelas = new ITelas();

        private readonly ILogger<TelaController> _logger;

        public TelaController(ILogger<TelaController> logger)
        {
            _logger = logger;
        }


        [Route("telas/showTela/{Cod_Tela}")]
        //  [Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<Tela> showTela(string Cod_Tela)
        {
            Tela tela = new Tela();
            tela = itelas.Consultar(Cod_Tela);
            return tela;
        }

        [Route("telas/showTelaPrincipal/{cod_ordtra}")]
        //  [Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<Tela> showTelaPrincipal(string cod_ordtra)
       {
           
            Tela tela = new Tela();
            tela = itelas.ConsultarTelaPrincipal(cod_ordtra);
            return tela;
           
           
        }

    }
}
