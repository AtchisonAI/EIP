define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        initRadio();
        initTabEvent();
        size = UtilWindowHeightWidth();
    });

function initRadio() {
    $('input[type=radio][name=timeOption]').change(function () {
        var $startTime = $('#StartTime');
        var $endTime = $('#EndTime');

        if (typeof timerGetUpToNowOption !== 'undefined'){
            clearInterval(timerGetUpToNowOption);
        }

        $startTime.attr("disabled", true);
        $endTime.attr("disabled", true); 

        $startTime.removeAttr('style');
        $endTime.removeAttr('style');
        if (this.value == '1') {
            timerGetUpToNowOption = setInterval(getUpToNowOption, 1000);
        }
        else if (this.value == '2') {
            getLastDayOption();
        } else if (this.value == '3') {
            getUpToNowOption();
            $startTime.attr("disabled", false);
            $startTime.css("background-color", 'white');
            $endTime.attr("disabled", false);
            $endTime.css("background-color", 'white');
        }
    });

    timerGetUpToNowOption = setInterval(getUpToNowOption, 1000);
}
var timerGetUpToNowOption;

function getUpToNowOption() {
    var $startTime = $('#StartTime');
    var $endTime = $('#EndTime');
    var timeNow = getTimeNow();
    var todayStart = getTodayStartTime(timeNow);
    $startTime.val(todayStart.Format('yyyy-MM-dd hh:mm:ss'));
    $endTime.val(timeNow.Format('yyyy-MM-dd hh:mm:ss'));
}

function getLastDayOption() {
    var $startTime = $('#StartTime');
    var $endTime = $('#EndTime');
    var timeNow = getTimeNow();
    var lastDayEnd = getTodayStartTime(timeNow);
    var lastStart = getLastDayStart(lastDayEnd);
    $startTime.val(lastStart.Format('yyyy-MM-dd hh:mm:ss'));
    $endTime.val(lastDayEnd.Format('yyyy-MM-dd hh:mm:ss'));
}


var oneday = 1000 * 60 * 60 * 24;

function getLastDayStart(todayStartTime) {
    var lastDayStart = new Date(todayStartTime - oneday);
    return lastDayStart;
}

function getTodayStartTime(timeNow) {
    var currentDate = new Date(timeNow); //Current Date + 8 Hours
    currentDate.setHours(8);//UTC Time Compare
    currentDate.setMinutes(0);
    currentDate.setSeconds(0);
    currentDate.setMilliseconds(0);
    //If Current Time > Current Date + 8 Hours Return Current Date + 8 Hours
    if (timeNow > currentDate) {
        return currentDate;
    } else { //Return Current Date - 1 Day + 8 Hours
        return new Date(currentDate - oneday)
    }
}

function getTimeNow() {
    return new Date();
}

