var second = 0;    //距离该场次开拍倒计时的秒数

var setTimeConfrimBox = null               //刷新 提示场次开拍倒计时的时间间隔句柄
    , setTimeByPlusCountdownSecond = null  //页面递减竞价时间的句柄
    , setTimeByGetGoodsInfor = null        //获取商品信息的句柄
;

var isStartGoodsBid = false; //是否能够开始获取竞拍商品的信息，通过Ajax

var getGoodsInforByAjaxInterval = 3; //获取竞拍商品的信息的时间间隔

var IsCurrentGoodsEnabledBid = false;

var goodsNextIndex = 0;

var ConfrimBoxTimeLastSecond = false;   //更新倒计时提示框时间的时候判断是否为最后一秒

var isAgencyPrice = false;

function CommomAjax(options) {
    var methodType = options.methodType == undefined ? "get" : options.methodType;
    $.ajax({
        url: options.url,
        type: methodType,
        data: options.data,
        success: options.success,
        error: function (ex) { }
    });
}
function InitialURL(controller, action) {
    var url = window.location.protocol + "//" + window.location.hostname + ":" + window.location.port + "/" + controller + "/" + action;
    return url;
}
function GetPrice() {
    var min = parseInt($("#GoodsLowestAmplitude").val());
    var money = parseInt($("#CurrentPrice").text());
    var bidder = $("#Bidder").text();
    if (bidder.length === 0) {
        return money;
    } else {
        return min + money;
    }
}

function GetPriceByTJ() {
    var price = parseInt($("#PriceText").val());
    var money = parseInt($("#CurrentPrice").text());
    return price + money;
}


function IsCurrentNick() {
    return $("#NickName").val().toLowerCase() === $("#Bidder").text().toLowerCase();
}


$(function () {
    $.ajaxSetup({ cache: false });

    if (parseInt($("#CountdownSecondInput").val()) <= 0) {
        $("#BidButton").css('background-image', "url(../../image/cj_bg_false.gif)")
        $("#CountdownSecondText").text("已结束");
        $(".cjq").empty().append($("<p style='text-align:center; font-size:24px; margin-top:20px;'>竞价已结束</p>"));
    }

    second = $("#CountSecond").val();
    IsCurrentGoodsEnabledBid = $("#IsCurrentGoodsEnabledBid").val();
    if (second > 0) {
        if (null != setTimeConfrimBox) {
            clearInterval(setTimeConfrimBox);
        }
        setTimeConfrimBox = setInterval(UpdateConfrimBoxTime, 1000);
    } else {
        $("#CountdownSecondBox").hide();

    } if ((IsCurrentGoodsEnabledBid.toLowerCase() === "true")) {
        $("#CountdownSecondBox").hide();
        //开始商品页面倒计时
        isStartGoodsBid = true;
        StartGoodsCountdownSecondInPage();
        if (parseInt($("#CountdownSecondInput").val()) > 0)
            $("#BidButton").css('background-image', "url(../../image/cj_bg.jpg)")
    } else {
        $("#CountdownSecondBox").hide();

    }

    //出价按钮事件
    $("#ButtonBid").live("click", function () {
        var re = new RegExp("false", "g");
        var goodsId = $(this).attr("GoodsId");
        var minPrice = GetPrice();

        //可以竞价
        if ($(this).css('background-image').match(re) === null) {
            if ($("#NickName").val().length == 0) {
                alert("您现在处于未登录状态,请您先登录.");
                return false;
            }
            if (parseInt($("#BailMoney").val()) == 0) {
                alert("您未缴纳竞拍保证金,请您先联系工作人员，缴纳竞拍保证金.");
                return false;
            }
            if (IsCurrentNick() === true) {
                alert("您已经是目前的最高价,不能再出价.");
                return false;
            }
            var price = parseInt($("#CurrentPrice").val());
            var min = parseInt($("#GoodsLowestAmplitude").val());
            var option = {
                url: InitialURL("DDGoods", "BidDDGoods"),
                data: { goodsId: goodsId, price: minPrice },
                success: SuccessBidGoodsInforByAjax,
                error: ErrorBidGoodsInforByAjax,
                type: "get"
            };
            CommomAjax(option);
        }
    });


    //跳价按钮事件
    $("#TiaoJiaButton").live("click", function () {
        var re = new RegExp("false", "g");
        var goodsId = $(this).attr("GoodsId");
        var price = GetPriceByTJ();
        //可以竞价
        if ($("#ButtonBid").css('background-image').match(re) === null) {
            if ($("#NickName").val().length == 0) {
                alert("您现在处于未登录状态,请您先登录.");
                return false;
            }
            if (parseInt($("#BailMoney").val()) == 0) {
                alert("您未缴纳竞拍保证金,请您先联系工作人员，缴纳竞拍保证金.");
                return false;
            }
            var min = parseInt($("#GoodsLowestAmplitude").val());
            var pricetext = parseInt($("#PriceText").val());
            if (pricetext < min) {
                alert("跳价必须大于最低加价幅度(该商品的最低加价幅度是：" + min.toString() + "元).");
                return false;
            }
            if (IsCurrentNick() === true) {
                alert("您已经是目前的最高价,不能再出价.");
                return false;
            }
            var option = {
                url: InitialURL("DDGoods", "BidDDGoods"),
                data: { goodsId: goodsId, price: price },
                success: SuccessBidGoodsInforByAjax,
                error: ErrorBidGoodsInforByAjax,
                type: "get"
            };
            CommomAjax(option);
        } else {
            alert("该商品目前不能竞价.");
        }
    });

    $("#PriceAdd").click(function () {
        var price = parseInt($("#PriceText").val());
        $("#PriceText").val((price += 100).toString());
    });

    $("#PriceMinus").click(function () {
        var price = parseInt($("#PriceText").val());
        price = price - 100 >= 0 ? price - 100 : 0;
        $("#PriceText").val(price);
    });

    $("#AgencyPriceButton").click(function () {
        var re = new RegExp("false", "g");
        if ($("#ButtonBid").css('background-image').match(re) === null) {
            if ($("#NickName").val().length == 0) {
                alert("您现在处于未登录状态,请您先登录.");
                return false;
            }
            if (parseInt($("#BailMoney").val()) == 0) {
                alert("您未缴纳竞拍保证金,请您先联系工作人员，缴纳竞拍保证金.");
                return false;
            }
            if (isAgencyPrice === true) {
                alert("您已经启用了代理.");
            }
            var agprice = parseInt($("#PriceText").val());
            var currprice = parseInt($("#CurrentPrice").text());

            if (isAgencyPrice === false && agprice > currprice) {
                isAgencyPrice = true;
                alert("代理成功,最高代理出价是：" + $("#PriceText").val());
            } else {
                alert("代理价格必须大于当前价");
            }
        } else {
            alert("该商品目前不能竞价.");
        }
    });
});

