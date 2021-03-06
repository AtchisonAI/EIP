﻿define(['reportingbootstrap'],
    function (abc) {
        initGird(); 
        if ($("#beginDate").val() == '') {
            initDataselect();
        }
        
        size = UtilWindowHeightWidth();
        if ($('#moduleHidden').val() !== '') {
            $('[name="ModuleCode"]').val($('#moduleHidden').val());
            $('[name="analysisUnit"]').val($('analysisUnitHidden').val());
            $("[name='btn_select_box']").click();
        }
    });

var $grid,
    size; //宽高

function windowResized() {
    if (typeof $grid != 'undefined')
        $grid.setGridWidth($('#listpnlbody').width());
}

function initDataselect() {
    var now = new Date();

    //格式化日，如果小于9，前面补0
    var day = ("0" + now.getDate()).slice(-2);
    //格式化月，如果小于9，前面补0
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    //拼装完整日期格式
    var today = now.getFullYear() + (month) + (day);
    var monthfirstday = now.getFullYear() + (month) + ("01");

    $("#beginDate").val(monthfirstday);
    $("#endDate").val(today);
}

/*function initChart(data,chart) {

    // 基于准备好的dom，初始化echarts实例
    barChart = echarts.init(document.getElementById('browserAnalysisBar'));
    lineChart = echarts.init(document.getElementById('browserAnalysisLine'));
    pieChart = echarts.init(document.getElementById('browserAnalysisPie'));
}*/

//初始化表格
function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype:"local",
            //multiselect: true,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/HoldLotHistoryDetailInfo/QueryHoldLotHistoryDetailInfo',
            colModel: [
                //lable字段解释 Employ ID为自定义名，name为后台SQL语句定义的表列的别名也可以是原名，index为数据库表列中的原名，可以带表的别名 
                { label: "Lot type", name: "LOTTYPE", index: "LOTTYPE", width: 100, fixed: true, align: 'center'},
                { label: "Area", name: "AREA", index: "AREA", width: 90, fixed: true, align: 'center'},
                { label: "Product ID", name: "PRODUCTID", index: "PRODUCTID", width: 100, fixed: true, align: 'center'},
                { label: "Lot ID", name: "LOTID", index: "LOTID", width: 90, fixed: true, align: 'center'},
                { label: "Stage Name", name: "STAGENAME", index: "STAGENAME", width: 100, fixed: true, align: 'center'},
                { label: "Step SEQ", name: "STEPSEQ", index: "STEPSEQ", width: 100, fixed: true, align: 'center'},
                { label: "Step Name", name: "STEPNAME", index: "STEPNAME", width: 130, fixed: true, align: 'center'},
                { label: "EQP ID", name: "EQID", index: "EQID", width: 100, fixed: true, align: 'center'},
                { label: "Priority", name: "PRI", index: "PRI", width: 60, fixed: true, align: 'center'},
                { label: "Quantity", name: "QTY", sortable: false, width: 60, fixed: true, align: 'center'},
                { label: "Hold Owner", name: "HOLDUSER", index: "HOLDUSER", width: 100, fixed: true, align: 'center'},
                { label: "Hold Module", name: "HOLDMODULE", index: "HOLDMODULE", width: 100, fixed: true, align: 'center'},
                { label: "Hold Time", name: "REP_EMPNO", index: "REP_EMPNO", width: 100, fixed: true, align: 'center'},
                { label: "Last Hold Time", name: "LASTHOLDTIME", index: "LASTHOLDTIME", width: 130, fixed: true, align: 'center'},
                { label: "Hold code", name: "HOLDCODE", index: "HOLDCODE", align: "center", fixed: true, width: 130, align: 'center'},
                { label: "Hold comment", name: "HOLDCOMMENT", align: "center", fixed: true, width: 130, align: 'center'},
                { label: "Release owner", name: "RELEASEUSER", index: "RELEASEUSER", align: "center", fixed: true, width: 130, align: 'center'},
                { label: "Releaseuser Module", name: "RELEASEUSERMODULE", index: "RELEASEUSERMODULE", align: "center", fixed: true, width: 130, align: 'center'},
                { label: "Release time", name: "RELEASETIME", index: "RELEASETIME", align: "center", fixed: true, width: 130, align: 'center'},
                { label: "Hold qtime", name: "HOLDQTIME", index: "HOLDQTIME", align: "center", fixed: true, width: 130, align: 'center'}
            ],
            sortname: "lotid",
            height: 200,
            sortorder: "asc",
            loadComplete: function (json) {
                var griddatatype = $(this).getGridParam("datatype");
                if (griddatatype == 'json') {
                    initFillChart(json.ExtraDatas.Summary)
                }
            }
        });
}

function initFillChart(data) {
    var rowdiv;
    var width;
    var interval;
    if (data.length >= 3) {
        interval = 4;
    } else {
        interval = 12 / data.length;
    }
    $.each(data, function (i, item) {
        if (i % 3 === 0) {
            rowdiv = $('<div class="row"></div>');
            $('#chartpnlbody').append(rowdiv);
            width = rowdiv.width();
        }
        var childdiv = $('<div class="col-lg-'+interval+'"><div id="' + item.title.text + '" style="height:300px;" class="chart"><div></div>');
        rowdiv.append(childdiv);

        //初始化chart；
        chart = echarts.init(document.getElementById(item.title.text));
        chart.setOption(item);
    });

    $charts = $('.chart');
}

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    //asdfadsfasdf
    $('#chartpnlbody').html('');
    return true;
}

function ValidateInput() {
    if ($('#beginDate').val() == '') {
        DialogTipsMsgError('请输入日期!', 5000);
        $('#beginDate').focus();
        return false;
    }

    if ($('#endDate').val() == '') {
        DialogTipsMsgError('请输入日期!', 5000);
        $('#endDate').focus();
        return false;
    }
    return true;
}