function initSelect() {

    $("#selArea").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择Area！",
        maximumSelectionLength: 2,  //设置最多可以选择多少项
        multiple: true,//设置是否可以多选
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryAreaSelectList",//获取数据的地址
            dataType: 'json',
            delay: 250,//按键之后多久才提交后台进行查询,
            processResults: function (result, params) {//获取到后台数据后，进行解析
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data
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

    $("#selArea").on("select2:unselect", function (e) {//绑定选中事件
        $("#selEQP").val(null).trigger('change');
    });

    $("#selArea").on("select2:select", function (e) {//绑定取消选中事件
        $("#selEQP").val(null).trigger('change');
    });


    //远程筛选
    $("#selEQPType").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择EQP Type！",
        maximumSelectionLength: 4,  //设置最多可以选择多少项
        multiple: true,
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryEQPTypeSelectList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                //控件联动，获取到选择的productfamily，传递给后台，过滤product
                var area;
                if ($("#selArea").val() !== null) {
                    area = $("#selArea").val().join("','");
                }

                return {
                    area: area,
                    q: params.term
                };
            },
            processResults: function (result, params) {
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data
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


    //远程筛选
    $("#selEQP").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择EQP Type！",
        maximumSelectionLength: 4,  //设置最多可以选择多少项
        multiple: true,
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryEQPSelectList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                //控件联动，获取到选择的productfamily，传递给后台，过滤product
                var area;
                if ($("#selArea").val() !== null) {
                    area = $("#selArea").val().join("','");
                }
                
                var eqpType;
                if ($("#selEQPType").val() !== null) {
                    eqpType = $("#selEQPType").val().join("','");
                }

                return {
                    area: area,
                    eqpType: eqpType,
                    q: params.term,
                    page: params.page || 1//当前页数
                };
            },
            processResults: function (result, params) {
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


//重置流程
//ResetBefore
//如果 ResetBefore 返回 true
//  自动执行clearCondition();
//  自动执行clearGrids();
//  自动执行clearCharts();
//  AdditionalReset

function ResetBefore() {
    //自动重置之前，执行，如果不希望执行自动重置逻辑，则返回false
}

function AdditionalReset() {
    chartData = null;
    clickedEQP = null;
    $('#listDetail').jqGrid("clearGridData");
    $('#listProcessLots').jqGrid("clearGridData");
    $('#chartLegend').html('');

    $('#rdoUpToNow').prop('checked', 'checked');
    var $startTime = $('#StartTime');
    var $endTime = $('#EndTime');

    if (typeof timerGetUpToNowOption !== 'undefined') {
        clearInterval(timerGetUpToNowOption);
    }

    $startTime.attr("disabled", true);
    $endTime.attr("disabled", true);

    $startTime.removeAttr('style');
    $endTime.removeAttr('style');
    timerGetUpToNowOption = setInterval(getUpToNowOption, 500);
    

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

    var fromTime = new Date($('#StartTime').val());
    var endTime = new Date($('#EndTime').val());
    if (endTime <= fromTime) {
        DialogTipsMsgError('结束时间必须大于开始时间!', 5000);
        $('#StartTime').focus();
        return false;
    }

    if ($('#selEQP').val() == null || $('#selEQP').val().length ===0) {
        DialogTipsMsgError('请选择需要查询的设备!', 5000);
        $('#selEQP').focus();
        return false;
    }
}

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    var selectedEQP = $('#selEQP').val().join("','");
    var fromTime = $('#StartTime').val();
    var endTime = $('#EndTime').val();
    var isIncludeChamber = $('#chkIsIncludeChamber').prop('checked');

    $.ajax({
        url: '/Reporting/EQPStatusMonitor/QueryEQPStatusMonitorData',
        type: 'post',
        dataType: 'json',
        data: { EQPList: selectedEQP, StartTime: fromTime, EndTime: endTime, IsIncludeChamber: isIncludeChamber },
        success: function (data, status) {
            //test();
            loadGraph(data);
            loadChartLegend(data.StatusColor);
        }
    });

    return false;
}


function AfterSearchClick() {

}

//默认执行class为grid和chart的自适应方法
function windowResized() {

    $('#listDetail').setGridWidth($('#listDetail').parents('.ui-jqgrid').parent().width());
    $('#listProcessLots').setGridWidth($('#listProcessLots').parents('.ui-jqgrid').parent().width());
}


function loadChartLegend(data) {
    var rowDiv;
    var idx = 0;
    $('#chartLegend').html('');
    $.each(data, function (status, color) {
        if (idx % 4 === 0) {
            rowDiv = $('<div class = "row"></div>');
            $('#chartLegend').append(rowDiv);
        }

        rowDiv.append($('<div class="col-sm-3 text-center" style="padding-top:5px;"><div class="input-group"><div class="input-group-addon"  style="background-color:' + color + '";></div><input readonly type="text" class="form-control"  value="' + status + '" ></input> </div> </div>'));
        idx++;
    });
}


function renderItem(params, api) {
    var categoryIndex = api.value(0);
    var start = api.coord([api.value(1), categoryIndex]);
    var end = api.coord([api.value(2), categoryIndex]);
    var height = api.size([0, 1])[1] * 0.6;

    return {
        type: 'rect',
        shape: echarts.graphic.clipRectByRect({
            x: start[0],
            y: start[1] - height / 2,
            width: end[0] - start[0],
            height: height
        }, {
                x: params.coordSys.x,
                y: params.coordSys.y,
                width: params.coordSys.width,
                height: params.coordSys.height
            }),
        style: api.style()
    };
}


var chartData;

function loadGraph(data) {
    chartData = data;
    var option = {
        tooltip: {
            formatter: function (params) {
                return params.marker + params.name + ': ' + params.value[4] + ' m';
            }
        },
        legend: {
            orient: 'vertical',
            x: 'right'
        },
        dataZoom: [{
            type: 'slider',
            filterMode: 'weakFilter',
            showDataShadow: false,
            top: 500,
            height: 10,
            borderColor: 'transparent',
            backgroundColor: '#e2e2e2',
            handleIcon: 'M10.7,11.9H9.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4h1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7v-1.2h6.6z M13.3,22H6.7v-1.2h6.6z M13.3,19.6H6.7v-1.2h6.6z', // jshint ignore:line
            handleSize: 20,
            handleStyle: {
                shadowBlur: 6,
                shadowOffsetX: 1,
                shadowOffsetY: 2,
                shadowColor: '#aaa'
            },
            labelFormatter: ''
        }, {
            type: 'inside',
            filterMode: 'weakFilter'
        }],
        grid: {
            height: 400
        },
        xAxis: {
            min: data.StartDate,
            max: data.EndDate,
            scale: true,
            axisLabel: {
                formatter: function (val) {
                    return new Date(val).Format("yyyy-MM-dd hh:mm:ss")
                }
            }
        },
        yAxis: {
            data: data.categories
        },
        series: [{
            type: 'custom',
            renderItem: renderItem,
            itemStyle: {
                normal: {
                    opacity: 0.8
                }
            },
            encode: {
                x: [1, 2],
                y: 0
            },
            data: data.data
        }]
    };

    var myChart = echarts.getInstanceByDom(document.getElementById('browserAnalysis'));
    myChart.setOption(option);

    myChart.on('click', function (params) {

        clickedEQP = new Object();
        clickedEQP.EQPName = params.value[5];
        clickedEQP.ParentEQPName = params.value[6];
        clickedEQP.StartTime = new Date(params.value[1]).Format('yyyyMMdd hhmmss000');
        clickedEQP.EndTime = new Date(params.value[2]).Format('yyyyMMdd hhmmss000');
        
        ShowDetails();
    });
}

var clickedEQP;


function loadStatusPie(data) {
    //chartStatusPie
    var option = {
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} m({d}%)"
        },
        legend: {
            orient: 'vertical',
            x: 'left'
        },
        series: [
            {
                name: '状态',
                type: 'pie',
                radius: '80%',//饼图的半径大小
                center: ['60%', '50%'],//饼图的位置
                data: data.StatusDetails
            }
        ],
        color: data.Colors
    };

    var myChart = echarts.getInstanceByDom(document.getElementById('chartStatusPie'));
    myChart.setOption(option);
    myChart.resize();
}

