$(document).ready(function(){

    $('.scoreInput').change(function (event) {
        var selectList = $(event.currentTarget);

        var detailItemId = selectList.attr('data-detailItemId');
        var selectedValue = selectList.find(":selected").text();

        var url = window.location.origin + '/Evaluations/UpdateScore'
        var data = { detailItemId: detailItemId, score: selectedValue };


        $.post(url, data, function () { })
    });
})