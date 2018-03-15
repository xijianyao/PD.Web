function updatepwd() {
    $.ajax({

        type: "GET",

        url: "/Agency/UpdatePwd",

        dataType: "html",

        success: function (data) {

            var d = art.dialog({
                content: data,
                fixed: true,
                lock: true,
                opacity: .5,
                cancel: false,
                title: false,
                id: 'test'
            });

        }
    });

}
function mdfcus(u) {
    $.ajax({

        type: "GET",

        url: "/Agency/UpdateUser",

        data:"UserId="+u,

        dataType: "html",

        success: function (data) {

            $("body").append(data);
            $("#bgdiv").css("width", $(document).width());
            $("#bgdiv").css("height", $(document).height())

        }
    });
}
function delcus(u) {
    if (!confirm("确定删除吗")) return;
    $.ajax({

        type: "GET",

        url: "/Agency/DelUser",

        data: "UserId=" + u,

        dataType: "html",

        success: function (data) {
            if (data == "success") {
                alert("删除成功！");
                window.location = "/Agency/MyCustomers";
            }
            else {
                alert("出错啦");
            }
        }
    });
}

function cfnUdtPwd() {
    if ($("#newpwd1").val() == "" || $("#newpwd2").val() == "" || $("oldpwd").val() == "") {
        alert("不能为空"); return;
    }
    if ($("#newpwd1").val() != $("#newpwd2").val()) {
        alert("两次新密码不相同,请重新输入");
        return;
    }
    $.ajax({

        type: "POST",

        url: "/Agency/UpdatePwd",

        data: $("#UP-form").serialize(),

        success: function (data) {

            if (data == "success") {
                alert("修改成功");
                art.dialog({ id: 'test' }).close();
            }
            else if (data == "error") {
                alert("密码错误");
            }
            else {
                alert("修改失败");
            }
        }
    });



} function clsUdtPwd() {
    art.dialog({ id: 'test' }).close();
}

function exit() {
    var one = document.getElementById("d_addcus");
    one.parentNode.removeChild(one);
}
function AddCustm(v) {
    if (v) 
    $.ajax({

        type: "POST",

        url: "/Agency/AddCustomer",

        dataType: "html",

        data: $('#CustmForm').serialize(),

        success: function (data) {


            if ($('#ContinueAdd').checked == true)
                $('#CustmForm')[0].reset();
            else
                exit();
        }

    });
}
function dlgcus() {
        $.ajax({

            type: "GET",

            url: "/Agency/AddCustomer",

            dataType: "html",

            success: function (data) {


                $("body").append(data);
                $("#bgdiv").css("width", $(document).width());
                $("#bgdiv").css("height", $(document).height())

            }

        });
}
$(function () {
    $(".menuitem").hover(function () { $(this).addClass("select") }, function () { $(this).removeClass("select") });
});