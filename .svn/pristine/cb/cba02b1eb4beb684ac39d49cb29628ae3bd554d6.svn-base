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
    if ($('#RECORD_DATE').val() == '') {
        DialogTipsMsgError('请输入日期!', 5000);
        $('#RECORD_DATE').focus();
        return false;
    }
    return true;
}

function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/ProductIndices/QueryDetails',
            colModel: [
                //{
                //    name: "SYSID", width: 130, fixed: true, hidden: true
                //},
                { label: "Lot id", name: "LOTID", width: 110, fixed: true },
                { label: "Lot Type", name: "LOTTYPE", width: 110, fixed: true },
                { label: "Priority", name: "PRIORITY", width: 130, fixed: true },
                { label: "Part id", name: "PARTID", width: 130, fixed: true },
                { label: "Stage", name: "STAGE", width: 130, fixed: true },
                { label: "Scrap Comment", name: "HANDLE", width: 130, fixed: true },
                { label: "Process Seq", name: "PROCESSOPERATIONSEQ", width: 130, fixed: true },
                { label: "Process id", name: "PROCESSOPERATIONID", width: 130, fixed: true },
                { label: "Step Seq", name: "STEPSEQ", width: 130, fixed: true },
                { label: "Step id", name: "STEPID", width: 130, fixed: true },
                { label: "Rework Qty", name: "REWORKQTY", width: 130, fixed: true },
                { label: "Timestamp", name: "TXNTIMESTAMP", width: 130, fixed: true }
                
      
            ],
            sortname: "hs.wipid",

            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
