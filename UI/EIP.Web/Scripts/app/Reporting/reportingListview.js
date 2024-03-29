﻿//页面初始化执行
var $grids, $charts;
function initOnDocumentReady() {
    $(document).ajaxError(function (e, xhr, opt) {
        DialogCloseTipsMsgWait();
        DialogTipsMsgError(xhr.responseText, 5000);
    });

    $(document).ajaxSuccess(function (e, xhr, opt) {
        DialogCloseTipsMsgWait();
    });

    $grids = $('.grid');
    $charts = $('.chart');
    initCharts();
    //搜索
    $("[name='btn_select_box']").click(function () {
        DialogTipsMsgWait(Language.common.wait);
        if (typeof ValidateInput != 'undefined' && ValidateInput instanceof Function) {
            if (ValidateInput() == false) {
                DialogCloseTipsMsgWait();
                return false;
            }
        }


        if (typeof BeforeSearchClick != 'undefined' && BeforeSearchClick instanceof Function) {
            if (BeforeSearchClick() == false) {
                return true;
            }
        }
        var $this = $(this);
        search($this.parents('form'));

        if (typeof AfterSearchClick != 'undefined' && AfterSearchClick instanceof Function) {
            AfterSearchClick();
        }
    });

    //重置
    $("[name='btn_reset_box']").click(function () {

        if (typeof ResetBefore != 'undefined' && ResetBefore instanceof Function) {
            if (ResetBefore() === false) {
                return true;
            }
        }

        clearCondition($(this));
        clearGrids();
        clearCharts();

        if (typeof AdditionalReset != 'undefined' && AdditionalReset instanceof Function) {
            AdditionalReset();
        }
        //search($selectbox);
    });

    //回车进行查询
    document.onkeydown = function (e) {
        var ev = document.all ? window.event : e;
        if (ev.keyCode === 13) {
            var select = $("[name='btn_select_box']");
            if (select.length > 0) {
                search($(select[0]).parent());
            }
        }
    }
}

function clearCharts() {

    if (typeof $charts != 'undefined') {
        $charts.each(function () {
            var chart = echarts.getInstanceByDom(document.getElementById($(this).attr('id')));
            chart.clear();
        });
    }
}

function initCharts() {

    if (typeof $charts != 'undefined') {
        $charts.each(function () {
            var chart = echarts.init(document.getElementById($(this).attr('id')));
        });
    }
}

function clearGrids() {

    if (typeof $grids != 'undefined') {
        $grids.each(function () {
            $(this).jqGrid("clearGridData");
        });
    }
}

function clearCondition(button) {

    var $this = button;
    var $selectbox = $this.parents('form');
    $('.filter', $selectbox).each(function () {
        $(this).val("");
    });

    $('.manualfilter:not(.select2,input[type="radio"])', $selectbox).each(function () {
        $(this).val("");
    });

    var selects = $('.manualfilter.select2', $selectbox);
    $.each(selects, function () {
        $(this).val(null).trigger('change');
    });


}

//查询
function search($selectbox) {

    var filters = getFilters($selectbox);
    var manualFilters = getManulFilters($selectbox);
    //获取列表参数
    if (typeof $grids != 'undefined' && $grids.length >0) {
        $grids.each(function () {
            var gridParam = $(this).getGridParam();
            $(this).jqGrid('setGridParam', { datatype: 'json' });
            //是否是一次性加载
            if (gridParam.loadonce) {
                var postData = $(this).getGridParam('postData');
                $.extend(postData, { filters: filters });
                $.extend(postData, manualFilters);
                $(this).setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]); // must search true
            }
            //否则远程加载
            else {
                $.extend($(this).getGridParam('postData'), { filters: filters });
                $.extend($(this).getGridParam('postData'), manualFilters);
                $(this).trigger("reloadGrid", [{ page: 1 }]);
            }
        });
    } else {

        DialogCloseTipsMsgWait();
    }
  
}

//获取表单条件:需在查询框前指定查询类型(模糊、准确等)
function getFilters($selectbox) {
    var rules = "";
    $('.filter', $selectbox).each(function () {
        var searchField = $(this).attr("name"),
            searchOper = $(this).prev().val(),
            searchString = $(this).val();
        (searchField && searchOper && searchString) && (rules += (',{"field":"' + searchField + '","op":"' + searchOper + '","data":"' + searchString + '"}'));
    });
    rules && (rules = rules.slice(1));
    var filtersStr = '{"groupOp":"AND","rules":[' + rules + ']}';
    return filtersStr;
}


