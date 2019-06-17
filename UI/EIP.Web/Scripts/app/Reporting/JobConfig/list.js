define(['list', 'layout'],
function () {
    initLayout();
    initGird();
    initSearch();
    size = UtilWindowHeightWidth();
    initGridTableData('');
});

var $grid,
    $grid_table,
    size,
    rowId = null;

//初始化布局
function initLayout() {
    $("body").layout({
        "west": {
            size: 480,
            closable: true, //是否可伸缩
            resizable: true, //是否可调整大小
            sliderTip: "显示/隐藏侧边栏", //在某个Pane隐藏后，当鼠标移到边框上显示的提示语。
            togglerTip_open: "关闭", //pane打开时，当鼠标移动到边框上按钮上，显示的提示语
            togglerTip_closed: "打开", //pane关闭时，当鼠标移动到边框上按钮上，显示的提示语
            resizerTip: "可调整大小", //鼠标移到边框时，提示语
            slidable: true
        },
        "center": {
            onresize_end: function () {
                GridSetWidthAndHeight($grid, $("#uiCenter").width());
                GridSetWidthAndHeight($grid_table, $("#uiCenter").width());
            }
        }
    });
    $("#layout").layout({
        "north": {
            size: 29,
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
                $grid.jqGrid("setGridHeight", $("#list_center").height() - 51).jqGrid("setGridWidth", $("#list_center").width() - 2);
                $grid_table.jqGrid("setGridHeight", $("#list_table_center").height() - 51).jqGrid("setGridWidth", $("#list_table_center").width() - 2);
            }
        }
    });
    $("#layout_table").layout({
        "north": {
            size: 29,
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
                $grid.jqGrid("setGridHeight", $("#list_center").height() - 51).jqGrid("setGridWidth", $("#list_center").width() - 2);
                $grid_table.jqGrid("setGridHeight", $("#list_table_center").height() - 51).jqGrid("setGridWidth", $("#list_table_center").width() - 2);
            }
        }
    });
}

//初始化表格
function initGird() {
    //应用数据库
    $grid = $("#list").jgridview(
        {
            multiselect: false,
            loadonce: false,
            url: "/Reporting/JobConfig/PagingConfigQuery",
            datatype: "json",
            pager: 'pager',
            colModel: [
                { name: "SYSID", label: "", width: 0, hidden: true, align: "center" },
                { name: "PROCEDURENAME", label: "Procedure Name", width: 0, align: "center" },
                { name: "SEQUENCE", label: "Seq", width: 0, align: "center" },
                { name: "TRIGGER_TYPE", label: "Trigger Type", width: 0, align: "center" },
                { name: "CURRENT_CYCLE_JOB_STATUS_ID", label: "", hidden: true, width: 0, align: "center" },
                { name: "MAX_RETRY_COUNT", label: "Max Retry Count", width: 0, align: "center" },
                { name: "IS_STOP_WHEN_FAILED", label: "Is Stop When Failed", width: 0, align: "center", formatter: "YesOrNo" },
                {
                    name: "JOB_STATE", label: "Job State", width: 0, align: "center", formatter: function (cellval, opts, rwd, act) {
                        if (cellval == 1) {
                            return '<span>Normal</sapn>';
                        } else {

                            return '<span>Failed</sapn>';
                        }
                    }
                },
                { name: "LatestCircleStatus", label: "Latest Circle Status", width: 0, align: "center" },
                { name: "LastestCircleStartTime", label: "Lastest Circle StartTime", width: 0, align: "center" },
                { name: "NextRunTime", label: "Next Run Time", width: 0, align: "center" },
                { name: "LastestCircleRetryCount", label: "Lastest Circle Retry Count", width: 0, align: "center" }
            ],
            height: $("#uiCenter").height() - 60,
            loadComplete: function () {
            },
            sortname: "T.sequence",
            sortorder: "asc",
            onSelectRow: function () {
                getTableGridData();
            }
        });
}

//初始化
function initGridTableData(id) {
    $grid_table = $("#list_table").jqGrid(
        {
            url: "/Reporting/JobConfig/PagingConfigParamQuery",
            viewrecords: true,
            loadonce: false,
            mtype: "post",
            datatype: "json",
            pagerpos: "left",
            colModel: [
                { label: "Param Name", name: "ParamName", width: 248, fixed: true },
                { label: "Sequence", name: "ParamSequence", width: 100, fixed: true },
                { label: "Param Type", name: "ParamType", width: 150, align: "center", fixed: true },
                { label: "Value Type", name: "ValueType", width: 150, align: "center", fixed: true },
                { label: "Expression", name: "ParamExpression", width: 150, align: "center", fixed: true },
                { label: "Description", name: "Description", width: 150, align: "center"}
            ],
            rowNum: 500,
            rowList: [500, 800, 1000],
            height: $("#list_table_center").height() - 51,
            width: $("#list_table_center").width(),
            pager: '#pager_table',
            sortname: 'Param_Sequence',
            sortorder: "asc",
            postData: { ProcedureName: id },
            multiselect: false
        });
}

//获取表格数据
function getTableGridData() {
    var info = GridGetSingSelectData($grid);
    if (typeof (info.PROCEDURENAME) != "undefined") {
        reloadTableGridData(info.PROCEDURENAME);
    }
}

function reloadTableGridData(procedureName) {
    var filters = getFilters($("#grid_table_search").parent());
    var postData = $grid_table.getGridParam('postData');
    $.extend(postData, { filters: filters });
    $.extend(postData, { ProcedureName: procedureName });
    $grid_table.setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]); // must search true
}

//操作:新增
function add() {
    ArtDialogOpen("/Reporting/JobConfig/Edit", "新增Job", true, 700, 1024);
}

//操作:编辑
function edit() {
    //查看是否选中
    GridIsSelect($grid, function () {
        var info = GridGetSingSelectData($grid);
        ArtDialogOpen("/Reporting/JobConfig/Edit?id=" + info.SYSID, "修改Job-" + info.PROCEDURENAME, true, 700, 1024);
    });
}

//删除匹配项
function del() {
    //查看是否选中
    GridIsSelect($grid, function () {
        ArtDialogConfirm(Language.common.deletemsg, function () {
            UtilAjaxPostWait(
                "/Reporting/JobConfig/delete",
                { id: GridGetSingSelectData($grid).SYSID },
                perateStatus
            );
        });
    });
}



//请求完成
function perateStatus(data) {
    DialogAjaxResult(data);
    if (data.ResultSign === 0) {
        getGridData();
    }
}

function getGridData() {
    var filters = getFilters($(this).parent());
    var postData = $grid.getGridParam('postData');
    $.extend(postData, { filters: filters });
    $grid_table.jqGrid("clearGridData");
    $grid.setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]); // must search true
}

//搜索事件
function initSearch() {

    //系统详细数据库表
    $("#grid_table_search").click(function () {
        getTableGridData();
    });

    //系统列表
    $("#grid_search").click(function () {
        getGridData();
    });
}