function UpdateConfrimBoxTime_Text(_sec) {
    if (ConfrimBoxTimeLastSecond !== true && _sec >= 0) {
        var str = "";
        var day = parseInt((_sec / (60 * 60 * 24)).toString());
        str += (day < 10 ? '0' + day.toString() : day.toString()) + '天';
        str += GetCountdownSecondByText(_sec);
        $("#Second").text(str);
    }
    if (_sec === 0)
        ConfrimBoxTimeLastSecond = true;
}

function UpdateConfrimBoxTime() {
    if (second === 0) {
        isStartGoodsBid = true;
        IsCurrentGoodsEnabledBid = "true";
        //开始商品页面倒计时
        StartGoodsCountdownSecondInPage();
        clearInterval(setTimeConfrimBox);
    } else {
        UpdateConfrimBoxTime_Text(second);
        --second;
    }
}

function GetCountdownSecondByText(_second) {
    var str = "";
    var day = parseInt((_second / (60 * 60 * 24)).toString());
    var hours = parseInt((_second > (60 * 60 * 24) ? (_second - (day * 60 * 60 * 24)) : _second) / (60 * 60).toString());
    str += (hours < 10 ? '0' + hours.toString() : hours.toString()) + ':';
    var min = parseInt(((_second > (hours * 60 * 60 + (60 * 60 * 24 * day)) ? (_second - (hours * 60 * 60 + (60 * 60 * 24 * day))) : _second) / 60).toString());
    min = min < 0 ? 0 : min;
    str += (min < 10 ? '0' + min.toString() : min.toString()) + ':';
    var se = _second % 60;
    str += (se < 10 ? '0' + se.toString() : se.toString());
    return str;
}

//开始商品页面倒计时
function StartGoodsCountdownSecondInPage() {

    if ((IsCurrentGoodsEnabledBid.toLowerCase() === "true") && (isStartGoodsBid === true)) {
        var first = $("#CountdownSecondInput");
        //console.log($(first).val());
        if (parseInt($(first).val()) > 0) {
            if (null != setTimeByPlusCountdownSecond) {
                clearInterval(setTimeByPlusCountdownSecond);
            }
            setTimeByPlusCountdownSecond = setInterval(PlusCountdownSecond, 1050);
        }
    }
}


