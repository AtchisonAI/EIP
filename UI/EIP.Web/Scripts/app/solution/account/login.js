﻿var currentindex = 1,
    timerID,
    method = {
        //绑定事件
        bindEvent: function () {
            $("#flashBg").css("background", $("#flash1").attr("name"));

            $(".flash_bar div").mouseover(function () {
                method.stopAm();
            }).mouseout(function () {
                method.startAm();
            });

            $("#btnSubmit,#btnTempLogin").mousemove(function () {
                $(this).addClass("btn-submit-over");
            }).mouseout(function () {
                $(this).removeClass("btn-submit-over");
            });

            $("#btnSubmit").click(function () {
                method.submit();
            });
            $("#loginAsTem").click(function () {
                method.loginAsTemp();
            });



            $("#userCode,#userPwd").bind("keypress", function (event) {
                if (event.keyCode == "13") {
                    method.submit();
                }
            });
        },

        submit: function () {
            var code = $("#userCode").val();
            var pwd = $("#userPwd").val();
            if (code === "") {
                $("#userCode").focus();
                formMessage(Language.login.noname, 'warning');
                return;
            }
            if (pwd === "") {
                $("#userPwd").focus();
                formMessage(Language.login.nopwd, 'warning');
                return;
            }

            formMessage(Language.login.loginwait, 'succeed');

            $(this).attr("disabled", "disabled");
            $.post("/Account/Submit",
                {
                    code: code,
                    pwd: pwd,
                    remberme: $("#remember").prop("checked"),
                    returnUrl: $("#returnHidden").val()
                },
                function (data) {
                    var resultType = data.ResultSign;
                    var resultMsg = data.Message; //--------跳转地址
                    $("#btnSubmit").removeAttr("disabled");
                    if (resultType === 2) {
                        formMessage(resultMsg, 'error');
                    } else {
                        formMessage('登录验证成功,正在跳转首页', 'succeed');
                        setInterval(Load(resultMsg), 1000);
                    }
                }, "json").success(function () {//成功

                }).error(function () {//失败
                    formMessage("登录失败,请稍后重试", 'error');
                }).complete(function () {//完成
                });
        },
        loginAsTemp: function () {
            $("#userCode").val('rptuser');
            $("#userPwd").val('123456');
            method.submit();
        },
        //改变滚动
        changeflash: function (i) {
            currentindex = i;
            for (var j = 1; j <= 3; j++) {
                if (j == i) {
                    $("#flash" + j).fadeIn("slow");
                    $("#flash" + j).css("display", "block");
                    $("#f" + j).removeClass();
                    $("#f" + j).addClass("dq");
                    $("#flashBg").css("background", $("#flash" + j).attr("name"));
                }
                else {
                    //$("#flash" + j).css("display", "none");
                    $("#flash" + j).fadeOut("slow");
                    $("#f" + j).removeClass();
                    $("#f" + j).addClass("no");
                }
            }
        },

        //滚动
        startAm: function () {
            timerID = setInterval("method.timerTick()", 3000);
        },

        //记时器
        timerTick: function () {
            currentindex = currentindex >= 3 ? 1 : currentindex + 1;
            method.changeflash(currentindex);
        },

        //停止滚动
        stopAm: function () {
            clearInterval(timerID);
        },

        //获取登录幻灯片
        getLoginSlideList: function () {
            var flashhtml = "", flashbarhtml = "";
            $.ajax({
                url: "/Account/GetLoginSlideList", // 跳转到地址    
                data: {},
                type: "post",
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.ResultSign === 0) {
                        $.each(data.Data, function (i, item) {
                            i = i + 1;
                            var cla = i == 1 ? "dq" : "no";
                            flashhtml += ' <a href="#" id="flash' + i + '" style="display: block;"><img src="' + item.Src + '" width="980" height="393"></a>';
                            flashbarhtml += '<div class="' + cla + '" id="f' + i + '" onclick=" method.changeflash(' + i + ') "></div>';
                        });
                        $("#flash").html(flashhtml + ' <div class="flash_bar">' + flashbarhtml + '</div>');
                    } else {
                        formMessage(data.Message, 'error');
                    }
                },
                error: function () {
                    formMessage("获取登录幻灯片,请稍后重试", 'error');
                }
            });
        },

        relocationLoginForm: function () {
            $(window).resize(function () {
                $('#login').css('left', $('#main').width() * 0.65);
            });
        }
    }

$(document).ready(function () {
    $('#login').css('left', $('#main').width()*0.65);
    method.getLoginSlideList();
    $("#userCode").focus();
    method.bindEvent();
    method.startAm();
    method.relocationLoginForm();
});


//登录加载
function Load(url) {
    window.location.href = url;
    return false;
}
//提示信息
function formMessage(msg, type) {
    $('.form-message').html('');
    $('.form-message').append('<div class="form-' + type + '-text" title="' + msg + '">' + msg + '</div>');
}