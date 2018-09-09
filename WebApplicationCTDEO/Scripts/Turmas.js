$(function () {
    $('table tr td').on("click", function () {
        $('table tr').attr('class', '');
        $(this).parent().attr('class', 'bg-secondary text-light');
        $('#ModalidadeId').val($(this).parent().attr('id'));
    });
});

