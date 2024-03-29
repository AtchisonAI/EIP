﻿define(['reportingbootstrap'],
    function (abc) {
        initGird();
        size = UtilWindowHeightWidth();
});


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
    return true;
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
   
    return true;
}

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    AdditionalReset();
    //asdfadsfasdf
    //adsfadsf
    return true;
}


function AfterSearchClick() {
    return true;
}

//默认执行class为grid和chart的自适应方法
function windowResized() {

}

function loadGraph(data) {

    // 基于准备好的dom，获取echarts实例
    var myChart = echarts.getInstanceByDom(document.getElementById('browserAnalysis'));
    myChart.setOption(data);
    // 基于准备好的dom，获取echarts实例
    var myChart1 = echarts.getInstanceByDom(document.getElementById('browserAnalysis1'));
    myChart1.setOption(data);
}

//初始化表格
function initGird() {
        var grid = $("#list").jgridview(
            {
                datatype: "local",
                multiselect: false,
                loadonce: false,
                shrinkToFit: true,
                url: '/Reporting/LotHistory/QueryLotHistoryInfo',
                colModel: [
                    { label: "Product ID", name: "PRODUCTID", width: 150, fixed: true },
                    { label: "Lot Type", name: "LOTTYPE", width: 50, fixed: true },
                    { label: "Qty", name: "LOTQTYIN", width: 50, fixed: true },
                    { label: "Priority", name: "PRIORITY", width: 50, fixed: true },
                    { label: "Stage", name: "STAGENAME", width: 130, fixed: true },
                    { label: "Step", name: "STEPID", width: 130, fixed: true },
                    { label: "Step Seq", name: "STEPSEQ", width: 130, fixed: true },
                    { label: "Capability", name: "CAPABILITY", width: 50, fixed: true },
                    { label: "EQ_ID", name: "LOCATION", width: 130, fixed: true },
                    { label: "ArriveTime", name: "ARRIVETIME", width: 130, fixed: true },
                    { label: "TrackinTime", name: "TRACKINTIME", width: 130, fixed: true },
                    { label: "TrackoutTime", name: "TRACKOUTTIME", width: 130, fixed: true },
                    { label: "Run Time", name: "RUNTIME", width: 130, fixed: true },
                    { label: "Q_T", name: "QUEUETIME", width: 130, fixed: true },
                    {
                        label: "Hold Time", name: "HOLDTIME", width: 130, fixed: true,
                        formatter: function (cellValue, options, rowdata, action) {
                            if (rowdata.HOLDTIME != 0) {
                                return "<a herf='javascript:(0)' onclick='showHoldHistory(\"" + rowdata.HOLDRELEASE + "\")' ><font color='blue'><u>" + rowdata.HOLDTIME + "</u></blue></a>";
                            } else {
                                return "<font color='blue'>" + rowdata.HOLDTIME + "</blue>";
                            }
                        }
                    }
                ],
                sortname: "HS.TIMEHERESINCE",
                height: '800px',
                sortorder: "asc",
                additionalLoadCompleteAction: function (json) {
                }
            });
}


function showHoldHistory(HOLDRELEASE) {
    ArtDialogOpen("/Reporting/LotHistory/HoldIndex?HOLDRELEASE=" + HOLDRELEASE, "Hold Details", true, 750, 1200, true);
  
}
