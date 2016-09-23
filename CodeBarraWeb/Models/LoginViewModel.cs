using CodeBarraBL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBarraWeb.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Minimo 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
    }

    public class ValidaUsuarioVistaModelo
    {
        public bool ValidaUsuario(LoginViewModel cu)
        {
            
             BLAdmin usuario = new BLAdmin();
            return usuario.ValidaUsuario(cu.Usuario , cu.Contraseña);
        }

        public bool ValidaUsuarioSiglas(LoginViewModel cu)
        {

            BLAdmin usuario = new BLAdmin();
            return usuario.ValidaUsuarioSiglas(cu.Usuario, cu.Contraseña);
        }
    }
}