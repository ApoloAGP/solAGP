using CodeBarraBE;
using CodeBarraBL;
using CodeBarraWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace CodeBarraWeb.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ReportePopup()
        {


            if (Session["Usuario"] == null)
            {
                string macAddresses = "", lnsUsuario = "";
                BLAdmin admin = new BLAdmin();
                macAddresses = System.Web.HttpContext.Current.Request.UserHostAddress;

                lnsUsuario = admin.ObtenerUsuario(macAddresses);

                if (lnsUsuario!="")
                {
                    Session["Usuario"] = lnsUsuario;
                    ReporteProduccionModelo rp = new ReporteProduccionModelo();
                    return View(rp);
                }
                else
                    return RedirectToAction("Login", "Login");
            }
            else
            {
                ReporteProduccionModelo rp = new ReporteProduccionModelo();
                return View(rp);
            }
        }

        public ActionResult ReporteTV()
        {

            if (Session["Usuario"] == null)
            {
                string macAddresses = "", lnsUsuario = "";
                BLAdmin admin = new BLAdmin();
                macAddresses = System.Web.HttpContext.Current.Request.UserHostAddress;

                lnsUsuario = admin.ObtenerUsuario(macAddresses);

                if (lnsUsuario != "")
                {
                    Session["Usuario"] = lnsUsuario;
                    ReporteProduccionModelo rp = new ReporteProduccionModelo();
                    return View(rp);
                }
                else
                    return RedirectToAction("Login", "Login");
            }
            else
            {
                ReporteProduccionModelo rp = new ReporteProduccionModelo();
                return View(rp);
            }
        }

        public ActionResult ReportePopupParcial(string Proceso, string Producto)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                BLReporte blreporte = new BLReporte();
                BEReporteCompleto beReporte = new BEReporteCompleto();

                beReporte = blreporte.ReporteTV("25", Proceso, Producto, "16");


                return new JsonResult()
                {
                    Data = new ReporteProduccionModelo()
                    {
                        Dia = beReporte.Dia,
                        Mes = beReporte.Mes,
                        Yield = beReporte.Yield,
                        Real = beReporte.Real,
                        Objetivo = beReporte.Objetivo,
                        Cumplimiento = beReporte.Cumplimiento,
                        ColorCumplimiento = beReporte.ColorCumplimiento,
                        Area = beReporte.Area,
                        Modelo = beReporte.Modelo,
                        Fecha = DateTime.Now.ToString(),
                        SemDet = beReporte.SemDet,
                        DiaDet = beReporte.DiaDet,
                        TurDet = beReporte.TurnoDet,
                        // Volumen
                        VTurObjetivoDes = beReporte.VTurObjetivoDes,
                        VTurObjetivoPor = beReporte.VTurObjetivoPor,
                        VTurRealDes = beReporte.VTurRealDes,
                        VTurRealPor = beReporte.VTurRealPor,

                        VDiaObjetivoDes = beReporte.VDiaObjetivoDes,
                        VDiaObjetivoPor = beReporte.VDiaObjetivoPor,
                        VDiaRealDes = beReporte.VDiaRealDes,
                        VDiaRealPor = beReporte.VDiaRealPor,

                        VSemObjetivoDes = beReporte.VSemObjetivoDes,
                        VSemObjetivoPor = beReporte.VSemObjetivoPor,
                        VSemRealDes = beReporte.VSemRealDes,
                        VSemRealPor = beReporte.VSemRealPor,

                        // Yield

                        YTurObjetivoDes = beReporte.YTurObjetivoDes,
                        YTurObjetivoPor = beReporte.YTurObjetivoPor,
                        YTurRealDes = beReporte.YTurRealDes,
                        YTurRealPor = beReporte.YTurRealPor,

                        YDiaObjetivoDes = beReporte.YDiaObjetivoDes,
                        YDiaObjetivoPor = beReporte.YDiaObjetivoPor,
                        YDiaRealDes = beReporte.YDiaRealDes,
                        YDiaRealPor = beReporte.YDiaRealPor,

                        YSemObjetivoDes = beReporte.YSemObjetivoDes,
                        YSemObjetivoPor = beReporte.YSemObjetivoPor,
                        YSemRealDes = beReporte.YSemRealDes,
                        YSemRealPor = beReporte.YSemRealPor,

                    }
                };
            }
        }


        public JsonResult MostrarProceso(string sidx, string sord, int page, int rows)  //Gets the todo Lists.
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            BLReporte blreporte = new BLReporte();
            string lnsUsuario = "";
            //lnsUsuario = Session["Usuario"].ToString().Trim();

            var todoListsResults = blreporte.ListaUsuarioProceso(lnsUsuario).Select(
                    a => new
                    {
                        a.CodProceso,
                        a.Usuario,
                        a.RutaImagen,
                        a.Proceso,
                        a.Producto,
                        a.Periodo
                    });
            int totalRecords = todoListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                todoListsResults = todoListsResults.OrderByDescending(s => s.Usuario);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                todoListsResults = todoListsResults.OrderBy(s => s.Usuario);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = todoListsResults
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ArmarCombo(string Proceso, string Producto)
        {

            List<BECombo> Combo = new List<BECombo>();
            BLGeneral blgeneral = new BLGeneral();

            Combo = blgeneral.ArmarCombo("PRC", 0, 0, "PRC");

            return Json(Combo);
        }

        [HttpPost]
        public JsonResult AgregarModicarImagen(BEReporteProcesoImagen bereporteimagen)  //Gets the todo Lists.
        {
            string strRespuesta = "";
            try
            {
                BLReporte blreporte = new BLReporte();
                bereporteimagen.Usuario = Session["Usuario"].ToString().Trim();
                if (bereporteimagen.Codigo != 0)
                    strRespuesta = blreporte.ModificarImagenProceso(bereporteimagen);
                else
                    strRespuesta = blreporte.AgregarImagenProceso(bereporteimagen);
            }
            catch (Exception ex)
            {

                strRespuesta = "Fallo: " + ex.Message;
            }
            return Json(strRespuesta);
        }


        [HttpPost]
        public ActionResult Upload()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    string lnsRespuesta = "";
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        lnsRespuesta = fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Imagenes/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json(lnsRespuesta);
                }
                catch (Exception ex)
                {
                    return Json("Error detallado: " + ex.Message);
                }
            }
            else
            {
                return Json("No hay archivos seleccionados.");
            }
        }


        public JsonResult MostrarProcesoImagen(string sidx, string sord, int page, int rows)  //Gets the todo Lists.
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            BLReporte blreporte = new BLReporte();
            string lnsUsuario = "asas";
            //lnsUsuario = Session["Usuario"].ToString().Trim();

            var todoListsResults = blreporte.ListaReporteProcesoImagen(" ").Select(
                    a => new
                    {
                        a.Codigo,
                        a.Proceso,
                        a.Ruta,
                        a.Tiempo,
                        a.TipoDes,
                        a.Tipo,
                        a.Orden,
                        a.CodProceso
                    });
            int totalRecords = todoListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                todoListsResults = todoListsResults.OrderByDescending(s => s.Codigo);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                todoListsResults = todoListsResults.OrderBy(s => s.Codigo);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = todoListsResults
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MostrarProcesoImagen1(string CodProceso)  //Gets the todo Lists.
        {
            BLReporte blreporte = new BLReporte();
            List<BEReporteProcesoImagen> proceso = new List<BEReporteProcesoImagen>();
            proceso = blreporte.ListaReporteProcesoImagen(CodProceso);
            return Json(proceso);
        }

        // Carga la lista de Procesos que se mostrara en la pantalla
        public JsonResult CargarProceso()
        {
            string lnsUsuario = "";
            lnsUsuario = Session["Usuario"].ToString();

            List<BEUsuarioProceso> Proceso = new List<BEUsuarioProceso>();
            BLReporte blreporte = new BLReporte();
            Proceso = blreporte.ListaUsuarioProceso(lnsUsuario);
            if (Proceso.Count == 0)
                Proceso = blreporte.ListaUsuarioProceso("");

            return Json(Proceso);
        }

        // Mues la Lista de Imagenes que mostrara de acuerdo al proceso
        public JsonResult CargarImagenProceso(string Proceso)
        {
            List<BEReporteProcesoImagen> imagen = new List<BEReporteProcesoImagen>();
            BLReporte blreporte = new BLReporte();
            imagen = blreporte.ListaReporteProcesoImagen(Proceso);
            return Json(imagen);
        }

        [HttpGet]
        public ActionResult MuestraImagen(string file)
        {
            var path = Server.MapPath("~/Imagenes");
            var fullPath = Path.Combine(path, file);
            return File(fullPath, "Imagenes/png", file);
        }

        // Actualiza Tiempo Proceso
        [HttpPost]
        public JsonResult ActualizarTiempoProceso(string Proceso, int Tiempo)  //Gets the todo Lists.
        {
            string strRespuesta = "";
            try
            {
                BLReporte blreporte = new BLReporte();
                strRespuesta = blreporte.ActualizarTiempoProceso(Proceso, Tiempo);

            }
            catch (Exception ex)
            {

                strRespuesta = "Fallo: " + ex.Message;
            }
            return Json(strRespuesta);
        }

        public JsonResult GetMAC1()
        {
            string macAddresses = "";
            macAddresses = Request.UserHostAddress;
            // macAddresses = System.Net.Dns.GetHostEntry(Request.UserHostAddress).ToString();
            //macAddresses = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;

            return Json(macAddresses);
        }

        public JsonResult GetMAC()
        {
            string macAddresses = "";

            macAddresses = System.Web.HttpContext.Current.Request.UserHostAddress; 
            return Json(macAddresses);
        }

        

    }
    }