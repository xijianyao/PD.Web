$(function () {
    $("#layout-tabs").tabs({
        fit: true, border: false,
        onContextMenu: function (e, title) {
            e.preventDefault();
            $("#layout-tabs-menu").menu("show", { left: e.pageX, top: e.pageY }).data("tabTitle", title);
        }
    });
    $.MiniEditorInit("#settings-copyright", 175, "p", false);
    $("#layout-tabs-menu").menu({
        onClick: function (item) {
            var curTabTitle = $(this).data("tabTitle"), type = $(item.target).attr("type");

            if (type == "refresh") { $("#layout-tabs").tabs("getTab", curTabTitle).panel("refresh"); return; }

            if (type == "close") {
                var t = $("#layout-tabs").tabs("getTab", curTabTitle);
                if (t.panel("options").closable) { $("#layout-tabs").tabs("close", curTabTitle); }
                return;
            }

            var allTabs = $("#layout-tabs").tabs("tabs"), closeTabsTitle = [];

            $.each(allTabs, function () {
                var opt = $(this).panel("options");
                if (opt.closable && opt.title != curTabTitle && type == "closeOther") {
                    closeTabsTitle.push(opt.title);
                } else if (opt.closable && type == "closeAll") { closeTabsTitle.push(opt.title); }
            });

            for (var i = 0; i < closeTabsTitle.length; i++) { $("#layout-tabs").tabs("close", closeTabsTitle[i]); }
        }
    });
});

//添加标签
function AddTab(title, url) {
    var layouttabs = $("#layout-tabs");
    if (layouttabs.tabs("exists", title)) { layouttabs.tabs("select", title); }
    else { layouttabs.tabs("add", { title: title, closable: true, href: url }); }
}

//添加窗口
function AddDialog(url) {
    $.ajax({
        url: url,
        type: "get",
        beforeSend: function () { $.AppendLoading(); },
        success: function (result) {
            $("#layout-common-dialog").html(result);
        },
        complete: function () { $.RemoveLoading(); },
        error: function (ex) { $.messager.alert("错误", "出错啦!"); }
    });
}

//切换主题
function ChangeTheme(theme){
    $("#main-themes").attr("href", "../public/easyui/themes/" + theme + "/easyui.css");
    $("#index-themes").attr("href", "styles/" + theme + "/index.css");
    $("#page-themes").attr("href", "styles/" + theme + "/page.css");

    $.cookie("themes", theme, { expires: 7 });
}