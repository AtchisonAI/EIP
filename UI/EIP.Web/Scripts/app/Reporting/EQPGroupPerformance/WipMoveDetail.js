define(['reportingbootstrap'],
    function (abc) {

        initGird();
        size = UtilWindowHeightWidth();
        if ($('#RECORD_DATE').val() !== '') {
            $("[name='btn_select_box']").click();
        }
    });

var $grid,
    size; //宽高


function ValidateInput() {
  
    return true;
}

function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/EQPGroupPerformance/GetEQPGroupWipMoveDetail',
            colModel: [
                //{
                //    name: "SYSID", width: 130, fixed: true, hidden: true
                //},
                
                { label: "Date", name: "RECORD_DATE", index: "T.RECORD_DATE", width: 120, fixed: true },
                { label: "Area", name: "AREA", index: "T.AREA", width: 120, fixed: true },
                { label: "Capability", name: "CAPABILITY", index: "T.CAPABILITY", width: 120, fixed: true },
                { label: "Eqptype", name: "EQPTYPE", index: "T.EQPTYPE", width: 120, fixed: true },
                { label: "Move", name: "MOVEWAFERQTY", index: "T.MOVEWAFERQTY", width: 120, fixed: true },
                { label: "WIP", name: "WIP", index: "WIP.WIP", width: 120, fixed: true }
   
            ],
            sortname: "T.RECORD_DATE",

            height: '300px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {

                var DATE = $('#RECORD_DATE').val();
                var AREA = $('#AREA').val();
                var CAPABILITY = $('#CAPABILITY').val();
                var EQPTYPE = $('#EQPTYPE').val();
                var StartTime = $('#StartTime').val();
                var EndTime = $('#EndTime').val();

                $.ajax({
                    url: '/Reporting/EQPGroupPerformance/GetEQPGroupWipMoveData',
                    type: 'post',
                    dataType: 'json',
                    data: { RECORD_DATE: DATE, AREA: AREA, CAPABILITY: CAPABILITY, EQPTYPE: EQPTYPE, StartTime: StartTime, EndTime: EndTime },
                    success: function (data, status) {
                        loadGraph(data, 'WipMoveChart');
                    }
                });

                //return true;

            }
        });
}


function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
   
}

function loadGraph(data, ChartName) {

    // 基于准备好的dom，获取echarts实例
    echarts.getInstanceByDom(document.getElementById(ChartName)).setOption(data);
    //// 基于准备好的dom，获取echarts实例
    //var myChart1 = echarts.getInstanceByDom(document.getElementById('MTDChart'));
    //myChart1.setOption(data2);
    //data.echarts.Series



}





