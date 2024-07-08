// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.main-tabs-head li').click(function () {
    var tab_id = $(this).attr('data-tab');
    if ($("#" + tab_id).hasClass('current')) {
        $("#" + tab_id).removeClass('current');
        $(this).removeClass('current');
        return;
    }
    $('.main-tabs-head li').removeClass('current');
    $('.main-tabs-content li.tab-content').removeClass('current');
    $(this).addClass('current');
    $("#" + tab_id).addClass('current');
})