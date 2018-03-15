jQuery.extend(jQuery.validator.messages, {
    required: "必须填写",
    remote: "用户名已存在",
    email: "email不正确",
    url: "请输入合法的网址",
    date: "请输入合法的日期",
    dateISO: "请输入合法的日期 (ISO).",
    number: "请输入合法的数字",
    digits: "只能输入整数",
    creditcard: "请输入合法的信用卡号",
    equalTo: "请再次输入相同的值",
    accept: "请输入拥有合法后缀名的字符串",
    maxlength: jQuery.validator.format("长度最多是 {0}"),
    minlength: jQuery.validator.format("长度最少是 {0}"),
    rangelength: jQuery.validator.format("请输入 一个长度介于 {0} 和 {1} 之间的字符串"),
    range: jQuery.validator.format("请输入一个介于 {0} 和 {1} 之间的值"),
    max: jQuery.validator.format("请输入一个最大为{0} 的值"),
    min: jQuery.validator.format("请输入一个最小为{0} 的值")
});
(function ($) {
    $.extend({
        metadata: {
            defaults: {
                type: 'class',
                name: 'metadata',
                cre: /({.*})/,
                single: 'metadata'
            },
            setType: function (type, name) {
                this.defaults.type = type;
                this.defaults.name = name;
            },
            get: function (elem, opts) {
                var settings = $.extend({}, this.defaults, opts);
                // check for empty string in single property
                if (!settings.single.length) settings.single = 'metadata';
                var data = $.data(elem, settings.single);
                // returned cached data if it already exists
                if (data) return data;
                data = "{}";
                if (settings.type == "class") {
                    var m = settings.cre.exec(elem.className);
                    if (m)
                        data = m[1];
                } else if (settings.type == "elem") {
                    if (!elem.getElementsByTagName)
                        return undefined;
                    var e = elem.getElementsByTagName(settings.name);
                    if (e.length)
                        data = $.trim(e[0].innerHTML);
                } else if (elem.getAttribute != undefined) {
                    var attr = elem.getAttribute(settings.name);
                    if (attr)
                        data = attr;
                }
                if (data.indexOf('{') < 0)
                    data = "{" + data + "}";
                data = eval("(" + data + ")");
                $.data(elem, settings.single, data);
                return data;
            }
        }
    });
    /**
    * Returns the metadata object for the first member of the jQuery object.
    *
    * @name metadata
    * @descr Returns element's metadata object
    * @param Object opts An object contianing settings to override the defaults
    * @type jQuery
    * @cat Plugins/Metadata
    */
    $.fn.metadata = function (opts) {
        return $.metadata.get(this[0], opts);
    };
})(jQuery);
//$.extend($.fn.validatebox.defaults.rules, {
//    mobile: {// 验证手机号码
//        validator: function (value) {
//            return /^(13|15|18)\d{9}$/i.test(value);
//        },
//        message: '手机号码格式不正确.'
//    },
//});

