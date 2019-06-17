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
                { label: "Lot ID",    name: "LOT_ID", width: 130, fixed: true },
                { label: "Lot Type",  name: "LOTTYPE", width: 130, fixed: true },
                { label: "Parent ID", hidden:true, name: "PARENT_ID", width: 130, fixed: true },
                { label: "Priority",  name: "PRIORITY", width: 130, fixed: true },
                { label: "Part ID",   name: "PART_ID", width: 130, fixed: true },
                { label: "User ID", name: "EVENT_USER", width: 130, fixed: true },
                { label: "Start Time", name: "TXNTIMESTAMP", width: 130, fixed: true },
                { label: "Start Qty",  name: "START_QTY", width: 130, fixed: true }
                
      
            ],
            sortname: "HS.WIPID",
            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