function ShowDetails() {
    if (typeof clickedEQP !== 'undefined' && clickedEQP != null) {
        var activeTab = $('#tabList >li.active').children('a').attr("href");
        if (activeTab === '#detail') {

            $('#listDetail').jqGrid("clearGridData");
            $("#listDetail").setGridParam({ data: chartData.StatusDetails[clickedEQP.EQPName].StatusDetails }).trigger('reloadGrid');

        } else if (activeTab == '#utility') {
            loadStatusPie(chartData.StatusDetails[clickedEQP.EQPName])
        } else if (activeTab == '#processLots'){
            $('#listProcessLots').jqGrid("clearGridData");


            var postData = $('#listProcessLots').getGridParam('postData');
            $.extend(postData, { EQPName: clickedEQP.ParentEQPName, StartTime: clickedEQP.StartTime, EndTime: clickedEQP.EndTime });
            $('#listProcessLots').setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]); // must search true
        }
    } else {
        $('#listDetail').jqGrid("clearGridData");
        $('#listProcessLots').jqGrid("clearGridData");
        var myChart = echarts.getInstanceByDom(document.getElementById('chartStatusPie'));
        myChart.clear();
    }
}



//初始化表格
function initGird() {
    $("#listDetail").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: true,
            shrinkToFit: true,
            pager:'pagerDetail',
            colModel: [
                {
                    label: "Status", name: "name", width: 250, fixed: true
                },
                { label: "Start Time", name: "StartTime", width: 150, fixed: true },
                { label: "End Time", name: "EndTime", width: 150, fixed: true },
                { label: "Duration(M)", name: "value", width: 130, fixed: true }
            ],
            height: '462px',
            sortorder: "asc"
        });

    $("#listProcessLots").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            pager: 'pagerProcessLots',
            url: '/Reporting/EQPStatusMonitor/GetProcessLotList',
            colModel: [
                {
                    label: "Lot ID", name: "WIPID", index: "FTO.WIPID", width: 130, fixed: true
                },
                { label: "Qty", name: "STEPQTY", index: "fwsh.stepqty", width: 50, fixed: true },
                { label: "Priority", name: "PRIORITY", width: 90, fixed: true },
                { label: "Product Name", name: "PRODUCTID", index: "fwh.Productid", width: 100, fixed: true },
                { label: "Main Plan", name: "PLANID", index: "fwh.Planid", width: 200, fixed: true },
                { label: "Stage", name: "STAGENAME",  width: 130, fixed: true },
                { label: "Step Name", name: "STEPNAME", width: 130, fixed: true },
                { label: "Process Operation", name: "PROCESSOPERATION", width: 200, fixed: true },
                { label: "Recipe", name: "RECIPEID", width: 130, fixed: true }
            ],
            sortname: "FTO.WIPID",
            height: '462px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
            }
        });


    $('#listProcessLots').jqGrid('setGridParam', { datatype: 'json' });
}

function initTabEvent() {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        var activeTabName = $(e.target).attr('href');
        if (activeTabName === '#utility' || activeTabName === "#chartLegend") {
        } else {
            var activeGrid;
            if (activeTabName === '#detail') {
                activeGrid = $('#listDetail');
            }
            else {
                activeGrid = $('#listProcessLots');
            }
            activeGrid.setGridWidth(activeGrid.parents('.ui-jqgrid').parent().width());
        }


        ShowDetails();
    });
}

function showLotHistory(lotID) {
    ArtDialogOpen("/Reporting/XuTao/LotHistory?lotID=" + lotID, "Lot History-" + lotID, true, 750, 1200, true);
}
