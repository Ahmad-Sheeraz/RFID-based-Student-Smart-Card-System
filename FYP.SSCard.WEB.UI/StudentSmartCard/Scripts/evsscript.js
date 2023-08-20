$(".form-control:required").blur(function () {
    if ($(this).val().length == 0) {
        $(this).parent().removeClass("has-success");
        $(this).parent().addClass("has-error");
        $(this).next().html("<span class='glyphicon glyphicon-warning-sign'></span>");
    }
    else {
        $(this).parent().removeClass("has-error");
        $(this).parent().addClass("has-success");
        $(this).next().html("<span class='glyphicon glyphicon-check'></span>");

    }
});

$(".panel-heading").click(function () {
    var animtype = $(this).parent().data("hideanim");
    if (animtype == "slide") {
        $(this).next().slideToggle(500);
    }
    else {
        if (animtype == "fade") {
            $(this).next().fadeToggle(500);
        }
    }
});