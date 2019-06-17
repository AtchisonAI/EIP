define(["list", "layout"],
    function() {
        initLayout();
        initGird();
    });

var $grid;

//初始化布局
function initLayout() {
    $("body").layout({
        "north": {
            size: 30,
            closable: true,
            resizable: false,
            sliderTip: "显示/隐藏侧边栏",
            togglerTip_open: "关闭",
            togglerTip_closed: "打开",
            resizerTip: "上下拖动可调整大小", //鼠标移到边框时，提示语
            slidable: true
        },
        "center": {
            onresize_end: function() {
                //获取调整后高度
                $grid.jqGrid("setGridHeight", $("#uiCenter").height() - 50).jqGrid("setGridWidth", $("#uiCenter").width() - 2);
            }
        }
    });
}

//初始化表格
function initGird() {
    $grid = $("#list").jgridview(
    {
        shrinkToFit: true,
        multiselect: false,
            url: "/Reporting/JobConfig/GetList",
        colModel: [
            {name:"SYSID",label:"",width:0,hidden:true,align:"center"},
            {name:"PROCEDURENAME",label:"Procedure Name",width:0,align:"center"},
            {name:"TRIGGER_TYPE",label:"Trigger Type",width:0,align:"center"},
            { name: "CURRENT_CYCLE_JOB_STATUS_ID", label: "", hidden: true,width:0,align:"center"},
            {name:"MAX_RETRY_COUNT",label:"Max Retry Count",width:0,align:"center"},
            {name:"IS_STOP_WHEN_FAILED",label:"Is Stop When Failed",width:0,align:"center",formatter:"YesOrNo"},
            {
                name: "JOB_STATE", label: "Job State", width: 0, align: "center",formatter: function (cellval, opts, rwd, act) {
                    if (cellval == 1) {
                        return '<span>Normal</sapn>';
                    } else {

                        return '<span>Failed</sapn>';
                    }
                }}
        ],
        height: $("#uiCenter").height() - 51
    });
}

//获取表格数据
function getGridData() {
    UtilAjaxPost("/Reporting/JobConfig/GetList", {}, function(data) {
        GridReloadLoadOnceData($grid, data);
    });
}

//新增
function add() {
    ArtDialogOpen("/Reporting/JobConfig/Edit", "新增", true, '100%', '100%');
}

//编辑
function edit() {
    //查看是否选中
    GridIsSelect($grid, function() {
        var info = GridGetSingSelectData($grid);
        ArtDialogOpen("/Reporting/JobConfig/Edit?id=" + info.SYSID, "修改", true, '100%','100%');
    });
}

//删除
function del() {
    //查看是否选中
    GridIsSelect($grid, function() {
        ArtDialogConfirm(Language.common.deletemsg, function() {
            UtilAjaxPostWait(
                "/Reporting/JobConfig/Delete",
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