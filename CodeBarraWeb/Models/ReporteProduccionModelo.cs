using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBarraWeb.Models
{
        public class ReporteProduccionModelo
        {
            public string Dia { get; set; }
            public string Mes { get; set; }
            public string Yield { get; set; }
            public string Objetivo { get; set; }
            public string Real { get; set; }
            public string Cumplimiento { get; set; }
            public string Area { get; set; }
            public string Modelo { get; set; }
            public string Fecha { get; set; }
            public string VTurObjetivoDes { get; set; }
            public string VTurObjetivoPor { get; set; }
            public string YTurObjetivoDes { get; set; }
            public string YTurObjetivoPor { get; set; }
            public string VTurRealDes { get; set; }
            public string VTurRealPor { get; set; }
            public string YTurRealDes { get; set; }
            public string YTurRealPor { get; set; }
            public string VDiaObjetivoDes { get; set; }
            public string VDiaObjetivoPor { get; set; }
            public string YDiaObjetivoDes { get; set; }
            public string YDiaObjetivoPor { get; set; }
            public string VDiaRealDes { get; set; }
            public string VDiaRealPor { get; set; }
            public string YDiaRealDes { get; set; }
            public string YDiaRealPor { get; set; }
            public string VSemObjetivoDes { get; set; }
            public string VSemObjetivoPor { get; set; }
            public string YSemObjetivoDes { get; set; }
            public string YSemObjetivoPor { get; set; }
            public string VSemRealDes { get; set; }
            public string VSemRealPor { get; set; }
            public string YSemRealDes { get; set; }
            public string YSemRealPor { get; set; }
            public string TurDet { get; set; }
            public string DiaDet { get; set; }
            public string SemDet { get; set; }
            public string ColorCumplimiento { get; set; }
    }


    

    public class UsuarioProcesoModelo
    {
        public string Usuario { get; set; }
        public string RutaImagen { get; set; }
        public string Proceso { get; set; }
        public string Producto { get; set; }
        public string Periodo { get; set; }
    }
}