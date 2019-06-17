define(["edit"], function() {});

//提交
function formSubmit() {
    var submitValue = $("#form").getValue();
    UtilAjaxPostWait("/Reporting/JobConfig/Save",
        submitValue, success);
}

//成功
function success(data) {
    if (DialogAjaxResult(data)) {
        var win = artDialog.open.origin; //来源页面
        win.getGridData();
        if (UtilEditIsdialogClose()) {
            if ($("#SYSID").val() === Language.common.guidempty) {
                UtilFormReset("form");
            }
        } else {
            art.dialog.close();
        }
    }
}