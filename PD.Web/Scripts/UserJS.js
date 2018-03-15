
var loop = 3000000;

function InitialURL(controller, action) {
    var url = window.location.protocol + "//" + window.location.hostname + ":" + window.location.port + "/" + controller + "/" + action;
    return url;
}


$(function () {

    $("#login_btn").click(function () {

        var l_phone = $("#L_Phone").val();
        var l_Pwd = $("#L_Pwd").val();
        var b_phone = validatemobileForLogin(l_phone);
        var b_pwd = validatePasswdForLogin(l_Pwd);
        if (b_phone && b_pwd) {
            var option = {
                url: "/User/Login",
                success: SuccessCallBackLoginSubmit,
                error: Error,
                data: { Phone: l_phone, UPwd: l_Pwd },
                methodType: "post"
            };
            CommomAjax(option);
        }

    });


    $("#register_btn").click(function () {

        var UNickname = $("#UNickname").val();
        var UPwd = $("#UPwd").val();
        var UPwd2 = $("#UPwd2").val();
        var phone = $("#Phone").val();

        var b_phone = validatemobile(phone);
        var b_nike = validateNikeName(UNickname);
        var b_pwd = validatePasswd(UPwd);
        var b_pwd2 = validatePasswdMatch(UPwd, UPwd2);
        var b_xy = validateXYChecked();
        var genderV = $('input[name="gender"]:checked').val();

        if (b_phone && b_nike && b_pwd && b_pwd2 && b_xy) {

            var option = {
                url: "/User/Register",
                success: SuccessCallBackSubmit,
                error: Error,
                data: { Phone: phone, UNickname: UNickname, gender: genderV, UPwd: UPwd },
                methodType: "post"
            };
            CommomAjax(option);
        }
    });

    $("#UPwd").change(function () {
        validatePasswd($(this).val());
    });
});
function validatePasswdForLogin(pwd) {
    if (pwd.length === 0) {
        alert("请输入密码");
        return false;
    } return true;
}

function validatemobileForLogin(mobile) {
    if (mobile.length == 0) {
        alert('请输入手机号码！');
        return false;
    }
    if (mobile.length != 11) {
        alert('请输入有效的手机号码！');
        return false;
    }

    var myreg = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|170)+\d{8})$/;
    if (!myreg.test(mobile)) {
        alert('请输入有效的手机号码！');
        return false;
    }
    return true;
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



function validatePasswd(string) {

    if (string.length >= 6) {
        if (/[a-zA-Z]+/.test(string) && /[0-9]+/.test(string) && /\W+\D+/.test(string)) {
            noticeAssign(1);
        } else if (/[a-zA-Z]+/.test(string) || /[0-9]+/.test(string) || /\W+\D+/.test(string)) {
            if (/[a-zA-Z]+/.test(string) && /[0-9]+/.test(string)) {
                noticeAssign(-1);
            } else if (/\[a-zA-Z]+/.test(string) && /\W+\D+/.test(string)) {
                noticeAssign(-1);
            } else if (/[0-9]+/.test(string) && /\W+\D+/.test(string)) {
                noticeAssign(-1);
            } else {
                noticeAssign(0);
            }
        }
    } else {
        noticeAssign(null);
        return false;
    }
    return true;
}

function validatePasswdMatch(pwd1, pwd2) {
    if (pwd2 !== pwd1)
        $("#Pwd2Err").css('color', 'red').text("密码不一致");
    else
        $("#Pwd2Err").css('color', 'green').text("通过验证");
        return pwd1 === pwd2;
}


function validateXYChecked() {
    if ($("#XYCheckbox").attr("checked") != "checked") {
        $("#XYErr").css('color', 'red').text("必须同意条款后,才能注册");
    } else {
        $("#XYErr").css('color', 'green').text("通过验证");
    }
    return $("#XYCheckbox").attr("checked") == "checked";
}

function validateNikeName(string) {
    if (string.length < 2 || string.length > 10) {
        $("#NikeErr").css('color', 'red').text('请输入长度为2~10位的字符！');
        return false;
    } else {
        $("#NikeErr").css('color', 'green').text("通过验证");
    }
    return true;

}

function validatemobile(mobile) {
    if (mobile.length == 0) {
        $("#PhoneErr").css('color', 'red').text('请输入手机号码！');
        return false;
    }
    if (mobile.length != 11) {
        $("#PhoneErr").css('color', 'red').text('请输入有效的手机号码！');
        return false;
    }

    var myreg = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|170)+\d{8})$/;
    if (!myreg.test(mobile)) {
        $("#PhoneErr").css('color', 'red').text('请输入有效的手机号码！');
        //document.form1.mobile.focus();
        return false;
    }
    $("#PhoneErr").css('color', 'green').text("通过验证");
    return true;
}

function Error() { }
function SuccessCallBackSubmit(data) {
    if (data.Successful == true) {
        window.location.href = InitialURL("My", "Portal", "Index");
    }

    if (data.isPhoneExist == true) {
        $("#PhoneErr").css('color', 'red').text('电话号码已被使用！');
    } else {
        $("#PhoneErr").css('color', 'green').text("通过验证");
    }
    if (data.isNikeExist == true) {
        $("#NikeErr").css('color', 'red').text('昵称已被使用！');
    } else {
        $("#NikeErr").css('color', 'green').text("通过验证");
    }
}
function SuccessCallBackLoginSubmit(data) {
    if (data.Successful == true) {
        window.location.href = InitialURL("My", "Portal", "Index");
    }

    else {
        alert(data.Error);
    }
}


function noticeAssign(num) {
    if (num == 1) {
        $('#weak').css({ backgroundColor: '#CCC' });
        $('#middle').css({ backgroundColor: '#CCC' });
        $('#strength').css({ backgroundColor: '#009900' });
        $("#PwdErr").css('color', 'green').text("通过验证");
        $('#strength').html('很强');
    } else if (num == -1) {
        $('#weak').css({ backgroundColor: '#CCC' });
        $('#middle').css({ backgroundColor: '#ffcc33' });
        $('#strength').css({ backgroundColor: '#CCC' });
        $("#PwdErr").css('color', 'green').text("通过验证");
        $('#middle').html('中');
    } else if (num == 0) {
        $('#weak').css({ backgroundColor: '#dd0000' });
        $('#middle').css({ backgroundColor: '#CCC' });
        $('#strength').css({ backgroundColor: '#CCC' });
        $("#PwdErr").css('color', 'green').text("通过验证");
        $('#weak').html('弱');
    } else {
        $('#weak').css({ backgroundColor: '' });
        $('#middle').css({ backgroundColor: '' });
        $('#strength').css({ backgroundColor: '' });
        $("#PwdErr").css('color', 'red').text("密码为6~18个字符");
    }
}
