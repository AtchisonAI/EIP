﻿define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        initRadio();
        size = UtilWindowHeightWidth();
        ChartPointCheck();

    });

function ChartPointCheck() {

    var myChart = echarts.getInstanceByDom(document.getElementById('Chart'));

    myChart.on('click', function (params) {

        clickedBar = new Object();
        //clickedBar.labtype = params.seriesName;
        clickedBar.chktime = params.name;
        var StartTime = $('#StartTime').val();
       // var ByDate = $('input[type=radio][name=ByDate]').val;
        var ByDate = $("input[name='ByDate']:checked").val();
            
        $("#list").jqGrid('setGridParam', { datatype: 'json' });
        var postData = $("#list").getGridParam('postData');
        $.extend(postData, { Stage: clickedBar.chktime, StartTime: StartTime, ByDate: ByDate});
        $("#list").setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]);

    });
}



function initRadio() {
    $('input[type=radio][name=ByDate]').change(function () {
        var $startTime = $('#StartTime');
   
        $startTime.attr("disabled", true);
        $startTime.removeAttr('style');
        if (this.value === '1') {
            $startTime.attr("disabled", true);
            $startTime.removeAttr('style');      
        }

        if (this.value === '2') {
            $startTime.attr("disabled", false);
            $startTime.css("background-color", 'white');
        }

      

    });
}


function initSelect() {

    $("#selProduct").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入产品！",
        //maximumSelectionLength: 1,  //设置最多可以选择多少项
        //multiple: true,//设置是否可以多选
        allowClear: true,//允许清空

        ajax: {
            url: "/Common/Common/QueryProductSelectList",// /Common 文件夹名，/common controllers名字，/query..方法名字 获取数据的地址
            dataType: 'json',
            delay: 250,//按键之后多久才提交后台进行查询
            data: function (params) {//查询参数
                return {
                    StateGrp: params.term,//获取输入，提交后台
                    page: params.page || 1//当前页数
                };
            },
            processResults: function (result, params) {//获取到后台数据后，进行解析
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data,
                        pagination: {
                            more: (params.page * 10) < result.totalCount//分页条件：当前已显示数量<总数
                        }
                    };
                } else {
                    return {
                        results: null
                    };
                }
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });
}

var size;//宽高

//提交流程
//ValidateInput
//如果 ValidateInput 返回 true
//  BeforeSearchClick
//  如果 BeforeSearchClick 返回 true
//      自动执行获取条件
//      自动执行所有class为grid的元素的reload事件
//      AfterSearchClick
function ValidateInput() {
    //客户端条件验证，如果不通过，返回false

   // var byDate = new ($('#ByDate').val());
    //if (byDate == '2') {
       // var fromTime = new Date($('#StartTime').val());
    //    if (fromTime == null) {
    //        DialogTipsMsgError('请选择Daily 时间!', 5000);
    //        $('#StartTime').focus();
    //        return false;
    //    }
    //}
    if ($('#selProduct').val() === null || $('#selProduct').val().length ===0) {
        DialogTipsMsgError('请选择需要查询的产品!', 5000);
        $('#selProduct').focus();
        return false;
    }
}



function AdditionalReset() {

    $('#rdoUpToNow').prop('checked', 'checked');
}


function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false

    clearGrids();
    clearCharts();
    initChart();
   // $("#list").jqGrid('setGridParam', { datatype: 'local' });
   // return true;
    return false;
}

function loadGraph(data, ChartName) {
    // 基于准备好的dom，获取echarts实例
    var myChart = echarts.init(document.getElementById(ChartName));
    myChart.setOption(data);
    //// 基于准备好的dom，获取echarts实例
    //var myChart1 = echarts.getInstanceByDom(document.getElementById('MTDChart'));
    //myChart1.setOption(data2);
    //data.echarts.Series

    myChart.on('click', function (params) {

        clickedBar = new Object();
        clickedBar.labtype = params.seriesName;
        //var chktime = params.name;
        //alert(achktime.replace("/", ""));
        clickedBar.chktime = params.name;

        // clickedBar.ChartName = ChartName;
        ShowDetails();
    });

}

//初始化表格
function initGird() {
    $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: true,
            shrinkToFit: false,
            pager: 'pager',
            url: '/Reporting/WIPProfile/QueryWIPData',
            colModel: [
                {
                    label: "LOT", name: "APPID", index: "LOT.APPID", width: 130, fixed: true,
                    formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showLotForecast(\"" + rowdata.APPID + "\")' ><font color='blue'><u>" + rowdata.APPID + "</u></blue></a>";
                    }
                },
             //   { label: "PRODUCT", name: "PRODUCTID", width: 130, fixed: false },
                { label: "STAGE", name: "STAGENAME", width: 130, fixed: true },
                { label: "STEPSEQ", name: "STEPSEQ", width: 150, fixed: true },
                { label: "STEPID", name: "STEPID", width: 150, fixed: true },
                { label: "EQPID", name: "LOCATION", width: 130, fixed: true },
                { label: "PROCESSOPERATION", name: "PROCESSOPERATIONID", width: 130, fixed: true },
                { label: "TRACKINQTY", name: "TRACKINQTY", width: 90, fixed: true },
                { label: "TRACKOUTQTY", name: "TRACKOUTQTY", width: 95, fixed: true },
              //  { label: "CAPABILITY", name: "CAPABILITY", width: 130, fixed: true },
                { label: "PRIORITY", name: "PRIORITY", width: 130, fixed: true },
                { label: "RECIPEID", name: "RECIPEID", width: 130, fixed: true },
                { label: "QT", name: "QUEUETIME", width: 130, fixed: true },
                { label: "RT", name: "RUNTIME", width: 130, fixed: true },
                { label: "HT", name: "HOLDTIME", width: 130, fixed: true },
                { label: "REASON", name: "REASON", width: 130, fixed: true },
                { label: "BRIEFDESCRIPTION", name: "BRIEFDESCRIPTION", width: 130, fixed: true }
            ],
            sortname: "LOT.APPID",
            height: '462px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
            }
        });

    

}

function showLotForecast(APPID) {
    ArtDialogOpen("/Reporting/WIPProfile/LotForecast?lotID=" + APPID, "Lot Forecast-" + APPID, true, 750, 1200, true);
}


function initChart() {
    var Product = $('#selProduct').val();
    var StartTime = $('#StartTime').val();
    var ByDate = $('#ByDate').val();
    //   var IsIncludeEngLots = $('#IsIncludeEngLots').check();

    $.ajax({
        url: '/Reporting/WIPProfile/QueryChartData',
        type: 'post',
        dataType: 'json',
        data: { Product: Product, StartTime: StartTime, ByDate: ByDate },
        success: function (data, status) {
            
            loadGraph(data, 'Chart');
        }
    });
}