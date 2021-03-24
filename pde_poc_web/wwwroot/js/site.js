// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".hour-input").change(updateFormTotals);

$("#table-schedule").ready(updateFormTotals);

function updateFormTotals() {
    var scheduleRows = $("#table-schedule tr");

    var totalHmvo = 0;
    var totalCmvo = 0;
    var totalOther = 0;

    for (var i = 1; i < scheduleRows.length - 1; i++) {
        var rowData = $(scheduleRows[i]).find("td");
        var cmvo = $(rowData[1]).find("input").val();
        var hmvo = $(rowData[2]).find("input").val();
        var other = $(rowData[3]).find("input").val();

        var dayTotal = Number(cmvo) + Number(hmvo) + Number(other);
        totalCmvo += Number(cmvo);
        totalHmvo += Number(hmvo);
        totalOther += Number(other);

        $(rowData[5]).find(".day-total").text(dayTotal);
    }

    var lastRow = $(scheduleRows[scheduleRows.length-1]);

    var grandTotal = totalHmvo + totalCmvo + totalOther;

    $(lastRow).find("td.cmvo-total").text(totalCmvo);
    $(lastRow).find("td.hmvo-total").text(totalHmvo);
    $(lastRow).find("td.other-total").text(totalOther);
    $(lastRow).find("td.grand-total").text(grandTotal);
}