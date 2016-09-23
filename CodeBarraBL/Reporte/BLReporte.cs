using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBarraDA;
using CodeBarraBE;
using System.Data;

namespace CodeBarraBL
{
    public class BLReporte
    {

        BDReporte bdreporte = null;

        #region Contructor
        public BLReporte()
        {
            bdreporte = new BDReporte();
        }

        ~BLReporte()
        {
            Disponse();
        }
        public void Disponse()
        {
            bdreporte = null;
        }
        #endregion

        public BEReporteCompleto ReporteTV(string Linea, string Proceso, string Producto,string ProcesoCabecera)
        {
            BEReporteCompleto bereportecompleto = new BEReporteCompleto();
            List<BEReporteDetalle> beLstDetalle = new List<BEReporteDetalle>();
            try
            {
                BEReporteCabecera beCabecera = new BEReporteCabecera();
                beCabecera = ReporteCabecera(Linea, ProcesoCabecera, Producto);
                beLstDetalle = ReporteDetalle(Linea, Proceso, Producto);
                if (beCabecera!=null)
                {
                    int intCumplimiento = 0;
                    bereportecompleto.Dia = beCabecera.Dia;
                    bereportecompleto.Mes = beCabecera.Semana;
                    bereportecompleto.Yield = beCabecera.Yield;
                    bereportecompleto.Objetivo = beCabecera.MetaAhora;
                    bereportecompleto.Real = beCabecera.RealAhora;
                    bereportecompleto.Cumplimiento = beCabecera.Cumplimiento;
                    intCumplimiento = Convert.ToInt32(beCabecera.Cumplimiento.Replace('%', ' ').Trim());
                    if (intCumplimiento <= 80) bereportecompleto.ColorCumplimiento = "col-md-2 bg-red";
                    if (intCumplimiento >= 81 && intCumplimiento <= 95) bereportecompleto.ColorCumplimiento = "col-md-2 bg-yellow";
                    if (intCumplimiento >= 96) bereportecompleto.ColorCumplimiento = "col-md-2 bg-green";
                }

                if (beLstDetalle!=null)
                {
                    foreach (var beDetalle in beLstDetalle)
                    {
                        switch (beDetalle.Orden)
                        {
                            case "1":
                                bereportecompleto.VTurObjetivoPor = beDetalle.MetaVelocidad;
                                bereportecompleto.VTurObjetivoDes = "Obj.(" + beDetalle.MetaVelocidad + ")";
                                bereportecompleto.VTurRealPor = beDetalle.RealVelocidad;
                                bereportecompleto.VTurRealDes = "Real (" + beDetalle.RealVelocidad + ")";
                                bereportecompleto.YTurObjetivoPor = beDetalle.MetaEficiencia;
                                bereportecompleto.YTurObjetivoDes= "Obj.(" + beDetalle.MetaEficiencia + ")";
                                bereportecompleto.YTurRealPor = beDetalle.RealEficiencia;
                                bereportecompleto.YTurRealDes = "Real (" + beDetalle.RealEficiencia + ")";
                                if (bereportecompleto.VTurObjetivoPor == "0" ) bereportecompleto.VTurObjetivoPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VTurObjetivoPor) > 100) bereportecompleto.VTurObjetivoPor = "100";
                                if (bereportecompleto.VTurRealPor == "0") bereportecompleto.VTurRealPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VTurRealPor) > 100) bereportecompleto.VTurRealPor = "100";
                                if (bereportecompleto.YTurObjetivoPor == "0%") bereportecompleto.YTurObjetivoPor = "30%";
                                if(bereportecompleto.YTurRealPor == "0%") bereportecompleto.YTurRealPor = "30%";
                                bereportecompleto.TurnoDet ="T"+ beDetalle.Turno;
                                break;
                            case "2":
                                bereportecompleto.VDiaObjetivoPor = beDetalle.MetaVelocidad;
                                bereportecompleto.VDiaObjetivoDes = "Obj.(" + beDetalle.MetaVelocidad + ")";
                                bereportecompleto.VDiaRealPor = beDetalle.RealVelocidad;
                                bereportecompleto.VDiaRealDes = "Real (" + beDetalle.RealVelocidad + ")";
                                bereportecompleto.YDiaObjetivoPor = beDetalle.MetaEficiencia;
                                bereportecompleto.YDiaObjetivoDes = "Obj.(" + beDetalle.MetaEficiencia + ")";
                                bereportecompleto.YDiaRealPor = beDetalle.RealEficiencia;
                                bereportecompleto.YDiaRealDes = "Real (" + beDetalle.RealEficiencia + ")";
                                if (bereportecompleto.VDiaObjetivoPor == "0") bereportecompleto.VDiaObjetivoPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VDiaObjetivoPor) > 100) bereportecompleto.VDiaObjetivoPor = "100";
                                if (bereportecompleto.VDiaRealPor == "0") bereportecompleto.VDiaRealPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VDiaRealPor) > 100) bereportecompleto.VDiaRealPor = "100";
                                if (bereportecompleto.YDiaObjetivoPor == "0%") bereportecompleto.YDiaObjetivoPor = "30%";
                                if (bereportecompleto.YDiaRealPor == "0%") bereportecompleto.YDiaRealPor = "30%";
                                bereportecompleto.DiaDet = "D" + beDetalle.Dia;
                                break;
                            case "3":
                                bereportecompleto.VSemObjetivoPor = beDetalle.MetaVelocidad;
                                bereportecompleto.VSemObjetivoDes = "Obj.(" + beDetalle.MetaVelocidad + ")";
                                bereportecompleto.VSemRealPor = beDetalle.RealVelocidad;
                                bereportecompleto.VSemRealDes = "Real (" + beDetalle.RealVelocidad + ")";
                                bereportecompleto.YSemObjetivoPor = beDetalle.MetaEficiencia;
                                bereportecompleto.YSemObjetivoDes = "Obj.(" + beDetalle.MetaEficiencia + ")";
                                bereportecompleto.YSemRealPor = beDetalle.RealEficiencia;
                                bereportecompleto.YSemRealDes = "Real (" + beDetalle.RealEficiencia + ")";
                                if (bereportecompleto.VSemObjetivoPor == "0" ) bereportecompleto.VSemObjetivoPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VSemObjetivoPor) > 100) bereportecompleto.VSemObjetivoPor = "100";
                                if (bereportecompleto.VSemRealPor == "0") bereportecompleto.VSemRealPor = "30";
                                if (Convert.ToInt32(bereportecompleto.VSemRealPor) > 100) bereportecompleto.VSemRealPor = "100";
                                if (bereportecompleto.YSemObjetivoPor == "0%") bereportecompleto.YSemObjetivoPor = "30%";
                                if (bereportecompleto.YSemRealPor == "0%") bereportecompleto.YSemRealPor = "30%";
                                bereportecompleto.SemDet = "S" + beDetalle.Semana;
                                break;
                        }
                        bereportecompleto.Area = beDetalle.Proceso.Trim();
                        bereportecompleto.Modelo = beDetalle.Desprod.Trim();

                    }
                }

            }
            catch 
            {

                throw;
            }
            return bereportecompleto;
        }

        private BEReporteCabecera ReporteCabecera(string Linea, string Proceso, string Producto)
        {
            BEReporteCabecera beCabecera = new BEReporteCabecera();
            try
            {
                beCabecera = bdreporte.ReporteCabecera(Linea, Proceso, Producto);
            }
            catch
            {

                throw;
            }

            return beCabecera;
        }

        public List<BEReporteDetalle> ReporteDetalle(string Linea, string Proceso, string Producto)
        {
            List<BEReporteDetalle> beLstDetalle = new List<BEReporteDetalle>();
            try
            {
                beLstDetalle = bdreporte.ReporteDetalle(Linea, Proceso, Producto);
            }
            catch
            {

                throw;
            }

            return beLstDetalle;
        }

        public List<BEUsuarioProceso> ListaUsuarioProceso(string usuario)
        {
            List<BEUsuarioProceso> beLstDetalle = new List<BEUsuarioProceso>();
            try
            {
                beLstDetalle = bdreporte.ListaUsuarioProceso(usuario);
            }
            catch
            {

                throw;
            }

            return beLstDetalle;
        }

        public string RutaImagen(string usuario)
        {
            string imagen = "";
            imagen = bdreporte.RutaImagen(usuario);
            return imagen;
        }


        public string ActualizarImagenProceso(string Proceso, string Imagen)
        {

            string strRespuesta = "";
            try
            {
                strRespuesta = bdreporte.ActualizarImagenProceso(Proceso,Imagen);
            }
            catch
            {

                throw;
            }

            return strRespuesta;
        }

        public string ActualizarTiempoProceso(string Proceso, int tiempo)
        {

            string strRespuesta = "";
            try
            {
                strRespuesta = bdreporte.ActualizarTiempoProceso(Proceso, tiempo);
            }
            catch
            {

                throw;
            }

            return strRespuesta;
        }

        public string AgregarImagenProceso(BEReporteProcesoImagen beprocesoimagen)
        {

            string strRespuesta = "";
            try
            {
                if (beprocesoimagen.CodProceso=="99")
                {
                    List<BEUsuarioProceso> proceso = new List<BEUsuarioProceso>();
                    proceso = ListaUsuarioProceso("");
                    foreach (var item in proceso)
                    {
                        beprocesoimagen.CodProceso = item.CodProceso;
                        strRespuesta = bdreporte.AgregarImagenProceso(beprocesoimagen);
                    }

                }
                else
                    strRespuesta = bdreporte.AgregarImagenProceso(beprocesoimagen);
            }
            catch
            {

                throw;
            }

            return strRespuesta;
        }

        public string ModificarImagenProceso(BEReporteProcesoImagen beprocesoimagen)
        {

            string strRespuesta = "";
            try
            {
                strRespuesta = bdreporte.ModificarImagenProceso(beprocesoimagen);
            }
            catch
            {

                throw;
            }

            return strRespuesta;
        }

        public List<BEReporteProcesoImagen> ListaReporteProcesoImagen(string CodProceso)
        {
            List<BEReporteProcesoImagen> beLstDetalle = new List<BEReporteProcesoImagen>();
            try
            {
                beLstDetalle = bdreporte.ListaReporteProcesoImagen(CodProceso);
            }
            catch
            {

                throw;
            }

            return beLstDetalle;
        }

        public DataTable ConsolidadoPendientesProceso(List<OrdenBE> lstOrden)
        {

            DataTable dtProceso = new DataTable();

            //Dim keys(0) As DataColumn
            //Dim keyColumn As New DataColumn()
            //keyColumn.ColumnName = "CodProceso"
            //keys(0) = keyColumn
            //dtProceso.Columns.Add(keyColumn)

            dtProceso.Columns.Add("CodProceso", Type.GetType("System.String"));
            dtProceso.Columns.Add("Proceso", Type.GetType("System.String"));
            //dtProceso.PrimaryKey = keys
            dtProceso.Rows.Add("01", "CORTE");
            dtProceso.Rows.Add("05", "PULIDO");
            dtProceso.Rows.Add("03", "SERIGRAFIA");
            dtProceso.Rows.Add("04", "VITRIFICADO");
            dtProceso.Rows.Add("47", "TEMPLADO GRAVEDAD");
            dtProceso.Rows.Add("06", "FILTRO SL");
            dtProceso.Rows.Add("06", "FILTRO S1");
            dtProceso.Rows.Add("37", "LAVADO");
            dtProceso.Rows.Add("08", "PRD-ENSAMBLE");
            dtProceso.Rows.Add("23", "EMBOLSADO");
            dtProceso.Rows.Add("10", "AUTOCLAVE");
            dtProceso.Rows.Add("11", "ACABADO");
            dtProceso.Rows.Add("16", "INSPECCION");
            dtProceso.Rows.Add("43", "EMBALAJE");

            //Dim s As String = ""
            //s = dtProceso.Rows.Find("11")("CodProceso")

            foreach (OrdenBE item in lstOrden)
            {
                List<OrdenProceso> lstProceso = new List<OrdenProceso>();
                string lnsNombreColumna = "";
                int intCantidad = 0;
                string lnsProcesoAnterior = "";
                string lnsActividadAnterior = "";
                lstProceso = bdreporte.ListaProcesoOrden(item);
                lnsNombreColumna = item.Orden + "-" + item.Item;
                dtProceso.Columns.Add(lnsNombreColumna, Type.GetType("System.Int32"));

                for (int iRow = 0; iRow < dtProceso.Rows.Count; iRow++)
                {
                    dtProceso.Rows[iRow][lnsNombreColumna] = 0;
                }
                lnsProcesoAnterior = "XX";
                lnsActividadAnterior = "";
                foreach (OrdenProceso Proceso in lstProceso)
                {
                    intCantidad = 0;
                    intCantidad = bdreporte.CantidadPendienteOrden(item, Proceso, lnsProcesoAnterior, lnsActividadAnterior);
                    for (int iRow = 0; iRow < dtProceso.Rows.Count; iRow++)
                    {
                        if (dtProceso.Rows[iRow]["CodProceso"].ToString() == Proceso.CodProceso)
                        {

                            if (dtProceso.Rows[iRow]["CodProceso"].ToString() == "06")
                            {
                                if (dtProceso.Rows[iRow]["Proceso"].ToString().Right(2) == item.Grupo)
                                {
                                    dtProceso.Rows[iRow][lnsNombreColumna] = intCantidad;
                                }
                            }
                            else
                            {
                                dtProceso.Rows[iRow][lnsNombreColumna] = intCantidad;
                            }
                        }
                    }
                    lnsProcesoAnterior = Proceso.CodProceso;
                    lnsActividadAnterior = Proceso.Actividad;
                }
            }
            dtProceso.Columns.Add("IZQUIERDO", Type.GetType("System.Int32"));
            dtProceso.Columns.Add("DERECHO", Type.GetType("System.Int32"));
            dtProceso.Columns.Add("TOTAL", Type.GetType("System.Int32"));


            int lniIzquierdo = 0;
            int lniDerecho = 0;

            for (int iRow = 0; iRow < dtProceso.Rows.Count; iRow++)
            {
                lniIzquierdo = 0;
                lniDerecho = 0;
                foreach (DataColumn col in dtProceso.Columns)
                {
                    if (col.ColumnName.Right(3) == "002")
                    {
                        lniDerecho +=Convert.ToInt32(dtProceso.Rows[iRow][col]);
                    }
                    if (col.ColumnName.Right(3) == "001")
                    {
                        lniIzquierdo += Convert.ToInt32(dtProceso.Rows[iRow][col]);
                    }
                }
                dtProceso.Rows[iRow]["IZQUIERDO"] = lniIzquierdo;
                dtProceso.Rows[iRow]["DERECHO"] = lniDerecho;
                dtProceso.Rows[iRow]["TOTAL"] = lniDerecho + lniIzquierdo;
            }
            //GraficoBarras
            //ExportarExcelBL blexportar = new ExportarExcelBL();
            //blexportar.GraficoBarras(dtProceso);
            return dtProceso;
        }
    }
}
