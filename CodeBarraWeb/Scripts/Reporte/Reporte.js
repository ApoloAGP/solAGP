var lnsNombreImagen = "", lnsRespuesta = "",lnsRutaImagenProceso="";
var lniCodigo = 0;
var gridArrayData = [];
function ArmarCombo(proc, Prod) {
    $.ajax(
    {
        type: "POST",
        url: "/Reporte/ArmarCombo",
        contentType: "application/json",
        data: JSON.stringify({ Proceso: proc, Producto: Prod }),
        processData: false,
        success:
        function (resultado) {
            for (var item in resultado) {
                $("#ddlFEstado").append('<option value="' + resultado[item].Codigo + '">' + resultado[item].Descripcion + '</option>');
                $("#ddlProceso").append('<option value="' + resultado[item].Codigo + '">' + resultado[item].Descripcion + '</option>');
            }
        },
    });
}

function Validar() {
    if ($("#ddlFEstado").val() == '00') {
        lnsRespuesta = 'FALLO Seleccione el Proceso';
        $("#ddlFEstado").focus();
        return false;
    }
    if (lniCodigo==0) {
        if ($("#FileUpload").get(0).files.length == 0) {
            lnsRespuesta = 'FALLO Debe seleccionar la imagen';
            $("#FileUpload").focus();
            return false;
        }
    }
    else
    {
        if ($("#FileUpload").get(0).files.length == 0 && lnsRutaImagenProceso == "") {
            lnsRespuesta = 'FALLO Debe seleccionar la imagen';
            $("#FileUpload").focus();
            return false;
        }
    }

    if ($("#txtTiempo").val() == '') {
        lnsRespuesta = 'FALLO Debe ingresar el tiempo';
        $("#txtTiempo").focus();
        return false;
    }
    if ($("#txtOrden").val() == '') {
        lnsRespuesta = 'FALLO Debe ingresar el orden';
        $("#txtOrden").focus();
        return false;
    }
    if ($("#ddlTipo").val() == '') {
        lnsRespuesta = 'FALLO Debe ingresar el tipo de carga';
        $("#ddlTipo").focus();
        return false;
    }
}

function ValidarTiempo() {
    if ($("#ddlProceso").val() == '00') {
        lnsRespuesta = 'FALLO Seleccione el Proceso';
        $("#ddlProceso").focus();
        return false;
    }
    if ($("#txtTiempoProceso").val() == '') {
        lnsRespuesta = 'FALLO Debe ingresar el tiempo';
        $("#txtTiempoProceso").focus();
        return false;
    }

    if ($("#txtIP").val() == '') {
        lnsRespuesta = 'FALLO Debe ingresar la IP';
        $("#txtIP").focus();
        return false;
    }
}
function Grabar() {
    if (Validar() == false) {
        return false;
    }
    var proceso = new Object();
    proceso.Codigo = lniCodigo;
    proceso.CodProceso = $("#ddlFEstado").val();
    if ($("#FileUpload").get(0).files.length > 0)
        proceso.Ruta = $("#FileUpload").get(0).files[0].name;
    else
        proceso.Ruta = lnsRutaImagenProceso;
    proceso.Tiempo =parseInt($("#txtTiempo").val());
    proceso.Orden = $("#txtOrden").val();
    proceso.Tipo = $("#ddlTipo").val();
    proceso.AudEstado = $("#ddlEstado").val();
    $.ajax(
    {
        type: "POST",
        url: "/Reporte/AgregarModicarImagen",
        contentType: "application/json",
        data: JSON.stringify(proceso),
        processData: false,
        success:
        function (resultado) {
            lnsRespuesta = resultado;
        },
    });
}

function GrabarTiempo() {
    if (ValidarTiempo() == false) {
        return false;
    }
    var proc = "",Ip="";
    var tpo = 0;
    tpo = $("#txtTiempoProceso").val();
    Ip = $("#txtIP").val();
    proc = $("#ddlProceso").val();
    $.ajax(
    {
        type: "POST",
        url: "/Reporte/ActualizarTiempoProceso",
        contentType: "application/json",
        data: JSON.stringify({ Proceso: proc, Tiempo: tpo, Iptv: Ip }),
        processData: false,
        success:
        function (resultado) {
            lnsRespuesta = resultado;
        },
    });
}

