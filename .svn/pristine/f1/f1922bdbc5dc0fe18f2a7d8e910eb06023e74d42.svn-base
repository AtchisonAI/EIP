define(['reporting'],
    function (abc) {
        initLayout();
        initGird();
        size = UtilWindowHeightWidth();
    });

var $grid,
    size; //宽高
//布局
function initLayout() {
    $("body").layout({
        "south": {
            size: 350,
            closable: true,
            resizable: true,
            sliderTip: "显示/隐藏侧边栏", //在某个Pane隐藏后，当鼠标移到边框上显示的提示语。
            togglerTip_open: "关闭", //pane打开时，当鼠标移动到边框上按钮上，显示的提示语
            togglerTip_closed: "打开", //pane关闭时，当鼠标移动到边框上按钮上，显示的提示语
            resizerTip: "上下拖动可调整大小", //鼠标移到边框时，提示语
            slidable: true,
            onresize_end: function () {
                resetForm();
            }
        },
        "center": {
            onresize_end: function () {
                //获取调整后高度
                $grid.jqGrid("setGridHeight", $("#uiCenter").height() - 80).jqGrid("setGridWidth", $("#uiCenter").width() - 2);
            }
        }
    });
    $("#layout").layout({
        "north": {
            size: 60,
            closable: true,
            resizable: false,
            sliderTip: "显示/隐藏侧边栏",
            togglerTip_open: "关闭",
            togglerTip_closed: "打开",
            resizerTip: "上下拖动可调整大小", //鼠标移到边框时，提示语
            slidable: true
        },
        "center": {
            onresize_end: function () {
                //获取调整后高度
                $grid.jqGrid("setGridHeight", $("#uiCenter").height() - 80).jqGrid("setGridWidth", $("#uiCenter").width() - 2);
            }
        }
    });

    $("#layoutToolBar").layout({
        "north": {
            size: 23,
            closable: false,
            resizable: false,
            sliderTip: "显示/隐藏侧边栏",
            togglerTip_open: "关闭",
            togglerTip_closed: "打开",
            resizerTip: "上下拖动可调整大小", //鼠标移到边框时，提示语
            slidable: true
        },
        "south": {
            onresize_end: function () {
                //获取调整后高度
                $grid.jqGrid("setGridHeight", $("#uiCenter").height() - 80).jqGrid("setGridWidth", $("#uiCenter").width() - 2);
            }
        }
    });

}

function loadGraph(data) {

    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('browserAnalysis'));
    var option = {
            title: {
                text: 'Hold Code分析',
                x: 'center'
            },
            toolbox: {
                show: true,
                feature: {
                    restore: { show: true },
                    saveAsImage: { show: true },
                    dataView: { show: true },
                    magicType: {
                        type: []
                    }
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            series: [
                {
                    //roseType:true,
                    name: 'Hold Code',
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: data,
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        };
    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);
}

//初始化表格
function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype:"local",
            multiselect: true,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/MultiReleaseLot/QueryLotHoldInfo',
            colModel: [
                { label: "Is Success", name: "RESULT", sortable: false,hidden:true, width: 50, fixed: true },
                { label: "Error Message", name: "ERRORMSG", sortable: false, hidden: true, width: 200, fixed: true },
                { label: "Submit Time", name: "SUBMITTIME", sortable: false, hidden: true, width: 120, fixed: true },
                { label: "Lot ID", name: "LOTID", index: "LOT.APPID", width: 130, fixed: true },
                { label: "Carrier ID", name: "CARRIERID", index: "LOT.TRANSPORTID", width: 130, fixed: true },
                { label: "Step SEQ", name: "STEPSEQ", index:"FWS.Handle", width: 130, fixed: true },
                { label: "Step Name", name: "STEPNAME",index:"FWS.StepName", width: 130, fixed: true },
                { label: "Product Name", name: "PRODUCTNAME",index:"LOT.ProductName", width: 130, fixed: true },
                { label: "Reason", name: "REASON", index: "HR.Reason", width: 50, fixed: true },
                { label: "Reason Description", name: "REASONDESCRIPTION", width: 160, fixed: true },
                { label: "Hold To Owner ID", name: "HOLDTOOWNERID", index: "HR.COMMENTCODE", width: 130, fixed: true },
                { label: "Hold Type", name: "HOLDTYPE", index: "HR.HOLDTYPE", width: 50, fixed: true },
                { label: "Hold To Owner Name", name: "HOLDTOOWNERNAME", sortable:false, width: 130, fixed: true },
                { label: "Hold To Owner Dept", name: "HOLDTOOWNERDEPT",index:"NVL(TOEMP.DEPT_CODE, REPLACE(HR.COMMENTCODE, '@', ''))", width: 130, fixed: true },
                { label: "Comments", name: "COMMENTS",sortable:false, width: 130, fixed: true },
                { label: "Hold User ID", name: "HOLDUSERID", sortable: false, width: 130, fixed: true },
                { label: "Hold User Name", name: "HOLDUSERNAME", sortable: false, width: 130, fixed: true },
                {
                    label: "Hold Time", name: "HOLDTIME", index: "HR.HOLDTIME", align: "center", fixed: true, width: 130
                }
            ],
            sortname: "Reason,HoldTime",
            height: $("#uiCenter").height() - 80,
            sortorder: "asc",
            onSelectRow: checkRowInfo,
            onSelectAll: checkAllRowInfo,
            loadComplete: function (json) {
                if (json.rows.length > 0) {

                    $grid.hideCol(["RESULT", "ERRORMSG", "SUBMITTIME"])
                    loadGraph(json.ExtraDatas.Summary);
                }
                //alert(123);
                //return false;
            }
        });
}

