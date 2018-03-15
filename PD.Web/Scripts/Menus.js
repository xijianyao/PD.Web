$("#Setting").live("click", function () {
    $.ModelDialog({
        title: "系统设置", href: "/Setting/Setting", width: 510, height: 436, handler: function () {
            var button = $(this);
            $.ModelForm({
                id: "#settings-model",  validate: true,
                editor: "#settings-copyright",
                url: $.InvokeUrl("Setting", "SettingModel"),
                success: function (result) { }
            });
        },
        onLoad: function () {
            $.EditorInit("#settings-copyright", 338, "p", true);
        }
    });
})
$("#user").live("click", function () {
    var title = $("#user a").html();
    AddTab(title, "/Admin/Index");
})
$("#news").live("click", function () {
    var title = $("#news a").html();
    AddTab(title, "/News/Index");
})
$("#focus").live("click", function () {
    var title = $("#focus a").html();
    AddTab(title, "/Focus/Index");
})
$("#product").live("click", function () {
    var title = $("#product a").html();
    AddTab(title, "/Product/Index");
})
function SettingsFormInit() {
    $.MiniEditorInit("#settings-copyright", 175, "p", false);
}
$("#Info").live("click", function () {
    var title = $("#Info a").html();
    AddTab(title, "/Info/Index");
})

$("#Download").live("click", function () {
    var title = $("#Download a").html();
    AddTab(title, "/Download/Index");
})

$("#link").live("click", function () {
    var title = $("#link a").html();
    AddTab(title, "/Link/Index");
})
$("#Msg").live("click", function () {
    var title = $("#Msg a").html();
    AddTab(title, "/Msg/Index");
})
$("#category").live("click", function () {
    var title = $("#category a").html();
    AddTab(title, "/category/Index");
})