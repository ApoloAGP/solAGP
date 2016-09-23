using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBarraDA;
using CodeBarraBE;

namespace CodeBarraBL
{
   public class BLGeneral
    {
        BDGeneral bdgeneral = null;

        #region Contructor
        public BLGeneral()
        {
            bdgeneral = new BDGeneral();
        }

        ~BLGeneral()
        {
            Disponse();
        }
        public void Disponse()
        {
            bdgeneral = null;
        }
        #endregion

        public List<BECombo> ArmarCombo(string TipoCombo, int Nivel, int Aplicacion, string GrupoProducto)
        {
            List<BECombo> beLstDetalle = new List<BECombo>();
            try
            {
                beLstDetalle = bdgeneral.ArmarCombo(TipoCombo,Nivel, Aplicacion,GrupoProducto);
            }
            catch
            {

                throw;
            }

            return beLstDetalle;
        }
    }
}
