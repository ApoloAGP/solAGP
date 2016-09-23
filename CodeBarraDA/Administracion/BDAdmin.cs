using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBarraDA
{
    public class BDAdmin
    {
        #region Usuario
        public bool ValidaUsuario(string login, string password)
        {
            bool result = false;
            string  usuario = "";
            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_ValidaUsuarioReporte";
                    db.AddParameter("@Usuario", SqlDbType.VarChar, ParameterDirection.Input, login);
                    db.AddParameter("@Clave", SqlDbType.VarChar, ParameterDirection.Input, password);

                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        usuario = dr["Usuario"].ToString();

                    }
                    if (usuario != "")
                        result = true;
                    else
                        result = false;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public string  ObtenerUsuario(string IP)
        {
            string usuario = "";
            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_ConsultaUsuarioReporteIP";
                    db.AddParameter("@ip", SqlDbType.VarChar, ParameterDirection.Input, IP);

                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        usuario = dr["Usuario"].ToString();

                    }
                 }
            }
            catch
            {
                throw;
            }
            return usuario;
        }


        public bool ValidaUsuarioSiglas(string login, string password)
        {
            bool result = false;
            string usuario = "";
            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_ValidaUsuarioReporteSiglas";
                    db.AddParameter("@Usuario", SqlDbType.VarChar, ParameterDirection.Input, login);
                    db.AddParameter("@Clave", SqlDbType.VarChar, ParameterDirection.Input, password);

                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        usuario = dr["Usuario"].ToString();

                    }
                    if (usuario != "")
                        result = true;
                    else
                        result = false;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion
    }
}