//开始获取竞价商品的信息
function AjaxGetGoodsBidRequest() {
    var goodsId = $("#GoodsId").val();
    if ((IsCurrentGoodsEnabledBid.toLowerCase() === "true") && (isStartGoodsBid === true)) {
        var option = {
            url: InitialURL("DDGoods", "GetDDGoodsInforByIdInDetailsPage"),
            data: { ddGoodsId: goodsId },
            success: SuccessUpdateGoodsInforByAjax,
            error: ErrorUpdateGoodsInforByAjax,
            type: "get"
        };
        CommomAjax(option);
    }
}



//刷新商品竞拍时间
function PlusCountdownSecond() {

    UpdateConfrimBoxTime_Text(0); //更新倒计时提示框时间的时候为0
    $("#CountdownSecondBox").hide();
    var _second = parseInt($("#CountdownSecondInput").val());
    //如果当前商品的竞拍时间结束，下一个商品变为可竞拍
    if (_second === 0) {

        //清楚当前获取当前商品信息的句柄
        clearInterval(setTimeByGetGoodsInfor);
        clearInterval(setTimeByPlusCountdownSecond);
        //如果商品竞拍完，结束线程
        //if ($("#NextGoodsId").val().toLowerCase() !== "end")
        //    window.location.href = InitialURL("Goods", "Details") + "?goodsId=" + $("#NextGoodsId").val();
        //else
        //    alert("当前场次的所有商品已经全部竞价完毕.");
    }
    else {
        --_second;
        $("#CountdownSecondInput").val(_second);
        $("#CountdownSecondText").text(GetCountdownSecondByText(_second));
        //开启获取竞价商品的信息的线程
        if (setTimeByGetGoodsInfor === null) {
            if (null != setTimeByGetGoodsInfor) {
                clearInterval(setTimeByGetGoodsInfor);
            }
            setTimeByGetGoodsInfor = setInterval(AjaxGetGoodsBidRequest, 2000);
        }
    }
}

function ErrorUpdateGoodsInforByAjax(data) {
    console.log("error" + data);
}

function SuccessUpdateGoodsInforByAjax(data) {
    if (data.Successful == true) {
        if (IsCurrentGoodsEnabledBid == "false") {
        }

        $("#CurrentPrice").text(data.CurrentPrice);
        $("#Bidder").text(data.Bidder == null ? "" : data.Bidder);
        var body = $("#HisTBody");
        $(body).empty();
        for (var i = 0; i < data.History.length; i++) {
            var html = "<tr>";
            html += "<td><span>" + data.History[i].BidderName + "</span></td>";
            html += "<td><span>" + data.History[i].BidPrice + "</span></td>";
            html += "<td><span>" + data.History[i].BidTime + "</span></td>";
            html += "</tr>";
            $(html).appendTo($("#HisTBody"));
        }
        //如果有代理出价
        //if (isAgencyPrice === true) {
        //    var price = parseInt($("#PriceText").val());
        //    var min = parseInt($("#GoodsLowestAmplitude").val());
        //    var goodsid = $("#AgencyPriceButton").attr('goodsid');
        //    if (data.CurrentPrice < price) {
        //        var currPrice = data.CurrentPrice + min;
        //        var option = {
        //            url: InitialURL("DDGoods", "BidDDGoods"),
        //            data: { goodsId: goodsid, price: currPrice },
        //            success: SuccessBidGoodsInforByAjax,
        //            error: ErrorBidGoodsInforByAjax,
        //            type: "get"
        //        };
        //        CommomAjax(option);
        //    } else {
        //        isAgencyPrice = false;
        //    }
        //}
    } else if (data.Successful == false && data.Sync == false) {
        //alert("由于网络延时，您目前竞拍的有些商品实际已经结束竞拍, 请您重新刷新页面同步正在竞拍的商品.");
        window.location.href = window.location.href;
    }

}


function ErrorBidGoodsInforByAjax(data) {
    console.log("error" + data);
}

function SuccessBidGoodsInforByAjax(data) {
    if (data.Successful == true) {
        $("#CountdownSecondInput").val(parseInt($("#CountdownSecondInput").val()));
        $("#CountdownSecondText").text(GetCountdownSecondByText(parseInt($("#CountdownSecondInput").val())));
        $("#CurrentPrice").text(data.CurrentPrice);
        $("#Bidder").text(data.Bidder == null ? "" : data.Bidder);
    } else if (data.Successful == false && data.sync == false) {
        alert("由于网络延时，您目前竞拍的商品实际已经结束竞拍, 请您重新刷新页面同步正在竞拍的商品.");
        window.location.reload();
    }
}