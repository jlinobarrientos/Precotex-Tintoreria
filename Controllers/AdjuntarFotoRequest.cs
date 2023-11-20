using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws_prectoex.Controllers
{
    public class AdjuntarFotoRequest
    {
        public int CodActivoFijo { get; set; }
        public string? TipoDocumento { get; set; }
        public IFormFile? Documento { get; set; }
        public string? Observacion { get; set; }

    }
}