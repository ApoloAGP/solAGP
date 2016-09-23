using System.Web.Optimization;

namespace CodeBarraWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            RegistrarLayout(bundles);
            RegistrarReporte(bundles);
            BundleTable.EnableOptimizations = false;

        }

        private static void RegistrarLayout(BundleCollection bundles)
        {
            // Styles
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Bootstrap/assets/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Bootstrap/css/custom-theme").Include(
                "~/Bootstrap/css/custom-theme/jquery-ui-1.10.0.custom.css"));

            bundles.Add(new StyleBundle("~/Bootstrap/assets/css").Include(
                "~/Bootstrap/assets/css/font-awesome.min.css",
                "~/Bootstrap/assets/css/docs.css"));

            bundles.Add(new StyleBundle("~/Bootstrap/assets/js/google-code-prettify").Include(
                "~/Bootstrap/assets/js/google-code-prettify/prettify.css"));

            bundles.Add(new StyleBundle("~/JQGrid/css").Include(
                "~/Bootstrap/css/ui.jqgrid.css"));

            // Script
            bundles.Add(new ScriptBundle("~/Bootstrap/assets/js").Include(
                "~/Bootstrap/assets/js/jquery-1.9.0.min.js",
                "~/Bootstrap/assets/js/bootstrap.min.js",
                "~/Bootstrap/assets/js/jquery-ui-1.10.0.custom.min.js"));

            bundles.Add(new ScriptBundle("~/Bootstrap/assets/js/google-code-prettify").Include(
                "~/Bootstrap/assets/js/google-code-prettify/prettify.js"));

            bundles.Add(new ScriptBundle("~/Bootstrap/assets/js2").Include(
                 "~/Bootstrap/assets/js/tabs.js",
                "~/Bootstrap/assets/js/docs.js"));

            bundles.Add(new ScriptBundle("~/JQGrid/js").Include(
                 "~/Bootstrap/js/grid.locale-es.js",
                "~/Bootstrap/js/jquery.jqGrid.min.js"));
        }

        private static void RegistrarReporte(BundleCollection bundles)
        {
            

            // bootstrap CSS
            bundles.Add(new StyleBundle("~/bootstrapPopup/css").Include(
                "~/Bootstrap/css/bootstrap.css"));
            // Stilos Generales CSS
            bundles.Add(new StyleBundle("~/Estilos/css").Include(
                "~/Bootstrap/css/Estilos2.css"));

            bundles.Add(new ScriptBundle("~/Script/Reporte/js").Include(
            "~/Scripts/Reporte/Reporte.js"));

            // Reporte Popup
            bundles.Add(new ScriptBundle("~/ReportePopup/js").Include(
                "~/Scripts/Reporte/ReportePopup.js"));
            // Reporte TV
            bundles.Add(new ScriptBundle("~/ReporteTV/js").Include(
                "~/Scripts/Reporte/ReporteTV.js"));

            // Reporte PEN
            bundles.Add(new ScriptBundle("~/ReportePen/js").Include(
                "~/Scripts/ReportePen/ReportePen.js"));
        }
    }
}