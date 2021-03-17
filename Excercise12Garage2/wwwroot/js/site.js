// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

function window_print() {
    var ButtonControl = document.getElementById("btnprint");
    ButtonControl.style.visibility = "hidden";
    window.print();
}