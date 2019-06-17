define(['reportingbootstrap'],
    function (abc) {
        initDataselect();
        size = UtilWindowHeightWidth();

        var myChart = echarts.getInstanceByDom(document.getElementById('MonthChart'));

        myChart.on('click', function (params) {

            clickedBar = new Object();
            clickedBar.labtype = params.seriesName;
            clickedBar.chktime = params.name;
            ShowDetails();
        });

        var myChart1 = echarts.getInstanceByDom(document.getElementById('MTDChart'));

        myChart1.on('click', function (params) {

            clickedBar = new Object();
            clickedBar.labtype = params.seriesName;
            clickedBar.chktime = params.name;
            ShowDetails();
        });
    });

//var chartDictionary;

function windowResized() {
    //if (chartDictionary != 'undefined') {
    //    for (var key in chartDictionary) {
    //        chartDictionary[key].resize();
    //    }
    //}
}

function initDataselect() {
    var now = new Date();

    //格式化日，如果小于9，前面补0
    var day = ("0" + now.getDate()).slice(-2);
    //格式化月，如果小于9，前面补0
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    //拼装完整日期格式
    var today = now.getFullYear() + (month);
    var monthfirstday = now.getFullYear() + ("01");

    $("#sMonthStart").val(monthfirstday);
    $("#sMonthEnd").val(today);
    $("#sMTD").val(today);
}


function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    var MDT = $('#sMTD').val();
    var fromTime = $('#sMonthStart').val();
    var endTime = $('#sMonthEnd').val();

    $.ajax({
        url: '/Reporting/WIPWaferInOut/QueryMonInOutInfoData',
        type: 'post',
        dataType: 'json',
        data: { sMonthStart: fromTime, sMonthEnd: endTime },
        success: function (data, status) {
            loadGraph(data, 'MonthChart');
        }
    });

    $.ajax({
        url: '/Reporting/WIPWaferInOut/QueryMTDInOutInfoData',
        type: 'post',
        dataType: 'json',
        data: { sMTD: MDT },
        success: function (data, status) {
            loadGraph(data, 'MTDChart');
        }
    });

    return false;
}




function loadGraph(data, ChartName) {

    // 基于准备好的dom，获取echarts实例
    echarts.getInstanceByDom(document.getElementById(ChartName)).setOption(data);
    //// 基于准备好的dom，获取echarts实例
    //var myChart1 = echarts.getInstanceByDom(document.getElementById('MTDChart'));
    //myChart1.setOption(data2);
    //data.echarts.Series



}

var clickedBar;


function ShowDetails() {

    ArtDialogOpen("/Reporting/WIPWaferInOut/WaferInOutDetails?date=" + clickedBar.chktime + "&type=" + clickedBar.labtype, "WaferInOutDetails-" + clickedBar.chktime, true, 750, 1200, true);

}

//function ValidateInput() {
//    if ($('#beginDate').val() == '') {
//        DialogTipsMsgError('请输入日期!', 5000);
//        $('#beginDate').focus();
//        return false;
//    }

//    if ($('#endDate').val() == '') {
//        DialogTipsMsgError('请输入日期!', 5000);
//        $('#endDate').focus();
//        return false;
//    }

//    return true;
//}