function CargarData() {
    var id = $("#grid").getGridParam('selrow');
    if (id != null) {       
        var rowdata = $("#grid").getRowData(id);
        fetchGridData(rowdata["CodProceso"]);
        //$('#ddlFEstado').prop('disabled', false);
        //$('#ddlFEstado').prop('disabled', 'disabled');
        $("#ddlFEstado").val(rowdata["CodProceso"]);
        $("#divListado").hide();
        $("#divProceso").hide();
        $("#divGrillaImagen").show();

        $("#tabs").tabs({ disabled: [0] });
        $("#tabs").tabs({ disabled: [2] });
        $("#tabs").tabs({ active: 1 });

    }
    else { alert("Seleccione un registro de la lista"); return false; }
    return true;
}

function CargarDataProceso() {
    var id = $("#grid").getGridParam('selrow');
    if (id != null) {
        var rowdata = $("#grid").getRowData(id);
        fetchGridData(rowdata["CodProceso"]);
        //$('#ddlFEstado').prop('disabled', false);
        $("#ddlProceso").val(rowdata["CodProceso"]);
        $("#txtIP").val(rowdata["RutaImagen"]);
        $("#txtTiempoProceso").val(rowdata["Periodo"]);
        $("#divListado").hide();
        $("#divGrillaImagen").hide();
        $("#divProceso").show();
        $("#tabs").tabs({ disabled: [0] });
        $("#tabs").tabs({ disabled: [1] });
        $("#tabs").tabs({ active: 2 });
    }
    else { alert("Seleccione un registro de la lista"); return false; }
    return true;
}
function CargarDataImagen() {
    var id = $("#gridImagen").getGridParam('selrow');
    if (id != null) {
        var rowdata = $("#gridImagen").getRowData(id);
        $("#ddlFEstado").val(rowdata["CodProceso"]);
        $("#txtTiempo").val(rowdata["Tiempo"]);
        $("#txtOrden").val(rowdata["Orden"]);
        $("#ddlTipo").val(rowdata["Tipo"]);
        $("#ddlEstado").val(rowdata["AudEstado"]);
        lnsRutaImagenProceso=rowdata["Ruta"];
        lniCodigo = rowdata["Codigo"];
    }
    else { alert("Seleccione un registro de la lista"); return false; }
    return true;
}

function CargarImagen() {
    if (window.FormData !== undefined) {
        var fileUpload = $("#FileUpload").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        fileData.append('username', 'Manas');
        $.ajax({
            url: '/Reporte/Upload',
            type: "POST",
            async: false,
            cache: false,
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                lnsNombreImagen = result;
            },
            error: function (err) {
                lnsNombreImagen = "Fallo - " + err.statusText;
            }
        });
    } else {
        lnsNombreImagen = "Fallo - El formato no es compatible";
    }
}
/*
function CargarListaImagen1() {
    $("#gridImagen").jqGrid({
        url: "/Reporte/MostrarProcesoImagen",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['Codigo', 'Proceso', 'Ruta', 'Tiempo', 'TipoDes', 'Orden', 'Tipo', 'CodProceso'],
        colModel: [
            { key: true, hidden: true, name: 'Codigo', index: 'Codigo', editable: true },
            { key: false, name: 'Proceso', index: 'Proceso', editable: true },
            { key: false, name: 'Ruta', index: 'Ruta', editable: true },
            { key: false, name: 'Tiempo', index: 'Tiempo', editable: true },
            { key: false, name: 'TipoDes', index: 'TipoDes', editable: true },
            { key: false, name: 'Orden', index: 'Orden', editable: true },
            { key: false, hidden: true, name: 'Tipo', index: 'Tipo', editable: true },
            { key: false, hidden: true, name: 'CodProceso', index: 'CodProceso', editable: true }],
        pager: jQuery('#pagerImagen'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Imagen Procesos',
        emptyrecords: 'No hay registros para mostrar',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#pagerImagen', { edit: false, add: false, del: false, search: false, refresh: true });

}*/


