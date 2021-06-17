$(function () {
    $('#chkPass').click(function () {
        if ($(this).is(":checked")) {
            $('#txtPassword').attr('type', 'text');
        } else {
            $('#txtPassword').attr('type', 'password');
        }
    });
});