//$
//.extend(
//    $.fn.validatebox.defaults.rules,
//    {
//        minLength: {
//            validator: function (value, param) {
//                return value.length >= param[0];
//            },
//            message: '长度需要大于{0}个字符.'
//        },
//        maxLength: {
//            validator: function (value, param) {
//                return value.length <= param[0];
//            },
//            message: '长度需要小于{0}个字符.'
//        },
//        maxCNLen: {
//            validator: function (value, param) {
//                var cArr = value.match(/[^\x00-\xff]/ig);
//                var len = value.length + (cArr == null ? 0 : cArr.length);
//                return len <= param[0];
//            },
//            message: '长度需要小于{0}个字符,中文算2个字符.'
//        },
//        intOrFloat: {// 验证整数或小数
//            validator: function (value) {
//                return /^\d+(\.\d+)?$/i.test(value);
//            },
//            message: '请输入数字，并确保格式正确'
//        },
//        idcard: {// 验证身份证
//            validator: function (value) {
//                return /^\d{15}(\d{2}[A-Za-z0-9])?$/i.test(value);
//            },
//            message: '身份证号码格式不正确'
//        },
//        length: {
//            validator: function (value, param) {
//                var len = $.trim(value).length;
//                return len >= param[0] && len <= param[1];
//            },
//            message: "输入内容长度必须介于{0}和{1}之间."
//        },
//        phone: {// 验证电话号码
//            validator: function (value) {
//                return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i
//                        .test(value);
//            },
//            message: '格式不正确,请使用下面格式:020-88888888'
//        },
//        mobile: {// 验证手机号码
//            validator: function (value) {
//                return /^(13|15|18)\d{9}$/i.test(value);
//            },
//            message: '手机号码格式不正确'
//        },
//        currency: {// 验证货币
//            validator: function (value) {
//                return /^\d+(\.\d+)?$/i.test(value);
//            },
//            message: '货币格式不正确'
//        },
//        qq: {// 验证QQ,从10000开始
//            validator: function (value) {
//                return /^[1-9]\d{4,9}$/i.test(value);
//            },
//            message: 'QQ号码格式不正确'
//        },
//        integer: {// 验证整数
//            validator: function (value) {
//                return /^[+]?[1-9]+\d*$/i.test(value);
//            },
//            message: '请输入整数'
//        },
//        integerAndMaxLength: {
//            validator: function (value, param) {
//                return (value.length <= param[0])
//                        && (/^[+]?[1-9]+\d*$/i.test(value));
//            },
//            message: '请输入长度小于{0}个字符的整数.'
//        },
//        integer: {// 验证固定长度的整数
//            validator: function (value) {
//                return /^[+]?[1-9]+\d*$/i.test(value);
//            },
//            message: '请输入整数'
//        },
//        age: {// 验证年龄
//            validator: function (value) {
//                return /^(?:[1-9][0-9]?|1[01][0-9]|120)$/i
//                        .test(value);
//            },
//            message: '年龄必须是0到120之间的整数'
//        },

//        chinese: {// 验证中文
//            validator: function (value) {
//                return /^[\Α-\￥]+$/i.test(value);
//            },
//            message: '请输入中文'
//        },
//        english: {// 验证英语
//            validator: function (value) {
//                return /^[A-Za-z]+$/i.test(value);
//            },
//            message: '请输入英文'
//        },
//        unnormal: {// 验证是否包含空格和非法字符
//            validator: function (value) {
//                return /.+/i.test(value);
//            },
//            message: '输入值不能为空和包含其他非法字符'
//        },
//        username: {// 验证用户名
//            validator: function (value) {
//                return /^[a-zA-Z][a-zA-Z0-9_]{5,15}$/i.test(value);
//            },
//            message: '用户名不合法（字母开头，允许6-16字节，允许字母数字下划线）'
//        },
//        faxno: {// 验证传真
//            validator: function (value) {
//                // return /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[
//                // ]){1,12})+$/i.test(value);
//                return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i
//                        .test(value);
//            },
//            message: '传真号码不正确'
//        },
//        zip: {// 验证邮政编码
//            validator: function (value) {
//                return /^[1-9]\d{5}$/i.test(value);
//            },
//            message: '邮政编码格式不正确'
//        },
//        ip: {// 验证IP地址
//            validator: function (value) {
//                return /d+.d+.d+.d+/i.test(value);
//            },
//            message: 'IP地址格式不正确'
//        },
//        name: {// 验证姓名，可以是中文或英文
//            validator: function (value) {
//                return /^[\Α-\￥]+$/i.test(value)
//                        | /^\w+[\w\s]+\w+$/i.test(value);
//            },
//            message: '请输入姓名'
//        },
//        date: {// 验证姓名，可以是中文或英文
//            validator: function (value) {
//                // 格式yyyy-MM-dd或yyyy-M-d
//                return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i
//                        .test(value);
//            },
//            message: '清输入合适的日期格式'
//        },
//        msn: {
//            validator: function (value) {
//                return /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
//                        .test(value);
//            },
//            message: '请输入有效的msn账号(例：abc@hotnail(msn/live).com)'
//        },
//        same: {
//            validator: function (value, param) {
//                if ($("#" + param[0]).val() != "" && value != "") {
//                    return $("#" + param[0]).val() == value;
//                } else {
//                    return true;
//                }
//            },
//            message: '两次输入的密码不一致！'
//        }
//    });