function searchFailed() {
    $("#searchResult").html("There are no books with name like this");
}


$("input[data-autocomplete-source]").each(function () {
    var target = $(this);
    target.autocomplete({ source: target.attr("data-autocomplete-source") });
});

function begin() {
    $("#searchResult").html("started...");
}