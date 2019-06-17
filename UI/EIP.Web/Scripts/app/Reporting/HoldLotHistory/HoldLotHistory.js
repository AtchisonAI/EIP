define(['reportingbootstrap'],
    function (abc) {
        initDataselect();
        initGird();
        size = UtilWindowHeightWidth();

        if ($('#beginDate').val() !== '') {
            $("[name='btn_select_box']").click();
        }
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
    var today = now.getFullYear() + (month) + (day);
    var monthfirstday = now.getFullYear() + (month) + ("01");

    $("#beginDate").val(monthfirstday);
    $("#endDate").val(today);
}

//初始化表格
function initGird() {
    $("#listhide").hide();
    $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: true,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/HoldLotHistory/QueryHoldLotHistory',
            colModel: [
                //假的grid并且隐藏 
                { label: "Lot type", name: "LOTTYPE", index: "LOTTYPE", width: 100, fixed: true },
                { label: "Area", name: "AREA", index: "AREA", width: 90, fixed: true },
                { label: "Product ID", name: "PRODUCTID", index: "PRODUCTID", width: 100, fixed: true },
                { label: "Lot ID", name: "LOTID", index: "LOTID", width: 90, fixed: true },
                { label: "Stage Name", name: "STAGENAME", index: "STAGENAME", width: 100, fixed: true },
                { label: "Step SEQ", name: "STEPSEQ", index: "STEPSEQ", width: 100, fixed: true },
                { label: "Step Name", name: "STEPNAME", index: "STEPNAME", width: 130, fixed: true },
                { label: "EQP ID", name: "EQID", index: "EQID", width: 100, fixed: true },
                { label: "Priority", name: "PRI", index: "PRI", width: 60, fixed: true },
                { label: "Quantity", name: "QTY", sortable: false, width: 60, fixed: true },
                { label: "Hold Owner", name: "HOLDUSER", index: "HOLDUSER", width: 100, fixed: true },
                { label: "Hold Module", name: "HOLDMODULE", index: "HOLDMODULE", width: 100, fixed: true },
                { label: "Hold Time", name: "REP_EMPNO", index: "REP_EMPNO", width: 100, fixed: true },
                { label: "Last Hold Time", name: "LASTHOLDTIME", index: "LASTHOLDTIME", width: 130, fixed: true },
                { label: "Hold code", name: "HOLDCODE", index: "HOLDCODE", align: "center", fixed: true, width: 130 },
                { label: "Hold comment", name: "HOLDCOMMENT", align: "center", fixed: true, width: 130 },
                { label: "Release owner", name: "RELEASEUSER", index: "RELEASEUSER", align: "center", fixed: true, width: 130 },
                { label: "Releaseuser Module", name: "RELEASEUSERMODULE", index: "RELEASEUSERMODULE", align: "center", fixed: true, width: 130 },
                { label: "Release time", name: "RELEASETIME", index: "RELEASETIME", align: "center", fixed: true, width: 130 },
                { label: "Hold qtime", name: "HOLDQTIME", index: "HOLDQTIME", align: "center", fixed: true, width: 130 }
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

/*function initFillChart(data) {
    var rowdiv;
    $.each(data, function (i, item) {
        if (i % 3 === 0) {
            rowdiv = $('<div class="row"></div>');
            $('#chartpnlbody').append(rowdiv);
        }
        var childdiv = $('<div class="col-lg-4"><div onclick="popDetailInfo(\''+item.title.text+'\')" id="'+ item.title.text+'" style="height:300px;" class="chart"><div></div>');
        rowdiv.append(childdiv);

        //初始化chart；
        var chart = echarts.init(document.getElementById(item.title.text));
        chart.setOption(item);
    });

    $charts = $('.chart');
}*/

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
        var childdiv = $('<div class="col-lg-' + interval + '"><div onclick="popDetailInfo(\'' + item.title.text + '\')" id="' + item.title.text + '" style="height:300px;" class="chart"><div></div>');
        rowdiv.append(childdiv);

        //初始化chart；
        chart = echarts.init(document.getElementById(item.title.text));
        chart.setOption(item);
    });

    $charts = $('.chart');
}

function popDetailInfo(moduleCode) {
    ArtDialogOpen("/Reporting/HoldLotHistoryDetailInfo/HoldLotHistoryDetail?moduleCode=" + moduleCode + "&beginDate=" + $("#beginDate").val() + "&endDate=" + $("#endDate").val() + "&analysisUnit=" + $("#analysisUnit").val(), "Hold lot History detail-" + moduleCode, true, 900, 1440, true);
}


function AdditionalReset() {

    return true;
}

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
}

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    AdditionalReset();
    //asdfadsfasdf
    //adsfadsf
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

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    //asdfadsfasdf
    $('#chartpnlbody').html('');
    return true;
}