using CodeBarraBE;
using CodeBarraBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBarraWeb.Controllers
{
    public class ReportePenController : Controller
    {
        // GET: ReportePen
        public ActionResult BufferPendiente()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CargarColumna()
        {
            string lnsUsuario = "";
            //lnsUsuario = Session["Usuario"].ToString();

            DataTable dtReporte = new DataTable();
            List<OrdenBE> orden = new List<OrdenBE>();
            orden = new List<OrdenBE> { new OrdenBE { Anio ="2016",Grupo="SL",Item ="001",Linea ="25",Orden= "0509009" },
            new OrdenBE { Anio ="2016",Grupo="SL",Item ="002",Linea ="25",Orden= "0509009" }};
            BLReporte blreporte = new BLReporte();
            dtReporte = blreporte.ConsolidadoPendientesProceso(orden);

            List<ColsModel> lstCols = new List<ColsModel>();


            foreach (DataColumn  col in dtReporte.Columns )
            {
                ColsModel cols = new ColsModel();
                cols.Name = col.ColumnName;
                cols.index = col.ColumnName;
                cols.label = col.ColumnName;
                cols.width = 40;
                cols.align = "left";
                cols.editable = false;
                cols.editType = "text";
                lstCols.Add(cols);
            }
             return Json(lstCols);
        }

        [HttpPost]
        public JsonResult CargarFila()
        {
            string lnsUsuario = "";


            DataTable dtReporte = new DataTable();
            List<OrdenBE> orden = new List<OrdenBE>();
            orden = new List<OrdenBE> { new OrdenBE { Anio ="2016",Grupo="SL",Item ="001",Linea ="25",Orden= "0509009" },
            new OrdenBE { Anio ="2016",Grupo="SL",Item ="002",Linea ="25",Orden= "0509009" }};
            BLReporte blreporte = new BLReporte();
            dtReporte = blreporte.ConsolidadoPendientesProceso(orden);
            List<Array> lstPrueba = new List<Array>();
            string[] prueba1 = new string[dtReporte.Columns.Count];
            int c = 0;
            foreach (DataColumn item in dtReporte.Columns )
            {
                prueba1[c] = item.ColumnName.ToString(); 
                c += 1;
            }
            lstPrueba.Add(prueba1);
            for (int i = 0; i < dtReporte.Rows.Count  ; i++)
            {

                string[] prueba = new string[dtReporte.Columns.Count];
                for (int j = 0; j < dtReporte.Columns.Count  ; j++)
                {
                    prueba[j]=dtReporte.Rows[i][j].ToString();
                }
                lstPrueba.Add(prueba);
            }
            //{ "id": 1,"cell":[ "1","Davolio","Nancy","F","F","F","F"]}
            
            return Json(lstPrueba);
        }
       
    }
}