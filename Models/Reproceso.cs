using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws_prectoex.Models
{
    public class Reproceso
    {
       public DateTime Fecha_Registro { get; set; }
        public int IdGrupo { get; set; }
        public string Cod_Ordtra { get; set; }
        public int Num_Secuencia { get; set; }
        public string Cod_Tela { get; set; }
        public string Cod_Comb { get; set; }
        public Double Kgs_Crudo { get; set; }
        public string Flg_Principal { get; set; }
        public string observacion { get; set; }
        
    }

    public class MotivoReproceso
    {
        public string Cod_Motivo_Reproceso { get; set; }
        public string Descripcion { get; set; }
        public string Flg_Reproceso { get; set; }
        public string Flg_Reproceso_Neto { get; set; }
        public bool Estado { get; set; }

    }

    public class MotivoTiempoImproductivo {
        public string Cod_Motivo_Impr { get; set; }
        public string Descripcion  { get; set; }
        public string Flg_Estado { get; set; }
        public string Cod_Motivo_Imp_Orgatex  { get; set; }
    }

}
