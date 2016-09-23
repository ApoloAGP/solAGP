using CodeBarraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBarraWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            ValidaUsuarioVistaModelo vu = new ValidaUsuarioVistaModelo();
            if (vu.ValidaUsuario(model))
            {
                Session["Usuario"] = model.Usuario;
                return RedirectToAction("ReportePopup", "Reporte");               
            }
            else
            {
                if (vu.ValidaUsuarioSiglas(model))
                {
                    Session["Usuario"] = model.Usuario;
                    return RedirectToAction("Index", "Reporte");
                }
                else
                    return View("Login");
            }
        }
    }
}