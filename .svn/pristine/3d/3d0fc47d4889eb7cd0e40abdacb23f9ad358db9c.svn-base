define(['reporting'],
    function (abc) {
        initLayout();
        initGird();
        size = UtilWindowHeightWidth();
    });

var $grid,
    size,$charts; //宽高
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
    $charts = echarts.init(document.getElementById('browserAnalysis'));
    var option = {
            title: {
                text: 'Product Info',
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
    $grid = $("#list").jgridview(
        {
            datatype:"local",
            multiselect: true,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/Product/QueryProduct',
            colModel: [
               // { label: "Is Success", name: "RESULT", sortable: false,hidden:true, width: 50, fixed: true },
               // { label: "Error Message", name: "ERRORMSG", sortable: false, hidden: true, width: 200, fixed: true },
               // { label: "Submit Time", name: "SUBMITTIME", sortable: false, hidden: true, width: 120, fixed: true },
                { label: "Lot ID", name: "LOTID", index: "LOT.APPID", width: 130, fixed: true },
                { label: "Plan Name", name: "PLANNAME", index: "PLANNAME", width: 130, fixed: true },
                { label: "Product Name", name: "PRODUCTNAME", index: "PRODUCTNAME", width: 130, fixed: true },
                { label: "QTY", name: "STEPNAME", index: "FWS.CURRENTQTY", width: 130, fixed: true },
                { label: "Stage Name", name: "STAGENAME", index: "STAGENAME", width: 130, fixed: true },
                { label: "Carrierid", name: "CARRIERID", index: "LOT.TRANSPORTID", width: 130, fixed: true },
                { label: "Step Name", name: "STEPNAME", index: "STEPNAME", width: 130, fixed: true },
                { label: "Processing Status", name: "PROCESSINGSTATUS", index: "PROCESSINGSTATUS", width: 130, fixed: true },
                { label: "Extra Status", name: "EXTRASTATUS", index: "EXTRASTATUS", width: 130, fixed: true },
            ],
            sortname: "APPID,PLANNAME,PRODUCTNAME,CURRENTQTY,STAGENAME,TRANSPORTID,STEPNAME,PROCESSINGSTATUS,EXTRASTATUS",
            height: $("#uiCenter").height() - 80,
            sortorder: "asc",
            
            
            loadComplete: function (json) {
                if (json.rows.length > 0) {

                    $grid.hideCol(["RESULT", "ERRORMSG", "SUBMITTIME"])
                    loadGraph(json.ExtraDatas.Summary);
                }else
                {

                    loadGraph([]);
                }
                //alert(123);
                //return false;
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

