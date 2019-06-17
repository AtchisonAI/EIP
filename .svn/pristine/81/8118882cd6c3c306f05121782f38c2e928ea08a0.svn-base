define(['reportingbootstrap'],
    function (abc) {
        initGird();
        initLayout();
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

    // 基于准备好的dom，初始化echarts实例
    $charts = echarts.init(document.getElementById('browserAnalysis'));
    var option = {
        title: {
            text: 'WIPStatus',
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
                name: 'Product',
                type: 'pie',
                radius: '55%',
                center: ['50%', '50%'],
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
    $charts.setOption(option);
}



//初始化表格
function initGird() {
    var grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/WIPStatus/QueryWIPStatus',
            colModel: [
                { label: "PRODUCTNAME", name: "PRODUCTNAME", width: 150, fixed: true },
                { label: "APPID", name: "APPID", width: 150, fixed: true },
                { label: "COMPONENTQTY", name: "COMPONENTQTY", width: 150, fixed: true },
                { label: "PRODUCTREVISION", name: "PRODUCTREVISION", width: 150, fixed: true },
                { label: "STEPNAME", name: "STEPNAME", width: 130, fixed: true },
                { label: "STEPSEQ", name: "STEPSEQ", width: 130, fixed: true },
                { label: "STEPREVISION", name: "STEPREVISION", width: 130, fixed: true },
                { label: "PROCESSOPERRATIONID", name: "PROCESSOPERATIONID", width: 200, fixed: true },
                { label: "SUBPLANID", name: "SUBPLANID", width: 200, fixed: true }

            ],
            sortname: "APPID",
            height: '800px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
                if (json.rows.length > 0) {
                   // $grid.hideCol(["RESULT", "ERRORMSG", "SUBMITTIME"])
                    loadGraph(json.ExtraDatas.Summary);
                } else {

                    loadGraph([]);
                }
               
            }
        });
}


//获取数据
function getGridData() {
    var select = $("[name='btn_select_box']");
    if (select.length > 0) {
        search($(select[0]).parent());
    }
}

//删除匹配项
function releaseLots() {

    //查看是否选中
    GridIsSelect($grid, function () {
        ArtDialogOpen("/Reporting/MultiReleaseLot/ReleaseLotsView", "Lot Release", true, 380, 580);
    });
}


function releaseComplete(data) {
    $grid.showCol(["RESULT", "ERRORMSG", "SUBMITTIME"])
    var selectedIDs = $grid.jqGrid("getGridParam", "selarrrow").slice(0);
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