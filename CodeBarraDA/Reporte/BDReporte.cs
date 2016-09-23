using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CodeBarraBE;
namespace CodeBarraDA
{
    public class BDReporte
    {
        public string RutaImagen(string usuario)
        {
            string imagen = "";

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_Ver_ReporteUsuarioProceso";
                    db.AddParameter("@Usuario", SqlDbType.VarChar, ParameterDirection.Input, usuario);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        imagen = dr["RutaImagen"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }


            return imagen;
        }

        public BEReporteCabecera ReporteCabecera(string Linea, string Proceso, string Producto)
        {
            BEReporteCabecera beCabecera = new BEReporteCabecera( );

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_VER_ReporteInspeccionTV";
                    db.AddParameter("@Linea", SqlDbType.VarChar, ParameterDirection.Input, Linea);
                    db.AddParameter("@Proceso", SqlDbType.VarChar, ParameterDirection.Input, Proceso);
                    db.AddParameter("@Producto", SqlDbType.VarChar, ParameterDirection.Input, Producto);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        beCabecera.Proceso= dr["Proceso"].ToString();
                        beCabecera.Dia = dr["Dia"].ToString();
                        beCabecera.Semana = dr["Semana"].ToString();
                        beCabecera.Yield = dr["Yield"].ToString();
                        beCabecera.MetaAhora = dr["MetaAhora"].ToString();
                        beCabecera.RealAhora = dr["RealAhora"].ToString();
                        beCabecera.Cumplimiento = dr["cumplimiento"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

            return beCabecera;
        }

        public List<BEReporteDetalle> ReporteDetalle(string Linea, string Proceso, string Producto)
        {
            List<BEReporteDetalle>  beLstDetalle = new List<BEReporteDetalle>();

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_VER_ReporteControlProduccionTV";
                    db.AddParameter("@Linea", SqlDbType.VarChar, ParameterDirection.Input, Linea);
                    db.AddParameter("@Proceso", SqlDbType.VarChar, ParameterDirection.Input, Proceso);
                    db.AddParameter("@Producto", SqlDbType.VarChar, ParameterDirection.Input, Producto);
                    db.AddParameter("@GrupoProducto", SqlDbType.VarChar, ParameterDirection.Input, Producto);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        BEReporteDetalle beDetalle = new BEReporteDetalle();
                        beDetalle.Orden  = dr["Orden"].ToString();
                        beDetalle.Linea = dr["Linea"].ToString();
                        beDetalle.Proceso = dr["Proceso"].ToString();
                        beDetalle.Producto = dr["Producto"].ToString();
                        beDetalle.Periodo = dr["Periodo"].ToString();
                        beDetalle.MetaVelocidad = dr["MetaVelocidad"].ToString();
                        beDetalle.RealVelocidad = dr["RealVelocidad"].ToString();
                        beDetalle.DifVelocidad = dr["DifVelocidad"].ToString();
                        beDetalle.MetaEficiencia = dr["MetaEficiencia"].ToString();
                        beDetalle.RealEficiencia = dr["RealEficiencia"].ToString();
                        beDetalle.MetaDisponibilidad = dr["MetaDisponibilidad"].ToString();
                        beDetalle.RealDisponibilidad = dr["RealDisponibilidad"].ToString();
                        beDetalle.MetaOEEE = dr["MetaOEEE"].ToString();
                        beDetalle.RealOEEE = dr["RealOEEE"].ToString();
                        beDetalle.Desprod = dr["Desprod"].ToString();
                        beDetalle.Turno = dr["Turno"].ToString();
                        beDetalle.Dia = dr["Dia"].ToString();
                        beDetalle.Semana = dr["Semana"].ToString();
                        beLstDetalle.Add(beDetalle);
                        beDetalle = null;
                    }
                }
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

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_Ver_ReporteUsuarioProceso";
                    db.AddParameter("@Usuario", SqlDbType.VarChar, ParameterDirection.Input, usuario);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        BEUsuarioProceso proceso = new BEUsuarioProceso();
                        proceso.Usuario= dr["Usuario"].ToString();
                        proceso.RutaImagen = dr["RutaImagen"].ToString();
                        proceso.Proceso = dr["Proceso"].ToString();
                        proceso.Producto = dr["Producto"].ToString();
                        proceso.Periodo = dr["Tiempo"].ToString();
                        proceso.CodProceso = dr["codproceso"].ToString();
                        beLstDetalle.Add(proceso);
                        proceso = null;
                    }
                }
            }
            catch
            {
                throw;
            }


            return beLstDetalle;
        }

        public string ActualizarImagenProceso(string Proceso,string Imagen)
        {
            string result = "";
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    IDataReader dr;
                    db.ProcedureName = "PA_Mod_ImagenUsuarioProceso";
                    db.AddParameter("@Proceso", SqlDbType.VarChar, ParameterDirection.Input, Proceso);
                    db.AddParameter("@RutaImagen", SqlDbType.VarChar, ParameterDirection.Input, Imagen);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        result = dr["Codigo"].ToString();
                        if (result != "EXITO")
                            result = dr["Mensaje"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

        public string ActualizarTiempoProceso(string Proceso, int Tiempo)
        {
            string result = "";
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    IDataReader dr;
                    db.ProcedureName = "PA_Mod_TiempoProceso";
                    db.AddParameter("@Proceso", SqlDbType.VarChar, ParameterDirection.Input, Proceso);
                    db.AddParameter("@Tiempo", SqlDbType.Int, ParameterDirection.Input,Tiempo );
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        result = dr["Codigo"].ToString();
                        if (result != "EXITO")
                            result = dr["Mensaje"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }


        public string AgregarImagenProceso(BEReporteProcesoImagen beprocesoimagen)
        {
            string result = "";
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    IDataReader dr;
                    db.ProcedureName = "PA_Ins_ReporteProcesoImagen";
                    db.AddParameter("@CodProceso", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.CodProceso);
                    db.AddParameter("@Ruta", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Ruta);
                    db.AddParameter("@Tiempo", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Tiempo);
                    db.AddParameter("@Orden", SqlDbType.Int, ParameterDirection.Input, beprocesoimagen.Orden);
                    db.AddParameter("@Tipo", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Tipo);
                    db.AddParameter("@AudEstado", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.AudEstado);
                    db.AddParameter("@AudUsuCrea", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Usuario);
                    db.AddParameter("@AudTerminal", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Terminal);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        result = dr["Codigo"].ToString();
                        if (result != "EXITO")
                            result = dr["Mensaje"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

        public string ModificarImagenProceso(BEReporteProcesoImagen beprocesoimagen)
        {
            string result = "";
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    IDataReader dr;
                    db.ProcedureName = "PA_Mod_ReporteProcesoImagen";
                    db.AddParameter("@Codigo", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Codigo);
                    db.AddParameter("@Ruta", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Ruta);
                    db.AddParameter("@Tiempo", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Tiempo);
                    db.AddParameter("@Orden", SqlDbType.Int, ParameterDirection.Input, beprocesoimagen.Orden);
                    db.AddParameter("@Tipo", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Tipo);
                    db.AddParameter("@AudEstado", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.AudEstado);
                    db.AddParameter("@AudUsuCrea", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Usuario);
                    db.AddParameter("@AudTerminal", SqlDbType.VarChar, ParameterDirection.Input, beprocesoimagen.Terminal);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        result = dr["Codigo"].ToString();
                        if (result != "EXITO")
                            result = dr["Mensaje"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

        public List<BEReporteProcesoImagen> ListaReporteProcesoImagen(string CodProceso)
        {
            List<BEReporteProcesoImagen> beLstDetalle = new List<BEReporteProcesoImagen>();
            if (CodProceso.Trim() == "") CodProceso = "99";

            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = @"PA_Ver_ReporteProcesoImagen";
                    db.AddParameter("@CodProceso", SqlDbType.VarChar, ParameterDirection.Input, CodProceso);
                    dr = db.GetDataReader();
                    while (dr.Read())
                    {
                        BEReporteProcesoImagen proceso = new BEReporteProcesoImagen();
                        proceso.Codigo =Convert.ToInt32(dr["Codigo"]);
                        proceso.Ruta = dr["Ruta"].ToString();
                        proceso.Proceso = dr["Proceso"].ToString();
                        proceso.Tiempo = Convert.ToInt32(dr["Tiempo"]);
                        proceso.Tipo = dr["Tipo"].ToString();
                        proceso.TipoDes = dr["TipoDes"].ToString();
                        proceso.Orden =Convert.ToInt32(dr["Orden"]);
                        proceso.CodProceso = dr["codproceso"].ToString();
                        proceso.AudEstado = dr["AudEstado"].ToString();
                        beLstDetalle.Add(proceso);
                        proceso = null;
                    }
                }
            }
            catch
            {
                throw;
            }


            return beLstDetalle;
        }

        #region Consolidado

        public List<OrdenProceso> ListaProcesoOrden(OrdenBE Orden)
        {
            List<OrdenProceso> lstOrdenProceso = new List<OrdenProceso>();
            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = "PA_Ver_ProcesoOrden";
                    db.AddParameter("@Linea", SqlDbType.VarChar, ParameterDirection.Input, Orden.Linea);
                    db.AddParameter("@CodProd", SqlDbType.VarChar, ParameterDirection.Input, Orden.Grupo);
                    db.AddParameter("@Anio", SqlDbType.VarChar, ParameterDirection.Input, Orden.Anio);
                    db.AddParameter("@Orden", SqlDbType.VarChar, ParameterDirection.Input, Orden.Orden);
                    db.AddParameter("@Item", SqlDbType.VarChar, ParameterDirection.Input, Orden.Item);
                    dr = db.GetDataReader(5000);
                    while (dr.Read())
                    {
                        OrdenProceso lOrden = new OrdenProceso();
                        lOrden.CodProceso = dr["PROCESO"].ToString();
                        lOrden.Actividad = dr["Actividad"].ToString();
                        lOrden.Orden = dr["Orden"].ToString();
                        lOrden.RegistroVidrio = dr["registroxvidrio"].ToString();
                        lOrden.ProcAnterior = dr["ProcesoAnt"].ToString();
                        lOrden.ActAnterior = dr["ActivadadAnt"].ToString();
                        lstOrdenProceso.Add(lOrden);
                    }
                }
            }
            catch 
            {

                throw;
            }
           
            return lstOrdenProceso;
        }

        public int CantidadPendienteOrden(OrdenBE Orden, OrdenProceso OrdenProceso, string ProcAnterior, string ActAnterior)
        {
            int intCantidad = 0;
            IDataReader dr;
            try
            {
                using (Database db = new Database(DatabaseHelper.ConexionDataSistemas))
                {
                    db.ProcedureName = "PA_Ver_CantidadPendienteProcesoOrden";
                    db.AddParameter("@Linea", SqlDbType.VarChar, ParameterDirection.Input, Orden.Linea);
                    db.AddParameter("@Anio", SqlDbType.VarChar, ParameterDirection.Input, Orden.Anio);
                    db.AddParameter("@Orden", SqlDbType.VarChar, ParameterDirection.Input, Orden.Orden);
                    db.AddParameter("@Item", SqlDbType.VarChar, ParameterDirection.Input, Orden.Item);
                    db.AddParameter("@Proceso", SqlDbType.VarChar, ParameterDirection.Input, OrdenProceso.CodProceso);
                    db.AddParameter("@Actividad", SqlDbType.VarChar, ParameterDirection.Input, OrdenProceso.Actividad);
                    db.AddParameter("@codprod", SqlDbType.VarChar, ParameterDirection.Input, Orden.Grupo);
                    db.AddParameter("@REGISTROPORVIDRIO", SqlDbType.VarChar, ParameterDirection.Input, OrdenProceso.RegistroVidrio);
                    db.AddParameter("@ANTERIORPROCESO", SqlDbType.VarChar, ParameterDirection.Input, ProcAnterior);
                    db.AddParameter("@PARREG_ANTPRO", SqlDbType.VarChar, ParameterDirection.Input, OrdenProceso.ProcAnterior);
                    db.AddParameter("@ANTERIORACTIVIDAD", SqlDbType.VarChar, ParameterDirection.Input, ActAnterior);
                    db.AddParameter("@PARREG_ANTACT", SqlDbType.VarChar, ParameterDirection.Input, OrdenProceso.ActAnterior);
                    dr = db.GetDataReader(5000);
                    while (dr.Read())
                    {
                        intCantidad = Convert.ToInt32(dr["Cantidad"]);
                    }
                }
            }
            catch
            {

                throw;
            }
            
            return intCantidad;
        }

        #endregion


    }
}
