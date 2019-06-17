define(['reportingbootstrap'],
    function (abc) {
 //       initLayout();
        initGird();   
        size = UtilWindowHeightWidth();
    });

var $grid,
    size; //宽高

var barChart;
var lineChart;
var PieChart;

function windowResized() {
    if (typeof barChart != 'undefined')
        barChart.resize();
    if (typeof pieChart != 'undefined')
        pieChart.resize();
    if (typeof lineChart != 'undefined')
        lineChart.resize();
    if (typeof $grid != 'undefined')
        $grid.setGridWidth($('#listpnlbody').width());
}

/*function initChart(data,chart) {

    // 基于准备好的dom，初始化echarts实例
    barChart = echarts.init(document.getElementById('browserAnalysisBar'));
    lineChart = echarts.init(document.getElementById('browserAnalysisLine'));
    pieChart = echarts.init(document.getElementById('browserAnalysisPie'));
}*/

function fillChart(data, charName) {
    if (typeof char == 'undefined') {
        chart = echarts.init(document.getElementById(charName));
    } 

    if (typeof chart != 'undefined')
    {
        chart.setOption(data)
    } else {
        alert ('chart is undefined')
    }
}

//初始化表格
function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype:"local",
            multiselect: true,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/EmployInfo/QueryEmployInfo',
            colModel: [
                //lable字段解释 Employ ID为自定义名，name为后台SQL语句定义的表列的别名也可以是原名，index为数据库表列中的原名，可以带表的别名 
                { label: "Employ ID", name: "ID", index: "emp.ID", width: 130, fixed: true },
                { label: "Chinese Name", name: "EMPLOYEE_NAME", width: 130, fixed: true },
                { label: "English Name", name: "E_EMPLOYEE_NAME", index: "emp.E_EMPLOYEE_NAME", width: 130, fixed: true },
                { label: "Email", name: "EMAIL",width: 130, fixed: true },
                { label: "Pager", name: "PAGER",index:"emp.PAGER", width: 130, fixed: true },
                { label: "Extension_No", name: "EXTENSION_NO", index: "emp.EXTENSION_NO", width: 50, fixed: true },
                { label: "Chinese Title", name: "CHINESE_TITLE", width: 160, fixed: true },
                { label: "English Title", name: "ENGLISH_TITLE", index: "emp.ENGLISH_TITLE", width: 130, fixed: true },
                { label: "Dept Code", name: "DEPT_CODE", index: "emp.DEPT_CODE", width: 50, fixed: true },
                { label: "Dept Name", name: "DEPT_NAME", sortable:false, width: 130, fixed: true },
                { label: "E_Dept Name", name: "E_DEPT_NAME",width: 130, fixed: true },
                { label: "Group Code", name: "GROUP_CODE",index:"emp.GROUP_CODE",width: 130, fixed: true },
                { label: "Dir Manager", name: "DIR_MANAGER",index:"emp.DIR_MANAGER" , width: 130, fixed: true },
                { label: "Rep Empno", name: "REP_EMPNO", index:"emp.REP_EMPNO", width: 130, fixed: true },
                { label: "Action Flag", name: "ACTION_FLAG", align: "center", fixed: true, width: 130 },
                { label: "Rcd Date", name: "RCD_DATE", align: "center", fixed: true, width: 130 },
                { label: "Basic Person", name: "BASIC_PERSON", align: "center", fixed: true, width: 130 },
                { label: "Basic Org", name: "BASIC_ORG", align: "center", fixed: true, width: 130 }
            ],
            sortname: "emp.ID",
            height: 200,
            sortorder: "asc",
            loadComplete: function (json) {
                if (json.rows.length > 0) {
//                    initChart();
                    fillChart(json.ExtraDatas.SummaryPie, 'browserAnalysisPie')
                    fillChart(json.ExtraDatas.SummaryBar, 'browserAnalysisBar')
                    fillChart(json.ExtraDatas.SummaryLine, 'browserAnalysisLine')
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