function fetchGridData(proc) {
    gridArrayData = [];
    $.ajax({
        type: "POST",
        contentType: "application/json",
        processData: false,
        data: JSON.stringify({ CodProceso: proc }),
        url: "/Reporte/MostrarProcesoImagen1",
        success:
        function (resultado) {
            for (var item in resultado) {
                gridArrayData.push({
                    Codigo: resultado[item].Codigo,
                    Proceso: resultado[item].Proceso,
                    Ruta: resultado[item].Ruta,
                    Tiempo: resultado[item].Tiempo,
                    TipoDes: resultado[item].TipoDes,
                    Orden: resultado[item].Orden,
                    Tipo: resultado[item].Tipo,
                    CodProceso: resultado[item].CodProceso
                })
            }
            $("#gridImagen").jqGrid("clearGridData", true).trigger("reloadGrid");

            $("#gridImagen").jqGrid('setGridParam', { data: gridArrayData });
            // hide the show message
            $("#gridImagen")[0].grid.endReq();
            // refresh the grid
            $("#gridImagen").trigger('reloadGrid');
        },

    });
}
       
function CargarListaImagen(proc) {
    
    $("#gridImagen").jqGrid({
        datatype: "local",
        data: gridArrayData,
        colModel: [
            { key: true, hidden: true, name: 'Codigo', index: 'Codigo', editable: true },
            { key: false, name: 'Proceso', index: 'Proceso', editable: true },
            { key: false, name: 'Ruta', index: 'Ruta', editable: true },
            { key: false, name: 'Tiempo', index: 'Tiempo', editable: true },
            { key: false, name: 'TipoDes', index: 'TipoDes', editable: true },
            { key: false, name: 'Orden', index: 'Orden', editable: true },
            { key: false, hidden: true, name: 'Tipo', index: 'Tipo', editable: true },
            { key: false, hidden: true, name: 'CodProceso', index: 'CodProceso', editable: true }],
        viewrecords: true, // show the current page, data rang and total records on the toolbar
        width: 780,
        height: 200,
        rowNum: 15,
        datatype: 'local',
        pager: "#pagerImagen",
        caption: "Lista de Procesos con Imagen"
    });
    fetchGridData(proc);
}

function RecuperarMac() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        processData: false,
        url: "/Reporte/GetMAC",
        async: false,
        cache: false,
        success:
        function (resultado) {
            $('#spnMAC').text(resultado);
        },

    });
}

function Limpiar() {
    $("#ddlFEstado").val('00');
    $("#ddlTipo").val('01');
    $("#txtOrden").val('');
    $("#txtTiempo").val('');
}


