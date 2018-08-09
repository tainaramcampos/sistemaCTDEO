$("#RegAdm").hide();

$(document).on('change', '#tipoInst', function () {
    if ($('#tipoInst').val() == 0) {
        $("#RegAdm").show();
    }
    else
    {
        $("#RegAdm").hide();
    }
});