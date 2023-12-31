﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace Ws_prectoex.Data
{
    public class Auditor
    {
        public string Tip_Auditor { get; set; }
        public string sCod_Auditor { get; set; }
        public string Codigo { get; set; }
        public string Nom_Auditor { get; set; }
        public string Respuesta { get; set; }
    }

    public class Restric
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public class OrdRollos
    {
        public string ID { get; set; }
        public string ROLLO { get; set; }
        public string TALLA { get; set; }
        public string OT { get; set; }
        public string Lote { get; set; }
        public string Partida { get; set; }
        public string OC { get; set; }
        public string PROVEEDOR { get; set; }
        public string Prefijo_Maquina { get; set; }
        public string Codigo_Rollo { get; set; }
        public string TELA_COMB { get; set; }
        public string NOMBRE_TELA { get; set; }
        public string Cod_Maquina_Tejeduria { get; set; }
        public string MAQUINA { get; set; }
        public string Sec_Maquina { get; set; }
        public string Tip_Trabajador_Tejedor { get; set; }
        public string Cod_Trabajador_Tejedor { get; set; }
        public string TEJEDOR { get; set; }
        public string KGS_PRODUCIDOS { get; set; }
        public string STATUS_ROLLO { get; set; }
        public string CALIDAD { get; set; }
        public string Calf_Auto { get; set; }
        public string Def_Tej { get; set; }
        public string INSPECTOR { get; set; }
        public string Observaciones_Inspeccion { get; set; }
        public string FECHA_CALIFICACION { get; set; }
        public string DIGITADOR { get; set; }
        public string TURNO { get; set; }
        public string FECHA_PRODUCCION { get; set; }
        public string FECHA_ALMACEN { get; set; }
        public string FECHA_DESPACHO_CRUDO { get; set; }
        public string flg_status { get; set; }
        public string RESTRICCION { get; set; }
        public string OBSERVACION { get; set; }
        public string AUTORIZA_TERCERO { get; set; }
        public string PEDIDO { get; set; }
        public string Cod_Auditor { get; set; }
        public string Cod_Digitador { get; set; }
        public string Cod_Restriccion { get; set; }
        public string Cod_Turno { get; set; }
        public string MetrosCuad { get; set; }
    }

    public class CC_Confec_Motivos
    {
        public string Cod_Motivo { get; set; }
        public string Descripcion { get; set; }
        public string Cod_Area_CC { get; set; }
        public string Secuencia { get; set; }
        public string Cod_UniMed { get; set; }
        public string Factor_Conversion { get; set; }
        public string Cod_Abr { get; set; }
        public string Cod_Tmb { get; set; }
        public string Glosa_Responsable_Origen { get; set; }
        public string Cod_Calidad_Prendas { get; set; }
        public string flg_motivo_notable_tejeduria { get; set; }
        public string Flg_Estado { get; set; }
        public string Editable { get; set; }
        public string abr_corta { get; set; }
        public string Flg_Origen { get; set; }
    }

    public class Detalle_Defectos_4_Puntos
    {
        public string Cod_Ordtra { get; set; }
        public string Codigo_Rollo { get; set; }
        public string MTRS { get; set; }
        public string Cod_Motivo { get; set; }
        public string Descripcion_Def { get; set; }
        public string Ptos { get; set; }
        public string seg_usuario { get; set; }
        public string seg_fecha { get; set; }
        public string size { get; set; }
        public string Ot { get; set; }
        public string Rollo { get; set; }
        public string Prefijo_Maquina{ get; set; }
        public string Num_secuencia { get; set; }
    }

    public class SumaPtos
    {
        public string SumaPt { get; set; }
        public string Status { get; set; }
        public string Mensaje { get; set; }
    }
 
    public class Lb_Programa_Receta_Agrupado
    {
        public string Num_Corre { get; set; }
        public string Nom_Analista { get; set; }
        public string Nom_Cliente { get; set; }
        public string Clave { get; set; }
        public string Des_Colcli { get; set; }
        public string Des_Colorante { get; set; }
        public string Fec_Programa { get; set; }
        public string Fec_Termino { get; set; }
        public string Partidas { get; set; }
        public string Color { get; set; }
    }

    public class Lectura_Tobera_net
    {
        public string IdSeg { get; set; }
        public string Tobera { get; set; }
        public string Toberasel { get; set; }
        public string Maquina { get; set; }
        public string Partida { get; set; }
        public string RutaFoto { get; set; }
        public string CodReceta { get; set; }
        public List<Lectura_Tobera_Detalle?> Imagenes { get; set; } = null!;
    }

    public class Lectura_Tobera_Detalle
    {      
        public string RutaFoto { get; set; }
        public string CodReceta { get; set; }
        public string Secuencia { get; set; }
    }

    public class ModelResponse
    {
        public int status { get; set; }
        public string? Respuesta { get; set; }
    }

        public partial class AfDocumento
        {
            public int IdDocumento { get; set; }
            public int CodActivoFijo { get; set; }
            public string TipoDocumento { get; set; } = null!;
            public string Documento { get; set; } = null!;
            public string? Observacion { get; set; }          
        }

    public  class Archivo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; } 
        public double tamanio { get; set; } 
        public string ubicacion { get; set; }
    }

    public class Proceso
    {
        public string Cod_Proceso_Tinto { get; set; }
        public string Descripcion { get; set; }
    }

    public class partida_resumen {
        public string Cod_OrdTra { get; set; }
        public int Check { get; set; }
        public string Cod_tela { get; set; }
        public string Des_Tela { get; set; }
        public decimal Crudo { get; set; }
        public string Rollos_Asignados { get; set; }
        public string Respuesta  { get; set; }
}
    public class tela_proceso
    {
        public string Partida { get; set; }        
        public string Tela { get; set; }
        public string Proceso { get; set; }
        public string Descripcion { get; set; }
        public string Cod_Receta { get; set; }
        public string Des_Receta { get; set; }
        public string Termino { get; set; }        
        public bool Estado { get; set; }
        public bool Ruta_Madre { get; set; }
        public string Cod_Motivo { get; set; }
        public int Id_Proceso { get; set; }
        public string Flg_Reproceso { get; set; }
    }

    public class partida_resumen2
    {
        public string partida { get; set; }
    }

    public class tintoreria_procesos {
        public string Cod_OrdTra { get; set; }
        public string Proceso { get; set; }
        public string Descripcion { get; set; }
        public int Secuencia { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Maquina { get; set; }
        public string Observaciones { get; set; }
        public string fechaini { get; set; }
        public string fechafin { get; set; }
        public string reproceso { get; set; }
        public string motivo { get; set; }
        public string codigomotivo { get; set; }  
        public int id_proceso { get; set; }
        public string flg_orden { get; set; }

    }

    public class telas_partida_proceso{
    public string Cod_OrdTra { get; set; }
    public int Num_Secuencia { get; set; }
    public string Cod_Tela { get; set; }
    public string Des_Tela { get; set; }
    public string Cod_Comb { get; set; }
    public string Comb { get; set; }
    public string Cod_Talla { get; set; }
    public int Sel { get; set; }
    public Decimal kgs_crudo { get; set; }
    public Decimal kgs_crudo_Editable { get; set; }
    public string Rollo { get; set; }
    public string Respuesta { get; set; }

    }

    public class maquinaProceso {
        public string Cod_Proceso_Tinto { get; set; }
        public string Descripcion { get; set; }
        public string Cod_Motivo_Repro { get; set; }
        public string Descrip_Repro { get; set; }
        public string Obser_Repro { get; set; }
        public string Flg_Reproceso { get; set; }
        public string Flg_Orden { get; set; }   
        public int Id_Proceso { get; set; }        

    }

    public class partidaStatus {
        public string Cliente { get; set; }
        public string Color { get; set; }
        public string Clase { get; set; }
        public string status { get; set; }
        public string StatusCal { get; set; }
        public DateTime FechaCal { get; set; } 
        public int IngrTinto { get; set; }
        public bool Habilitado { get; set; }
    }

    public class RptaPx
    {
        public string Status { get; set; }
        public string Mensaje { get; set; }

    }

}
