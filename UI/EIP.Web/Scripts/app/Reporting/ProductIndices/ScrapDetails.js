﻿define(['reportingbootstrap'],
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
                { label: "Lot id", name: "LOT_ID", width: 130, fixed: true },
                { label: "Lot Type", name: "LOTTYPE", width: 130, fixed: true },
                //{ label: "PARENT_ID", name: "PARENT_ID", width: 130, fixed: true },
                { label: "Scarp Qty",  name: "SCRAP_QTY", width: 130, fixed: true },
                { label: "Scrap Code", name: "SCRAP_CODE", width: 130, fixed: true },
                { label: "Scrap Comment", name: "SCRAP_COMMENT", width: 130, fixed: true },
                { label: "Priority", name: "PRIORITY", width: 130, fixed: true },
                { label: "Part id", name: "PART_ID", width: 130, fixed: true },
                { label: "Step id", name: "STEPID", width: 130, fixed: true },
                { label: "User id", name: "USERID", width: 130, fixed: true },
                { label: "Timestamp", name: "TXNTIMESTAMP", width: 130, fixed: true }
                
      
            ],
            sortname: "FSL.WIPID",

            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