//Grid选中行事件，用于判断选择的行是否是Release成功的，如果是则无法选中
function checkRowInfo(rowid) {
    var rowDatas = $grid.jqGrid('getRowData', rowid);
    if (rowDatas.RESULT == "true") {
        $grid.jqGrid("setSelection", rowid, false);
    }
}

//Grid全选事件，用于判断选择的行是否是Release成功的，如果是则无法选中
function checkAllRowInfo(rowids, status) {
    if (status) {
        for (var i = 0; i < rowids.length; i++) {
            var rowData = $grid.jqGrid("getRowData", rowids[i]);

            if (rowData.RESULT == "true") {
                $grid.jqGrid("setSelection", rowids[i], false);

            }
        }
    }
}


//获取数据
function getGridData() {
    var select = $("[name='btn_select_box']");
    if (select.length > 0) {
        search($(select[0]).parent());
    }
}

//Release弹出框
function releaseLots() {
    
    //查看是否选中
    GridIsSelect($grid, function () {
        ArtDialogOpen("/Reporting/MultiReleaseLot/ReleaseLotsView", "Lot Release", true, 380, 580);
    });
}


function releaseComplete(data) {
    $grid.showCol(["RESULT", "ERRORMSG","SUBMITTIME"])
    var selectedIDs =$grid.jqGrid("getGridParam", "selarrrow").slice(0) ;
    var submitTime = (new Date()).toLocaleTimeString();
    if (selectedIDs.length) {
        for (var i = 0; i < selectedIDs.length; i++) {
            var rowData = $grid.jqGrid("getRowData", selectedIDs[i]);
            var backcolor;
            if (data[i].Result) {
                backcolor = "#99FFCC";
                $grid.setSelection(selectedIDs[i], false);
            } else {

                backcolor = "#FF9999";
            }

            $grid.setCell(selectedIDs[i], "RESULT", data[i].Result, { background: backcolor });
            $grid.setCell(selectedIDs[i], "ERRORMSG", data[i].ErrorMsg, { background: backcolor });
            $grid.setCell(selectedIDs[i], "SUBMITTIME", submitTime, { background: backcolor });
        }
    }
}

function getSeletedHoldInfo(data) {
    var selectedIDs = $grid.jqGrid("getGridParam", "selarrrow");
    if (selectedIDs.length) {
        for (var i = 0; i < selectedIDs.length; i++) {
            var rowData = $grid.jqGrid("getRowData", selectedIDs[i]);
            data["HoldInfoList[" + i + "].CarrierID"] = rowData.CARRIERID;
            data["HoldInfoList[" + i + "].LotID"] = rowData.LOTID;
            data["HoldInfoList[" + i + "].HoldReason"] = rowData.REASON;
            data["HoldInfoList[" + i + "].HoldType"] = rowData.HOLDTYPE;
        }
    }
    return data;
}