$(function () {

    RecuperarMac();
    
    $("#tabs").tabs({ disabled: [1] });
    $("#tabs").tabs({ disabled: [2] });
    $("#tabs").tabs({ active: 0 });
    $("#divListado").show();
    $("#divProceso").hide();
    $("#divGrillaImagen").hide();

    ArmarCombo("00", "00");

    $("#btnNuevo").click(function () {
        Limpiar();
        lniCodigo = 0;
        $('#ddlFEstado').prop('disabled', false);
        $("#divListado").hide();
        $("#divProceso").hide();        
        $("#divGrillaImagen").show();
        $("#tabs").tabs({ disabled: [0] });
        $("#tabs").tabs({ disabled: [2] });
        $("#tabs").tabs({ active: 1 });
        return false;
    });
    $("#btnGuardar").click(function () {
        Grabar();        
        if (lnsRespuesta.substring(0, 5).toUpperCase() != "FALLO") {

            if ($("#FileUpload").get(0).files.length > 0) {
                CargarImagen();
            }
            $("#gridImagen").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
            alert("Se actualizo con exito");
            $("#divGrillaImagen").hide();
            $("#divProceso").hide();
            $("#divListado").show();
            $("#tabs").tabs({ disabled: [1] });
            $("#tabs").tabs({ disabled: [2] });
            $("#tabs").tabs({ active: 0 });            
        }
        else { alert(lnsRespuesta); return false; }
    });

    $("#btnAceptar").click(function () {
        GrabarTiempo();
        if (lnsRespuesta.substring(0, 5).toUpperCase() != "FALLO") {
            $("#grid").jqGrid('setGridParam', { page: 1 }).trigger("reloadGrid");
            alert("Se actualizo con exito");
            $("#divGrillaImagen").hide();
            $("#divListado").show();
            $("#divProceso").hide();
            $("#tabs").tabs({ disabled: [1] });
            $("#tabs").tabs({ disabled: [2] });
            $("#tabs").tabs({ active: 0 });
        }
        else { alert(lnsRespuesta); return false; }
    });

    $("#btnModificar").click(function () {
        Limpiar();
        CargarData();
        lniCodigo = 0;
    });

    $("#btnProceso").click(function () {
        CargarDataProceso();

    });

    $("#btnActualizar").click(function () {
        lniCodigo = 0;
        CargarDataImagen();
    });
    

    $("#btnCancelar").click(function () {
        $("#divGrillaImagen").hide();
        $("#divProceso").hide();
        $("#divListado").show();
        $("#tabs").tabs({ disabled: [1] });
        $("#tabs").tabs({ disabled: [2] });
        $("#tabs").tabs({ active: 0 });
    });

    $("#btnRegresa").click(function () {
        $("#divProceso").hide();
        $("#divGrillaImagen").hide();
        $("#divListado").show();
        $("#tabs").tabs({ disabled: [1] });
        $("#tabs").tabs({ disabled: [2] });
        $("#tabs").tabs({ active: 0 });
    });

    $("#gridImagen").jqGrid({
        datatype: "local",
        data: gridArrayData,
        colModel: [
            { key: true, hidden: true, name: 'Codigo', index: 'Codigo', editable: true },
            { key: false, name: 'Proceso', index: 'Proceso', editable: true },
            { key: false, name: 'Ruta', index: 'Ruta', editable: true },
            { key: false, name: 'Tiempo', index: 'Tiempo', editable: true },
            { key: false, name: 'TipoDes', index: 'TipoDes', editable: true },
            { key: false, name: 'Orden', index: 'Orden', editable: true },
            { key: false, hidden: true, name: 'Tipo', index: 'Tipo', editable: true },
            { key: false, hidden: true, name: 'CodProceso', index: 'CodProceso', editable: true },
            { key: false, hidden: true, name: 'AudEstado', index: 'AudEstado', editable: true }],
        viewrecords: true, // show the current page, data rang and total records on the toolbar
        width: 780,
        height: 200,
        rowNum: 15,
        datatype: 'local',
        pager: "#pagerImagen",
        caption: "Lista de Imagenes"
    });
    fetchGridData("");


    $("#grid").jqGrid({
        url: "/Reporte/MostrarProceso",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['CodProceso','Usuario', 'IP', 'Proceso', 'Producto', 'Periodo' ],
        colModel: [
            { key: true, hidden: true, name: 'CodProceso', index: 'CodProceso', editable: true },
            { key: false, name: 'Usuario', index: 'Usuario', editable: true },
            { key: false, name: 'RutaImagen', index: 'RutaImagen', editable: true },
            { key: false, name: 'Proceso', index: 'Proceso', editable: true },
            { key: false, name: 'Producto', index: 'Producto', editable: true },
            { key: false, name: 'Periodo', index: 'Priodo', editable: true }],
        pager: jQuery('#pager'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Listado Procesos',
        emptyrecords: 'No hay registros para mostrar',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#pager', { edit: false, add: false, del: false, search: false, refresh: true });

});

$(window).resize(function () {
    var outerwidth = $('#divgrid').width();
    $('#grid').setGridWidth(outerwidth);
});