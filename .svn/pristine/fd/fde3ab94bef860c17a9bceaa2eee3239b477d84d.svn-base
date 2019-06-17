define(['edit'], function () { });

//表单提交
function formSubmit() {
    var submitValue = $("#form").getValue();
    var win = artDialog.open.origin; //来源页面

    var submitValue = win.getSeletedHoldInfo(submitValue);


    UtilAjaxPostWait("/Reporting/MultiReleaseLot/ReleaseLots",
        submitValue, success);
}

//提交成功
function success(data) {
    top.DialogShowTopMsg("Release 提交成功！", 2000, ResultSign.Success);
    var win = artDialog.open.origin; //来源页面
    win.releaseComplete(data);
    art.dialog.close();
}