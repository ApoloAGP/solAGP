using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBarraBE;
using System.Data;

namespace CodeBarraDA
{
    public class BDGeneral
    {
        public List<BECombo> ArmarCombo(string TipoCombo, int Nivel, int Aplicacion,string GrupoProducto)
        {
            List<BECombo> beLstDetalle = new List<BECombo>();

            beLstDetalle.Add(GenSeleccione());

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_Ver_CombosMenuProductosPlanta";
                    db.AddParameter("@TipoCombo", SqlDbType.VarChar, ParameterDirection.Input, TipoCombo);
                    db.AddParameter("@Nivel", SqlDbType.Int, ParameterDirection.Input, Nivel);
                    db.AddParameter("@Aplicacion", SqlDbType.Int, ParameterDirection.Input, Aplicacion);
                    db.AddParameter("@GrupoProducto", SqlDbType.VarChar, ParameterDirection.Input, GrupoProducto);

                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        BECombo beDetalle = new BECombo();
                        beDetalle.Codigo = dr["Codigo"].ToString();
                        beDetalle.Descripcion = dr["Descripcion"].ToString();
                        beLstDetalle.Add(beDetalle);
                        beDetalle = null;
                    }
                }
            }
            catch
            {
                throw;
            }
            beLstDetalle.Add(GenTodos());
            return beLstDetalle;
        }

        private BECombo GenSeleccione()
        {
            BECombo combo = new BECombo();
            combo.Codigo = "00";
            combo.Descripcion = "-- Seleccionar --";
            return combo;
        }

        private BECombo GenTodos()
        {
            BECombo combo = new BECombo();
            combo.Codigo = "99";
            combo.Descripcion = "-- TODOS --";
            return combo;
        }
    }
}
