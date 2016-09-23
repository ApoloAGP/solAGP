using CodeBarraBL.Securidad;
using CodeBarraDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBarraBL
{
    public class BLAdmin
    {
        BDAdmin bdadmin = null;

        #region Contructor
        public BLAdmin()
        {
            bdadmin = new BDAdmin();
        }

        ~BLAdmin()
        {
            Disponse();
        }
        public void Disponse()
        {
            bdadmin = null;
        }
        #endregion

        #region Usuario
        public bool ValidaUsuario(string login, string password)
        {

           return bdadmin.ValidaUsuario(login, password);
        }

        public string ObtenerUsuario(string IP)
        {

            return bdadmin.ObtenerUsuario(IP);
        }

        public bool ValidaUsuarioSiglas(string login, string password)
        {

            return bdadmin.ValidaUsuarioSiglas(login, password);
        }

        #endregion
    }
}