function getManulFilters($selectbox) {
    var o = {};
    var a = $('.manualfilter:not(.select2,input[type="checkbox"])', $selectbox).serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value;
        }
    });


    var b = $('.manualfilter:input[type="checkbox"]', $selectbox);
    $.each(b, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
                o[this.name].push($(this).prop('checked'));
        } else {
            
            o[this.name] = $(this).prop('checked');
        }
    });
    // 

    var selects = $('.manualfilter.select2', $selectbox);
    $.each(selects, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            if ($(this).val() !== null)
                if (Array.isArray($(this).val()))
                    o[this.name].push($(this).val().join("','"));
                else
                    o[this.name].push($(this).val());

            else
                o[this.name].push('');
        } else {
            if ($(this).val() !== null)
                if (Array.isArray($(this).val()))
                    o[this.name] = $(this).val().join("','");
                else
                    o[this.name] = $(this).val();
            else
                o[this.name] = '';
        }
    });

    return o;
}

//==========================自定义格式化====================================

// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}  


//时间(年月日时分秒)格式
$.fn.fmatter.datetime = function (cellval, opts, rwd, act) {
    var op = $.extend({}, opts.date);
    return cellval == null ? "" : $.jgrid.parseDate("Y-m-d H:i:s", cellval, "Y-m-d H:i:s", op);
};

//图标
$.fn.fmatter.icon = function (cellval, opts, rwd, act) {
    if (cellval != "" && cellval != null) {
        return '<span><div class="l-icon" style="margin: 0 auto;background: url(\'/Contents/images/icons/' + cellval + '.png\') no-repeat center;"></div></sapn>';
    }
    return "";
};

//性别男/女图标显示格式化
$.fn.fmatter.sex = function (cellval, opts, rwd, act) {
    if (cellval == true) {
        return '<span><div class="l-icon l-icon-user-green" title="男" style="margin: 0 auto;"></div></sapn>';
    } else {
        return '<span><div class="l-icon l-icon-user-red-female" title="女" style="margin: 0 auto;"></div></sapn>';
    }
};

//冻结/启用图标显示格式化
$.fn.fmatter.state = function (cellval, opts, rwd, act) {
    if (cellval == true) {
        return '<span><div class="l-icon l-icon-checknomark" title="冻结" style="margin: 0 auto;"></div></sapn>';
    } else {
        return '<span><div class="l-icon l-icon-checkokmark" title="开启" style="margin: 0 auto;"></div></sapn>';
    }
};

//是/否图标显示格式化
$.fn.fmatter.YesOrNo = function (cellval, opts, rwd, act) {
    if (cellval == true) {
        return '<span><div class="l-icon l-icon-checkokmark" title="是" style="margin: 0 auto;"></div></sapn>';
    } else {
        return '<span><div class="l-icon l-icon-checknomark" title="否" style="margin: 0 auto;"></div></sapn>';
    }
};


//email格式
$.fn.fmatter.Email = function (cellval, opts, rwd, act) {
    if (cellval != "" && cellval != null) {
        return '<span title="点击给' + cellval + '发送邮件"><a href="mailto:' + cellval + '">' + cellval + '</a></sapn>';
    }
    return "";
};

//编辑删除点击格式化
$.fn.fmatter.upOrdel = function (cellvalue, options, rowObject) {
    return "<div title='编辑' class=\"l-icon-jqgrid l-icon l-icon-edit \" onclick=\"editor(" + options.rowId + ")\"></div><div title='删除' style=\"margin-left:11px\" class=\"l-icon l-icon-delete l-icon-jqgrid\" onclick=\"del(" + options.rowId + ");\"></div>";
};

//删除点击格式化
$.fn.fmatter.del = function (cellvalue, options, rowObject) {
    return "<div title='删除' style=\"margin-left:11px\" class=\"l-icon l-icon-delete l-icon-jqgrid\" onclick=\"del(" + options.rowId + ");\"></div>";
};

//编辑点击格式化
$.fn.fmatter.update = function (cellvalue, options, rowObject) {
    return "<div title='编辑' class=\"l-icon-jqgrid l-icon l-icon-edit \" onclick=\"editor(" + options.rowId + ")\"></div>";
};

//图片
$.fn.fmatter.image = function (cellvalue, options, rowObject) {
    return '<img height="90px" width="400px" title="' + rowObject.Title + '" border="0" src="' + cellvalue + '" onclick=" $("#Src").click(); ">';
};

//====流程相关===

