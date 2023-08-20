$(".panel-heading").dblclick(function () {
    var action = $(this).parent().data("evs-hide");
    if (action == 'slide') {
        $(this).next().slideToggle(500);
    }
    else if (action == 'fade') {
        $(this).next().fadeToggle(500);
    }
});

$(".evs-imgswap").hover(function () {
    var main = $(this).attr("src");
    var alt = $(this).data("altsrc");
    $(this).attr("src", alt);
    $(this).data("altsrc", main);
});

$(".img-thumbnail").mouseenter(function () {
    var temp = "#" + $(this).data("target");
    $(temp).attr("src", $(this).attr("src"));
});

$(".form-control:required").blur(function () {
    if ($(this).val().length === 0) {
        $(this).parent().addClass("has-error");
        $(this).parent().removeClass("has-success");
        //$(this).next().html("<span class='glyphicon glyphicon-warning-sign'></span>");
        $(this).parent().children(".form-control-feedback").remove();
        $(this).parent().append("<span class='form-control-feedback' > <span class='glyphicon glyphicon-warning-sign'></span></span>");
    }
    else {
        $(this).parent().addClass("has-success");
        $(this).parent().removeClass("has-error");
        //$(this).next().html("<span class='glyphicon glyphicon-check'></span>");
        $(this).parent().children(".form-control-feedback").remove();
        $(this).parent().append("<span class='form-control-feedback' > <span class='glyphicon glyphicon-check'></span></span>");
    }

});
