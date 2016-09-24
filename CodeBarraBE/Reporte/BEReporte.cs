using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBarraBE
{
    public class BEReporteCompleto
    {
        #region Variables

        private string _Dia;
        private string _Mes;
        private string _Yield;
        private string _Objetivo;
        private string _Real;
        private string _Cumplimiento;
        private string _Area;
        private string _Modelo;
        private string _Fecha;
        private string _VTurObjetivoDes;
        private string _VTurObjetivoPor;
        private string _YTurObjetivoDes;
        private string _YTurObjetivoPor;
        private string _VTurRealDes;
        private string _VTurRealPor;
        private string _VTurRealColor;
        private string _YTurRealDes;
        private string _YTurRealPor;
        private string _YTurRealColor;
        private string _VDiaObjetivoDes;
        private string _VDiaObjetivoPor;
        private string _YDiaObjetivoDes;
        private string _YDiaObjetivoPor;
        private string _VDiaRealDes;
        private string _VDiaRealPor;
        private string _VDiaRealColor;
        private string _YDiaRealDes;
        private string _YDiaRealPor;
        private string _YDiaRealColor;
        private string _VSemObjetivoDes;
        private string _VSemObjetivoPor;
        private string _YSemObjetivoDes;
        private string _YSemObjetivoPor;
        private string _VSemRealDes;
        private string _VSemRealPor;
        private string _VSemRealColor;
        private string _YSemRealDes;
        private string _YSemRealPor;
        private string _YSemRealColor;
        private string _Turdet;
        private string _DiaDet;
        private string _SemDet;
        private string _ColorCumplimiento;

        #endregion

        #region Propiedades



        public string Dia
        {
            get {return _Dia; }
            set { _Dia=value; }
        }

        public string Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }

        public string Yield
        {
            get { return _Yield; }
            set { _Yield = value; }
        }

        public string Objetivo
        {
            get { return _Objetivo ; }
            set { _Objetivo = value; }
        }
        public string Real
        {
            get { return _Real; }
            set { _Real = value; }
        }
        public string Cumplimiento
        {
            get { return _Cumplimiento; }
            set { _Cumplimiento = value; }
        }
        
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string VTurObjetivoDes
        {
            get { return _VTurObjetivoDes; }
            set { _VTurObjetivoDes = value; }
        }

        public string VTurObjetivoPor
        {
            get { return _VTurObjetivoPor; }
            set { _VTurObjetivoPor = value; }
        }

        public string YTurObjetivoDes
        {
            get { return _YTurObjetivoDes; }
            set { _YTurObjetivoDes = value; }
        }

        public string YTurObjetivoPor
        {
            get { return _YTurObjetivoPor; }
            set { _YTurObjetivoPor = value; }
        }

        public string VTurRealDes
        {
            get { return _VTurRealDes; }
            set { _VTurRealDes = value; }
        }

        public string VTurRealPor
        {
            get { return _VTurRealPor; }
            set { _VTurRealPor = value; }
        }
        public string VTurRealColor
        {
            get { return _VTurRealColor; }
            set { _VTurRealColor = value; }
        }

        public string YTurRealDes
        {
            get { return _YTurRealDes; }
            set { _YTurRealDes = value; }
        }

        public string YTurRealPor
        {
            get { return _YTurRealPor; }
            set { _YTurRealPor = value; }
        }

        public string YTurRealColor
        {
            get { return _YTurRealColor; }
            set { _YTurRealColor = value; }
        }

        public string VDiaObjetivoDes
        {
            get { return _VDiaObjetivoDes; }
            set { _VDiaObjetivoDes = value; }
        }

        public string VDiaObjetivoPor
        {
            get { return _VDiaObjetivoPor; }
            set { _VDiaObjetivoPor = value; }
        }

        public string YDiaObjetivoDes
        {
            get { return _YDiaObjetivoDes; }
            set { _YDiaObjetivoDes = value; }
        }

        public string YDiaObjetivoPor
        {
            get { return _YDiaObjetivoPor; }
            set { _YDiaObjetivoPor = value; }
        }

        public string VDiaRealDes
        {
            get { return _VDiaRealDes; }
            set { _VDiaRealDes = value; }
        }

        public string VDiaRealPor
        {
            get { return _VDiaRealPor; }
            set { _VDiaRealPor = value; }
        }

        public string VDiaRealColor
        {
            get { return _VDiaRealColor; }
            set { _VDiaRealColor = value; }
        }

        public string YDiaRealDes
        {
            get { return _YDiaRealDes; }
            set { _YDiaRealDes = value; }
        }

        public string YDiaRealPor
        {
            get { return _YDiaRealPor; }
            set { _YDiaRealPor = value; }
        }

        public string YDiaRealColor
        {
            get { return _YDiaRealColor; }
            set { _YDiaRealColor = value; }
        }

        public string VSemObjetivoDes
        {
            get { return _VSemObjetivoDes; }
            set { _VSemObjetivoDes = value; }
        }

        public string VSemObjetivoPor
        {
            get { return _VSemObjetivoPor; }
            set { _VSemObjetivoPor = value; }
        }

        public string YSemObjetivoDes
        {
            get { return _YSemObjetivoDes; }
            set { _YSemObjetivoDes = value; }
        }

        public string YSemObjetivoPor
        {
            get { return _YSemObjetivoPor; }
            set { _YSemObjetivoPor = value; }
        }

        public string VSemRealDes
        {
            get { return _VSemRealDes; }
            set { _VSemRealDes = value; }
        }

        public string VSemRealPor
        {
            get { return _VSemRealPor; }
            set { _VSemRealPor = value; }
        }

        public string VSemRealColor
        {
            get { return _VSemRealColor; }
            set { _VSemRealColor = value; }
        }

        public string YSemRealDes
        {
            get { return _YSemRealDes; }
            set { _YSemRealDes = value; }
        }

        public string YSemRealPor
        {
            get { return _YSemRealPor; }
            set { _YSemRealPor = value; }
        }

        public string YSemRealColor
        {
            get { return _YSemRealColor; }
            set { _YSemRealColor = value; }
        }

        public string TurnoDet
        {
            get { return _Turdet; }
            set { _Turdet = value; }
        }

        public string DiaDet
        {
            get { return _DiaDet; }
            set { _DiaDet = value; }
        }

        public string SemDet
        {
            get { return _SemDet; }
            set { _SemDet = value; }
        }

        public string ColorCumplimiento
        {
            get { return _ColorCumplimiento; }
            set { _ColorCumplimiento = value; }
        }
        #endregion

    }

    public class BEReporteCabecera
    {
        #region Variables

        private string _Proceso;
        private string _Dia;
        private string _Semana;
        private string _Yield;
        private string _MetaAhora;
        private string _RealAhora;
        private string _Cumplimiento;

        #endregion

        #region Propiedades

        public string Proceso
        {
            get { return _Proceso; }
            set { _Proceso = value; }
        }

        public string Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }

        public string Semana
        {
            get { return _Semana; }
            set { _Semana = value; }
        }

        public string Yield
        {
            get { return _Yield; }
            set { _Yield = value; }
        }

        public string MetaAhora
        {
            get { return _MetaAhora; }
            set { _MetaAhora = value; }
        }

        public string RealAhora
        {
            get { return _RealAhora; }
            set { _RealAhora = value; }
        }

        public string Cumplimiento
        {
            get { return _Cumplimiento; }
            set { _Cumplimiento = value; }
        }

        #endregion
    }

    public class BEReporteDetalle
    {
        #region Variables

        private string _Orden;
        private string _Linea;
        private string _Proceso;
        private string _Producto;
        private string _Periodo;
        private string _MetaVelocidad;
        private string _RealVelocidad;
        private string _DifVelocidad;
        private string _MetaEficiencia;
        private string _RealEficiencia;
        private string _MetaDisponibilidad;
        private string _RealDisponibilidad;
        private string _MetaOEEE;
        private string _RealOEEE;
        private string _Desprod;
        private string _Turno;
        private string _Dia;
        private string _Semana;

        #endregion

        #region Propiedades

        public string Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        public string Linea
        {
            get { return _Linea; }
            set { _Linea = value; }
        }

        public string Proceso
        {
            get { return _Proceso; }
            set { _Proceso = value; }
        }

        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public string Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }

        public string MetaVelocidad
        {
            get { return _MetaVelocidad; }
            set { _MetaVelocidad = value; }
        }

        public string RealVelocidad
        {
            get { return _RealVelocidad; }
            set { _RealVelocidad = value; }
        }

        public string DifVelocidad
        {
            get { return _DifVelocidad; }
            set { _DifVelocidad = value; }
        }

        public string MetaEficiencia
        {
            get { return _MetaEficiencia; }
            set { _MetaEficiencia = value; }
        }

        public string RealEficiencia
        {
            get { return _RealEficiencia; }
            set { _RealEficiencia = value; }
        }

        public string MetaDisponibilidad
        {
            get { return _MetaDisponibilidad; }
            set { _MetaDisponibilidad = value; }
        }

        public string RealDisponibilidad
        {
            get { return _RealDisponibilidad; }
            set { _RealDisponibilidad = value; }
        }

        public string MetaOEEE
        {
            get { return _MetaOEEE; }
            set { _MetaOEEE = value; }
        }

        public string RealOEEE
        {
            get { return _RealOEEE; }
            set { _RealOEEE = value; }
        }

        public string Desprod
        {
            get { return _Desprod; }
            set { _Desprod = value; }
        }

        public string Turno
        {
            get { return _Turno; }
            set { _Turno = value; }
        }

        public string Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }

        public string Semana
        {
            get { return _Semana; }
            set { _Semana = value; }
        }
        #endregion
    }


    public class BEUsuarioProceso
    {
        #region Variables

        private string _Usuario;
        private string _RutaImagen;
        private string _Proceso;
        private string _Producto;
        private string _Periodo;
        private string _CodProceso;

        #endregion

        #region Propiedades

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string RutaImagen
        {
            get { return _RutaImagen; }
            set { _RutaImagen = value; }
        }

        public string Proceso
        {
            get { return _Proceso; }
            set { _Proceso = value; }
        }

        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public string Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }

        public string CodProceso
        {
            get { return _CodProceso; }
            set { _CodProceso = value; }
        }

        #endregion

    }

    public class BEReporteProcesoImagen
    {
        #region Variables

        private int _Codigo;
        private string _Codproceso;
        private string _proceso;
        private string _Ruta;
        private int _Tiempo;
        private int _Orden;
        private string _Tipo;
        private string _TipoDes;
        private string _AudEstado;
        private string _Usuario;
        private string _Terminal;

        #endregion

        #region Propiedades

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string CodProceso
        {
            get { return _Codproceso; }
            set { _Codproceso = value; }
        }

        public string Proceso
        {
            get { return _proceso; }
            set { _proceso = value; }
        }

        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }

        public int Tiempo
        {
            get { return _Tiempo; }
            set { _Tiempo = value; }
        }

        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public string TipoDes
        {
            get { return _TipoDes; }
            set { _TipoDes = value; }
        }

        public string AudEstado
        {
            get { return _AudEstado; }
            set { _AudEstado = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }

        #endregion
    }

    public class OrdenBE
    {

        private int _id;
        private string _orden;
        private string _item;
        private string _grupo;
        private string _linea;
        private string _anio;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Orden
        {
            get
            {
                return _orden;
            }
            set
            {
                _orden = value;
            }
        }

        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }

        public string Grupo
        {
            get
            {
                return _grupo;
            }
            set
            {
                _grupo = value;
            }
        }
        public string Linea
        {
            get
            {
                return _linea;
            }
            set
            {
                _linea = value;
            }
        }
        public string Anio
        {
            get
            {
                return _anio;
            }
            set
            {
                _anio = value;
            }
        }
    }

    public class OrdenProceso
    {

        private string _CodProceso;
        private string _Proceso;
        private string _Actividad;
        private string _Orden;
        private string _RegistroVidrio;
        private string _ProcAnterior;
        private string _ActAnterior;

        public string CodProceso
        {
            get
            {
                return _CodProceso;
            }
            set
            {
                _CodProceso = value;
            }
        }

        public string Proceso
        {
            get
            {
                return _Proceso;
            }
            set
            {
                _Proceso = value;
            }
        }

        public string Actividad
        {
            get
            {
                return _Actividad;
            }
            set
            {
                _Actividad = value;
            }
        }

        public string Orden
        {
            get
            {
                return _Orden;
            }
            set
            {
                _Orden = value;
            }
        }

        public string RegistroVidrio
        {
            get
            {
                return _RegistroVidrio;
            }
            set
            {
                _RegistroVidrio = value;
            }
        }

        public string ProcAnterior
        {
            get
            {
                return _ProcAnterior;
            }
            set
            {
                _ProcAnterior = value;
            }
        }

        public string ActAnterior
        {
            get
            {
                return _ActAnterior;
            }
            set
            {
                _ActAnterior = value;
            }
        }

    }

}
