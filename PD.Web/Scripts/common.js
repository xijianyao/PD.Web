$.extend({
    //处理地址
    InvokeUrl: function (assembly, method) {
        return "/" + assembly + "/" + method;
    },
    //写入等待
    AppendLoading: function () {
        var body = $("body").eq(0);
        $("<div class=\"datagrid-mask\" style=\"display:block; z-index:88888;\"></div>").appendTo(body);
        var msg = $("<div class=\"datagrid-mask-msg\" style=\"display:block; z-index:88888;\"></div>").html("正在处理，请稍待。。。").appendTo(body);
        msg.css("left", (body.width() - msg._outerWidth()) / 2);
    },
    //移除等待
    RemoveLoading: function () {
        var body = $("body").eq(0);
        body.children("div.datagrid-mask-msg").remove();
        body.children("div.datagrid-mask").remove();
    },
    //执行方法
    MutualInvoke: function (options) {
        $.ajax({
            url: "/" + options.assembly + "/" + options.method,
            type: "post",
            data: options.data,
            beforeSend: function () { $.AppendLoading(); },
            success: options.success,
            complete: function () { $.RemoveLoading(); },
            error: function (ex) { $.messager.alert("错误", "出错啦!"); }
        });
    },
    //刷新列表
    DataGridReload: function (value) {
        $("#" + value).datagrid("reload");
        $("#" + value).datagrid("clearChecked");
    },
    //刷新树表
    TreeGridReload: function (value) {
        $("#" + value).treegrid("reload");
        $("#" + value).treegrid("unselectAll");
    },
    //展开节点
    TreeGridExpandAll: function (value) {
        $("#" + value).treegrid("expandAll");
    },
    //收起节点
    TreeGridCollapseAll: function (value) {
        $("#" + value).treegrid("collapseAll");
    },
    //提示信息
    Message: function (content) {
        $.messager.alert("提示", content);
    },
    //浮出信息
    Slide: function (content) {
        $.messager.show({ title: "提示", msg: content });
    },
    //确认提示
    Confirm: function (content, handler) {
        $.messager.confirm("提示", content, handler);
    },
    //获取图标
    GetIcon: function (value) {
        return "<span class='list-span' style='background:url(/Scripts/icons/" + value + ") no-repeat center top;'></span>";
    },
    //获取easyui图标
    EasyuiIcon: function (value) {
        return "<span class='list-span' style='background:url(/Scripts/easyui/themes/icons/" + value + ") no-repeat center top;'></span>";
    },
    //获取是否
    GetOkOrNo: function (value) {
        if (value) {
            return "<input type='checkbox' checked='checked' disabled='disabled' />";
        }
        else {
            return "<input type='checkbox' disabled='disabled' />";
        }
    },
    //实体窗口
    ModelDialog: function (options) {
        var dialog = $("<div />").dialog({
            title: options.title, href: options.href,
            width: options.width, height: options.height,
            modal: true, cache: false,
            buttons: [
                { text: "确定", iconCls: "icon-ok", handler: options.handler },
                { text: "关闭", iconCls: "icon-no", handler: function () { $.ButtonCloseDialog(this); } }
            ],
            onLoad: options.onLoad,
            onClose: function () { $(this).dialog("destroy"); }
        });
    },
    //关闭窗口
    ButtonCloseDialog: function (button) {
        $(button).closest(".window-body").dialog("destroy");
    },
    //表单实体
    ModelForm: function (options) {
        var submit = function () {
            var bool = $(this).form("validate");
            if (options.editor) { KindEditor.sync(options.editor); }
            if (bool) bool = options.validate;
            if (bool) $.AppendLoading(); return bool;
        }
        $(options.id).form("submit", {
            url: options.url, onSubmit: submit,
            success: function (result) {
                $.RemoveLoading();
                switch (result) {
                    case "{$True}":
                        options.success();
                        if (options.editor) { KindEditor.remove(options.editor); }
                        $.ButtonCloseDialog(options.button);
                        break;
                    case "{$Insert}":
                        $.Slide("添加成功"); options.success();
                        if (options.editor) { KindEditor.remove(options.editor); }
                        $.ButtonCloseDialog(options.button);
                        break;
                    case "{$Update}":
                        $.Slide("修改成功"); options.success();
                        if (options.editor) { KindEditor.remove(options.editor); }
                        $.ButtonCloseDialog(options.button);
                        break;
                    default: $.Message(result); break;
                }
            },
            error: function (ex) { $.RemoveLoading(); $.Message(ex); return false; }
        });
    },
    //编辑器初始化
    EditorInit: function (textid, height, lingtag, filterMode) {
        var editorkey = KindEditor.create(textid, {
            uploadJson: "/Scripts/kindeditor/FilesUpload.ashx",
            fileManagerJson: "/Scripts/kindeditor/FilesManager.ashx",
            width: "auto", height: height, allowFileManager: true,
            newlineTag: lingtag, filterMode: filterMode, resizeType: 0,
            items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink'
            ]
        });
        prettyPrint(); return editorkey;
    },
    //迷你编辑器初始化
    MiniEditorInit: function (textid, height, lingtag, filterMode) {
        var editorkey = KindEditor.create(textid, {
            uploadJson: "/Scripts/kindeditor/FilesUpload.ashx",
            fileManagerJson: "/Scripts/kindeditor/FilesManager.ashx",
            width: "auto", height: height, allowFileManager: true,
            newlineTag: lingtag, filterMode: filterMode, resizeType: 0,
            items: [
                'source', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', '|', 'fontsize', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', '|', 'link', 'unlink'
            ]
        });
        prettyPrint(); return editorkey;
    }
});

