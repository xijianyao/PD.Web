var second = 0;    //距离该场次开拍倒计时的秒数

var setTimeConfrimBox = null               //刷新 提示场次开拍倒计时的时间间隔句柄
    , setTimeByPlusCountdownSecond = null  //页面递减竞价时间的句柄
    , setTimeByGetGoodsInfor = null        //获取商品信息的句柄
;

var isStartGoodsBid = false; //是否能够开始获取竞拍商品的信息，通过Ajax

var getGoodsInforByAjaxInterval = 3; //获取竞拍商品的信息的时间间隔

var currentShowPlaceEnabledBid = false;

var goodsNextIndex = 0;

var ConfrimBoxTimeLastSecond = false;   //更新倒计时提示框时间的时候判断是否为最后一秒

$(function () {
    $("#kinMaxShow").kinMaxShow({
        //设置焦点图高度(单位:像素) 必须设置 否则使用默认值 500    
        height: 236,
        //设置焦点图 按钮效果
        button: {
            //设置焦点图切换方式为mouseover 鼠标经过按钮切换图片, 默认为 click， 可选 click[鼠标点击切换]或mouseover[鼠标滑过切换]        
            switchEvent: 'mouseover',
            //设置显示 索引数字  true 显示， 默认为 false 不显示            
            showIndex: true,
            //按钮常规下 样式设置 ，css写法，类似jQuery的 $('xxx').css({key:value,……})中css写法。            
            //【友情提示：可以设置透明度哦 不用区分浏览器 统一为 opacity，CSS3属性也支持哦 如：设置按钮圆角、投影等，只不过IE8及以下不支持】            
            normal: { width: '18px', height: '18px', lineHeight: '18px', left: '16px', bottom: '16px', fontSize: '12px', opacity: 0.8, background: "#666666", border: "1px solid #999999", color: "#CCCCCC", marginRight: '6px' },
            //当前焦点图按钮样式 设置，写法同上            
            focus: { background: "#CC0000", border: "1px solid #FF0000", color: "#000000" }
        }
    });
});
function CommomAjax(options) {


    var methodType = options.methodType == undefined ? "get" : options.methodType;
    $.ajax({
        url: options.url,
        type: methodType,
        data: options.data,
        success: options.success,
        error: function (ex) {  }
    });
}
function InitialURL(controller, action) {
    var url = window.location.protocol + "//" + window.location.hostname + ":" + window.location.port + "/" + controller + "/" + action;
    return url;
}
function GetPrice(goodsIndex) {
    var min = parseInt($("#GoodsLowestAmplitude").val());
    var money = parseInt($($(".cj_moneytext").get(goodsIndex)).text());
    var bidder =$($(".bidder").get(goodsIndex)).text() ;
    if (bidder.length === 0) {
        return money;
    } else {
        return min + money;
    }
}

function PreparPageDom() {

        $(".BidButton").css('background-image', "url(../../image/cj_bg.jpg)");
        $("#CountdownSecondBox").hide();
}

function IsCurrentNick(obj) {
    return $("#NickName").val().toLowerCase() === $(".bidder",$(obj)).text().toLowerCase();
}

