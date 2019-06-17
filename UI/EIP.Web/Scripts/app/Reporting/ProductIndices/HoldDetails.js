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
                { label: "Lot id", name: "LOT_ID", width: 120, fixed: true },
                { label: "Lot Type", name: "LOTTYPE", width: 120, fixed: true },
                { label: "Priority", name: "PRIORITY", width: 120, fixed: true },
                { label: "Part id", name: "PART_ID", width: 120, fixed: true },
                { label: "Hold Qty", name: "HOLD_QTY", width: 120, fixed: true },
                { label: "Hold Code", name: "HOLD_CODE", width: 120, fixed: true },
                { label: "Hold Comment", name: "HOLD_COMMENT", width: 130, fixed: true },
                { label: "User id", name: "USERID", width: 120, fixed: true },
                { label: "HoldTime", name: "TXNTIMESTAMP", width: 120, fixed: true }
            ],
            sortname: "h.wipid",

            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
