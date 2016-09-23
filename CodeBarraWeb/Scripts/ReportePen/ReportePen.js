var colMode = [];
var DataMode = [];
var gridArrayData = [];
//



function convertToArrayOfObjects(DataMode) {
    var keys = DataMode.shift();
    DataMode = DataMode.map(function (row) {
        return keys.reduce(function (obj, key, i) {
            obj[key] = row[i];
            return obj;
        }, {});
    });
    
    //$("#gridConsolidado").jqGrid("clearGridData", true).trigger("reloadGrid");
    $("#gridConsolidado").jqGrid('setGridParam', { data: DataMode });
    // hide the show message
    //$("#gridConsolidado")[0].grid.endReq();
    // refresh the grid
    $("#gridConsolidado").trigger('reloadGrid');

    // return output;
}

function convertToArrayOfObjects1(data) {
    var keys = data.shift(),
        i = 0, k = 0,
        obj = null;
    DataMode.length = 0;

    for (i = 0; i < data.length; i++) {
        obj = {};

        for (k = 0; k < keys.length; k++) {
            obj[keys[k]] = data[i][k];
        }

        DataMode.push(obj);
    }

    //$("#gridConsolidado").jqGrid("clearGridData", true).trigger("reloadGrid");
    $("#gridConsolidado").jqGrid('setGridParam', { data: DataMode });
    // hide the show message
    //$("#gridConsolidado")[0].grid.endReq();
    // refresh the grid
    $("#gridConsolidado").trigger('reloadGrid');

   // return output;
}

function CargaColModel() {
    colMode.length = 0;
    $.ajax({
        type: "POST",
        contentType: "application/json",
        processData: false,
        //data: JSON.stringify({ CodProceso: proc }),
        url: "/ReportePen/CargarColumna",
        async: false,
        cache: false,
        success:
        function (resultado) {
            var i = 0;
            $.each(resultado, function (index, persona) {
                i += 1;
                colMode.push({ name: persona.Name, index: persona.index, label: persona.label, width: persona.width, align: persona.align, editable: persona.editable, edittype: persona.editType, editrules: { edithidden: true }, hidden: false });
            })
        },

    });
}

function fetchGridData() {
    gridArrayData.length = 0;
    $.ajax({
        type: "POST",
        contentType: "application/json",
        processData: false,
        url: "/ReportePen/CargarFila",
        async: false,
        cache: false,
        success:
        function (resultado) {
            convertToArrayOfObjects(resultado);
        },

    });
}

function GeneraGrilla() {
    $("#gridConsolidado").jqGrid({
        datatype: "local",
        data: DataMode,
        colModel: colMode,
        viewrecords: true, // show the current page, data rang and total records on the toolbar
        width: 780,
        height: 200,
        rowNum: 30,
        datatype: 'local',
        pager: "#pager",
        caption: "Prueba"
    });
    fetchGridData();
}



$(function () {
    
    CargaColModel();
    GeneraGrilla();
   

    
});