$(function () {
    $.ajaxSetup({ cache: false })

    second = $("#CountSecond").val();
    currentShowPlaceEnabledBid = $("#ShowPlaceEnabledBid").val();
    if (second > 0) {
        if (null != setTimeConfrimBox) {
            clearInterval(setTimeConfrimBox);
        }
        setTimeConfrimBox = setInterval(UpdateConfrimBoxTime, 1000);
    } else {
        PreparPageDom();
    }
    if ((currentShowPlaceEnabledBid.toLowerCase() === "true")) {

        //开始商品页面倒计时
        isStartGoodsBid = true;
        StartGoodsCountdownSecondInPage();
        PreparPageDom();
    } else {
        $(".BidButton").css("background-image", "url(../../image/cj_bg_false.gif)");
    }

    $(".BidButton").live("click", function () {
        var re = new RegExp("false", "g");
        var goodsId = $(this).attr("GoodsId");
        var price = GetPrice($(".BidButton").index(this));
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
            if (IsCurrentNick($(this).parents("div.auction_content")) === true) {
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
        PreparPageDom();
        isStartGoodsBid = true;
        currentShowPlaceEnabledBid = "true";
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

    if ((currentShowPlaceEnabledBid.toLowerCase() === "true") && (isStartGoodsBid === true)) {

        if (null != setTimeByPlusCountdownSecond) {
            clearInterval(setTimeByPlusCountdownSecond);
        }
        setTimeByPlusCountdownSecond = setInterval(PlusCountdownSecond, 1000);
    }
}


//开始获取竞价商品的信息
function AjaxGetGoodsBidRequest() {
    var goodsIds = '';
    $(".DDGoodsId").each(function () {
        goodsIds += $(this).val() + '|';
    });
    if ((currentShowPlaceEnabledBid.toLowerCase() === "true") && (isStartGoodsBid === true)) {
        var option = {
            url: InitialURL("DDGoods", "GetDDGoodsInforByIdInListPage"),
            data: { ddGoodsIds: goodsIds },
            success: SuccessUpdateGoodsInforByAjax,
            error: ErrorUpdateGoodsInforByAjax,
            type: "get"
        };
        CommomAjax(option);
    }
}



//刷新商品竞拍时间
function PlusCountdownSecond() {

    var _second = parseInt($("#EndBidCountdownSecond").val());
    UpdateConfrimBoxTime_Text(0); //更新倒计时提示框时间的时候为0
    $("#CountdownSecondBox").hide();
    //如果当前商品的竞拍时间结束，下一个商品变为可竞拍
    if (_second === 0) {

        //清楚当前获取当前商品信息的句柄
        clearInterval(setTimeByGetGoodsInfor);

        //如果所有商品都以竞拍完，结束线程
        clearInterval(setTimeByPlusCountdownSecond);
        $(".BidButton").css("background-image", "url(../../image/cj_bg_false.gif)");
    }
    else {
        --_second;
        $(".CountdownSecondText").each(function () {
            $(this).text(GetCountdownSecondByText(_second));
        });
        $("#EndBidCountdownSecond").each(function () {
            $(this).val(_second);
        });
        //开启获取竞价商品的信息的线程
        if (null == setTimeByGetGoodsInfor) {
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
        for (var i = 0; i < data.Info.length; i++) {
            $($(".cj_moneytext")
            .filter(function () { return $(this).attr('GoodsId') == data.Info[i].GoodsId; })).text(data.Info[i].CurrentPrice);
            $($(".bidder")
            .filter(function () { return $(this).attr('GoodsId') == data.Info[i].GoodsId; })).text(data.Info[i].Bidder == null ? "" : data.Info[i].Bidder);
        }
    } else if (data.Successful == false && data.Sync == false) {
        alert("由于网络延时，您目前竞拍的有些商品实际已经结束竞拍, 请您重新刷新页面同步正在竞拍的商品.");
        window.location.href = window.location.href;
    }

}


function ErrorBidGoodsInforByAjax(data) {
    console.log("error" + data);
}

function SuccessBidGoodsInforByAjax(data) {
    if (data.Successful == true) {

        $($(".cj_moneytext")
            .filter(function () { return $(this).attr('GoodsId') == data.GoodsId; })).text(data.CurrentPrice);
        $($(".bidder")
            .filter(function () { return $(this).attr('GoodsId') == data.GoodsId; })).text(data.Bidder == null ? "" : data.Bidder);
    } else if (data.Successful == false && data.Sync == false) {
        alert("由于网络延时，您目前竞拍的商品实际已经结束竞拍, 请您重新刷新页面同步正在竞拍的商品.");
        window.location.href = window.location.href;
    }
}