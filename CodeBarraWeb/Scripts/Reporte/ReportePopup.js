var lnsAccion = "Proceso", lnsImagen = "";
var contador = 0, lniTotalImagen = 0, ContadorImagen = 0, lniTotalProceso = 0;
var arrProceso = new Array();
var arrImagenes = new Array();
var Intervalo = 1000; //300000
var relojito;

function CargarImagenes(proc) {
    arrImagenes.length = 0;
    $.ajax(
    {
        type: "POST",
        url: "/Reporte/CargarImagenProceso",
        contentType: "application/json",
        data: JSON.stringify({ Proceso: proc }),
        async: false,
        cache: false,
        processData: false,
        success:
        function (resultado) {
            for (var item in resultado) {
                var arrItem = [resultado[item].CodProceso, resultado[item].Ruta, resultado[item].Tiempo];
                arrImagenes.push(arrItem);
            }
        },
    });
}


function CargaProcesos() {
    arrProceso.length = 0;
    var proc = "", Prod = "";
    $.ajax(
    {
        type: "POST",
        url: "/Reporte/CargarProceso",
        contentType: "application/json",
        async: false,
        cache: false,
        processData: false,
        success:
        function (resultado) {
            for (var item in resultado) {
                var arrItem = [resultado[item].CodProceso, resultado[item].Producto, resultado[item].Periodo];
                arrProceso.push(arrItem);
            }
        },
    });
}

$(document).ready(function () {
    CargaProcesos();
    lniTotalProceso = arrProceso.length;
    $("#divDetalle").hide();
    function CambiarPantalla() {
        if (lnsAccion == "Imagen") {
            if (lniTotalImagen > 0) {
                lnsImagen = "";
                lnsImagen = arrImagenes[ContadorImagen][1].toString().trim();
                Intervalo = parseInt(arrImagenes[ContadorImagen][2]) * 60000;
                ContadorImagen = ContadorImagen + 1;
                if (ContadorImagen == lniTotalImagen) {
                    lnsAccion = "Proceso";
                    ContadorImagen = 0;
                }
                clearInterval(relojito);
                relojito = setInterval(CambiarPantalla, Intervalo);
                $("#idImagen").attr("src", "MuestraImagen?file=" + lnsImagen);
                $("#divPrincipal").hide();
                $("#divDetalle").show();
            }
            else {
                lnsAccion = "Proceso";
                clearInterval(relojito);
                relojito = setInterval(CambiarPantalla, Intervalo);
            }
        }
        else {

            lnsAccion = "Imagen";
            Intervalo = parseInt(arrProceso[contador][2]) * 60000;
            CargaReporte(arrProceso[contador][0].toString(), arrProceso[contador][1].toString())
            CargarImagenes(arrProceso[contador][0].toString());
            lniTotalImagen = arrImagenes.length;            
            clearInterval(relojito);
            relojito = setInterval(CambiarPantalla, Intervalo);
            contador = contador + 1;
            if (contador == lniTotalProceso) {
                contador = 0;
                CargaProcesos();
                lniTotalProceso = arrProceso.length;
            }
            if (lniTotalImagen == 0) lnsAccion = "Proceso";
            $("#divDetalle").hide();
            $("#divPrincipal").show();
        }
    }
    clearInterval(relojito);
    relojito = setInterval(CambiarPantalla, Intervalo);

    function CargaReporte(proc, Prod) {
        $.ajax(
        {
            type: "POST",
            url: "/Reporte/ReportePopupParcial",
            contentType: "application/json",
            data: JSON.stringify({ Proceso: proc, Producto: Prod }),
            processData: false,
            success:
            function (resultado) {

                // ---- Cabecera
                $("#divCumplimiento").removeClass("col-md-2 bg-green");

                $("#divCumplimiento").addClass(resultado.ColorCumplimiento);
                $('#spnDia').text(resultado.Dia);
                $('#spnMes').text(resultado.Mes);
                $('#spnYield').text(resultado.Yield);
                $('#spnObjetivo').text(resultado.Objetivo);
                $('#spnReal').text(resultado.Real);
                $('#spnCumplimiento').text(resultado.Cumplimiento);

                $('#spnArea').text(resultado.Area);
                $('#spnModelo').text(resultado.Modelo);
                $('#spnFecha').text(resultado.Fecha);

                $('#sVTurno').text(resultado.TurDet);
                $('#sVDia').text(resultado.DiaDet);
                $('#sVSemana').text(resultado.SemDet);
                // ---- Turno
                $('#VTurObjetivo').css('width', resultado.VTurObjetivoPor + '%');
                $('#sVTurObjetivo').text(resultado.VTurObjetivoDes);
                $('#VTurReal').css('width', resultado.VTurRealPor + '%');
                $('#sVTurReal').text(resultado.VTurRealDes);
                $('#YTurObjetivo').css('width', resultado.YTurObjetivoPor);
                $('#sYTurObjetivo').text(resultado.YTurObjetivoDes);
                $('#YTurReal').css('width', resultado.YTurRealPor);
                $('#sYTurReal').text(resultado.YTurRealDes);

                // ---- Dia
                $('#VDiaObjetivo').css('width', resultado.VDiaObjetivoPor + '%');
                $('#sVDiaObjetivo').text(resultado.VDiaObjetivoDes);
                $('#VDiaReal').css('width', resultado.VDiaRealPor + '%');
                $('#sVDiaReal').text(resultado.VDiaRealDes);
                $('#YDiaObjetivo').css('width', resultado.YDiaObjetivoPor);
                $('#sYDiaObjetivo').text(resultado.YDiaObjetivoDes);
                $('#YDiaReal').css('width', resultado.YDiaRealPor);
                $('#sYDiaReal').text(resultado.YDiaRealDes);

                // ---- Semana
                $('#VSemObjetivo').css('width', resultado.VSemObjetivoPor + '%');
                $('#sVSemObjetivo').text(resultado.VSemObjetivoDes);
                $('#VSemReal').css('width', resultado.VSemRealPor + '%');
                $('#sVSemReal').text(resultado.VSemRealDes);
                $('#YSemObjetivo').css('width', resultado.YSemObjetivoPor);
                $('#sYSemObjetivo').text(resultado.YSemObjetivoDes);
                $('#YSemReal').css('width', resultado.YSemRealPor);
                $('#sYSemReal').text(resultado.YSemRealDes);

            },
        });
    }
});

