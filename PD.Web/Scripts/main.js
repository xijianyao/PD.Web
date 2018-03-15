$(function () {
    $(".index input").focus(function () {
        if ($(this).val() == "防伪码查询" || $(this).val() == "搜索")
        $(this).val("");
    });
    $('#searchsc').blur(function () {
        if ($('#searchsc').val() == "") {
            $('#searchsc').val("防伪码查询");
        }
    });
    $('#search').blur(function () {
        if ($('#search').val() == "") {
            $('#search').val("搜索");
        }
    });
    $('#searchsc').keydown(function(e){
        if (e.keyCode == 13) {
            window.location="/Code/Index?code="+$(this).val();
            }
    });
    $('#search').keydown(function (e) {
        if (e.keyCode == 13) {
            window.location = "/Brand/Index?name=" + $(this).val();
        }
    });
})