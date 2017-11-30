$("input[data-autocomplete-source]").each(function () {
    var target = $(this);
    target.autocomplete(
        { source: target.attr("data-autocomplete-source") });
});

$(function () { $("#album-list").mouseover(function () { $(this).effect("fade", { time: 3, distance: 40 }); }); });