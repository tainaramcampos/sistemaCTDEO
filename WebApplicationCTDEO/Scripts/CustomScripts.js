$(function () {
    $('[data-toggle="tooltip"]').tooltip(); //inicializa o balão de dicas
});

//oculta ou mostra campos de acordo com a classificação da instituição (pública ou privada)
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

//alerta de salvamento de formulário
function confirmarSalvamento(e) {
    var conf = confirm("Confirma o salvamento?");
    var retorno = conf ? conf : e.preventDefault();
    return retorno;
};
//caso tente salvar apertando o enter
$('input[type=text]').on('keydown', function (e) {
    if (e.which == 13) {
        confirmarSalvamento(e);
    }
});


//permite apenas números nos campos descritos
$("#CPF,#RG,#CEP,#TelRes,#Cel").on("keypress", function (evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
});

//mudar letrar para uppercase
function InputToUpper(obj) {
    if (obj.value != "") {
        obj.value = obj.value.toUpperCase();
    }
}

$(function () {
    $("#nivelMod").hide();
    $("#grupo").hide();
    $(document).on('change', '#modalidade', function () {
        if ($('#modalidade').val() == 1) {
            $("#nivelMod").show();
            $("#grupo").show();
        }
    });
});