$(function () {

    $('table tr td').on("click", function () {

        var line = $(this).parent();
        if (line.hasClass('bg-secondary text-light')) { //caso clique numa lnha selecionada
            line.attr('class', ''); //limpa a formatação
            var ItemtoRemove = line.attr('id').toString() + ','; //item a ser removido da seleção
            var content = $('#IdsdeTurmas').val($('#IdsdeTurmas').val().replace(ItemtoRemove,'')); //campo de ids
            $('#IdsdeTurmas').text(content);
            return;
        }
        else { //caso clique pela primeira ver na linha
            $(this).parent().attr('class', 'bg-secondary text-light');
            var SingleId = $(this).parent().attr('id').toString();
            $('#IdsdeTurmas').val($('#IdsdeTurmas').val() + SingleId + ',');
        }
    });

});