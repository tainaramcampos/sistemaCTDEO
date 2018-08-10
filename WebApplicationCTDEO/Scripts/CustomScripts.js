
$("#RegAdm").hide();
$("#bolsa").hide();

$(document).on('change', '#tipoInst', function () {
    if ($('#tipoInst').val() == 0) {
        $("#RegAdm").show();
    }
    else
    {
        $("#bolsa").show();
        $("#RegAdm").hide();
    }
});