
function RecuperarMac() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        processData: false,
        url: "/Login/GetMAC",
        async: false,
        cache: false,
        success:
        function (resultado) {
            $('#spnMAC').text(resultado);
        },

    });
}

$(function () {

    RecuperarMac();

});