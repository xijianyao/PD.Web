$(function () {
    $("#updatePwd").click(function () {
        var thisPassWord = $("#thisPassWord").val();
        var newPassWord = $("#newPassWord").val();
        var passWord = $("#PassWord").val();
        var b_newPwd = validatePasswdForLogin(newPassWord);
        var b_thisPwd = validatePasswdForLogin(thisPassWord);
        var thisNew = validatePasswdForLoginNwe(newPassWord, passWord);
        if (b_newPwd && b_thisPwd && thisNew) {
            var option = {
                url: "/my/Portal/UserPassWordUpdate",
                success: function (result) {
                    switch (result) {
                        case "{$UpdateOK}":
                            $.Slide("修改成功");
                            $.RemoveLoading();
                            break;
                        case "{$Update}":
                            $.Slide("修改失败，当前密码错误");
                            $.RemoveLoading();
                            break;
                        default:
                            $.RemoveLoading(); $.Message(result)
                            break;
                    }
                },
                error: Error,
                data: { ThisPassWord: thisPassWord, PassWord: passWord },
                methodType: "post"
            };
            CommomAjax(option);
        }
    });

    $("#updateUNickname").click(function () {
        var name = $("#UNickname-id").val();
        var uNickname = validateUNickname(name);
        if (uNickname) {
            var option = {
                url: "/my/Portal/UpdateUNickname",
                success: function (result) {
                    switch (result) {
                        case "{$UpdateOK}":
                            $.Slide("修改成功"); 
                            $.RemoveLoading();
                            break;
                        case "{$Update}":
                            $.Slide("修改失败，该昵称已存在");
                            $.RemoveLoading(); 
                            break;
                        default:
                            $.RemoveLoading(); $.Message(result)
                            break;
                    }
                },
                error: Error,
                data: { uNickname: name },
                methodType: "post"
            };
            CommomAjax(option);
        }
    });
});
function LoginOK() { alert("修改成功") }

function validateUNickname(name) {
    if (name.length === 0) {
        alert("昵称不能为空");
        return false;
    } return true;
}

function validatePasswdForLogin(pwd) {
    if (pwd.length === 0) {
        alert("请输入密码");
        return false;
    } return true;
}
function validatePasswdForLoginNwe(pwd) {
    if (pwd.length === 0) {
        alert("请输入新密码");
        return false;
    } return true;
}
function validatePasswdForLoginNwe(newPassWord, passWord) {
    if (newPassWord != passWord) {
        alert("两次输入密码不一致");
        return false;
    } return true;
}

function CommomAjax(options) {
    var methodType = options.methodType == undefined ? "get" : options.methodType;
    $.ajax({
        url: options.url,
        type: methodType,
        data: options.data,
        success: options.success,
        error: function (ex) { console.log(ex); }
    });
}