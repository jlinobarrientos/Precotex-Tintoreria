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
    public class LoginController : ControllerBase
    {
        Ilogin ilogin = new Ilogin();

        private readonly ILogger<LoginController> _logger;



        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        [Route("login/validarUsuario/{usuario}/{pass}")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<Login> validarUsuario(string usuario, string pass)
        {
            Login login = new Login();
            try
            {
                login = ilogin.ConsultarLogin(usuario, pass);
                return login;
            }
            catch (Exception e)
            {
                throw new Exception("Error " + e.Message);
            }
        }

    }
}
