$(function () {
    var news_content = null;
    $("#setting-setid").datagrid({
        url: $.InitialURL("Admin","Setting", "DataGridJson"),
        remoteSort: false,
        nowrap: false, rownumbers: true, border: false,
        fit: true, fitColumns: true, pagination: true,
        pageSize: 20, idField: "Id",singleSelect:true,
        toolbar: "#setting-toolbar",
        columns:
             [[
                 { field: "Id", title: "项目ID", width: 100, align: "center", sortable: false, hidden: true },
                 { field: "MarkName", title: "项目名称", width: 100, align: "center", sortable: false },
                 { field: "Content", title: "项目内容", width: 100, align: "center", sortable: false },
             ]]
    });


    var p = $("#setting-setid").datagrid('getPager');
    $(p).pagination({
        pageSize: 20,//每页显示的记录条数，默认为20  
        pageList: [20, 30, 50],//可以设置每页记录条数的列表  
        beforePageText: '第',//页数文本框前显示的汉字  
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
    });


});



function UsersMutual(title, href) {
    $.ModelDialog({
        title: title, href: href, width: 455, height: 205, handler: function () {
            var button = $(this);
            $("#settings-model").form("submit", {
                url: $.InitialURL("admin","Setting", "Model"),
                onSubmit: function () {
                    var bool = $(this).form('validate');
                    if (bool) $.AppendLoading(); return bool;
                },
                success: function (result) {
                    switch (result) {
                        case "{$Insert}":
                            $.Slide("添加成功"); $.ButtonCloseDialog(button);
                            $.RemoveLoading(); $("#setting-setid").datagrid('clearSelections'); $.DataGridReload("setting-setid");
                            break;
                        case "{$Update}":
                            $.Slide("修改成功"); $.ButtonCloseDialog(button);
                            $.RemoveLoading(); $("#setting-setid").datagrid('clearSelections'); $.DataGridReload("setting-setid");
                            break;
                        default:
                            $.RemoveLoading(); $.Message(result)
                            break;
                    }
                },
                error: function (ex) { $.RemoveLoading(); $.Message(ex); return false; }
            });
        },
        onLoad: function () { UsersFormInit(); }
    });
}
//修改
function SettingEditFunction() {
    var rows = $("#setting-setid").datagrid("getChecked");
    if (rows.length == 1) {
        UsersMutual("修改", "/admin/Setting/Edit?SettingId=" + rows[0].SettingId);
    }
    else { $.Message("此操作必须并且只能选择一条数据!"); }
}

//   刷新
function SettingRefreshlFunction() {
    $.DataGridReload("setting-setid");
}