$.extend($.fn.validatebox.defaults.rules, {
    minLength: {
        validator: function (value, param) {
            return value.length >= param[0];
        },
        message: '长度不得小于 {0} 位'
    },
    equals: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次输入内容不一致'
    },
    length: {
        validator: function (value, param) {
            var len = $.trim(value).length;
            return len >= param[0] && len <= param[1];
        },
        message: "内容长度介于{0}和{1}之间."
    },
    tel: {
        validator: function (value) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: "格式不正确,请使用下面格式:010-88888888"
    },
    mobile: {
        validator: function (value) {
            return /^(13|15|18)\d{9}$/i.test(value);
        },
        message: "手机号码格式不正确(正确格式如：13845666666)"
    },
    telOrMobile: {
        validator: function (value) {
            return /^(13|15|18)\d{9}$/i.test(value) || /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: "请填入手机或电话号码,如 13845666666 或 010-8888888"
    },
    idcard: {
        validator: function (value) {
            return /^\d{15}(\d{2}[A-Za-z0-9])?$/i.test(value);
        },
        message: "身份证号码格式不正确"
    },
    currency: {
        validator: function (value) {
            return /^d{0,}(\.\d+)?$/i.test(value);
        },
        message: "货币格式不正确"
    },
    qq: {
        validator: function (value) {
            return /^[1-9]\d{4,9}$/i.test(value);
        },
        message: "QQ号码格式不正确"
    },
    chinese: {
        validator: function (value) {
            return /^[\u0391-\uFFE5]+$/i.test(value);
        },
        message: "请输入中文"
    },
    english: {
        validator: function (value) {
            return /^[A-Za-z]+$/i.test(value);
        },
        message: "请输入英文"
    },
    unnormal: {
        validator: function (value) {
            return /.+/i.test(value);
        },
        message: "输入值不能为空和包含其他非法字符"
    },
    username: {
        validator: function (value) {
            return /^[a-zA-Z][a-zA-Z0-9_]{5,15}$/i.test(value);
        },
        message: "用户名不合法(字母开头，允许6-16字节，允许字母数字下划线)"
    },
    zip: {
        validator: function (value) {
            return /^[1-9]\d{5}$/i.test(value);
        },
        message: "邮政编码格式不正确"
    },
    ip: {
        validator: function (value) {
            return /d+.d+.d+.d+/i.test(value);
        },
        message: "IP地址格式不正确"
    }
});

//改编孙宇的为 datagrid treegrid 增加表头菜单 显示和隐藏列
var createGridHeaderContextMenu = function (e, field) {
    e.preventDefault(); var grid = $(this), headerContextMenu = this.headerContextMenu;
    if (!headerContextMenu) {
        var tmenu = $("<div style='width:120px;'></div>").appendTo("body");
        var fields = grid.datagrid("getColumnFields");
        for (var i = 0; i < fields.length; i++) {
            var fildOption = grid.datagrid("getColumnOption", fields[i]);
            if (fildOption.title) {
                if (!fildOption.hidden) {
                    $("<div iconCls='icon-ok' field='" + fields[i] + "'/>").html(fildOption.title).appendTo(tmenu);
                } else {
                    $("<div iconCls='icon-empty' field='" + fields[i] + "'/>").html(fildOption.title).appendTo(tmenu);
                }
            }
        }
        headerContextMenu = this.headerContextMenu = tmenu.menu({
            onClick: function (item) {
                var field = $(item.target).attr("field");
                if (item.iconCls == "icon-ok") {
                    grid.datagrid("hideColumn", field);
                    $(this).menu("setIcon", { target: item.target, iconCls: "icon-empty" });
                } else {
                    grid.datagrid("showColumn", field);
                    $(this).menu("setIcon", { target: item.target, iconCls: "icon-ok" });
                }
            }
        });
    }
    headerContextMenu.menu("show", { left: e.pageX, top: e.pageY });
};

$.fn.datagrid.defaults.onHeaderContextMenu = createGridHeaderContextMenu;
$.fn.treegrid.defaults.onHeaderContextMenu = createGridHeaderContextMenu;

//改编孙宇的支持平滑数据格式
$.fn.tree.defaults.loadFilter = function (data, parent) {
    var treeData = [], tmpMap = [];
    for (var i = 0; i < data.length; i++) { tmpMap[data[i]["id"]] = data[i]; }
    for (var i = 0; i < data.length; i++) {
        if (tmpMap[data[i]["parent"]]) {
            if (!tmpMap[data[i]["parent"]]["children"]) {
                tmpMap[data[i]["parent"]]["children"] = [];
            }
            tmpMap[data[i]["parent"]]["children"].push(data[i]);
        } else { treeData.push(data[i]); }
    }
    return treeData;
};

//改编孙宇的支持平滑数据格式
$.fn.treegrid.defaults.loadFilter = function (data, parentId) {
    var opt = $(this).data().treegrid.options;
    var treeData = [], tmpMap = [];
    for (var i = 0; i < data.length; i++) { tmpMap[data[i][opt.idField]] = data[i]; }
    for (var i = 0; i < data.length; i++) {
        if (tmpMap[data[i][opt.parentField]]) {
            if (!tmpMap[data[i][opt.parentField]]["children"]) {
                tmpMap[data[i][opt.parentField]]["children"] = [];
            }
            tmpMap[data[i][opt.parentField]]["children"].push(data[i]);
        } else { treeData.push(data[i]); }
    }
    return treeData;
};

//改编孙宇的支持平滑数据格式
$.fn.combotree.defaults.loadFilter = $.fn.tree.defaults.loadFilter;