//流程状态
$.fn.fmatter.workflowStatus = function (cellvalue, options, rowObject) {
    switch (cellvalue) {
        case 2://处理中
            break;
        case 4://已完成
            break;
        case 6://暂停中
            break;
        default:
    }
};

//流程紧急程度
$.fn.fmatter.workflowUrgency = function (cellvalue, options, rowObject) {
    switch (cellvalue) {
        case 2://正常
            return "<span class='font-green'>【正常】</span>";
        case 4://重要
            return "<span class='font-blue'>【重要】</span>";
        case 6://紧急
            return "<span class='font-red'>【紧急】</span>";
        default:
    }
};

//==============================================================

/**
 * 作用:给指定的Grid重新赋予高度和宽度
 * 参数:$grid:列表对象,width:需要减去的宽度,height:需要减去的高度
 */
function GridSetWindowWidthAndHeight($grid, width, height) {
    var size = UtilWindowHeightWidth();
    $grid.jqGrid("setGridWidth", size.WinW - width).jqGrid("setGridHeight", size.WinH - height);
};

/**
 * 作用:给指定的Grid重新赋予高度和宽度
 * 参数:$grid:列表对象,width:需要减去的宽度,height:需要减去的高度
 */
function GridSetWidthAndHeight($grid, width, height) {
    $grid.jqGrid("setGridWidth", width).jqGrid("setGridHeight", height);
};

/**
 * 作用:当界面加载完毕时若无数据则提示
 * 参数:$grid:列表对象
 */
function GridSetNoRecordsMsg($grid, msg) {
    $(".norecords").html("");
    var reRecords = $grid.getGridParam("records");
    if (reRecords === 0 || reRecords == null) {
        if (msg != "") {
            $("#list").parent().append("<div class=\"norecords\">" + msg + "</div>");
        }
        $(".norecords").show();
    } else {
        $(".norecords").hide();
    }
};

/**
 * 作用:重新加载Grid数据:一次性加载
 * 参数:$grid:列表对象,data:Json数据
 */
function GridReloadLoadOnceData($grid, data) {
    $(".norecords").hide();
    $grid.jqGrid("clearGridData", true);
    $grid.jqGrid("setGridParam", {
        datatype: "local",
        data: eval(data) //服务器返回的json格式，此处转换后给数据源赋值
    }).trigger("reloadGrid");
}; /**
 * 作用:重新加载Grid数据:分页
 * 参数:$grid:列表对象,data:Json数据
 */
function GridReloadPagingData($grid, param) {
    $(".norecords").hide();
    $grid.jqGrid("clearGridData", true);
    $grid.jqGrid("setGridParam", param).trigger("reloadGrid");
}; /**
 * 作用:获取选择一行的id，如果你选择多行，那下面的id是最后选择的行的id
 * 参数:$grid:列表对象
 */
function GridGetId($grid) {
    return $grid.jqGrid("getGridParam", "selrow");
}; /**
 * 作用:获取选择多行的id，那这些id便封装成一个id数组
 * 参数:$grid:列表对象
 */
function GridGetIds($grid) {
    return $grid.jqGrid("getGridParam", "selarrrow");
}; /**
 * 作用:获取选择的行的数据
 * 参数:$grid:列表对象
 */
function GridGetSingSelectData($grid) {
    return $grid.jqGrid("getRowData", $grid.jqGrid("getGridParam", "selrow"));
}; /**
 * 作用:指定某行选中
 * 参数:$grid:列表对象,rowId需要选中的行
 */
function GridSetSelection($grid, rowId) {
    $grid.jqGrid("setSelection", rowId);
}; /**
 * 作用:指定某行选中
 * 参数:$grid:列表对象,rowId需要获取的行数
 */
function GridGetRowData($grid, rowId) {
    return $grid.jqGrid("getRowData", rowId);
}; /**
 * 作用:表格是否选中
 * 参数:$grid:列表对象,method选中后执行方法
 */
function GridIsSelect($grid, method) {
    if (GridGetId($grid) == null) {
        DialogTipsMsgWarn("请选择需要操作的数据", 1000);
    } else {
        method();
    }
};

/**
* 作用:表格所有选中值Id,以逗号分割:如删除使用
* 参数:$grid:列表对象,key:主键名称
*/
function GridSelectIds($grid, key) {
    var ids = "";
    var rowData = $grid.jqGrid("getGridParam", "selarrrow");
    if (rowData.length) {
        for (var i = 0; i < rowData.length; i++) {
            var name = $grid.jqGrid('getCell', rowData[i], key); //name是colModel中的一属性
            ids += name + ",";
        }
    }
    return ids;
}